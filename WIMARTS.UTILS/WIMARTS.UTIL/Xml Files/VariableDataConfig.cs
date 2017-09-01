using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMARTS.UTIL.SystemIntegrity;
using RedXML;
using System.Windows.Forms;

namespace WIMARTS.UTIL
{
    //TBD:Add this in iCodemGr project
    public class VariableDataConfig
    {
        /// <summary>
        /// Config ID-This is not compulsory Fld ,If Variable data config contains more than one settings for SourceFld,then this will be used..
        /// If user has added only one settings for each source fld type then no need to pass Config ID,default value of config id is 1.
        /// </summary>
        private int _ConfigID=1;
        public int ConfigID
        {
            get { return _ConfigID; }
            set { _ConfigID = value; }
        }

        private VariableDataInfo _VariableDataInfo; 
        public VariableDataInfo VariableDataInfo
        {
            get { return _VariableDataInfo; }
            set { _VariableDataInfo = value; }
        } 

        private ExcelConfig _vdExcelConfig;
        public ExcelConfig excelConfig
        {
            get { return _vdExcelConfig; }
            set { _vdExcelConfig = value; }
        } 

        private CSVConfig _vdCsvConfig;
        public CSVConfig csvConfig
        {
            get { return _vdCsvConfig; }
            set { _vdCsvConfig = value; }
        }

        private DbStoreConfig _vdDbStoreConfig;
        public DbStoreConfig dbStoreConfig
        {
            get { return _vdDbStoreConfig; }
            set { _vdDbStoreConfig = value; }
        }

        private XMLConfig _vdXMLConfig;
        public XMLConfig xMLConfig
        {
            get { return _vdXMLConfig; }
            set { _vdXMLConfig = value; }
        }

        private SSCCGenConfig _vdSSCCGenConfig;
        public SSCCGenConfig sSCCGenConfig
        {
            get { return _vdSSCCGenConfig; }
            set { _vdSSCCGenConfig = value; }
        }

        private SerialConfig _vdSerialConfig;
        public SerialConfig serialConfig
        {
            get { return _vdSerialConfig; }
            set { _vdSerialConfig = value; }
        }
          
        private ReadFromHWConfig _vdReadFromHWConfig;
        public ReadFromHWConfig readFromHWConfig
        {
            get { return _vdReadFromHWConfig; }
            set { _vdReadFromHWConfig = value; }
        }

        public static List<VariableDataConfig> lstVariableDataConfig=new List<VariableDataConfig>();

        public static bool Read()
        {
            string filspath = SettingsPath.VariableDataSourceConfig;
            if (!System.IO.File.Exists(filspath))
            { 
                DefaultVdWrite();
                return true;
            }
            lstVariableDataConfig = GenericXmlSerializer<List<VariableDataConfig>>.Deserialize(filspath);
            if (lstVariableDataConfig == null && lstVariableDataConfig.Count == 0)
                return false;
            return true;
        }

        public static bool Write()
        {
            GenericXmlSerializer<List<VariableDataConfig>>.Serialize(lstVariableDataConfig, SettingsPath.VariableDataSourceConfig);
            return true;
        }

        /// <summary>
        /// SourceFld-SourceFldType of variable data
        /// Config ID-This is not compulsory Fld ,If Variable data config contains more than one settings for SourceFld,then this will be used..
        /// If user has added only one settings for each source fld type then no need to pass Config ID,default value of config id is 1.
        /// </summary>
        /// <param name="sourceFld"></param>
        /// <param name="configID"></param>
        /// <returns></returns>
        public static VariableDataConfig GetVDConfig(VdSourceType vdSourceType, int? configID)
        {
            if (configID == null)
                configID = 1;
            VariableDataConfig vdConfig = null;
            if (lstVariableDataConfig != null)
                vdConfig = lstVariableDataConfig.Find(item => item.VariableDataInfo.vdSourceType == vdSourceType && item.ConfigID == configID);
            return vdConfig;
        }
        public static VariableDataConfig GetVDConfig(string vdSourceType, int? configID)
        {
            if (configID == null)
                configID = 1;
            VariableDataConfig vdConfig = null;
            if (lstVariableDataConfig != null)
                vdConfig = lstVariableDataConfig.Find(item => item.VariableDataInfo.vdSourceType.ToString() == vdSourceType && item.ConfigID == configID);
            return vdConfig;
        }
        public static int GetVDConfigIndex(VdSourceType vdSourceType, int? configID)
        {
            int index = -1;
            if (configID == null)
                configID = 1;
          
            if (lstVariableDataConfig != null)
                return lstVariableDataConfig.FindIndex(item => item.VariableDataInfo.vdSourceType == vdSourceType && item.ConfigID == configID);
            return index;
        }
        public static void ReplaceItem(VariableDataConfig vd)
        {
            if (lstVariableDataConfig == null)
                lstVariableDataConfig = new List<VariableDataConfig>();
            int index = GetVDConfigIndex(vd.VariableDataInfo.vdSourceType, vd.ConfigID);
            if (index > -1)
                lstVariableDataConfig[index] = vd;
            else
                lstVariableDataConfig.Add(vd);
        }
        public static void DefaultVdWrite()
        {
            foreach (VariableDataInfo item in VariableDataInfo.lstVariableDataInfo)
            {
                if (item.vdSourceType == VdSourceType.RedUidGen || item.vdSourceType == VdSourceType.SerialNo || item.vdSourceType==VdSourceType.RedCSVGen)
                {
                    CreateDefaultConfigs(item, 1); 
                }
            }
        }
        public static void CreateDefaultConfigs(UTIL.VariableDataInfo vdInfo, int? configID)
        {
            VariableDataConfig vdC = new VariableDataConfig();
            vdC.VariableDataInfo = vdInfo;
            vdC.ConfigID = configID == null ? 1 : (int)configID;
            if (vdInfo.vdSourceType == VdSourceType.SerialNo)
            {
                vdC.serialConfig = new SerialConfig();
            }
            else if (vdInfo.vdSourceType == VdSourceType.RedUidGen)
            {

            }
            ReplaceItem(vdC);
            Write();
        }

        public static void Remove(VdSourceType vdSourceType, int? configID)
        {
            if (configID == null)
                configID = 1;
            int index = GetVDConfigIndex(vdSourceType, configID);
            if (index > -1)
                lstVariableDataConfig.RemoveAt(index);
        }
        public static int GetNewConfigID(VdSourceType vd)
        {
            int maxID = 0;
            if (lstVariableDataConfig == null)
                return maxID;

            foreach (VariableDataConfig item in lstVariableDataConfig)
            {
                if (item.VariableDataInfo.vdSourceType != vd)
                    continue;

                if (maxID < item.ConfigID)
                    maxID = item.ConfigID;
            }

            return maxID + 1;
        }


        public class ExcelConfig
        {
            private string _SourcefilePath;
            public string SourcefilePath
            {
                get { return _SourcefilePath; }
                set { _SourcefilePath = value; }
            }

            private int _StartRowIndex=1;
            public int StartRowIndex
            {
                get { return _StartRowIndex; }
                set { _StartRowIndex = value; }
            }

            private int _StartColumnIndex=1;
            public int StartColumnIndex
            {
                get { return _StartColumnIndex; }
                set { _StartColumnIndex = value; }
            }

            private int _LastUsedRowIndex;
            public int LastUsedRowIndex
            {
                get { return _LastUsedRowIndex; }
                set { _LastUsedRowIndex = value; }
            }

            private int _LastReadWorkBookIndex=1;
            public int LastReadWorkBookIndex
            {
                get { return _LastReadWorkBookIndex; }
                set { _LastReadWorkBookIndex = value; }
            }
        }
        public class CSVConfig
        { 
            private string _SourceFilePath;
            public string SourceFilePath
            {
                get { return _SourceFilePath; }
                set { _SourceFilePath = value; }
            }

            private long _TotalPrintedLines;
            public long TotalPrintedLines
            {
                get { return _TotalPrintedLines; }
                set { _TotalPrintedLines = value; }
            }
        }
        public class DbStoreConfig
        {
            private string _server;
            public string server
            {
                get { return _server; }
                set { _server = value; }
            }

            private string _database;
            public string database
            {
                get { return _database; }
                set { _database = value; }
            }

            private string _userID;
            public string userID
            {
                get { return _userID; }
                set { _userID = value; }
            }

            private string _pwd;
            public string Pwd
            {
                get { return _pwd; }
                set { _pwd = value; }
            }

            private string _table;
            public string table
            {
                get { return _table; }
                set { _table = value; }
            }

            private string _codeColumn;
            public string codeColumn
            {
                get { return _codeColumn; }
                set { _codeColumn = value; }
            }

            private string _statusColumn;
            public string statusColumn
            {
                get { return _statusColumn; }
                set { _statusColumn = value; }
            } 
        }
        public class XMLConfig
        {
            private string _SourcefilePath;
            public string SourcefilePath
            {
                get { return _SourcefilePath; }
                set { _SourcefilePath = value; }
            }
        }
        public class SSCCGenConfig
        {           
            private int _Pi;
            public int Pi
            {
                get { return _Pi; }
                set { _Pi = value; }
            }

            private int _LastReadSSCC;
            public int LastReadSSCC
            {
                get { return _LastReadSSCC; }
                set { _LastReadSSCC = value; }
            }
                     
            private string _GS1CompCode;
            public string GS1CompCode
            {
                get { return _GS1CompCode; }
                set { _GS1CompCode = value; }
            }

            private string _LineCode;
            public string LineCode
            {
                get { return _LineCode; }
                set { _LineCode = value; }
            }
        } 
        public class SerialConfig
        {
            private long  _number;
            public long number
            {
                get { return _number; }
                set { _number = value; }
            }
        }
        public class ReadFromHWConfig
        {
            private bool  _IsComPort;
            public bool IsComPort
            {
                get { return _IsComPort; }
                set { _IsComPort = value; }
            }
            private bool _IsTcp;
            public bool IsTcp
            {
                get { return _IsTcp; }
                set { _IsTcp = value; }
            }

            private string _ComPort;
            public string ComPort
            {
                get { return _ComPort; }
                set { _ComPort = value; }
            }

            private string _IpAddress;
            public string IpAddress
            {
                get { return _IpAddress; }
                set { _IpAddress = value; }
            }

            private int _Port;
            public int Port
            {
                get { return _Port; }
                set { _Port = value; }
            }
        }
    }
}
