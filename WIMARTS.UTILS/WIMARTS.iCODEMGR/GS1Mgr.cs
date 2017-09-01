using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using WIMARTS.UTIL;

namespace WIMARTS.CODEMGR
{
    public class GS1Mgr
    {
        public class GS1Values 
        {
            public string SSCC,
                GTIN,
                LOT,
                MFG,
                EXP,
                UID,
                PARTNO,
                MRP;
        }

        public enum GS1AI
        {
            SSCC = 0,
            GTIN = 1,
            LOT = 10,
            MFG = 11,
            EXP = 17,
            UID = 21,
            PARTNO=241,
            MRP=3900,
            COUNTOFITEMS=30,
            COUNTOFTRADEITEMS=37,

            None = -1
        }

        private const int SSCCLen = 18;
        private const int GTINLen = 14;
        private const int LOTLen = 20;
        private const int MFGLen = 6;
        private const int EXPLen = 6;
        private const int UIDLen = 20;

        public const string GS1DateFormat = "yyMMdd";
        public const string GS1GroupSeparator = "\x1D";

        #region DECODE_IDCODE
      
        public static List<AITagVal> DecodeIDCode(WIMARTS.UTIL.TemplateFields.eFldType datatype, string code, string filter, out bool isvalid)
        {
            List<AITagVal> lstAITag = new List<AITagVal>();
            isvalid = false;

            if (string.IsNullOrEmpty(filter))
                return lstAITag;
          
            string[] identifier = filter.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries); //IDProdGTIN#01|IDBatchNo#10|IDExpDate#17|IDSrNo#21

            for (int i = 0; i < identifier.Length; i++)
            {
                AITagVal aitag = new AITagVal();
                aitag.FldName = identifier[i].Split('~')[0];
                aitag.Identifier = identifier[i].Split('~')[1];
                lstAITag.Add(aitag);
            }

            if(datatype== TemplateFields.eFldType.CODE128)
                return DecodeCode128(code, lstAITag, out isvalid);
            else if (datatype == TemplateFields.eFldType.DATAMATRIX)
                return Decode2DCode(code, lstAITag, out isvalid);
                   

            return null;
        }

        public static List<AITagVal> DecodeCode128(string code, List<AITagVal> lstAITag, out bool IsGS1)
        {
            string codeBuf = code;
            IsGS1 = false;

            while (codeBuf.Length > 0)
            {
                if (true == codeBuf.StartsWith("00", true, null)) //SSCC Barcode
                {
                    AITagVal Ai = lstAITag.Find(itm => itm.Identifier == "00");
                    if (Ai == null)
                        break;
                    Ai.Value = codeBuf.Substring(2, codeBuf.Length - 2);
                    codeBuf = codeBuf.Substring(Ai.Value.Length + 2);
                }

                if (true == codeBuf.StartsWith("21", true, null)) ///UID Barcode
                {
                    AITagVal Ai = lstAITag.Find(itm => itm.Identifier == "21");
                    if (Ai == null)
                        break;
                    Ai.Value = codeBuf.Substring(2, codeBuf.Length - 2);

                    codeBuf = codeBuf.Substring(0, Ai.Value.Length + 2);
                }
                if (true == codeBuf.StartsWith("01", true, null))
                {
                    AITagVal Ai = lstAITag.Find(itm => itm.Identifier == "01");
                    if (Ai == null)
                        break;
                    Ai.Value = codeBuf.Substring(2, GTINLen);
                    codeBuf = codeBuf.Substring(GTINLen + 2);
                }
                if (true == codeBuf.StartsWith("11", true, null))
                {
                    string date = codeBuf.Substring(2, 6);
                    AITagVal Ai = lstAITag.Find(itm => itm.Identifier == "11");
                    if (Ai == null)
                        break;
                    Ai.Value = date;
                    codeBuf = codeBuf.Substring(8);
                }
                if (true == codeBuf.StartsWith("17", true, null))
                {
                    string date = codeBuf.Substring(2, 6); 
                    AITagVal Ai = lstAITag.Find(itm => itm.Identifier == "17");
                    if (Ai == null)
                        break;
                    Ai.Value = date;

                    codeBuf = codeBuf.Substring(8);
                }
                if (true == codeBuf.StartsWith("10", true, null))
                {
                    int sepLen = -1;
                    int len = GetSeparatorIndex(codeBuf, out sepLen);
                    string BatchNo = string.Empty;
                    // In case if Last String in 2DCode, No seperator available
                    if (len == -1)
                    {
                        len = codeBuf.Length > 22 ? 22 : codeBuf.Length;
                        BatchNo = codeBuf.Substring(2, codeBuf.Length - 2);
                        codeBuf = "";
                    }
                    else if (len > 2)
                    {
                        BatchNo = codeBuf.Substring(2, len - 2); // -2 as started from 3rd char  
                        codeBuf = codeBuf.Substring(len + sepLen); // +sepLen for seperator charachter '\x1D' 
                    }
                    AITagVal Ai = lstAITag.Find(itm => itm.Identifier == "10");
                    if (Ai == null)
                        break;
                    Ai.Value = BatchNo;
                }
                else
                    codeBuf = ""; //invalid code
            }

            AITagVal ai = lstAITag.Find(itm => string.IsNullOrEmpty(itm.Value) == true);

            if (ai == null)
                IsGS1 = true;
            else
                IsGS1 = false;

            return lstAITag;
        }

        private static int GetSeparatorIndex(string input, out int sepLen)
        {
            sepLen = 1;
            string separator = "\x1D";
            int len = -1;
            len = input.IndexOf(separator);

            if (len == -1) // THis is for Cognex, as its returning seperator different...
            {
                separator = "\x25ba";
                len = input.IndexOf(separator);
            }
            if (len == -1) // THis is for FNC1 ASCII <GS> returned by scanner as seperator... 
            {
                sepLen = 4;
                separator = "<GS>";
                len = input.IndexOf(separator);
            }
            if (len == -1) // THis is for HendheldScanner, as its returning seperator different...
            {
                int index = 0;
                sepLen = 1;
                foreach (char ch in input)
                {
                    bool isAlphNum = char.IsLetterOrDigit(ch);

                    if (isAlphNum == false && ch.Equals('-'))
                    {
                        len = index;
                        break;
                    }
                    index++;
                }

            }
            return len;
        }

        public static List<AITagVal> Decode2DCode(string code, List<AITagVal> lstAITag, out bool IsGS1)
        {  
            IsGS1 = false;

            int codeLen = code.Length;
            string codeBuf = code;
            bool hasGTIN, hasLOT, hasEXP, hasSRNO;
            hasGTIN = hasLOT = hasEXP = hasSRNO = false;
            string SerialNo = "";

            int retryCnt = 0;
            int sepLen;

            if (codeBuf.Length > 3 && true == codeBuf.StartsWith("]d2", true, null))
            {
                IsGS1 = true;
                codeBuf = codeBuf.Substring(3);
            }
            else if (codeBuf.Length > 3 && true == codeBuf.StartsWith("\x1D", true, null))
            {
                IsGS1 = true;
                codeBuf = codeBuf.Substring(1);
            }
            else
                IsGS1 = false;

            while (codeBuf.Length > 0)
            {
                if (retryCnt++ > 5)
                {
                    Trace.TraceWarning("{0},{1}{2}", DateTime.Now.ToString(), "WRONG DATA " + codeBuf + " PASSED --OR-- MAJOR LOGICAL BLUNDER!!!", "@DecodeCode NEED REVIEW OF SYSTEM");
                    break;
                }
                if (true == codeBuf.StartsWith("01", true, null) && codeLen > 16)
                {
                    lstAITag.Find(itm => itm.Identifier == "01").Value = codeBuf.Substring(2, GTINLen);  
                    codeBuf = codeBuf.Substring(GTINLen + 2);
                    hasGTIN = true;
                }
                if (true == codeBuf.StartsWith("10", true, null))
                {
                    string BatchNo = "";
                    int len = GetSeparatorIndex(codeBuf, out sepLen);
                    // In case if Last String in 2DCode, No seperator available
                    if (len == -1)
                    {
                        len = codeBuf.Length > 22 ? 22 : codeBuf.Length; // 22 (20:Max Len for VarData + 2:AI)
                        BatchNo = codeBuf.Substring(2, codeBuf.Length - 2);

                        codeBuf = "";
                        hasLOT = true;
                    }
                    else if (len > 2) // 2 for "10"
                    {
                        BatchNo = codeBuf.Substring(2, len - 2); // -2 as started from 3rd char  
                        codeBuf = codeBuf.Substring(len + sepLen); // +sepLen for seperator charachter '\x1D'
                        hasLOT = true;
                    }

                    lstAITag.Find(itm => itm.Identifier == "10").Value = BatchNo;  
                }
                if (true == codeBuf.StartsWith("241", true, null))
                {
                    string PartNo = "";
                    int len = GetSeparatorIndex(codeBuf, out sepLen);
                    // In case if Last String in 2DCode, No seperator available
                    if (len == -1)
                    {
                        len = codeBuf.Length > 22 ? 22 : codeBuf.Length; // 22 (20:Max Len for VarData + 2:AI)
                        PartNo = codeBuf.Substring(3, codeBuf.Length - 3);

                        codeBuf = "";
                    //    hasLOT = true;
                    }
                    else if (len > 3) // 2 for "10"
                    {
                        PartNo = codeBuf.Substring(3, len - 3); // -2 as started from 3rd char  
                        codeBuf = codeBuf.Substring(len + sepLen); // +sepLen for seperator charachter '\x1D'
                      //  hasLOT = true;
                    }

                    lstAITag.Find(itm => itm.Identifier == "241").Value = PartNo;
                }

                if (true == codeBuf.StartsWith("11", true, null))
                {
                    string date = codeBuf.Substring(2, 6);
                    //int day = int.Parse(date.Substring(4, 2));
                    //int month = int.Parse(date.Substring(2, 2));
                    //int year = 2000 + int.Parse(date.Substring(0, 2));
                    //int lastDayofMonth = DateTime.DaysInMonth(year, month);

                    lstAITag.Find(itm => itm.Identifier == "11").Value = date;// new DateTime(year, month, day != 0 ? day : lastDayofMonth).ToString();  
                    codeBuf = codeBuf.Substring(8);
                }
                if (true == codeBuf.StartsWith("17", true, null))
                {
                    string date = codeBuf.Substring(2, 6);
                    //int day = int.Parse(date.Substring(4, 2));
                    //int month = int.Parse(date.Substring(2, 2));
                    //int year = 2000 + int.Parse(date.Substring(0, 2));
                    //int lastDayofMonth = DateTime.DaysInMonth(year, month);

                    lstAITag.Find(itm => itm.Identifier == "17").Value = date;// new DateTime(year, month, day != 0 ? day : lastDayofMonth).ToString();
                   
                    codeBuf = codeBuf.Substring(8);
                    hasEXP = true;
                }
                if (true == codeBuf.StartsWith("21", true, null))
                {
                    int len = GetSeparatorIndex(codeBuf, out sepLen);
                   
                    // In case if Last String in 2DCode, No seperator available
                    if (len == -1)
                    {
                        len = codeBuf.Length > 22 ? 22 : codeBuf.Length; // 22 (20:Max Len for VarData + 2:AI)
                        SerialNo = codeBuf.Substring(2, len - 2);
                        codeBuf = "";
                        hasSRNO = true;
                    }
                    else if (len > 2) // 2 for "21"
                    {
                        SerialNo = codeBuf.Substring(2, len - 2); // -2 as started from 3rd char
                        codeBuf = codeBuf.Substring(len + 1); // +1 for seperator charachter '\x1D'
                        hasSRNO = true;
                    }

                    lstAITag.Find(itm => itm.Identifier == "21").Value = SerialNo; 
                }
            }
            if (hasGTIN == true && hasLOT == true && hasEXP == true &&  (string.IsNullOrEmpty(SerialNo) || hasSRNO == true))
                IsGS1 = true;
            else
                IsGS1 = false;

            return lstAITag;
        }

        public static GS1Values DecodeData(string code)
        {
            GS1Values oGs1 = new GS1Values();
            int codeLen = code.Length;
            string codeBuf = code;

            int retryCnt = 0;
            int sepLen;

            if (codeBuf.Length > 3 && true == codeBuf.StartsWith("]d2", true, null))
            {
                codeBuf = codeBuf.Substring(3);
            }
            else if (codeBuf.Length > 3 && true == codeBuf.StartsWith("\x1D", true, null))
            {
                codeBuf = codeBuf.Substring(1);
            }

            while (codeBuf.Length > 0)
            {
                if (retryCnt++ > 5)
                {
                    Trace.TraceWarning("{0},{1}{2}", DateTime.Now.ToString(), "WRONG DATA " + codeBuf + " PASSED --OR-- MAJOR LOGICAL BLUNDER!!!", "@DecodeCode NEED REVIEW OF SYSTEM");
                    break;
                }
                if (true == codeBuf.StartsWith("01", true, null) && codeLen > 16)
                {
                    oGs1.GTIN = codeBuf.Substring(2, GTINLen); // -2 as started from 3rd char  
                    codeBuf = codeBuf.Substring(GTINLen + 2);
                }
                if (true == codeBuf.StartsWith("10", true, null))
                {
                    int len = GetSeparatorIndex(codeBuf, out sepLen);
                    // In case if Last String in 2DCode, No seperator available
                    if (len == -1)
                    {
                        len = codeBuf.Length > 22 ? 22 : codeBuf.Length; // 22 (20:Max Len for VarData + 2:AI)
                        oGs1.LOT = codeBuf.Substring(2, codeBuf.Length - 2);

                        codeBuf = "";
                    }
                    else if (len > 2) // 2 for "10"
                    {
                        oGs1.LOT = codeBuf.Substring(2, len - 2); // -2 as started from 3rd char  
                        codeBuf = codeBuf.Substring(len + sepLen); // +sepLen for seperator charachter '\x1D'
                    }
                    //
                }
                if (true == codeBuf.StartsWith("241", true, null))
                {
                    int len = GetSeparatorIndex(codeBuf, out sepLen);
                    // In case if Last String in 2DCode, No seperator available
                    if (len == -1)
                    {
                        len = codeBuf.Length > 22 ? 22 : codeBuf.Length; // 22 (20:Max Len for VarData + 2:AI)
                        oGs1.PARTNO = codeBuf.Substring(3, codeBuf.Length - 3);

                        codeBuf = "";
                        //    hasLOT = true;
                    }
                    else if (len > 3) // 2 for "10"
                    {
                        oGs1.PARTNO = codeBuf.Substring(3, len - 3); // -2 as started from 3rd char  
                        codeBuf = codeBuf.Substring(len + sepLen); // +sepLen for seperator charachter '\x1D'
                        //  hasLOT = true;
                    }
                    //
                }

                if (true == codeBuf.StartsWith("11", true, null))
                {
                    string date = codeBuf.Substring(2, 6);
                    oGs1.MFG = date;
                    codeBuf = codeBuf.Substring(8);
                }
                if (true == codeBuf.StartsWith("17", true, null))
                {
                    string date = codeBuf.Substring(2, 6);
                    oGs1.EXP = date;
                    codeBuf = codeBuf.Substring(8);
                }
                if (true == codeBuf.StartsWith("21", true, null))
                {
                    int len = GetSeparatorIndex(codeBuf, out sepLen);

                    // In case if Last String in 2DCode, No seperator available
                    if (len == -1)
                    {
                        len = codeBuf.Length > 22 ? 22 : codeBuf.Length; // 22 (20:Max Len for VarData + 2:AI)
                        oGs1.UID = codeBuf.Substring(2, len - 2);
                        codeBuf = "";
                    }
                    else if (len > 2) // 2 for "21"
                    {
                        oGs1.UID = codeBuf.Substring(2, len - 2); // -2 as started from 3rd char
                        codeBuf = codeBuf.Substring(len + 1); // +1 for seperator charachter '\x1D'
                    }

                }
            }
            return oGs1;
        }

        #endregion END_DECODE_IDCODE

        #region GS1IDCODE

        public static string GetIDCode(string oGTIN, string oLOT, string oEXP, string oUID)
        {
            string output = "";

            if (string.IsNullOrEmpty(oGTIN) == false)
                output += "01" + oGTIN;

            if (string.IsNullOrEmpty(oLOT) == false)
                output += "10" + oLOT + GS1Mgr.GS1GroupSeparator;

            if (string.IsNullOrEmpty(oEXP) == false)
                output += "17" + oEXP;

            if (string.IsNullOrEmpty(oUID) == false)
                output += "21" + oUID + GS1Mgr.GS1GroupSeparator;

            if (output.EndsWith(GS1Mgr.GS1GroupSeparator))
            {
                output = output.Remove(output.Length - GS1Mgr.GS1GroupSeparator.Length);
            }
            return output;
        }
        /// <summary>
        /// Generated ID(1D/2D) Code in GS1 Format for provided AITagVal in specified sequence
        /// </summary>
        /// <param name="CodeBeginWith">Provide value if applicable or EMPTY STRING</param>
        /// <param name="GrpSep">Provide GS1 Group Seperator Applicable. "\x1D". For printer specific like "~1" etc</param>
        /// <param name="lstAITagVal"> GS1 AI and its Value in required sequence.
        /// GS1Mgr.AITagVal[] ss= new GS1Mgr.AITagVal[4];
        /// ss[0] = new GS1Mgr.AITagVal();
        /// ss[1] = new GS1Mgr.AITagVal();
        /// ss[2] = new GS1Mgr.AITagVal();
        /// ss[3] = new GS1Mgr.AITagVal();
        /// ss[0].AITag = GS1Mgr.GS1AI.GTIN;
        /// ss[0].AIVal = "12345678901231";
        /// ss[1].AITag = GS1Mgr.GS1AI.LOT;
        /// ss[1].AIVal = "LOT";
        /// ss[2].AITag = GS1Mgr.GS1AI.EXP;
        /// ss[2].AIVal = "170900";
        /// ss[3].AITag = GS1Mgr.GS1AI.UID ;
        /// ss[3].AIVal = "A1B3C5D7E9F1G3H";
        /// </param>
        /// <returns>Returns ID(1D/2D) Code string.
        /// "011234567890123110LOT<GS>1717090021A1B3C5D7E9F1G3H"
        /// </returns>
        /// 
        ///TBD:
        /// 

        public static string GetIDCode(string CodeBeginWith, string GrpSep, List<AITagVal> lstAITagVal)
        {
            string output = "";
            string commSep = ",";
      

            if (string.IsNullOrEmpty(CodeBeginWith) == false)
                output += CodeBeginWith; 

            foreach (AITagVal item in lstAITagVal)
            {
                if (item.Value == null)
                    continue;

                string identifier = IdentifierRemoveBracket(item.Identifier);
                if (item.Identifier == commSep)
                {
                    output += string.Format("{0:00}{1}", item.Identifier, item.Value);
                }
                else
                {
                    switch (Convert.ToInt16(identifier))
                    {
                        case (int)GS1AI.GTIN:
                        case (int)GS1AI.EXP:
                        case (int)GS1AI.MFG:
                        case (int)GS1AI.SSCC:
                            output += string.Format("{0:00}{1}", item.Identifier, item.Value); break;
                        case (int)GS1AI.LOT:
                        case (int)GS1AI.UID:
                            output += string.Format("{0:00}{1}{2}", item.Identifier, item.Value, GrpSep); break;
                        case (int)GS1AI.PARTNO:
                            output += string.Format("{0:000}{1}{2}", item.Identifier, item.Value, GrpSep); break;
                        case (int)GS1AI.MRP:
                            output += string.Format("{0:0000}{1}{2}", item.Identifier, item.Value, GrpSep); break;
                        case (int)GS1AI.COUNTOFITEMS:
                        case (int)GS1AI.COUNTOFTRADEITEMS:
                            output += string.Format("{0:00}{1}{2}", item.Identifier, item.Value, GrpSep); break;
                        default: //Smk
                            output += string.Format("{0:00}{1}", item.Identifier, item.Value); break;
                    }
                }
            }
            if (output.EndsWith(GrpSep))
            {
                output = output.Remove(output.Length - GrpSep.Length);
            }
          
            if (output.StartsWith(commSep))
            {
                output = output.Substring(commSep.Length, output.Length - commSep.Length);
            }
            return output;
        }
        public static string GetBarcode(string CodeBeginWith, string GrpSep, List<AITagVal> lstAITagVal)
        {
            string output = "";


            if (string.IsNullOrEmpty(CodeBeginWith) == false)
                output += CodeBeginWith;

            int i=-1;
            foreach (AITagVal item in lstAITagVal)
            {
                i++;
                if (item.Value == null)
                    continue;

                string identifier = IdentifierRemoveBracket(item.Identifier);

                switch (Convert.ToInt16(identifier))
                {
                    case (int)GS1AI.GTIN:
                    case (int)GS1AI.EXP:
                    case (int)GS1AI.MFG:
                    case (int)GS1AI.SSCC:
                        output += string.Format("{0:00}{1}", item.Identifier, item.Value); break;
                    case (int)GS1AI.LOT:
                        if (i == lstAITagVal.Count - 1) ///if lot is at last position ..then group separator will not add
                            output += string.Format("{0:00}{1}", item.Identifier, item.Value);
                        else
                            output += string.Format("{0:00}{1}{2}", item.Identifier, item.Value, GrpSep);
                        break;
                    case (int)GS1AI.UID: 
                        output += string.Format("{0:00}{1}", item.Identifier, item.Value); break;
                    default:
                        output += string.Format("{0:00}{1}", item.Identifier, item.Value); break;
                }
            }
            if (output.EndsWith(GrpSep))
            {
                output = output.Remove(output.Length - GrpSep.Length);
            }
            return output;
        }

        public static string IdentifierRemoveBracket(string identifier)
        {
            if (identifier.Contains('('))
                identifier = identifier.Replace('(', ' ');

            if (identifier.Contains(')'))
                identifier = identifier.Replace(')', ' ');

            return identifier;
        }
        public static string GetGS1AI(GS1AI AI)
        {
            return AI.ToString().PadLeft(2, '0');
        }
        public static List<GS1Mgr.GS1AI> GetGS1AISeq(string GS1AISeqFilter)
        {
            List<GS1Mgr.GS1AI> lstGS1AISeq = new List<GS1AI>();
            string[] GS1AISeq = GS1AISeqFilter.Split(new string[] { FilterData.fldDataSep }, StringSplitOptions.None);

            foreach (string AI in GS1AISeq)
            {
                if (AI.StartsWith("01"))      // GTIN
                {
                    lstGS1AISeq.Add(GS1AI.GTIN);
                }
                else if (AI.StartsWith("10")) // LOT or BATCH NO
                {
                    lstGS1AISeq.Add(GS1AI.LOT);
                }
                else if (AI.StartsWith("11")) // MFG
                {
                    lstGS1AISeq.Add(GS1AI.MFG);
                }
                else if (AI.StartsWith("17")) // EXPIRY
                {
                    lstGS1AISeq.Add(GS1AI.EXP);
                }
                else if (AI.StartsWith("21")) // UID or SRNO
                {
                    lstGS1AISeq.Add(GS1AI.UID);
                }
            }
            return lstGS1AISeq;
        }
        public static List<GS1Mgr.GS1AI> GetGS1AISeqDefault()
        {
            List<GS1Mgr.GS1AI> lstGS1AISeq = new List<GS1AI>();
            lstGS1AISeq.Add(GS1AI.GTIN);
            lstGS1AISeq.Add(GS1AI.LOT);
            lstGS1AISeq.Add(GS1AI.EXP);
            lstGS1AISeq.Add(GS1AI.UID);
            return lstGS1AISeq;
        }
        /// <summary>
        /// This function Calculates the GS1 CheckSum/CheckDigit
        /// </summary>
        /// <param name="GS1Data">Data Passed should be without GS1 CheckSum character at the end.
        /// Example. for 14 digit GTIN pass only first 13 characters
        /// </param>
        /// <returns>GS1 CheckSum/CheckDigit Value</returns>
        public static int GetGS1CheckSum(string GS1Data)
        {
            // Code here for GTIN CheckSum
            char[] dataCA = GS1Data.ToCharArray();

            int SUM = 0;
            int Val = 0;
            int digit = 0;
            int multiplier = 3;
            for (int i = 0; i < dataCA.Length; i++)
            {
                digit = Int32.Parse(dataCA[i].ToString());
                Val = digit * multiplier;
                if (multiplier == 3)
                    multiplier = 1;
                else
                    multiplier = 3;

                SUM += Val;
            }
            decimal d = (decimal)SUM;
            d = d / 10;
            decimal x = Math.Ceiling(d);
            int ceil = (int)x * 10;

            int checkSUM = ceil - SUM;
            return checkSUM;
        }
        /// <summary>
        /// This function returns the GS1 Format Date (yyMMdd).
        /// </summary>
        /// <param name="dateValue">Date which is to be formatted</param>
        /// <param name="IsUseExpirayDay">Date Contains Expiry Day or not (00)</param>
        /// <returns>GS1 Formatted Date</returns>
        public static string GetGS1Date(DateTime dateValue, bool IsUseExpirayDay)
        {
            string gs1Date = "";
            gs1Date += dateValue.Year.ToString().Substring(2);
            gs1Date += dateValue.Month.ToString().PadLeft(2, '0');
            if (IsUseExpirayDay == false)
            {
                gs1Date += "00";
            }
            else
            {
                gs1Date += dateValue.Day.ToString().PadLeft(2, '0');
            }
            return gs1Date;
        }
        
        public static bool IsValidGS1DataSize(string GS1Data, GS1AI GS1AI)
        {
            int dataLen = GS1Data.Length;
            if (GS1AI == GS1AI.SSCC && dataLen == SSCCLen)
                return true;
            else if (GS1AI == GS1AI.GTIN && dataLen == GTINLen)
                return true;
            else if (GS1AI == GS1AI.LOT && dataLen <= LOTLen)
                return true;
            else if (GS1AI == GS1AI.EXP && dataLen == EXPLen)
                return true;
            else if (GS1AI == GS1AI.UID && dataLen <= UIDLen)
                return true;
            else
                return false;

        }
        /// <summary>
        /// This function Checks the GS1 CheckSum/CheckDigit
        /// </summary>
        /// <param name="GS1Data">Data passed should be with CheckSum</param>
        /// <returns>True if CheckSum passes is correct; else false</returns>
        /// 
        public static bool IsValidGS1CheckSum(string GS1Data)
        {
            try
            {
                string data = GS1Data.Substring(0, GS1Data.Length - 1);
                int checkSUM = GetGS1CheckSum(data);
                int OriCheckSum = -1;
                Int32.TryParse(GS1Data.Substring(GS1Data.Length - 1, 1), out OriCheckSum);
                if (checkSUM != OriCheckSum)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
                return false;
            }
        }
        /// <summary>
        /// This function Compare the GS1 Date
        /// </summary>
        /// <param name="dateBaseVal">Benchmark Date </param>
        /// /// <param name="date2Check">Inspection Date </param>
        /// <returns>True if Dates are equal as per GS1; else false</returns>
        public static bool IsValidGS1Date(DateTime dateBaseVal, DateTime date2Check, bool isUseExpDay)
        {
            if (isUseExpDay == false)
            {
                if (date2Check != null && date2Check.Year > 2000 && dateBaseVal.Year != date2Check.Year && dateBaseVal.Month != date2Check.Month)
                    return false;
            }
            else
            {
                if (date2Check != null && date2Check.Year > 2000 && dateBaseVal != date2Check)
                    return false;
            }
            return true;
        }

        #endregion END_GS1IDCODE
    }

    public static class SampleData
    {
        public const string TestGTIN = "12345678901231";
        public const string TestUID = "SAMPLES4TESTING";
        public const string TestLOT = "L12345";

        public const string TestPARTNO = "TESTPARTNO";
        public const string TestMRP = "100.00";
    } 
    public static class FilterData
    {
        public const string fldSep = "|";
        public const string fldDataSep = "-";

        public const string fldGS12D1 = "GS12D1";
        public const string fldGS12D2 = "GS12D2";
        public const string fldGS1BC1 = "GS1BC1";
        public const string fldGS1BC2 = "GS1BC2";
        public const string fldGS1BC3 = "GS1BC3";

        public const string fldIDGTIN = "IDGTIN";
        public const string fldIDLOT = "IDLOT";
        public const string fldIDEXP = "IDEXP";
        public const string fldIDMFG = "IDMFG";
        public const string fldIDUID = "IDUID";
        public const string fldIDSSCC = "IDSSCC";

        public const string fldIDPARTNO = "IDPARTNO";
        public const string fldIDMRP = "IDMRP";
        public const string fldIDCOUNTOFITEMS = "COUNTOFITEMS";
        public const string fldIDCOUNTOFTRADEITEMS = "COUNTOFTRADEITEMS";

        public const string fldTxtGTIN = "GTIN";
        public const string fldTxtLOT = "LOT";
        public const string fldTxtEXP = "EXP";
        public const string fldTxtMFG = "MFG";
        public const string fldTxtUID = "UID";

        public const string fldTxtPARTNO = "PARTNO";
        public const string fldTxtMRP = "MRP";
        public const string fldTxtCOUNTOFITEMS = "COUNTOFITEMS";
        public const string fldTxtCOUNTOFTRADEITEMS = "COUNTOFTRADEITEMS";

        public const string fldTxtPRODNAME = "PRODNAME";

        public const string fldTxtADDDATA1 = "ADDDATA1";
        public const string fldTxtADDDATA2 = "ADDDATA2";
        public const string fldTxtADDDATA3 = "ADDDATA3";
        public const string fldTxtADDDATA4 = "ADDDATA4";

        /// <summary>
        /// "GS12D1-01-17-10-21|GTIN|LOT|EXP|UID"
        /// "GS12D1-01-17-10|GTIN|LOT|EXP"
        /// "GS12D1-01-10-17-21|GTIN|LOT|EXP|UID|ADDDATA1|ADDDATA2"
        /// "GS12D1-01-10-17-21|GTIN|ADDDATA1|ADDDATA2|LOT|EXP|UID"
        /// "GS12D1-01-10-17-21|GS12D2-01-10-11-17-21|GTIN|LOT|EXP|UID"
        /// </summary>
        /// <param name="giveAllFlds"></param>
        /// <returns></returns>
        public static string GetSampleFilter(bool giveAllFlds)
        {
            string Filter = string.Empty;

            if (giveAllFlds == false)
            {
                Filter += fldGS12D1 + fldDataSep + "01" + fldDataSep + "10" + fldDataSep + "17" + fldDataSep + "21" + fldSep;

                Filter += fldTxtGTIN + fldSep;
                Filter += fldTxtLOT + fldSep;
                Filter += fldTxtEXP + fldSep;
                Filter += fldTxtUID + fldSep;
            }
            else
            {
                Filter += fldGS12D1 + fldDataSep + "01" + fldDataSep + "10" + fldDataSep + "11" + fldDataSep + "17" + fldDataSep + "21" + fldSep;

                Filter += fldTxtGTIN + fldSep;
                Filter += fldTxtLOT + fldSep;
                Filter += fldTxtMFG + fldSep;
                Filter += fldTxtEXP + fldSep;
                Filter += fldTxtUID + fldSep;

                Filter += fldTxtADDDATA1 + fldSep;
                Filter += fldTxtADDDATA2 + fldSep;
                Filter += fldTxtADDDATA3 + fldSep;
                Filter += fldTxtADDDATA4 + fldSep;
            }
            if (Filter.EndsWith(fldSep) == true)
            {
                Filter = Filter.Remove(Filter.Length - fldSep.Length);
            }
            return Filter;
        }

    } 
   
}
