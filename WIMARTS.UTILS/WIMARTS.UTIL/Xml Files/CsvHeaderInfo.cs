using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedXML;

namespace WIMARTS.UTIL
{
    public class CsvHeaderInfo
    {
        private int _HeaderIndex;

        public int HeaderIndex
        {
            get { return _HeaderIndex; }
            set { _HeaderIndex = value; }
        }
        
        private string _HeaderName;

        public string HeaderName
        {
            get { return _HeaderName; }
            set { _HeaderName = value; }
        }

        public static List<CsvHeaderInfo> lstCsvHeaderInfo = new List<CsvHeaderInfo>();

        public static List<CsvHeaderInfo> LoadCsvHeaderInfo()
        {
            //Xml=xml;
            string filspath = SettingsPath.VeriableDataInfo;
            if (!System.IO.File.Exists(filspath))
            {
                lstCsvHeaderInfo = LoadDefaultInfo();
                GenericXmlSerializer<List<CsvHeaderInfo>>.Serialize(lstCsvHeaderInfo, filspath);
            }
            else
                lstCsvHeaderInfo = GenericXmlSerializer<List<CsvHeaderInfo>>.Deserialize(filspath);
            return lstCsvHeaderInfo;
        }

        private static List<CsvHeaderInfo> LoadDefaultInfo()
        {
            List<CsvHeaderInfo> lst = new List<CsvHeaderInfo>();
            CsvHeaderInfo vInfo = new CsvHeaderInfo();
            vInfo.HeaderIndex = 1;
            vInfo.HeaderName = "GTIN";
            lst.Add(vInfo);

            vInfo = new CsvHeaderInfo();
            vInfo.HeaderIndex = 2;
            vInfo.HeaderName = "BATCH";
            lst.Add(vInfo);

            vInfo = new CsvHeaderInfo();
            vInfo.HeaderIndex = 3;
            vInfo.HeaderName = "MFG";
            lst.Add(vInfo);

            vInfo = new CsvHeaderInfo();
            vInfo.HeaderIndex = 4;
            vInfo.HeaderName = "EXP";
            lst.Add(vInfo);

            vInfo = new CsvHeaderInfo();
            vInfo.HeaderIndex = 5;
            vInfo.HeaderName = "UID";
            lst.Add(vInfo);
            return lst;
        }

        public static bool Read()
        {
        //    string filspath = SettingsPath.CsvHeaderInfo;
        //    if (!System.IO.File.Exists(filspath))
        //    {
        //        //  DefaultVdWrite();
        //        LoadDefaultInfo();
        //        Write();
        //        return true;
        //    }
        //    lstCsvHeaderInfo = GenericXmlSerializer<List<CsvHeaderInfo>>.Deserialize(filspath);
        //    if (lstCsvHeaderInfo == null && lstCsvHeaderInfo.Count == 0)
        //        return false;
            return true;
        }

        public static bool Write()
        {
         //   GenericXmlSerializer<List<CsvHeaderInfo>>.Serialize(lstCsvHeaderInfo, SettingsPath.CsvHeaderInfo);
            return true;
        }
    }
}
