using System;
using System.Collections.Generic;
using RedUIDGenerator;
using PCH.UTIL.SystemIntegrity;
using PCH.UTIL;

namespace PCH.CODEMGR
{
    public class CodeManager
    {
        public event ReleaseObjectsHandler ReleaseOb;
        public event PrintedUidStatusHandler UpdateprintedUid;

        #region CODE MANAGER VARIABLES     
        private Queue<string> m_SerialCodes = new Queue<string>();

        public decimal MaxBatchNos { get; set; }

        private int m_CodesGenerated = 0;
        public int CodesGenerated
        {
            get { return m_CodesGenerated; }
        }
        public int CodesRemaining
        {
            get
            {
                return m_SerialCodes.Count;
            } 
        }

        private bool m_TestMode = true;
        public bool TestMode
        {
            get { return m_TestMode; }
            set { m_TestMode = value; }
        }

        VariableDataConfig VdConfig;
        public string fieldName = "SrNo"; 
        //public int Fldidentifier = 21;

        private List<GS1Mgr.GS1AI> mGS12DAIs = new List<GS1Mgr.GS1AI>();

        #endregion CODE MANAGER VARIABLES

        
        //vdSourceType m_UIDSource = vdSourceType.RedGEN;       
        object mRedCodes = null;

        public CodeManager(VariableDataConfig vdConfig)
        {
            VdConfig = vdConfig;
            fieldName = vdConfig.VeriableDataInfo.SourceType;
            //fieldName = sourceFieldName;
            //m_UIDSource = uidSource; // This will come from GLOBALS.UIDSource.bin
        }
      
        public bool Init(int prodType)
        {
            bool hasInit = false;
            //Globals.UidConfig.ReadSettings();

            switch (VdConfig.SourceType)
            {
                case vdSourceType.NONE:
                    break;
                case vdSourceType.RedGEN:
                    {
                        mRedCodes = new UIDGen();
                        ((UIDGen)mRedCodes).InitUIDGen(1, System.Windows.Forms.Application.StartupPath);
                        hasInit = true; 
                    }
                    break;
                case vdSourceType.CSV:
                    {
                        mRedCodes = new UIDCsvReader();
                        hasInit = ((UIDCsvReader)mRedCodes).InitUIDGen(VdConfig.cvsConfig.SourcefilePath , 1, 1);
                    }
                    break;
                case vdSourceType.EXCEL:
                    {                         
                        mRedCodes = new UIDExcelReader();
                        UIDExcelReader ob =(UIDExcelReader) mRedCodes;

                        hasInit = ob.InitUIDGen(VdConfig);
                        UpdateprintedUid += new PrintedUidStatusHandler(ob.SaveStatusOfUid);
                        ReleaseOb += new ReleaseObjectsHandler(ob.Quit);
                    }
                    break;
                case vdSourceType.XML:
                    {
                        mRedCodes = new CodeXMLReader();
                        if (string.IsNullOrEmpty(VdConfig.xMLConfig.SourcefilePath) == false)
                        {
                            if (System.IO.File.Exists(VdConfig.xMLConfig.SourcefilePath) == false)
                            {
                                throw new InvalidOperationException("Data File Location Missing");
                            }
                            hasInit = ((CodeXMLReader)mRedCodes).GetHCL_XMLData(VdConfig.xMLConfig.SourcefilePath);
                        }
                    }
                    break;
                case vdSourceType.DbStore:
                    {
                        mRedCodes = new UIDStore();
                        hasInit = ((UIDStore)mRedCodes).InitUIDGen(VdConfig.dbStoreConfig);
                    }
                    break;
                default:
                    break;
            }
            return hasInit;
        }       

        public string FetchNextUID()
        {
            if (m_CodesGenerated == MaxBatchNos)
                return null;

            string strUID = null;

            if (VdConfig.SourceType  == vdSourceType.RedGEN)
            {
                strUID = ((UIDGen)mRedCodes).GenNextUID();
            }
            else if (VdConfig.SourceType == vdSourceType.DbStore)
            {
                strUID = ((UIDStore)mRedCodes).GenNextUID();
            }
            else if (VdConfig.SourceType == vdSourceType.EXCEL)
            {
                strUID = ((UIDExcelReader)mRedCodes).GenNextUID();
            }
            else if (VdConfig.SourceType == vdSourceType.CSV)
            {
                strUID = ((UIDCsvReader)mRedCodes).GenNextUID();
            }
            else if (VdConfig.SourceType == vdSourceType.XML)
            {
                strUID = ((CodeXMLReader)mRedCodes).GetNextUID();
            }

            if (String.IsNullOrEmpty(strUID) == true)
                return "";

            m_SerialCodes.Enqueue(strUID);
            m_CodesGenerated++;

            return strUID;
        }

        #region UID FOR USAGE

        int m_TeachCount = 1;
        public string GetNextUID()
        {
            string output = "";
            if (m_TestMode == true)
            {
                output = "SAMPLETEST" + (m_TeachCount++).ToString().PadLeft(5, '0');
            }
            else
            {
                if (m_SerialCodes.Count > 0)
                {

                    output = m_SerialCodes.Dequeue();

                    UpdatePrintedUidStatus(output);

                    if (m_SerialCodes.Count == 0)
                        ReleaseObjects();
                }
            }
            return output;
        }    
        #endregion UID FOR USAGE 

        public void UpdatePrintedUidStatus(string uid)
        {
            if (UpdateprintedUid != null)
                UpdateprintedUid(uid);
        }

        public void ReleaseObjects()
        {
            if (ReleaseOb != null)
                ReleaseOb();
        }
    }
}
