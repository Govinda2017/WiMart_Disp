using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedXML;

namespace WIMARTS.UTIL
{
    public class ControllerPortConfig
    {
        private string _PrinterName; 
        public string PrinterName
        {
            get { return _PrinterName; }
            set { _PrinterName = value; }
        }

        private string _SerialPort;

        public string SerialPort
        {
            get { return _SerialPort; }
            set { _SerialPort = value; }
        }

        public static List<ControllerPortConfig> lstControllerPortConfig = new List<ControllerPortConfig>();

        public static bool Read()
        {
            //string filspath = SettingsPath.ControllerPortConfig;
            //if (!System.IO.File.Exists(filspath))
            //{
            //    return false;
            //}
            //lstControllerPortConfig = GenericXmlSerializer<List<ControllerPortConfig>>.Deserialize(filspath);
            //if (lstControllerPortConfig == null && lstControllerPortConfig.Count == 0)
            //    return false;
            return true;
        }

        public static bool Write()
        {
            //GenericXmlSerializer<List<ControllerPortConfig>>.Serialize(lstControllerPortConfig, SettingsPath.ControllerPortConfig);
            return true;
        }

        public static ControllerPortConfig GetConfig(string p)
        {
            ControllerPortConfig cs = lstControllerPortConfig.Find(itm=>itm.PrinterName==p);
            return cs;
        }

        public static void ReplaceItem(ControllerPortConfig cp)
        {
            int i = lstControllerPortConfig.FindIndex(itm => itm.PrinterName == cp.PrinterName);

            if (i > -1)
                lstControllerPortConfig[i] = cp;
            else
                lstControllerPortConfig.Add(cp);
        }


        public static void Remove(ControllerPortConfig cp)
        {
            int i = lstControllerPortConfig.FindIndex(itm => itm == cp);
            lstControllerPortConfig.RemoveAt(i);
        }
    }
}
