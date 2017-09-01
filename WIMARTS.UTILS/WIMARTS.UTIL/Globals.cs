using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using RedXML;

namespace WIMARTS.UTIL.SystemIntegrity
{ 
    public static class RoleName
    {
        public const string Admin = "Administrator";
        public const string Supervisor = "Supervisor";
        public const string Operator = "Operator";
        public const string QA = "QA";
        public const string SUPERUSER = "SUPERUSER";

    }
    public class Globals
    {
        public static void CreateDefaultSettings()
        {
            if (Directory.Exists(SettingsPath.SettingDir) == false)
            {
                Directory.CreateDirectory(SettingsPath.SettingDir);
            }

            //string TemplateFolder = SettingsPath.TemplateDir;

            //if (Directory.Exists(TemplateFolder) == false)
            //{
            //    Directory.CreateDirectory(TemplateFolder);
            //}

            //string LabelFolder = SettingsPath.LabelDir;

            //if (Directory.Exists(LabelFolder) == false)
            //{
            //    Directory.CreateDirectory(LabelFolder);
            //}

            if (Directory.Exists(SettingsPath.LogDir) == false)
            {
                Directory.CreateDirectory(SettingsPath.LogDir);
            }

            if (Directory.Exists(SettingsPath.LogDir) == false)
            {
                Directory.CreateDirectory(SettingsPath.LogDir);
            }
            else
            {
                try
                {
                    FileInfo f = new FileInfo(SettingsPath.LogDir + "\\logs_App.csv");
                    long s1 = f.Length;
                    if (s1 > 1024 * 1024)
                    {
                        string uniqTS = DateTime.Now.ToString("yyyy-MM-dd_HH-mm");
                        System.IO.File.Move(SettingsPath.LogDir + "\\logs_App.csv", SettingsPath.LogDir + "\\logs_App" + uniqTS + ".csv");
                    }
                }
                catch { }
            }
                      
            if (Directory.Exists(SettingsPath.DumpDir) == false)
            {
                Directory.CreateDirectory(SettingsPath.DumpDir);
            }

            if (File.Exists(SettingsPath.AppSettings) == false)
                AppSettings.WriteSettings();
            else
                AppSettings.ReadSettings();      

            if (File.Exists(SettingsPath.InspectionSettings1) == false)
                InspectionSettings1.WriteSettings();
            else
                InspectionSettings1.ReadSettings();
            if (File.Exists(SettingsPath.InspectionSettings2) == false)
                InspectionSettings2.WriteSettings();
            else
                InspectionSettings2.ReadSettings();

            if (File.Exists(SettingsPath.HWCSettings) == false)
                HWCSettings.WriteSettings();
            else
                HWCSettings.ReadSettings();

            if (File.Exists(SettingsPath.HWCValues) == false)
            {
                HWCSettings.WriteValues(new HWCValues());
            }
            else
                HWCSettings.ReadSettings();      

            //DeskPrinterConfig.Read();
            //VariableDataInfo.LoadVariableDataInfo();
            //VariableDataConfig.Read();
        }

        public class AppSettings
        {
            public static string LogFilePath = "D:\\Logs";
            public static string LogFile = "logs.csv";       
            public static string DefaultUserName = "Administrator";

            public static bool AllowOnlyScheduleDispatch = true;
            public static bool AllowOnlyProductionVerified = true;
            public static bool AllowFreeFlowDispatch = false;

            public static bool HasHwController = true;
            public static string BatchNameFormat = "dd-MM-yyyy HHmmss";
            public static int HWMode = 0; //0:MixesMode/Both; 1:Camera; 2:Scanner
            public static int LineID = 0;
            public static int DispatchDaysLimit = 60;

            public static void ReadSettings()
            {
                IniFile ini = new IniFile(SettingsPath.AppSettings);
                AppSettings.AllowOnlyScheduleDispatch = Convert.ToBoolean(ini.ReadValue("AppSettings", "AllowOnlyScheduleDispatch", AppSettings.AllowOnlyScheduleDispatch.ToString()));
                AppSettings.AllowOnlyProductionVerified = Convert.ToBoolean(ini.ReadValue("AppSettings", "AllowOnlyProductionVerified", AppSettings.AllowOnlyProductionVerified.ToString()));
                AppSettings.AllowFreeFlowDispatch = Convert.ToBoolean(ini.ReadValue("AppSettings", "AllowFreeFlowDispatch", AppSettings.AllowFreeFlowDispatch.ToString()));

                AppSettings.HasHwController = Convert.ToBoolean(ini.ReadValue("AppSettings", "HasHwController", AppSettings.HasHwController.ToString()));
                AppSettings.BatchNameFormat = ini.ReadValue("AppSettings", "BatchNameFormat", AppSettings.BatchNameFormat);
                AppSettings.HWMode = Convert.ToInt32(ini.ReadValue("AppSettings", "HWMode", AppSettings.HWMode.ToString()));
                AppSettings.DispatchDaysLimit = Convert.ToInt32(ini.ReadValue("AppSettings", "DispatchDaysLimit", AppSettings.DispatchDaysLimit.ToString()));
            }
            public static void WriteSettings()
            {
                IniFile ini = new IniFile(SettingsPath.AppSettings);
                ini.WriteValue("AppSettings", "AllowOnlyScheduleDispatch", AppSettings.AllowOnlyScheduleDispatch.ToString());
                ini.WriteValue("AppSettings", "AllowOnlyProductionVerified", AppSettings.AllowOnlyProductionVerified.ToString());
                ini.WriteValue("AppSettings", "AllowFreeFlowDispatch", AppSettings.AllowFreeFlowDispatch.ToString());

                ini.WriteValue("AppSettings", "HasHwController", AppSettings.HasHwController.ToString());
                ini.WriteValue("AppSettings", "BatchNameFormat", AppSettings.BatchNameFormat);
                ini.WriteValue("AppSettings", "HWMode", AppSettings.HWMode.ToString());
                ini.WriteValue("AppSettings", "DispatchDaysLimit", AppSettings.DispatchDaysLimit.ToString());
            }
            public static bool ReadSettings(string AppID, string ProdUID)
            {
                if (string.IsNullOrEmpty(RedSys.Integrity.AppStartUpPath) == true)
                    RedSys.Integrity.AppStartUpPath = System.Windows.Forms.Application.StartupPath;

                if (RedSys.Integrity.ProcessIfValid(AppID, ProdUID) == false)
                {
                    System.Windows.Forms.MessageBox.Show("FAILED TO INITIALIZE THE SYSTEM.", "SETUP FAILURE");
                    Trace.Assert(false, "FAILED TO INITIALIZE THE SYSTEM.", "SETUP FAILURE");
                    return false;
                }
                LineID = RedSys.Integrity.GetLineID;
                return true;
            }
        }

        public class InspectionSettings1
        {
            public static string DeviceName = "Omron_FQ2";
            public static bool IsSerial = false;
            public static string Address = "192.168.0.10";
            public static int Port = 9876;//Baumer 23
         
            public static void ReadSettings()
            {
                IniFile ini = new IniFile(SettingsPath.InspectionSettings1);
                InspectionSettings1.DeviceName = ini.ReadValue("InspectionSettings1", "DeviceName", InspectionSettings1.DeviceName);
                InspectionSettings1.IsSerial = Convert.ToBoolean(ini.ReadValue("InspectionSettings1", "IsSerial", InspectionSettings1.IsSerial.ToString()));
                InspectionSettings1.Address = ini.ReadValue("InspectionSettings1", "Address", InspectionSettings1.Address);
                InspectionSettings1.Port = Convert.ToInt32(ini.ReadValue("InspectionSettings1", "Port", InspectionSettings1.Port));
           }
            public static void WriteSettings()
            {
                IniFile ini = new IniFile(SettingsPath.InspectionSettings1);
                ini.WriteValue("InspectionSettings1", "DeviceName", InspectionSettings1.DeviceName);
                ini.WriteValue("InspectionSettings1", "IsSerial", InspectionSettings1.IsSerial.ToString());
                ini.WriteValue("InspectionSettings1", "Address", InspectionSettings1.Address);
                ini.WriteValue("InspectionSettings1", "Port", InspectionSettings1.Port);
           }
        }

        public class InspectionSettings2
        {           
            public static string DeviceName = "Scanner";
            public static bool IsSerial = true;
            public static string Address = "COM1";
            public static int Port = 9876;
          
            public static void ReadSettings()
            {
                IniFile ini = new IniFile(SettingsPath.InspectionSettings2);
                InspectionSettings2.DeviceName = ini.ReadValue("InspectionSettings2", "DeviceName", InspectionSettings2.DeviceName);
                InspectionSettings2.IsSerial = Convert.ToBoolean(ini.ReadValue("InspectionSettings2", "IsSerial", InspectionSettings2.IsSerial.ToString()));
                InspectionSettings2.Address = ini.ReadValue("InspectionSettings2", "Address", InspectionSettings2.Address);
                InspectionSettings2.Port = Convert.ToInt32(ini.ReadValue("InspectionSettings2", "Port", InspectionSettings2.Port));
            }

            public static void WriteSettings()
            {
                IniFile ini = new IniFile(SettingsPath.InspectionSettings2);
                ini.WriteValue("InspectionSettings2", "DeviceName", InspectionSettings2.DeviceName);
                ini.WriteValue("InspectionSettings2", "IsSerial", InspectionSettings2.IsSerial.ToString());
                ini.WriteValue("InspectionSettings2", "Address", InspectionSettings2.Address);
                ini.WriteValue("InspectionSettings2", "Port", InspectionSettings2.Port);
           }
        }

        public class HWCSettings
        {
            public static string SerialPort = "COM3";
            public static void ReadSettings()
            {
                IniFile ini = new IniFile(SettingsPath.HWCSettings);
                HWCSettings.SerialPort = ini.ReadValue("HWCSettings", "SerialPort", HWCSettings.SerialPort);
            }
            public static void WriteSettings()
            {
                IniFile ini = new IniFile(SettingsPath.HWCSettings);
                ini.WriteValue("HWCSettings", "SerialPort", HWCSettings.SerialPort);
            }
            public static HWCValues ReadValues()
            {
                HWCValues OHWCValues = new HWCValues();
                string filspath = SettingsPath.HWCValues;
                if (System.IO.File.Exists(filspath))
                {
                    OHWCValues = GenericXmlSerializer<HWCValues>.Deserialize(filspath);
                }
                return OHWCValues;
            }
            public static bool WriteValues(HWCValues oHWCValues)
            {
                GenericXmlSerializer<HWCValues>.Serialize(oHWCValues, SettingsPath.HWCValues);
                return true;
            }
        }

        public class HWCValues
        {
            private int _SettingsTriggerDelay = 100;

            public int SettingsTriggerDelay
            {
                get { return _SettingsTriggerDelay; }
                set { _SettingsTriggerDelay = value; }
            }

            private int _SettingsPulseDelay = 10;

            public int SettingsPulseDelay
            {
                get { return _SettingsPulseDelay; }
                set { _SettingsPulseDelay = value; }
            }

            private int _BuzzerTime = 100;

            public int BuzzerTime
            {
                get { return _BuzzerTime; }
                set { _BuzzerTime = value; }
            }

            private int _CamTriggerDelay = 0;

            public int CamTriggerDelay
            {
                get { return _CamTriggerDelay; }
                set { _CamTriggerDelay = value; }
            }
            private int _CamPulseDelay = 10;

            public int CamPulseDelay
            {
                get { return _CamPulseDelay; }
                set { _CamPulseDelay = value; }
            }
            private int _IllumLightMode = 0;

            public int IllumLightMode
            {
                get { return _IllumLightMode; }
                set { _IllumLightMode = value; }
            }
            private int _BuzzerONOFF = 1;

            public int BuzzerONOFF
            {
                get { return _BuzzerONOFF; }
                set { _BuzzerONOFF = value; }
            }
            private int _ConveyorDirection = 1;

            public int ConveyorDirection
            {
                get { return _ConveyorDirection; }
                set { _ConveyorDirection = value; }
            }
            private int _ErrorAction = 1;

            public int ErrorAction
            {
                get { return _ErrorAction; }
                set { _ErrorAction = value; }
            }

            private int _IgnoreETSignal = 1;

            public int IgnoreETSignal
            {
                get { return _IgnoreETSignal; }
                set { _IgnoreETSignal = value; }
            }
        }

        public class DataDumpFile
        {
            public static List<string> ReadFromFile(string Name)
            {
                string FileName = string.Empty;
                if (Name.Contains(".psv")==false)
                    FileName = SettingsPath.DumpDir + "\\" + Name + ".psv";
                else
                    FileName = SettingsPath.DumpDir + "\\" + Name;

                List<string> lstStr = new List<string>();
                try
                {
                    // Open the file to read from. 

                    using (StreamReader sr = File.OpenText(FileName))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            lstStr.Add(s);
                        }
                    }
                    File.Delete(FileName);
                }
                catch (Exception ex)
                {
                    Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
                }
                return lstStr;
            }

            public static void WriteToFile(string Name, string Data)
            {
                string FileName = string.Empty;
                if (Name.Contains(".psv") == false)
                    FileName = SettingsPath.DumpDir + "\\" + Name + ".psv";
                else
                    FileName = SettingsPath.DumpDir + "\\" + Name;
                try
                {
                    if (!File.Exists(FileName))
                    {
                        //Create a file
                        using (StreamWriter sw = File.CreateText(FileName))
                        {
                            sw.WriteLine(Data);
                        }
                    }
                    else
                    {
                        // This text is always added,
                        // if it is not deleted. 
                        using (StreamWriter sw = File.AppendText(FileName))
                        {
                            sw.WriteLine(Data);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
                }
            }

            public static List<string> GetFailedJobs()
            {
                List<string> lstStr = new List<string>();
                try
                {
                    if (Directory.Exists(SettingsPath.DumpDir) == true)
                    {
                        DirectoryInfo dr = new DirectoryInfo(SettingsPath.DumpDir);
                        foreach (FileInfo item in dr.GetFiles("*.psv"))
                        {
                            lstStr.Add(item.Name);
                        }
                    }                
                }
                catch (Exception ex)
                {
                    Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
                }             
                return lstStr;
            }
        }
    }
}
