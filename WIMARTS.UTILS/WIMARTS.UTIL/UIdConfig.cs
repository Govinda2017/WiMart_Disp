using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PCH.UTIL.SystemIntegrity;
using RedXML;
using System.IO;

namespace PCH.UTIL
{
    [Serializable]
    public class UIdConfig
    {
        string _printerName;

        public string PrinterName
        {
            get { return _printerName; }
            set { _printerName = value; }
        }

        UIDSourceType _UIDSourceType;

        public UIDSourceType UIDSourceType
        {
            get { return _UIDSourceType; }
            set { _UIDSourceType = value; }
        }


        string _UIDSourceLoc;

        public string UIDSourceLoc
        {
            get { return _UIDSourceLoc; }
            set { _UIDSourceLoc = value; }
        }

        public static List<UIdConfig> lstUidSourceConfig = new List<UIdConfig>();

        public static List<UIdConfig> LoadUidSourceConfig(List<string> printers)
        {
            //Xml=xml;
            if (File.Exists(SettingsPath.UIDSourceConfig))
            {
                lstUidSourceConfig = GenericXmlSerializer<List<UIdConfig>>.DeserializeString(SettingsPath.UIDSourceConfig);
            }
            else
            {
                lstUidSourceConfig = SaveDefault(printers);
            }
            return lstUidSourceConfig;
        }

        private static List<UIdConfig> SaveDefault(List<string> printers)
        {
            lstUidSourceConfig = new List<UIdConfig>(); 
            UIdConfig uidConfig =null;

            foreach (string  item in printers)
            {
                uidConfig = new UIdConfig();
                uidConfig.PrinterName = item;
                uidConfig.UIDSourceLoc = "";
                uidConfig.UIDSourceType = UIDSourceType.RedGEN;
                lstUidSourceConfig.Add(uidConfig);
            }
            
            GenericXmlSerializer<List<UIdConfig>>.DeserializeString(SettingsPath.UIDSourceConfig);
            return lstUidSourceConfig;
        }

    }
}
