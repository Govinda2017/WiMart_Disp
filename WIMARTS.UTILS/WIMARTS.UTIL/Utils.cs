using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Reflection; 
using System.Windows.Forms;

namespace WIMARTS.UTIL
{
    public class VDKeyValue
    {
        private string _key;

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
        private string _Value = "";

        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
    }
    public class Utils
    {
      
        public static long GetTimeDiff_MS(Stopwatch sw)
        {
            long milliseconds = (long)((double)sw.ElapsedTicks / ((double)Stopwatch.Frequency / (double)(1000L)));
            return milliseconds;
        }
        public static long GetTimeDiff_US(Stopwatch sw)
        {
            long microseconds = (long)((double)sw.ElapsedTicks / ((double)Stopwatch.Frequency / (double)(1000L * 1000L)));
            return microseconds;
        }
        public static long GetTimeDiff_NS(Stopwatch sw)
        {
            long nanoseconds = (long)((double)sw.ElapsedTicks / ((double)Stopwatch.Frequency / (double)(1000L * 1000L * 1000L)));
            return nanoseconds;
        }

        public static bool IsProcessOpen(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    return true;
                }
            }
            return false;
        }
        public static void ProcessStart(string name)
        {
            Process proc2Start = new Process();

            proc2Start.StartInfo.FileName = name; 
            proc2Start.Start();
        }
        public static void ProcessEnd(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    clsProcess.Kill();
                }
            }
        }
        public static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);

            //Loop through the running processes in with the same name 
            foreach (Process process in processes)
            {
                //Ignore the current process 
                if (process.Id != current.Id)
                {
                    //Make sure that the process is running from the exe file. 
                    //if (Assembly.GetExecutingAssembly().Location.
                    //     Replace("/", "\\") == current.MainModule.FileName)
                    //{
                    //    Trace.TraceInformation("{0} {1}", Assembly.GetExecutingAssembly().Location, current.MainModule.FileName);
                    //    //Return the other process instance.  
                    //    return process;
                    //}
                    return process;
                }
            }
            //No other instance was found, return null.  
            return null;
        }

        public static void CursorWaitSet(Form ob)
        { 
            ob.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ob.UseWaitCursor = true;
        }
        public static void CursorReset(Form ob)
        {
            ob.Cursor = System.Windows.Forms.Cursors.Default;
            ob.UseWaitCursor = false;
        } 
       
    }
    
    public class FooUtils
    {
        static bool logEnabled = true;
        long funcStartTime = 0;
        Stopwatch swFoo;
        public void FooStart(string fooName)
        {
            if (logEnabled == false)
                return;
            swFoo = new Stopwatch();
            swFoo.Start();
            funcStartTime = DateTime.Now.Ticks;
            Trace.TraceInformation("{0} {1} Start @ {2} ", DateTime.Now.ToString(), fooName, funcStartTime);
        }
        public void FooEnd(string fooName)
        {
            if (logEnabled == false)
                return;
            swFoo.Stop();
            long funcEndTime = DateTime.Now.Ticks;
            long timeDiff = Utils.GetTimeDiff_MS(swFoo);
            Trace.TraceInformation("{0} {1} End   @ {2} Diff {3}", DateTime.Now.ToString(), fooName, funcEndTime, timeDiff);
        }
    } 
    
}

