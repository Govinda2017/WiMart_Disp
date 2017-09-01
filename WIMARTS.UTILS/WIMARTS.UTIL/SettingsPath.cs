using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WIMARTS.UTIL
{
    public class SettingsPath   //SetupBinPaths
    {
        private static string _AppStartUpPath = Application.StartupPath;
        public static string AppStartUpPath
        {
            get { return _AppStartUpPath; }
            set { _AppStartUpPath = value; }
        }

        public static string InnerDir = "\\SetupBin";
        public static string SettingDir
        {
            get { return AppStartUpPath + InnerDir; }
        }

        public static string TemplateDir = SettingDir + "\\TemplateDesigns";
        public static string LabelDir = SettingDir + "\\LabelSchemas";

        public static string LogFileDir = "\\Logs";
        public static string LogDir
        {
            get { return AppStartUpPath + LogFileDir; }
        }

        private static string DumpFileDir = "\\Dump";
        public static string DumpDir
        {
            get { return AppStartUpPath + DumpFileDir; }
        }


        public static string DBConnection = SettingDir + "\\DB_Config.rxd";
    

        public static void CreateSettingsDir()
        {
            if (Directory.Exists(SettingDir) == false)
                Directory.CreateDirectory(SettingDir);
            if (Directory.Exists(TemplateDir) == false)
                Directory.CreateDirectory(TemplateDir);
            if (Directory.Exists(LabelDir) == false)
                Directory.CreateDirectory(LabelDir);
        }

        public static string AppSettings
        {
            get { return SettingDir + "\\AppSettings.bin"; }
        }
        public static string Vendor
        {
            get { return Application.StartupPath + InnerDir + "\\rodnev.bin"; }
        }
        public static string VariableDataSourceConfig
        {
            get { return SettingDir + "\\VariableDataSourceConfig.bin"; }
        }

        public static string VeriableDataInfo
        {
            get { return SettingDir  + "\\VariableDataInfo.bin"; }
        }
   
        public static string DeskPrinterConfig 
        {
            get { return SettingDir + "\\DeskPrinterConfig.bin"; } 
        }

        public static string InspectionSettings1
        {
            get { return SettingDir + "\\InspectionSettings1.rxd"; }
        }

        public static string InspectionSettings2
        {
            get { return SettingDir + "\\InspectionSettings2.rxd"; }
        }

        public static string HWCSettings
        {
            get { return SettingDir + "\\HWCSettings.rxd"; } 
        }
        public static string HWConfigPath_PLC
        {
            get { return SettingDir + "\\HWConfigPath_PLC.rdat"; }
        }
        public static string PLC_Setup
        {
            get { return SettingDir + "\\PLC_Setup.rdat"; }
        }
        public static string HWCValues
        {
            get { return SettingDir + "\\HWCValues.rxd"; }
        }

    }
}
