using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WIMARTS.HWController
{
    public delegate void UpdateData(string comname, string flow, string value, string cmdDdetails, long Start, long End);
    public delegate void LogData(string comname, string value, bool isHex);

    public partial class Watch : Form
    {
        public delegate void SendDataReqHandler(string data);
        public SendDataReqHandler OnSendDataReq;

        public Watch()
        {
            InitializeComponent();
            DG_View.AutoResizeColumns();
        }

        private Queue<DataNode> iNodeQueueUpdateCMDData = new Queue<DataNode>();
        EventWaitHandle UpdateCMDDataHandle = new AutoResetEvent(false);
        private Thread UpdateCMDDataThread = null;

        public void UpdatePerform(string comname, string flow, string value, string cmdDdetails, long Start, long End)
        {
            DataNode dn = new DataNode(comname, flow, value, cmdDdetails, Start, End);
            iNodeQueueUpdateCMDData.Enqueue(dn);
            if (UpdateCMDDataThread == null)
            {
                UpdateCMDDataThread = new Thread(new ParameterizedThreadStart(UpdateCMDDataTh));
                UpdateCMDDataThread.Start();
            }
            UpdateCMDDataHandle.Set();
        }
        void UpdateCMDDataTh(object node)
        {
            while (true)
            {
                UpdateCMDDataHandle.WaitOne();
                if (iNodeQueueUpdateCMDData.Count > 0)
                {
                    try
                    {
                        DataNode dn = iNodeQueueUpdateCMDData.Dequeue();
                        lock (this)
                        {
                            UpdatePerformUI(dn.comname, dn.flow, dn.value, dn.cmdDdetails, dn.Start, dn.End);
                        }
                    }
                    catch (Exception ex)
                    {
                        string mes = ex.Message;
                    }
                    if (iNodeQueueUpdateCMDData.Count > 0)
                        UpdateCMDDataHandle.Set();
                }
            }
        }

        public void UpdatePerformUI(string comname, string flow, string value, string cmdDdetails, long Start, long End)
        {
            try
            {
                if (DG_View.InvokeRequired == true)
                {
                    UpdateData d = new UpdateData(UpdatePerformUI);
                    this.Invoke(d, new object[] { comname, flow, value, cmdDdetails, Start, End });

                }
                else
                {
                    if (DG_View.ColumnCount > 0)
                    {
                        if (DG_View.Rows.Count > 100)
                            DG_View.Rows.Clear();
                        DG_View.Rows.Add(DG_View.Rows.Count.ToString(), comname, flow, value, cmdDdetails, Start, End);
                        DG_View.CurrentCell = DG_View[0, DG_View.Rows.Count - 1];
                    }
                }
            }
            catch
            {

            }
        }

        public void Log(string port, string txt, bool isHex)
        {
            if (TXT_SerialLog.InvokeRequired == true)
            {
                LogData d = new LogData(Log);
                this.Invoke(d, new object[] { port, txt, isHex });
            }
            else
            {
                string tmp = txt;
                if (isHex)
                {
                    string s = "";
                    foreach (char ch in txt)
                    {
                        int ich = ch;
                        s += (string.Format("{0:x2}", System.Convert.ToString(ich)) + " ");
                    }
                    tmp = s;
                }
                TXT_SerialLog.Text += (txt + "\r\n");
                TXT_Hex.Text += (tmp + "\r\n");
            }
        }
        private void BTN_Clear_Click(object sender, EventArgs e)
        {
            DG_View.Rows.Clear();
        }
        private void BTN_Save_Click(object sender, EventArgs e)
        {
            try
            {
                string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                StringBuilder sbCSV = new StringBuilder();
                int intColCount = DG_View.Columns.Count;
                for (int row = 0; row < DG_View.Rows.Count; row++)
                {
                    for (int x = 0; x < intColCount; x++)
                    {
                        //dr.Cells[x].Value
                        //sbCSV.Append(dr.Cells[x].ToString());
                        string cellData = (string)DG_View[x, row].Value;
                        sbCSV.Append(cellData);
                        if ((x + 1) != intColCount)
                        {
                            sbCSV.Append(",\t");
                        }
                    }
                    sbCSV.Append("\r\n");
                }
                using (StreamWriter sw = new StreamWriter(DesktopPath + @"\ZimbaWatch.csv"))
                {
                    sw.Write(sbCSV.ToString());
                }
            }
            catch
            {
            }
        }

        private void BTN_Send_Click(object sender, EventArgs e)
        {
            Button btnClicked = (Button)sender;
            if (OnSendDataReq != null)
            {
                string data2Send = "";
                if (btnClicked.Name == BTN_Send1.Name)
                    data2Send = TXT_CMD2Send1.Text.Trim();
                else if (btnClicked.Name == BTN_Send2.Name)
                    data2Send = TXT_CMD2Send2.Text.Trim();
                else
                    data2Send = TXT_CMD2Send3.Text.Trim();

                OnSendDataReq(data2Send);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TXT_SerialLog.Text = TXT_Hex.Text = "";
        }
    }
    public class DataNode
    {
        internal string comname;
        internal string flow;
        internal string value;
        internal string cmdDdetails;
        internal long Start;
        internal long End;
        public DataNode(string oComname, string oFlow, string oValue, string ocmdDdetails, long oStart, long oEnd)
        {
            this.comname = oComname;
            this.flow = oFlow;
            this.value = oValue;
            this.cmdDdetails = ocmdDdetails;
            this.Start = oStart;
            this.End = oEnd;
        }
    }
}
