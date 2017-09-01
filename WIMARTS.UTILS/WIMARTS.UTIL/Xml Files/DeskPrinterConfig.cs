using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedXML;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace WIMARTS.UTIL
{
    public class DeskPrinterConfig
    {
        private string _GivenName;
        public string GivenName
        {
            get { return _GivenName; }
            set { _GivenName = value; }
        }

        private string _printerName;
        public string printerName
        {
            get { return _printerName; }
            set { _printerName = value; }
        }

        private int _PrintCopies;
        public int PrintCopies
        {
            get { return _PrintCopies; }
            set { _PrintCopies = value; }
        }

        private bool _PrintCollated;
        public bool PrintCollated
        {
            get { return _PrintCollated; }
            set { _PrintCollated = value; }
        }

        private bool _PrintDisable;
        public bool PrintDisable
        {
            get { return _PrintDisable; }
            set { _PrintDisable = value; }
        }

        private string _SchemasDirectoryPath;
        public string SchemasDirectoryPath
        {
            get { return _SchemasDirectoryPath; }
            set { _SchemasDirectoryPath = value; }
        }

        private string _PrinterCurSchemas;
        public string PrinterCurSchemas
        {
            get { return _PrinterCurSchemas; }
            set { _PrinterCurSchemas = value; }
        }

        public bool IsPassBlankLbl 
        {
            get; set;
        }

        public string QTYPostLabel 
        { 
            get; set;
        } 

        public DeskPrinterConfig()
        {
            PrinterCurSchemas = "Label.bin";
            SchemasDirectoryPath = @"\LabelSchemas\";
        }

        public static List<DeskPrinterConfig> lstDeskPrinterConfig=new List<DeskPrinterConfig>();
        public static List<DeskPrinterConfig> Read()
        {
            //Xml=xml;
            string filspath = SettingsPath.DeskPrinterConfig ;
            if (System.IO.File.Exists(filspath))
            {
                lstDeskPrinterConfig = GenericXmlSerializer<List<DeskPrinterConfig>>.Deserialize(filspath);
            }
            else
            {

                foreach (string strPrinter in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    DeskPrinterConfig oDesk = new DeskPrinterConfig();
                    oDesk.GivenName = strPrinter;
                    oDesk.IsPassBlankLbl = false;
                    oDesk.PrintCollated = false;
                    oDesk.PrintCopies = 1;
                    oDesk.PrintDisable = false;
                    oDesk.PrinterCurSchemas = "rtpl1";
                    oDesk.printerName = strPrinter;
                    oDesk.QTYPostLabel = "0";
                    oDesk.SchemasDirectoryPath = SettingsPath.LabelDir;
                    lstDeskPrinterConfig.Add(oDesk);
                }
                Write();
            }
            return lstDeskPrinterConfig;
        }

        public static bool Write()
        {
            GenericXmlSerializer<List<DeskPrinterConfig>>.Serialize(lstDeskPrinterConfig, SettingsPath.DeskPrinterConfig);
            return true;
        }

        public static string GetFullFilePath(DeskPrinterConfig dpc)
        {
            string filePath = SettingsPath.LabelDir + "\\" + dpc.PrinterCurSchemas;
            if (filePath.EndsWith(".bin") == false)
            {
                filePath += ".bin";
            }
            return filePath;
        }

        public  string GetFullFilePath(string fileName)
        {
            string filePath = SettingsPath.LabelDir + "\\" + fileName;
            if (filePath.EndsWith(".bin") == false)
            {
                filePath += ".bin";
            }
            return filePath;
        }
        public string GetDirectoryPath()
        {
            string directoryPath = SettingsPath.LabelDir;
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            return directoryPath;
        }
        public static void ReplaceItem(DeskPrinterConfig cp)
        {
            int i = lstDeskPrinterConfig.FindIndex(itm => itm.GivenName == cp.GivenName);

            if (i > -1)
                lstDeskPrinterConfig[i] = cp;
            else
                lstDeskPrinterConfig.Add(cp);
        }

        public static void Remove(string givenName)
        {
            int i = lstDeskPrinterConfig.FindIndex(itm => itm.GivenName == givenName);
            if (i > -1)
                lstDeskPrinterConfig.RemoveAt(i);
        }

        public static DeskPrinterConfig Get(string givenName)
        {
            if (lstDeskPrinterConfig == null || lstDeskPrinterConfig.Count == 0)
                return null;
            return lstDeskPrinterConfig.Find(itm => itm.GivenName == givenName);
        }
        public static DeskPrinterConfig Getprnt(string printerName)
        {
            if (lstDeskPrinterConfig == null || lstDeskPrinterConfig.Count == 0)
                return null;
            return lstDeskPrinterConfig.Find(itm => itm.printerName == printerName);
        }
    }
}
