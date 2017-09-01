using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Reflection; 
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using WIMARTS.UTIL;
using System.Text;
using System.Collections;

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


namespace rSys
{
    public class CommonProcess
    {
        public static void ExitApplication()
        {
            try
            {
                Application.Exit();
                Environment.Exit(0);
                // HERE ALL THREADS STARTED MUST BE END. PROC.KILL is BAD PRACTICESSS
                System.Diagnostics.Process proc = System.Diagnostics.Process.GetCurrentProcess();
                proc.Kill();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError("{0}, Critical Exception @ {1}, {2}, {3}", DateTime.Now.ToString(), ex.Source, ex.Message, ex.StackTrace);
            }
            //this.Close();
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
                    if (Assembly.GetExecutingAssembly().Location.
                         Replace("/", "\\") == current.MainModule.FileName)
                    {
                        Trace.TraceInformation("{0} {1}", Assembly.GetExecutingAssembly().Location, current.MainModule.FileName);
                        //Return the other process instance.  
                        return process;
                    }
                }
            }
            //No other instance was found, return null.  
            return null;
        }

    }
    public class CommonDATA
    {
        /// <summary>
        /// It will compare two stringe,If strings are similar then it return true;Both string arguments should not null..
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool compare(string str1, string str2)
        {
            bool hassimilar = false;

            if (str1 != null && str2 != null)
            {
                hassimilar = (String.Compare(str1.Trim(), str2.Trim(), StringComparison.CurrentCultureIgnoreCase) == 0);
            }

            return hassimilar;
        }

        public static bool IsValidString(string InputStringtoValidate)
        {
            // The RegexOptions are optional to this call, we will go into more detail about them below.
            string pattern = @"((?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*\W).{8,})";
            Match matchValidStr = Regex.Match(InputStringtoValidate, pattern);
            return matchValidStr.Success;
        }
        public static bool IsValidString(string InputStringtoValidate, bool check4Number, bool check4CapLetter, bool check4SmallLetter, bool check4Symbol, int lengthRequired, int maxLength)
        {
            // The RegexOptions are optional to this call, we will go into more detail about them below.
            string pattern = @"(";

            if (check4Number == true)
                pattern += @"(?=.*\d)";

            if (check4CapLetter == true)
                pattern += @"(?=.*[A-Z])";

            if (check4SmallLetter == true)
                pattern += @"(?=.*[a-z])";

            if (check4Symbol == true)
                pattern += @"(?=.*\W)";

            if (lengthRequired >= 0 && maxLength < 0)
                pattern += @".{" + lengthRequired + ",}";       //@".{8,}"
            else if (lengthRequired >= 0 && maxLength >= 0)
                pattern += @".{" + lengthRequired + "," + maxLength + "}";       //@".{8,10}";

            pattern += @")";

            Match matchValidStr = Regex.Match(InputStringtoValidate, pattern);
            return matchValidStr.Success;
        }

        public static bool IsNumeric(object ValueToCheck)
        {
            double Dummy = new double();
            string InputValue = Convert.ToString(ValueToCheck);
            bool Numeric = double.TryParse(InputValue, System.Globalization.NumberStyles.Any, null, out Dummy);
            return Numeric;
        }
        public static bool IsNumeric(object ValueToCheck, out double Number)
        {
            double Dummy;
            string InputValue = Convert.ToString(ValueToCheck);
            bool Numeric = double.TryParse(InputValue, System.Globalization.NumberStyles.Any, null, out Dummy);
            Number = Dummy;
            return Numeric;
        }

        public static string GetValidFileName(string FileName, string replaceWith)
        {
            Regex illegalInFileName = new Regex(string.Format("[{0}]", Regex.Escape(new string(Path.GetInvalidFileNameChars()))), RegexOptions.Compiled);
            FileName = illegalInFileName.Replace(FileName, replaceWith);

            return FileName;
        }

    }
    public class CommonUI
    {
        public static System.Windows.Forms.ToolTip toolTipCCS = new System.Windows.Forms.ToolTip();

        /// <summary>
        /// This Method sets the Cursor to WAIT 
        /// </summary>
        /// <param name="ob"></param>
        /// <returns>Current Cursor before setting to wait</returns>
        public static Cursor CursorWaitSet(Form ob)
        {
            Cursor curCursor = ob.Cursor;
            ob.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ob.UseWaitCursor = true;
            return curCursor;
        }
        public static Cursor CursorWaitSet(Form ob, bool refreshImdtly)
        {
            Cursor curCursor = ob.Cursor;
            ob.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            ob.UseWaitCursor = true;
            if (refreshImdtly == true)
                Application.DoEvents();
            return curCursor;
        }
        public static Cursor CursorSet(Form ob, Cursor cursor2Set, bool refreshImdtly)
        {
            Cursor curCursor = ob.Cursor;
            ob.Cursor = cursor2Set;
            if (refreshImdtly == true)
                Application.DoEvents();
            return curCursor;
        }

        public static void CursorReset(Form ob)
        {
            ob.Cursor = System.Windows.Forms.Cursors.Default;
            ob.UseWaitCursor = false;
        }

        public static byte[] ReadBitmap2ByteArray(Image bp)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                bp.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                return stream.ToArray();
            }
            catch (Exception)
            {

            }
            return null;
        }
        public static Image ReadByteArray2Bitmap(byte[] byteArrayIn)
        {
            try
            {
                MemoryStream ms = new MemoryStream(byteArrayIn, 0, byteArrayIn.Length);
                ms.Write(byteArrayIn, 0, byteArrayIn.Length);
                return Image.FromStream(ms, true);
            }
            catch (Exception)
            {
            }
            return null;
        }
        public static Image ScaleImage(string fileLocation, int maxWidth, int maxHeight)
        {
            Image image = new Bitmap(fileLocation);
            return ScaleImage(image, maxWidth, maxHeight);
        }
        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            double ratioImg = (double)image.Width / (double)image.Height;

            //var imgDrawW = maxWidth;
            //var imgDrawH = (int)((double)imgDrawW / ratioImg);

            var imgDrawH = maxHeight;
            var imgDrawW = (int)((double)imgDrawH * ratioImg);

            var newImage = new Bitmap(imgDrawW, imgDrawH);
            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, imgDrawW, imgDrawH);

            return newImage;
        }
        public Image ResizeImage(Image img, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage((Image)b))
            {
                g.DrawImage(img, 0, 0, width, height);
            }
            return (Image)b;
        }

        //delegate void ShowProgressIndicator(Form frm,bool HasShow);
        //delegate void UpdateProgressPercentage(Form frm, int pvalue,string text);       
        //static PCH.CONTROLS.ProgressIndicator pIndicator=null;

        //public static void testProgressBar(Form frm, bool HasShow)
        //{
        //    if (pIndicator != null && frm.Controls.ContainsKey(pIndicator.Name))
        //    {
        //        if (HasShow == false)
        //        {
        //            pIndicator.Stop();
        //            pIndicator.Visible = false;
        //            //frm.Enabled = true;
        //            //frm.Controls.Remove(pIndicator);
        //            //pIndicator = null;
        //        }
        //    }
        //    else
        //    {
        //        if (HasShow == true)
        //        {
        //            if (pIndicator == null)
        //            {
        //                pIndicator = new PCH.CONTROLS.ProgressIndicator();
        //                pIndicator.Name = "pIndicator1";
        //                pIndicator.BackColor = Color.Transparent;
        //                pIndicator.CircleColor = Color.BlueViolet;
        //                pIndicator.AnimationSpeed = 40;
        //                pIndicator.CircleSize = 0.5f;
        //                //pIndicator.Control Size = 231;
        //                pIndicator.NumberOfCircles = 12;
        //                pIndicator.NumberOfVisibleCircles = 10;
        //                pIndicator.Visible = HasShow;
        //                pIndicator.Size = new Size(200, 200);
        //                pIndicator.Location = new Point(frm.Width / 2 - pIndicator.Width / 2, frm.Height / 2 - pIndicator.Height / 2);
        //                frm.Controls.Add(pIndicator);
        //            }
        //            pIndicator.Visible = true;
        //            pIndicator.BringToFront();
        //            pIndicator.Start();
        //            //frm.Enabled = false;
        //        }
        //    }
        //}
        //public static void ProgressBar(Form frm, bool HasShow)
        //{
        //    //if (frm.InvokeRequired)
        //    //{
        //    ShowProgressIndicator sctrlDel = new ShowProgressIndicator(testProgressBar);
        //    frm.Invoke(sctrlDel, new object[] { frm, HasShow });
        //    //}
        //    //else
        //    //{

        //    //}
        //} 
        //public static void ProgressBarUpdatePercentage(Form frm, int pvalue, string text)
        //{
        //    if (pIndicator.InvokeRequired)
        //    {
        //        UpdateProgressPercentage sctrlDel = new UpdateProgressPercentage(ProgressBarUpdatePercentage);
        //        frm.Invoke(sctrlDel, new object[] { frm, pvalue, text });
        //    }
        //    else
        //    {
        //        if (pIndicator != null)
        //        {
        //            if (pIndicator.ShowPercentage == false)
        //                pIndicator.ShowPercentage = true;

        //            if (string.IsNullOrEmpty(text)==false && pIndicator.ShowText == false)
        //                pIndicator.ShowText = true;

        //            pIndicator.Percentage = pvalue;
        //            pIndicator.Text = text;
        //        }
        //    }
        //} 

        public static void ControlVisibleInTh(Control ctrl, bool visible)
        {
            if (ctrl.InvokeRequired == true)
            {
                ctrl.Invoke(new MethodInvoker(delegate { ControlVisibleInTh(ctrl, visible); }));
            }
            else
            {
                ctrl.Visible = visible;
            }
        }
        public static void ControlEnabledInTh(Control ctrl, bool enabled)
        {
            if (ctrl.InvokeRequired == true)
            {
                ctrl.Invoke(new MethodInvoker(delegate { ControlEnabledInTh(ctrl, enabled); }));
            }
            else
            {
                ctrl.Enabled = enabled;
            }
        }
        public static void ControlSetFocusInTh(Control ctrl)
        {
            if (ctrl.InvokeRequired == true)
            {
                ctrl.Invoke(new MethodInvoker(delegate { ControlSetFocusInTh(ctrl); }));
            }
            else
            {
                ctrl.Focus();
            }
        }

        public static void ControlTextInTh(Control ctrl, string text)
        {
            if (ctrl.InvokeRequired == true)
            {
                ctrl.Invoke(new MethodInvoker(delegate { ControlTextInTh(ctrl, text); }));
            }
            else
            {
                ctrl.Text = text;
            }
        }
        public static void ControlValueInTh(NumericUpDown ctrl, decimal value)
        {
            if (ctrl.InvokeRequired == true)
            {
                ctrl.Invoke(new MethodInvoker(delegate { ControlValueInTh(ctrl, value); }));
            }
            else
            {
                ctrl.Value = value;
            }
        }

        public static void CmbLoadEnum(ComboBox cmb2Load, Type eNumType)
        {
            cmb2Load.Items.Clear();

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            foreach (int enumValue in Enum.GetValues(eNumType))
            {
                dictionary.Add(Enum.GetName(eNumType, enumValue), enumValue);
            }
            cmb2Load.DisplayMember = "Key";
            cmb2Load.ValueMember = "Value";
            cmb2Load.DataSource = new BindingSource(dictionary, null);

            if (cmb2Load.Items.Count > 0)
                cmb2Load.SelectedIndex = 0;
        }
        public static void CmbLoadEnum(ComboBox cmb2Load, Dictionary<string, int> dictionary)
        {
            try
            {
                cmb2Load.Items.Clear();

                cmb2Load.DisplayMember = "Key";
                cmb2Load.ValueMember = "Value";

                cmb2Load.DataSource = new BindingSource(dictionary, null);

                if (cmb2Load.Items.Count > 0)
                    cmb2Load.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void SetComboBoxIndex(ComboBox ctrl, int Index)
        {
            if (ctrl.InvokeRequired == true)
            {
                ctrl.Invoke(new MethodInvoker(delegate { SetComboBoxIndex(ctrl, Index); }));
            }
            else
            {
                ctrl.SelectedIndex = Index;
            }

        }
        public static void SetComboBoxValue(ComboBox ctrl, int Value)
        {
            if (ctrl.InvokeRequired == true)
            {
                ctrl.Invoke(new MethodInvoker(delegate { SetComboBoxValue(ctrl, Value); }));
            }
            else
            {
                ctrl.SelectedValue = Value;
            }

        }
        public static int GetComboBoxIndex(ComboBox ctrl)
        {
            if (ctrl.InvokeRequired == true)
            {
                ctrl.Invoke(new MethodInvoker(delegate { GetComboBoxIndex(ctrl); }));
            }
            else
            {
                return ctrl.SelectedIndex;
            }
            return 0;
        }

        public static void ControlSetColorInTh(Control ctrl, bool IsForeColor, Color oColor)
        {
            if (ctrl.InvokeRequired == true)
            {
                ctrl.Invoke(new MethodInvoker(delegate { ControlSetColorInTh(ctrl, IsForeColor, oColor); }));
            }
            else
            {
                if (IsForeColor == true)
                    ctrl.ForeColor = oColor;
                else
                    ctrl.BackColor = oColor;
            }
        }
        public static void TextBoxAppendInTh(TextBox ctrl, int MaxLines, string text)
        {
            if (ctrl.InvokeRequired == true)
            {
                ctrl.Invoke(new MethodInvoker(delegate { TextBoxAppendInTh(ctrl, MaxLines, text); }));
            }
            else
            {
                if (MaxLines > 0 && ctrl.Lines.Length > MaxLines)
                {
                    string data = ctrl.Text;

                    int startpos = data.IndexOf(Environment.NewLine);
                    if (startpos > 0)
                        data = data.Substring(startpos + Environment.NewLine.Length);
                    ctrl.Text = data;
                }
                ctrl.AppendText(text + Environment.NewLine);
            }
        }

        public static void SetTooltip(Control ctrl, string toolTipMsg)
        {
            if (ctrl.InvokeRequired == true)
            {
                ctrl.Invoke(new MethodInvoker(delegate { SetTooltip(ctrl, toolTipMsg); }));
            }
            else
            {
                toolTipCCS.SetToolTip(ctrl, toolTipMsg);
            }
        }

        public static void SetTooltip(ToolTip toolTipCtrl, Control ctrl, string toolTipMsg)
        {
            if (ctrl.InvokeRequired == true)
            {
                ctrl.Invoke(new MethodInvoker(delegate { SetTooltip(toolTipCtrl, ctrl, toolTipMsg); }));
            }
            else
            {
                toolTipCtrl.SetToolTip(ctrl, toolTipMsg);
            }
        }

        public static void UpdateStatusBar(string msg)
        {
            try
            {
                //if (statusStrip1.InvokeRequired == true)
                //{
                //    statusStrip1.Invoke(new MethodInvoker(delegate { UpdateStatusBar(msg); }));
                //}
                //else
                //{
                //    toolStripStatusLabel1.Text = msg;
                //    Application.DoEvents();
                //}
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
            }
        }
        public static bool UpdateErrorIndicator(Control ctrl, int value)
        {
            bool hasError = (value == 0 ? false : true);
            //ctrl.BackColor = (value == 0 ? Color.White : Color.White);
            //ctrl.ForeColor = (value == 0 ? Color.Red : Color.White);
            ctrl.Visible = hasError;

            return hasError;
        }

        public static void ChangeOrientation(SplitContainer scMain, SplitContainer scChild)
        {
            if (scMain.Orientation == Orientation.Horizontal)
            {
                scMain.Orientation = Orientation.Vertical;
                scChild.Orientation = Orientation.Horizontal;
                scChild.SplitterDistance = 400;
            }
            else
            {
                scMain.Orientation = Orientation.Horizontal;
                scChild.Orientation = Orientation.Vertical;
                scChild.SplitterDistance = 400;
            }
        }

        //public static string GetControlTextInTh(Control ctrl)
        //{
        //    if (ctrl.InvokeRequired == true)
        //    {
        //        ctrl.Invoke(new MethodInvoker(delegate { GetControlTextInTh(ctrl); }));
        //    }
        //    else
        //    {
        //        return ctrl.Text;
        //    }
        //    return string.Empty;
        //}

        public static void BackupFilePostSize(string filePath, long fileSize)
        {
            if (File.Exists(filePath) == true)
            {
                try
                {
                    FileInfo f = new FileInfo(filePath);
                    long s1 = f.Length;
                    if (s1 > fileSize) //1024 * 1024)
                    {
                        string uniqTS = DateTime.Now.ToString("yyyy-MM-dd_HH-mm");

                        string move2File = Path.GetDirectoryName(filePath) + "\\" + Path.GetFileNameWithoutExtension(filePath) + "_" + uniqTS + Path.GetExtension(filePath);
                        System.IO.File.Move(filePath, move2File);// ".csv");
                    }
                }
                catch { }
            }
        }

        //public static void SetupLogsSystem(System.Diagnostics.TraceListenerCollection traceListenerCollection)
        //{
        //    if (System.Diagnostics.Trace.Listeners.Count > 0 && System.Diagnostics.Trace.Listeners[0] is System.Diagnostics.TextWriterTraceListener)
        //    {
        //        if (Directory.Exists(SettingsPath.LogsDirPath) == false)
        //        {
        //            Directory.CreateDirectory(SettingsPath.LogsDirPath);
        //        }

        //        string LogFilePath = SettingsPath.LogsDirPath + SettingsPath.LogFile;
        //        CommonUI.BackupFilePostSize(LogFilePath, 1024 * 1024);

        //        ///Remove default log file path and added new in application folder
        //        while (System.Diagnostics.Trace.Listeners.Count > 0)
        //            System.Diagnostics.Trace.Listeners.RemoveAt(0);
        //        System.Diagnostics.DefaultTraceListener df = new System.Diagnostics.DefaultTraceListener();
        //        df.LogFileName = LogFilePath;
        //        System.Diagnostics.Trace.Listeners.Add(df);
        //    }
        //}

        public static void FLPanelObjectAllignment(FlowLayoutPanel flpCtrlHolder, Control FirstControl, Control LastControl)
        {
            int gap = (flpCtrlHolder.Width - (LastControl.Right - FirstControl.Left)) / 2;
            Padding pad = new System.Windows.Forms.Padding(gap, flpCtrlHolder.Padding.Top, flpCtrlHolder.Padding.Right, flpCtrlHolder.Padding.Bottom);
            flpCtrlHolder.Padding = pad;
        }

        public static void MoveUp(ListBox listBox)
        {
            MoveItem(listBox, -1);
        }
        public static void MoveDown(ListBox listBox)
        {
            MoveItem(listBox, 1);
        }
        private static void MoveItem(ListBox listBox, int direction)
        {
            // Checking selected item
            if (listBox.SelectedItem == null || listBox.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = listBox.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= listBox.Items.Count)
                return; // Index out of range - nothing to do

            object selected = listBox.SelectedItem;

            // Removing removable element
            listBox.Items.Remove(selected);
            // Insert it in new position
            listBox.Items.Insert(newIndex, selected);
            // Restore selection
            listBox.SetSelected(newIndex, true);
        }
    }

    public static class DataConvert
    {
        public static byte[] IntegerBinaryConvertM0(int IntValue, int BinaryLen)
        {
            int pos = 0;

            if (BinaryLen <= 0)
                BinaryLen = 8;
            byte remainder;
            byte[] result = new byte[BinaryLen];
            while (IntValue > 0)
            {
                remainder = (byte)(IntValue % 2);
                IntValue /= 2;
                result[pos] = remainder;
                pos++;
            }
            return result;
        }
        public static string IntegerBinaryConvertM1(int IntValue, int BinaryLen)
        {
            int remainder;
            string result = string.Empty;
            while (IntValue > 0)
            {
                remainder = IntValue % 2;
                IntValue /= 2;
                result = remainder.ToString() + result;
            }
            result = result.PadLeft(BinaryLen, '0');
            return result;
        }
        public static string IntegerBinaryConvertM2(int IntValue, int BinaryLen)
        {
            return (BinaryLen > 1 ? IntegerBinaryConvertM2(IntValue >> 1, BinaryLen - 1) : null) + "01"[IntValue & 1];
        }
        public static string IntegerBinaryConvertM3(int IntValue, int BinaryLen)
        {
            string result = Convert.ToString(IntValue, 2);
            result = result.PadLeft(BinaryLen, '0');
            return result;
        }

        public static string HexAsciiConvert(string hex)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= hex.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hex.Substring(i, 2),
                    System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }

        public static bool HexIntegerConvert(string hexValue, ref int IntVal)
        {
            try
            {
                int intValue = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);

                IntVal = intValue;
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string IntegerHexConvert(int IntValue, int hexValueLength)
        {
            string format = "X" + hexValueLength;
            string hex = IntValue.ToString(format);
            return hex;
        }

        public static string DisplaybleHexValues(string strData)
        {
            StringBuilder sBuffer = new StringBuilder();
            for (int i = 0; i < strData.Length; i++)
            {
                sBuffer.Append(" 0x" + Convert.ToInt32(strData[i]).ToString("x").ToUpper());
            }
            string hex = sBuffer.ToString();

            //hex = strData.Select(c => ((int)c).ToString("X")).Aggregate((a, s) => a + s);
            //hex = string.Join(string.Empty, strData.Select(c => ((int)c).ToString("X")).ToArray());

            return hex;
        }
        public static string DisplaybleAsciiValues(string strData)
        {
            StringBuilder sBuffer = new StringBuilder();
            for (int i = 0; i < strData.Length; i++)
            {
                sBuffer.Append(" " + Convert.ToInt32(strData[i]).ToString());
            }
            string hex = sBuffer.ToString();

            //hex = strData.Select(c => ((int)c).ToString("X")).Aggregate((a, s) => a + s);
            //hex = string.Join(string.Empty, strData.Select(c => ((int)c).ToString("X")).ToArray());

            return hex;
        }
        public static string DisplaybleTextValues(string strData)
        {
            StringBuilder sBuffer = new StringBuilder();
            for (int i = 0; i < strData.Length; i++)
            {
                if (strData[i] != '\0')
                    sBuffer.Append((strData[i]).ToString());
            }
            string buff = sBuffer.ToString();

            //hex = strData.Select(c => ((int)c).ToString("X")).Aggregate((a, s) => a + s);
            //hex = string.Join(string.Empty, strData.Select(c => ((int)c).ToString("X")).ToArray());

            return buff;
        }
        public static string TermMode2RawData(string msg, out int length)
        {
            //msg = msg.Replace(" ", "");
            string rawBuffer = string.Empty;
            length = 0;
            for (int i = 0; i < msg.Length; i++)
            {
                if (msg[i] == '$')//Hex Byte
                {
                    i++;
                    rawBuffer += HexAsciiConvert(msg.Substring(i, 2));
                    length++;
                    i++;
                }
                else
                {
                    rawBuffer += msg[i];
                    length++;
                }
            }
            return rawBuffer;
        }

        public static int IntegerWithBitValue(int BitPosition, bool BitValue)
        {
            int ParamValue = 0;

            if (BitValue == true)
            {
                int[] intArray = new int[16];
                var bitArray = new BitArray(intArray);
                bitArray.Set(BitPosition, true);
                bitArray.CopyTo(intArray, 0);
                ParamValue = intArray[0];
            }
            else
                ParamValue = 0;

            return ParamValue;
        }
    }
}