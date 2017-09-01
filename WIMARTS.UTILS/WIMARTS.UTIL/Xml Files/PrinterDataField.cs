using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedXML;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace WIMARTS.UTIL
{ 
    public class AITagVal
    {
        /// <summary>
        /// FieldName
        /// </summary>
        public string FldName; 
        /// <summary>
        /// Identifire
        /// </summary>
        public string Identifier;//int
        /// <summary>
        /// Value
        /// </summary>
        public string Value;

    }
    [Serializable]
    public class TemplateFields
    {  
        /// <summary>
        /// For Datatype=DATAMATRIX/CODE128
        /// Name=GS12D2
        /// filter=|GTIN#01|LOT#10|EXP#17
        /// </summary>
        /// <param name="TemplateXml"></param>
        /// <returns></returns>
        /// 

        const char  ID_GrpSeparator = '|';
        const char ID_FldSerparator = '~';



        public enum eFldType
        {
            STRING,
            IDFLDText,
            /// <summary>
            /// Filter -"en-US"#"f"
            /// CultureInfo-"en-US"....,Format,"c","f","g","n"
            /// </summary>            
            NUMBER,
            DATE,
            /// <summary>
            ///filter=|GTIN#01|LOT#10|EXP#17
            /// </summary>
            DATAMATRIX, 
            CODE128,
        }

        private eFldType _FldType;
        public eFldType FldType
        {
            get { return _FldType; }
            set { _FldType = value; }
        }

        private string _DataSource;
        public string DataSource
        {
            get { return _DataSource; }
            set { _DataSource = value; }
        }


        /// <summary>
        /// If variable Data it containd Config Id 
        /// </summary>
        private Nullable<int> _DataField;
        public Nullable<int> DataField
        {
            get { return _DataField; }
            set { _DataField = value; }
        }

        private string _FldName;
        public string FldName
        {
            get { return _FldName; }
            set { _FldName = value; }
        }

        /// <summary>
        /// This is required for variable field title..this will be only used for report.
        /// </summary>
        private string _FieldText;
        public string FieldText
        {
            get { return _FieldText; }
            set { _FieldText = value; }
        }
      
              
        private string _Prefix;
        public string Prefix
        {
            get { return _Prefix; }
            set { _Prefix = value; }
        }

        [XmlIgnore]
        public object Data;
     
        private string _Postfix;
        public string Postfix
        {
            get { return _Postfix; }
            set { _Postfix = value; }
        }

        private int _Length = 20;
        public int Length
        {
            get { return _Length; }
            set { _Length = value; }
        }

        private bool _IsVariable;
        public bool IsVariable
        {
            get { return _IsVariable; }
            set { _IsVariable = value; }
        }

        //DataFormating depends on fld type ,If fld type is date then data frommating will contain date format..
        //If fld type is ID fld then Data formatting will contains Filter.
        private string _DataFormat;
        public string DataFormat
        {
            get { return _DataFormat; }
            set { _DataFormat = value; }
        }



        //static string xml = "<PrinterDataField> <Type>STRING</Type>   <Name>ProdName</Name>    <PrinterDataField>(10)</PrinterDataField>    <PositionX>1</PositionX>    <PositionY>5</PositionY>    <Prefix>Name:</Prefix>    <Data />    <Postfix />    <Length>10</Length>    <IsVariable>false</IsVariable>    <DataFormating />PrinterDataField>  <PrinterDataField>    <Type>STRING</Type>  <Name>ProdCode</Name>    <PrinterDataField>(11)</PrinterDataField>    <PositionX>1</PositionX>    <PositionY>20</PositionY>    <Prefix>Code:</Prefix>    <Data />    <Postfix />    <Length>10</Length>    <IsVariable>false</IsVariable>    <DataFormating />  </PrinterDataField>";
        private  static List<TemplateFields> LoadTemplateDesign(string Xml)
        { 
            List<TemplateFields> lst = new List<TemplateFields>();
            try
            {
                lst = GenericXmlSerializer<List<TemplateFields>>.DeserializeString(Xml);
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}:{1},{2}",DateTime.Now,ex.Message,ex.StackTrace);
            } 
            return lst;
        }
      
        public static string CreateXML(List<TemplateFields> tfl)
        {
            return GenericXmlSerializer<List<TemplateFields>>.Serialize(tfl);
        }

        public static List<TemplateFields> CreateTemplateFields(string templateXml)
        {
            List<TemplateFields> lst = TemplateFields.LoadTemplateDesign(templateXml);
            foreach (TemplateFields item in lst)
            {
                if (TemplateFields.isIdCode(item.FldType))
                {
                    try
                    {
                        item.Data = FormatData(item.FldType, item.Data, item.DataFormat,item.Length);// TemplateFields.CreateIDTagVal(item.DataFormat);
                    }
                    catch (NotSupportedException)
                    {
                        throw new NotSupportedException("DATAFORMAT FOR " + item.DataSource + " DOES NOT SET PROPERLY");
                    }
                }
            }
            return lst;
        }

        //filter=|GTIN#01|LOT#10|EXP#17
        public static List<AITagVal> CreateIDTagVal(string filter)
        {
            //filter=|GTIN#01|LOT#10|EXP#17
            List<AITagVal> lst = new List<AITagVal>();
            try
            {
                string[] strfields = filter.Split(ID_GrpSeparator);
                if (strfields.Length > 0)
                {
                    foreach (string item in strfields)
                    {
                        string[] flds = item.Split(ID_FldSerparator);
                        if (flds.Length == 2)
                        {
                            AITagVal tagval = new AITagVal();
                            tagval.FldName = flds[0];
                            tagval.Identifier = flds[1];// Convert.ToInt16(flds[1]);
                            lst.Add(tagval);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}:{1},{2}", DateTime.Now, ex.Message, ex.StackTrace);
            }

            return lst;
        }

        public static bool isIdCode(eFldType dataType)
        {
            if (dataType == eFldType.DATAMATRIX || dataType == eFldType.CODE128)
                return true;
            else
                return false;
        }

        public static bool HasVaribleData( List<TemplateFields> lst)
        {
            TemplateFields tf = lst.Find(item=>item.IsVariable==true);
            if (tf != null)
                return true;
            return false;
        }
       
        public static bool IsNumeric(object ValueToCheck)
        {
            double Dummy = new double();
            string InputValue = Convert.ToString(ValueToCheck);
            bool Numeric = double.TryParse(InputValue, System.Globalization.NumberStyles.Any, null, out Dummy);
            return Numeric;
        }

        public static List<TemplateFields> CreateTemplateFieldsFromFile(string templatePath)
        {
            string templateXML = string.Empty;
            List<TemplateFields> lstTFld = new List<TemplateFields>();
            try
            {
                if (File.Exists(templatePath) == true)
                {
                    StreamReader reader = new StreamReader(templatePath);
                    templateXML = reader.ReadToEnd();
                    reader.Close();
                }
                if (string.IsNullOrEmpty(templateXML) == false)
                    lstTFld = CreateTemplateFields(templateXML);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(exceptionObject.ToString());
            }
            finally
            {

            }
            return lstTFld;
        }
        public static List<TemplateFields> CreateTemplateFields(int countTFlds)//TBD:, InputFileType fileType)
        {
            string templateXML = string.Empty;
            List<TemplateFields> lstTFld = new List<TemplateFields>();
            try
            {
                for (int curCnt = 1; curCnt <= countTFlds; curCnt++)
                {
                    TemplateFields tf = new TemplateFields();
                    tf.FldType = eFldType.STRING;
              //TBD:      tf.SourceFldName = fileType == InputFileType.CSV ? "RedCSVGen" : "ExcelGen";
                    tf.DataSource = "";//"CSV";
                    tf.FldName = "L" + curCnt;
                    tf.FieldText = "Column " + curCnt;
                    tf.DataField = 1;
                    tf.Prefix = string.Empty;
                    tf.Length = 20;
                    tf.IsVariable = true;
                    tf.DataFormat = string.Empty;
                    lstTFld.Add(tf);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(exceptionObject.ToString());
            }
            finally
            {

            }
            return lstTFld;
        }
        public static TemplateFields Copy(TemplateFields inTF)
        {
            TemplateFields outTF = new TemplateFields();
            outTF.DataField = inTF.DataField;
            outTF.DataFormat = inTF.DataFormat;
            outTF.DataSource = inTF.DataSource;
            outTF.FieldText = inTF.FieldText;
            outTF.FldName = inTF.FldName;
            outTF.FldType = inTF.FldType;
            outTF.IsVariable = inTF.IsVariable;
            outTF.Length = inTF.Length;
            outTF.Postfix = inTF.Postfix;
            outTF.Prefix = inTF.Prefix;
            if (isIdCode(inTF.FldType) == true)
                outTF.Data = CopyList((List<AITagVal>)inTF.Data);
            else
                outTF.Data = inTF.Data;
            return outTF;
        }

        public static AITagVal Copy(AITagVal inAITag)
        {
            AITagVal outAITag = new AITagVal();
            outAITag.FldName = inAITag.FldName;
            outAITag.Identifier = inAITag.Identifier;
            outAITag.Value = inAITag.Value;
            return outAITag;
        }

        public static List<AITagVal> CopyList(List<AITagVal> lstAITag)
        {
            List<AITagVal> lstOutAITag = new List<AITagVal>();
            foreach (AITagVal item in lstAITag)
            {
                AITagVal newItem = Copy(item);
                lstOutAITag.Add(newItem);
            }
            return lstOutAITag;
        }

        #region FormatData 

        /// <summary>
        /// Format given value accroding with data format in template fld
        /// </summary>
        /// <param name="fld"></param>
        /// <returns></returns>
        /// 


        public static object FormatData(eFldType FldType, object data, string format, int Length)
        { 
            switch (FldType)
            {
                case eFldType.STRING:
                    int MxLen = Length;
                    data = FormatString(Convert.ToString(data), MxLen);
                    break;
                case eFldType.NUMBER:
                    FormatNumber(data, format);
                    break;
                case eFldType.IDFLDText:
                    {
                        if (data is DateTime)
                            data = FormatDate(data, format);
                        else if (IsNumeric(data))
                            data = FormatNumber(data, format);
                    }
                    break;
                case eFldType.DATE:
                    {
                        data = FormatDate(data, format);
                    }
                    break;
                case eFldType.DATAMATRIX:
                case eFldType.CODE128:
                    {
                        data = CreateIDTagVal(format);
                    }
                    break;
                default:
                    break;
            }
            
            return data;
        }
        private static string FormatString(string data, int MxLen)
        {
            try
            {
                if (string.IsNullOrEmpty(data) == false)
                {
                    if (data.Length > MxLen)
                    {
                        string dt = data.Substring(0, MxLen);
                        if (char.IsWhiteSpace(data[MxLen]) == true)
                            return dt;
                        else
                        {
                            int i = dt.LastIndexOf(' ');
                            string outStr = dt.Substring(0, i);
                            return outStr;
                        }
                    }
                    else
                        return data;
                }
                return null;
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}:{1},{2}", DateTime.Now, ex.Message, ex.StackTrace);
            }

            return data;
        }
        private static object FormatNumber(object data,string format)
        { 
            try
            {
                if (format != null && data != null)
                {
                    string[] strfields = format.Split(ID_FldSerparator);
                    decimal number = 0;
                    decimal.TryParse(Convert.ToString(data), out number);

                    CultureInfo cInfo = new CultureInfo(strfields[0]);
                    if (strfields[1].Contains("{") == true)
                        data = String.Format(strfields[1], number);
                    else
                        data = number.ToString(strfields[1], cInfo);  
                }
            }
            catch (Exception ex)
            {
               // Trace.TraceError("{0}:{1},{2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
           
            return data;
        }
        private static object FormatDate(object data, string format)
        {
            if (string.IsNullOrEmpty(format) && data != null)
                return data;
            try
            {
                data = Convert.ToDateTime(data).ToString(format);
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, {1},{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
            }
            return data;
        }
       
    

        #endregion FormatData_Hanlder

      

        public static string GetDisplayName(List<TemplateFields> lst, string fldNAme)
        {
            TemplateFields pf = lst.Find(item => item.FldName == fldNAme);
            if (pf != null)
                return pf.FieldText;
            return string.Empty;
        }

        public static object GetFldData(List<TemplateFields> lst, string fldName)
        {
            TemplateFields pf = lst.Find(item => item.FldName == fldName);
            if (pf != null)
                return pf.Data;
            return string.Empty;
        }

        public static string GetFldName(List<TemplateFields> LstTf, string idCodeTXtFldName)
        {
            TemplateFields tf = LstTf.Find(itm => itm.FldName == idCodeTXtFldName);
            if (tf != null && tf.FldType == eFldType.IDFLDText)
            {
                TemplateFields tffld = LstTf.Find(itm => itm.DataSource == tf.DataSource
                                                        && itm.DataField == tf.DataField
                                                        && itm.FldType != TemplateFields.eFldType.IDFLDText);
                if (tffld != null)
                    return tffld.FldName;
            }
            return tf.FldName;
        }
         
        public static object GetDeFaultFormattedValue(TemplateFields item)
        { 
            switch (item.FldType)
            {
                case eFldType.STRING:
                    item.Data = "SampleToPrint";
                    break;
                case eFldType.IDFLDText:
                    item.Data = "SampleToPrint";
                    break;
                case eFldType.NUMBER:
                    item.Data = 123.45;
                    item.Data = FormatNumber(item.Data, item.DataFormat);
                    break;
                case eFldType.DATE:
                    item.Data = DateTime.Now;
                    item.Data = FormatDate(item.Data, item.DataFormat);
                    break;

                case eFldType.DATAMATRIX:
                case eFldType.CODE128:
                      item.Data = CreateIDTagVal(item.DataFormat);// "SampleToPrint";
                      if (item.Data == null)
                       return null;
                      List<AITagVal> al = (List<AITagVal>)item.Data;
                      foreach (AITagVal altg in al)
                      {
                          altg.Value = "SampleToPrint";
                      }
                      //item.Data = GetIDFldDefaultValue(al);
                    //item.Data = "SampleToPrint";
                    break;
                default:
                    break;
            }

            return item.Data;
        }

        public static object GetIDFldDefaultValue(object ob)
        { 
            string strdata = string.Empty;

            List<AITagVal> altag = (List<AITagVal>)ob;
            if (altag == null)
                return strdata;
            foreach (AITagVal altg in altag)
            {
                altg.Value = "SampleToPrint";
                strdata += altg.Identifier + altg.Value;
            }
            return strdata;
        }
    }
}
