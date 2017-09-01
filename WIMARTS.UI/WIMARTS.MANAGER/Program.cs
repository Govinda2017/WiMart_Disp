using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace WIMARTS.MANAGER
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Load Settings
            UTIL.SystemIntegrity.Globals.CreateDefaultSettings();

            //Remove default log file path and added nnew in application folder
            while (System.Diagnostics.Trace.Listeners.Count > 0)
                System.Diagnostics.Trace.Listeners.RemoveAt(0);
            DefaultTraceListener df = new DefaultTraceListener();
            df.LogFileName = UTIL.SettingsPath.LogDir + "\\logs_App.csv";
            System.Diagnostics.Trace.Listeners.Add(df);

            Trace.TraceInformation("");
            Trace.TraceInformation("{0}, ......APPLICATION STARTED......", DateTime.Now);
            Trace.TraceInformation("");


            DB.Connection.DbConnectionConfig.LoadConection();
            if (DB.Connection.DbConnectionConfig.CheckSQLDB() == true)
            {
                Application.Run(new FrmMDI());
            }

        }     
    }
}
