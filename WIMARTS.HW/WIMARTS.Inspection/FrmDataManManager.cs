using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cognex.DataMan.SDK;
using System.Diagnostics;
using Cognex.DataMan.SDK.Events;

namespace Red.CamInterface
{
    public partial class FrmDataManManager : Form
    {
        #region Creating DataMan objects that provide SDK functionalities

        /// <summary>
        /// Manages discovery of DataMan systems.
        /// </summary>
        Cognex.DataMan.SDK.DataManSystemManager myManager = null;

        /// <summary>
        /// Provides functionalities needed to work with DataMan devices.
        /// </summary>
        Cognex.DataMan.SDK.DataManSystem mySystem = null;

        /// <summary>
        /// List of discovered DataMan systems.
        /// </summary>
        List<DataManSystem> systemList = new List<DataManSystem>();

        #endregion

        public FrmDataManManager()
        {
            InitializeComponent();
            SortingProirityList();
            //Due to the fact that device discovery uses an asynchronous protocol the user has to
            //subscribe to the SystemDiscovered event that gets fired when a new device shows up.
            //Then one can register it in a list, show its address in a combobox, etc.
            //See: myManager_NetworkDeviceAppeared()
            myManager = new DataManSystemManager();
            myManager.SystemDiscovered += new DataManSystemManager.SystemDiscoveredEventHandler(myManager_NetworkDeviceAppeared);

            //Setting some controls
            //commandComboBox.SelectedIndex = 0;
            //heartbeatIntervalComboBox.SelectedIndex = 0;
        }

        #region CommonButtonFun
        public void LoadInitialSettings()
        {
            PNL_ConnectToReader.Visible = false;
            Pnl_ResultDisplay.Visible = false;
            PNL_LightCameraSetting.Visible = false;
            Pnl_SymbologySetting.Visible = false;
            PNL_SystemSetting.Visible = false;
            //  Pnl_Botton.Enabled = false;
        }
        private void Btn_ResultDisplay_Click(object sender, EventArgs e)
        {
            LoadInitialSettings();
            Pnl_ResultDisplay.Visible = true;
        }
        private void BTN_ConnectToReader_Click(object sender, EventArgs e)
        {
            LoadInitialSettings();
            PNL_ConnectToReader.Visible = true;
        }
        private void Btn_LightAndCameraSetting_Click(object sender, EventArgs e)
        {
            LoadInitialSettings();
            PNL_LightCameraSetting.Visible = true;
        }
        private void Btn_SymbologySetting_Click(object sender, EventArgs e)
        {
            LoadInitialSettings();
            Pnl_SymbologySetting.Visible = true;
        }
        private void Btn_SystemSettings_Click(object sender, EventArgs e)
        {
            LoadInitialSettings();
            PNL_SystemSetting.Visible = true;
        }
        private void BTn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion EndCommonButtonFun

        #region ConnectToReader

        /// <summary>
        /// Starts scanning serial ports and the network for DataMan devices.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detectSystemsButton_Click(object sender, EventArgs e)
        {
            systemListBox.Items.Clear();
            systemList.Clear();

            //Telling the manager to start device discovery
            myManager.Refresh();
        }
        /// <summary>
        /// Connects to the device either on serial port or over network.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (systemListBox.SelectedItem == null)
                return;

            string address = systemListBox.SelectedItem.ToString(); //Use: "xxx.xxx.xxx.xxx" (IPv4) or "COMx"

            if (mySystem == null)
            {
                mySystem = new DataManSystem();
            }

            try
            {
                mySystem.Imaging.Live.Enabled = false;
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
            try
            {
                mySystem.Connect(new DataManConnectionParams(address));
            }
            catch (Exception eConnect)
            {
                MessageBox.Show(eConnect.Message);
            }
            //If connected

            if (mySystem.IsConnected())
            {
                GetCurrentSetting();
                ConnectButton.Enabled = false;
                loadConfigButton.Enabled = true;
                DisconnectButton.Enabled = true;
                Pnl_Botton.Enabled = true;
                //To be able to receive data from the reader the user have to subscribe to the corresponding event
                mySystem.DmccResponseArrived += new DataManSystem.DmccResponseArrivedEventHandler(mySystem_DmccResponseArrived);
                mySystem.ImageArrived += new DataManSystem.ImageArrivedEventHandler(mySystem_ImageArrived);
                mySystem.GraphicArrived += new DataManSystem.GraphicArrivedEventHandler(mySystem_GraphicArrived);
                mySystem.ResultArrived += new DataManSystem.ResultArrivedEventHandler(mySystem_ResultArrived);

                //Registering for the HeartBeatSkipped event to be notified if the device is not responding
                mySystem.HeartBeatSkipped += new EventHandler(mySystem_HeartBeatSkipped);
            }
            else
            {
                Pnl_Botton.Enabled = false;
                connectionStatusLabel.Text = "Not connected";
                systemListBox.Enabled = true;
            }
        }
        /// <summary>
        /// To disconnect from the device simply dispose the DataManSystem object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            //Turn off live display if it is turned on
            if (_isLiveDisplayEnabled)
                liveDisplayCheckBox.Checked = false;

            //Disconnect
            if (mySystem != null)
            {
                //To be able to receive data from the reader the user have to subscribe to the corresponding event
                mySystem.DmccResponseArrived -= new DataManSystem.DmccResponseArrivedEventHandler(mySystem_DmccResponseArrived);
                mySystem.ImageArrived -= new DataManSystem.ImageArrivedEventHandler(mySystem_ImageArrived);
                mySystem.GraphicArrived -= new DataManSystem.GraphicArrivedEventHandler(mySystem_GraphicArrived);
                mySystem.ResultArrived -= new DataManSystem.ResultArrivedEventHandler(mySystem_ResultArrived);

                //Registering for the HeartBeatSkipped event to be notified if the device is not responding
                mySystem.HeartBeatSkipped -= new EventHandler(mySystem_HeartBeatSkipped);

                mySystem.Dispose();
            }
            ConnectButton.Enabled = true;
            Pnl_Botton.Enabled = false;
            connectionStatusLabel.Text = "Not connected";
        }
        /// <summary>
        /// Uploads a configuration file (.CFG) to the reader.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadConfigButton_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
                if (openFileDialog1.FileName != null)
                    mySystem.SendConfig(openFileDialog1.FileName); //parameter: filename as string
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        #endregion EndConnectToReader

        #region Sending DataMan Control Commands (DMCC)
        //SendDmcc() returns an incrementing command ID that can be used to
        //identify the responses coming asynchronously
        //See: "Receiving data from the reader"
        string idCmd = null;
        /// <summary>
        /// Use SendDmcc() to send DMCC commands to the device.
        /// The corresponding event gets fired when a response is received.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void SendCommandButton_Click(object sender, EventArgs e)
        {
            string cmdToSend = "";

            if (commandComboBox.SelectedItem != null)
                //Built-in examples
                cmdToSend = commandComboBox.SelectedItem.ToString();

            else
                //User typed-in command
                cmdToSend = commandComboBox.Text.Trim();

            sendCmd(cmdToSend);
        }
        private string sendCmd(string CmdToSend)
        {
            try
            {
                if (mySystem != null)
                {
                    idCmd = mySystem.SendDmcc(CmdToSend).ToString();
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
            }
            return idCmd;
        }
        private void commandComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SendCommandButton_Click(sender, e);
            }
        }
        #endregion

        #region Receiving data from the reader
        /// <summary>
        /// Register newly discovered devices.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void myManager_NetworkDeviceAppeared(object sender, SystemDiscoveredEventArgs e)
        {
            systemList.Add(new DataManSystem(new DataManConnectionParams(e.System.ConnectionParameters.Address)));
            systemListBox.Items.Add(e.System.ConnectionParameters.Address);
        }
        DateTime SysTriggerTime;
        Stopwatch sw;
        int totalCount = 0;
        int ImgRcvdCount = 0;
        int m_Good = 0;
        int m_Bad = 0;
        /// <summary>
        /// Display the last read result.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void mySystem_ResultArrived(object sender, ResultArrivedEventArgs e)
        {
            if (e.Result != null)
            {
                totalCount++;
                sw = new Stopwatch(); sw.Start();
                SysTriggerTime = DateTime.Now;
                responseLabel.Text = e.Result;
                label2.Text = "Image Update Time: ";
                label3.Text = "Data Scan Count:" + totalCount;
                if (String.IsNullOrEmpty(responseLabel.Text) == true)
                    m_Bad++;
                else
                    m_Good++;

                label4.Text = "Good:" + m_Good + " Bad: " + m_Bad;
                LST_RESULT.Items.Add(e.Result);
            }
        }
        /// <summary>
        /// Displaying responses to DMCC commands.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void mySystem_DmccResponseArrived(object sender, DmccResponseArrivedEventArgs e)
        {
            //Response arrived - To which sent command?          
            if (e.Id == idCmd)
            {
                responseLabel.Text = e.Data;
            }
            //Note: differentiate makes sense if we have more than one labels
            //e.g. one for displaying the device name and one for serial no.
            //else if (e.Id == idGetSerNo)
            //    responseLabel.Text = e.Data; // 
            //Error case
            else if (e.Status != "0")
                responseLabel.Text = "Status = " + e.Status;
            ////Handle here further cases (if any)            
            else
                responseLabel.Text = e.Data;
            ReceiveResponce(e.Data, e.Id);
        }
        /// <summary>
        /// Display images received from the device.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void mySystem_ImageArrived(object sender, ImageArrivedEventArgs e)
        {
            lastImagePictureBox.Image = e.Image;
            sw.Stop();
            long diffMS = sw.ElapsedMilliseconds;
            TimeSpan ts = DateTime.Now - SysTriggerTime;
            label2.Text = "Image Update Time: " + diffMS + "  " + ts.TotalMilliseconds;
            label5.Text = "Img Rcvd Count:" + (++ImgRcvdCount);
        }
        /// <summary>
        /// Updates Display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void UpdateDisplay(object sender, Image e)
        {
            lastImagePictureBox.Image = e;
        }
        private object graphicLock = new object();
        private void clearGraphics()
        {
            lock (graphicLock)
            {
                dmGraphics.Clear();
            }
        }
        private System.Collections.ArrayList dmGraphics = new System.Collections.ArrayList();
        private Boolean updateGraphics = false;
        /// <summary>
        /// Extracting coordinates from SVG graphics received from the reader and
        /// displaying polygon around the code that has been decoded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void mySystem_GraphicArrived(object sender, GraphicArrivedEventArgs e)
        {
            float xRatio = lastImagePictureBox.Width / 752f;    // 752 - width of the image acquired by the reader
            float yRatio = lastImagePictureBox.Height / 480f;   // 480 - height of the image acquired by the reader

            //If there is only image but no decoded result we don't want to parse out the coordinates
            int dataLength = e.Data.Length;
            int pointsIndex = e.Data.IndexOf("points", 0, dataLength);

            int startIndex;
            int endIndex;
            string coordsString;
            string[] coordsArray;

            updateGraphics = false;
            clearGraphics();
            while (pointsIndex != -1)
            {
                updateGraphics = true;

                startIndex = e.Data.IndexOf("points", pointsIndex, dataLength - pointsIndex) + 8;
                endIndex = e.Data.IndexOf('"', startIndex, dataLength - startIndex) - 1;
                coordsString = e.Data.Substring(startIndex, endIndex - startIndex);
                coordsArray = coordsString.Split(' ', ',');

                Point[] pointsToDraw = new Point[5];

                for (int i = 0; i < 8; i += 2)
                {
                    pointsToDraw[i / 2] = new Point((int)(Convert.ToInt32(coordsArray[i]) * xRatio),
                                                (int)(Convert.ToInt32(coordsArray[i + 1]) * yRatio));
                }

                //Adding the first point twice makes drawing easier (see: Graphics.DrawLines)
                pointsToDraw[4] = pointsToDraw[0];

                dmGraphics.Add(pointsToDraw);
                pointsIndex = e.Data.IndexOf("points", pointsIndex + 1, dataLength - pointsIndex - 1);
            }
        }
        private void lastImagePictureBox_Paint(object sender, PaintEventArgs e)
        {
            lock (graphicLock)
            {
                if (updateGraphics)
                {
                    Pen linePen = new Pen(Color.LawnGreen);
                    foreach (Point[] points in dmGraphics)
                    {
                        e.Graphics.DrawLines(linePen, points);
                    }
                }
            }
        }
        #endregion

        #region Live display

        /// <summary>
        /// Used to indicate that the live display thread should be started or stopped.
        /// </summary>
        bool _isLiveDisplayEnabled = false;

        /// <summary>
        /// A delegate is needed to update the GUI from another thread.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        delegate void ImageDelegate(object sender, Image e);

        /// <summary>
        /// The LiveDisplayThread thread (LiveDisplayReader()) is polling the reader.
        /// </summary>
        System.Threading.Thread liveDisplayThread;

        /// <summary>
        /// Worker on a separate thread that reads image from the reader periodically.
        /// </summary>
        private void LiveDisplayReader()
        {
            Image tempImage;
            while (true)
            {
                if (mySystem != null && _isLiveDisplayEnabled)
                {
                    tempImage = mySystem.GetImage();
                    lastImagePictureBox.Invoke(new ImageDelegate(this.UpdateDisplay), new object[] { this, tempImage });
                    System.Threading.Thread.Sleep(30);
                }
                else
                {
                    break;  //if _isLiveDisplayEnabled == false
                }
            }
        }

        private void liveDisplayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //Starting the live display thread
            if (liveDisplayCheckBox.Checked)
            {
                if (!_isLiveDisplayEnabled)
                {
                    _isLiveDisplayEnabled = true;
                    liveDisplayThread = null;
                    liveDisplayThread = new System.Threading.Thread(new System.Threading.ThreadStart(this.LiveDisplayReader));
                    liveDisplayThread.Name = "Live Display Polling Thread";
                    liveDisplayThread.IsBackground = true;
                    liveDisplayThread.Start();
                }

                //Don't display polygon when in live display mode
                updateGraphics = false;

                //Telling the reader to START continous image acquisition
                try
                {
                    mySystem.Imaging.Live.Enabled = true;
                }
                catch (Exception e1)
                {
                    _isLiveDisplayEnabled = false;
                    MessageBox.Show(e1.Message);
                }
            }

            //Stopping the live diplay thread
            else
            {
                try
                {
                    _isLiveDisplayEnabled = false;
                }
                catch (Exception e2)
                {
                    MessageBox.Show(e2.Message);
                }

                //Telling the reader to STOP continous image acquisition
                try
                {
                    mySystem.Imaging.Live.Enabled = false;
                }
                catch (Exception e4)
                {
                    MessageBox.Show(e4.Message);
                }
            }
        }

        #endregion //Live display

        #region Heartbeat

        private void setHeartBeatIntButton_Click(object sender, EventArgs e)
        {
            mySystem.HeartBeatInterval = 0;
            int interval = Convert.ToInt32(heartbeatIntervalComboBox.SelectedItem.ToString());
            mySystem.HeartBeatInterval = interval;
        }

        /// <summary>
        /// Called when the heartbeat interval elapses without having received "is alive" response
        /// from the device. See registering in ConnectButton_Click().
        /// </summary>
        void mySystem_HeartBeatSkipped(object sender, EventArgs e)
        {
            MessageBox.Show("Heartbeat skipped");
        }

        #endregion

        #region Light&BrightnessEventsFunctions
        private void Track_TargetBrightness_Scroll(object sender, EventArgs e)
        {
            TXT_AutomaticExpVal.Text = Track_TargetBrightness.Value.ToString();
        }
        private void Track_ManualExposure_Scroll(object sender, EventArgs e)
        {
            TXT_ManualExposure.Text = Track_ManualExposure.Value.ToString();
        }
        private void Track_Interval_Scroll(object sender, EventArgs e)
        {
            TXT_Interval.Text = Track_Interval.Value.ToString();
        }
        private void ManageTRIGGERTYPESelectionInput()
        {
            try
            {
                Pnl_Timeout.Visible = false;
                Pnl_Interval.Visible = false;
                Pnl_Exposure.Visible = false;
                Pnl_AutomaticExposure.Enabled = false;
                Pnl_ManualExposure.Enabled = false;
                Opt_AutomaticExposure.Checked = false;
                Opt_ManualExposure.Checked = false;
                Pnl_MaxExposure.Visible = false;
                PNL_SETNOOFCode.Enabled = false;
                if (CMB_TRIGGERTYPE.SelectedIndex == 0)
                {
                    Pnl_Timeout.Visible = true;
                    Pnl_Exposure.Visible = true;
                    Pnl_ManualExposure.Enabled = true;
                    Opt_ManualExposure.Checked = true;
                    Pnl_MaxExposure.Visible = true;
                    //
                    PNL_SETNOOFCode.Enabled = true;
                }
                else if (CMB_TRIGGERTYPE.SelectedIndex == 1)
                {
                    Pnl_AutomaticExposure.Enabled = true;
                    Pnl_ManualExposure.Enabled = true;
                    Pnl_Exposure.Visible = true;
                    Pnl_MaxExposure.Visible = true;
                }
                else if (CMB_TRIGGERTYPE.SelectedIndex == 2)
                {
                    Pnl_AutomaticExposure.Enabled = true;
                    Pnl_ManualExposure.Enabled = true;
                    Pnl_Exposure.Visible = true;
                    Pnl_MaxExposure.Visible = true;
                }
                else if (CMB_TRIGGERTYPE.SelectedIndex == 3)
                {
                    Opt_ManualExposure.Checked = true;
                    Pnl_ManualExposure.Enabled = true;
                    Pnl_Interval.Visible = true;
                    Pnl_Exposure.Visible = true;
                    Pnl_ManualExposure.Enabled = true;
                    Pnl_MaxExposure.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
            }
        }
        private void LightCameraChangedEvent(object sender, EventArgs e)
        {
            switch (sender.GetType().Name)
            {
                case "TextBox":
                    TextBox m_CurText = (TextBox)sender;
                    if (m_CurText == TXT_Interval)
                        Track_Interval.Value = Convert.ToInt16(TXT_Interval.Text);
                    else if (m_CurText == TXT_AutomaticExpVal)
                        Track_TargetBrightness.Value = Convert.ToInt16(TXT_AutomaticExpVal.Text);
                    else if (m_CurText == TXT_ManualExposure)
                        Track_ManualExposure.Value = Convert.ToInt16(TXT_ManualExposure.Text);
                    break;
                case "ComboBox":
                    ComboBox m_CurCombobox = (ComboBox)sender;
                    if (m_CurCombobox == CMB_TRIGGERTYPE)
                        ManageTRIGGERTYPESelectionInput();
                    break;
                case "RadioButton":
                    RadioButton m_CurOptBtn = (RadioButton)sender;
                    if (m_CurOptBtn == Opt_AutomaticExposure)
                    {
                        Opt_ManualExposure.Checked = false; //because of seperate panels need to mantain        
                        if (Opt_AutomaticExposure.Checked == true)
                            Grp_AutomaticExp.Enabled = true;
                        else
                            Grp_AutomaticExp.Enabled = false;
                    }
                    else if (m_CurOptBtn == Opt_ManualExposure)
                    {
                        Opt_AutomaticExposure.Checked = false;//because of seperate panels need to mantain        
                        if (Opt_ManualExposure.Checked == true)
                            Grp_ManualExp.Enabled = true;
                        else
                            Grp_ManualExp.Enabled = false;
                    }
                    break;
                //case "Trackbar":
                //    RadioButton m_CurOptBtn = (RadioButton)sender;
                //    break;
            }
            SendCmd_LightCameraChangedEvent(sender, e); //send cmd
        }
        #endregion EndBrightnessEventsFunctions

        #region GetSetCommandsAndRecieveResponce
        private string PrepareCmd(string Cmd, string[] ParamVal)
        {
            string CmdToSend = Cmd;
            for (int i = 0; i <= ParamVal.Length - 1; i++)
                CmdToSend += " " + ParamVal[i].ToString();
            return CmdToSend;
        }
        List<NameList> Lst = null;
        string[] ParamVal;
        private void GetCurrentSetting()
        {
            Lst = new List<NameList>();
            NameList cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetTriggerType);
            cmd.Name = CmdName.GetTriggerType.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetDecoderTimeout);
            cmd.Name = CmdName.GetDecoderTimeout.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetCameraInterval);
            cmd.Name = CmdName.GetCameraInterval.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetCameraExposure);
            cmd.Name = CmdName.GetCameraExposure.ToString();
            Lst.Add(cmd);

            //Symbology setting 2D
            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.Get2DALGORITHM);
            cmd.Name = CmdName.Get2DALGORITHM.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetDATAMATRIX);
            cmd.Name = CmdName.GetDATAMATRIX.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetQRCode);
            cmd.Name = CmdName.GetQRCode.ToString();
            Lst.Add(cmd);

            //Symbology setting 1D
            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetCode128);
            cmd.Name = CmdName.GetCode128.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetCode39);
            cmd.Name = CmdName.GetCode39.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetInterleaved2of5);
            cmd.Name = CmdName.GetInterleaved2of5.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetPharmacode);
            cmd.Name = CmdName.GetPharmacode.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetUpcEan);
            cmd.Name = CmdName.GetUpcEan.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetCode93);
            cmd.Name = CmdName.GetCode93.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetCodabar);
            cmd.Name = CmdName.GetCodabar.ToString();
            Lst.Add(cmd);

            //Symbology setting stacked
            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetPDF417);
            cmd.Name = CmdName.GetPDF417.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetMicroPDF417);
            cmd.Name = CmdName.GetMicroPDF417.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetDatabar);
            cmd.Name = CmdName.GetDatabar.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetEanUccComposite);
            cmd.Name = CmdName.GetEanUccComposite.ToString();
            Lst.Add(cmd);
            //Postal
            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetPostnet);
            cmd.Name = CmdName.GetPostnet.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetPlanet);
            cmd.Name = CmdName.GetPlanet.ToString();
            Lst.Add(cmd);
            //state code
            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetJapanPost);
            cmd.Name = CmdName.GetJapanPost.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetAustraliaPost);
            cmd.Name = CmdName.GetAustraliaPost.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetUPCPost);
            cmd.Name = CmdName.GetUPCPost.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GetIntelligentMailBarcode);
            cmd.Name = CmdName.GetIntelligentMailBarcode.ToString();
            Lst.Add(cmd);
            //Multicode
            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETAllowPartialResult);
            cmd.Name = CmdName.GETAllowPartialResult.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETNoOfCode);
            cmd.Name = CmdName.GETNoOfCode.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETMaxNoOFCode);
            cmd.Name = CmdName.GETMaxNoOFCode.ToString();
            Lst.Add(cmd);
            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETSymbologyReverse);
            cmd.Name = CmdName.GETSymbologyReverse.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETImageReverse);
            cmd.Name = CmdName.GETImageReverse.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETVerticleReverse);
            cmd.Name = CmdName.GETVerticleReverse.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETHorizontalReverse);
            cmd.Name = CmdName.GETHorizontalReverse.ToString();
            Lst.Add(cmd);
            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETMulticodeSortPriority);
            cmd.Name = CmdName.GETMulticodeSortPriority.ToString();
            Lst.Add(cmd);
            //System Settings

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETDeviceName);
            cmd.Name = CmdName.GETDeviceName.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETLine1_TrainCode);
            cmd.Name = CmdName.GETLine1_TrainCode.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETLine1_OptimizeBrightness);
            cmd.Name = CmdName.GETLine1_OptimizeBrightness.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETLine1_SetMatchString);
            cmd.Name = CmdName.GETLine1_SetMatchString.ToString();
            Lst.Add(cmd);
            //
            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GET3SecBtnPressAct_TrainCode);
            cmd.Name = CmdName.GET3SecBtnPressAct_TrainCode.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GET3SecBtnPressAct_OptimizeBrightness);
            cmd.Name = CmdName.GET3SecBtnPressAct_OptimizeBrightness.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GET3SecBtnPressAct_SetMatchString);
            cmd.Name = CmdName.GET3SecBtnPressAct_SetMatchString.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETDisableReaderBtn);
            cmd.Name = CmdName.GETDisableReaderBtn.ToString();
            Lst.Add(cmd);

            //System Setting -Outputs
            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETOPReservedForExtIllumination_Line0);
            cmd.Name = CmdName.GETOPReservedForExtIllumination_Line0.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETOPReservedForExtIllumination_Line1);
            cmd.Name = CmdName.GETOPReservedForExtIllumination_Line1.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETOutputEvents_Line0);
            cmd.Name = CmdName.GETOutputEvents_Line0.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETOutputEvents_Line1);
            cmd.Name = CmdName.GETOutputEvents_Line1.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETOutputAction_Line0);
            cmd.Name = CmdName.GETOutputAction_Line0.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETOutputAction_Line1);
            cmd.Name = CmdName.GETOutputAction_Line1.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETPulseWidth_Line0);
            cmd.Name = CmdName.GETPulseWidth_Line0.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETPulseWidth_Line1);
            cmd.Name = CmdName.GETPulseWidth_Line1.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETEnableBeeperOnGoodRead);
            cmd.Name = CmdName.GETEnableBeeperOnGoodRead.ToString();
            Lst.Add(cmd);

            cmd = new NameList();
            cmd.ID = sendCmd(DMCC_Commands.GETResultNoReadString);
            cmd.Name = CmdName.GETResultNoReadString.ToString();
            Lst.Add(cmd);
        }
        private void ReceiveResponce(string Response, string id)//bind data
        {
            int IndexLst = ReturnIndex(id);
            if (IndexLst == -1)
            {
                return;
            }
            if (Lst[IndexLst].Name == CmdName.GetTriggerType.ToString())
            {
                CMB_TRIGGERTYPE.SelectedIndex = Convert.ToInt16(Response);
                ManageTRIGGERTYPESelectionInput();
            }
            else if (Lst[IndexLst].Name == CmdName.GetDecoderTimeout.ToString())
            {
                TXT_Timeout.Text = Response;
            }
            else if (Lst[IndexLst].Name == CmdName.GetCameraInterval.ToString())
            {
                TXT_Interval.Text = Response;
            }
            else if (Lst[IndexLst].Name == CmdName.GetCameraExposure.ToString())
            {
                ParamVal = Response.Split(default(string[]), 4, StringSplitOptions.RemoveEmptyEntries);
                if (ParamVal[0].Contains("ON"))
                {
                    Opt_AutomaticExposure.Checked = true;
                    Opt_ManualExposure.Checked = false;
                }
                else
                {
                    Opt_AutomaticExposure.Checked = false;
                    Opt_ManualExposure.Checked = true;
                }
                TXT_AutomaticExpVal.Text = ParamVal[1];
                CMB_Exposure.SelectedIndex = Convert.ToInt16(ParamVal[2]);
                TXT_ManualExposure.Text = ParamVal[3];
            }
            //Symbology setting 2D
            else if (Lst[IndexLst].Name == CmdName.Get2DALGORITHM.ToString())
            {
                if (Response == "0")
                    OPT_IDMAX.Checked = true;
                else if (Response == "1")
                    OPT_IDQuick.Checked = true;
            }
            else if (Lst[IndexLst].Name == CmdName.GetDATAMATRIX.ToString())
            {
                if (Response == "ON")
                    CHK_Datamatrix.Checked = true;
                else
                    CHK_Datamatrix.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GetQRCode.ToString())
            {
                if (Response == "ON")
                    CHK_QRCode.Checked = true;
                else
                    CHK_QRCode.Checked = false;
            }
            //Symbology setting 1D

            else if (Lst[IndexLst].Name == CmdName.GetCode128.ToString())
            {
                if (Response == "ON")
                    CHK_Code128.Checked = true;
                else
                    CHK_Code128.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GetCode39.ToString())
            {
                if (Response == "ON")
                    CHK_Code39.Checked = true;
                else
                    CHK_Code39.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GetInterleaved2of5.ToString())
            {
                if (Response == "ON")
                    CHK_Interleaved2of5.Checked = true;
                else
                    CHK_Interleaved2of5.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GetPharmacode.ToString())
            {
                if (Response == "ON")
                    CHK_Pharmacode.Checked = true;
                else
                    CHK_Pharmacode.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GetUpcEan.ToString())
            {
                if (Response == "ON")
                    CHK_UPCEAN.Checked = true;
                else
                    CHK_UPCEAN.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GetCode93.ToString())
            {
                if (Response == "ON")
                    CHK_Code93.Checked = true;
                else
                    CHK_Code93.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GetCodabar.ToString())
            {
                if (Response == "ON")
                    CHK_Codebar.Checked = true;
                else
                    CHK_Codebar.Checked = false;
            }
            //Symbology setting Stacked
            else if (Lst[IndexLst].Name == CmdName.GetPDF417.ToString())
            {
                if (Response == "ON")
                    CHK_PDF417.Checked = true;
                else
                    CHK_PDF417.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GetMicroPDF417.ToString())
            {
                if (Response == "ON")
                    CHK_MicroPDF417.Checked = true;
                else
                    CHK_MicroPDF417.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GetDatabar.ToString())
            {
                if (Response == "ON")
                    CHK_Databar.Checked = true;
                else
                    CHK_Databar.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GetEanUccComposite.ToString())
            {
                if (Response == "ON")
                    CHK_EANUCCComposite.Checked = true;
                else
                    CHK_EANUCCComposite.Checked = false;
            }
            //Symbology setting Postal
            else if (Lst[IndexLst].Name == CmdName.GetPostnet.ToString())
            {
                if (Response == "ON")
                    CHK_Postnet.Checked = true;
                else
                    CHK_Postnet.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GetPlanet.ToString())
            {
                if (Response == "ON")
                    CHK_Planet.Checked = true;
                else
                    CHK_Planet.Checked = false;
            }
            //Symbology setting State Code
            else if (Lst[IndexLst].Name == CmdName.GetJapanPost.ToString())
            {
                if (Response == "ON")
                    CHK_JapanPost.Checked = true;
                else
                    CHK_JapanPost.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GetAustraliaPost.ToString())
            {
                if (Response == "ON")
                    CHK_AustaliaPost.Checked = true;
                else
                    CHK_AustaliaPost.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GetUPCPost.ToString())
            {
                if (Response == "ON")
                    CHK_UPC.Checked = true;
                else
                    CHK_UPC.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GetIntelligentMailBarcode.ToString())
            {
                if (Response == "ON")
                    CHK_IntelligentMailBarcode.Checked = true;
                else
                    CHK_IntelligentMailBarcode.Checked = false;
            }
            //Multicode
            else if (Lst[IndexLst].Name == CmdName.GETNoOfCode.ToString())
            {
                Num_NoOfCodes.Value = Convert.ToInt16(Response);
            }
            else if (Lst[IndexLst].Name == CmdName.GETAllowPartialResult.ToString())
            {
                if (Response.Contains("ON"))
                    CHK_PartialResult.Checked = true;
                else
                    CHK_PartialResult.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GETMaxNoOFCode.ToString())
            {
                string str = Response;
                ParamVal = Response.Split(default(string[]), 4, StringSplitOptions.RemoveEmptyEntries);
                NUM_DatamatrixNoOfCode.Value = Convert.ToInt16(ParamVal[0]);
                NUM_QRNoOfCode.Value = Convert.ToInt16(ParamVal[1]);
                NUM_1DStackedPostalNoOfCode.Value = Convert.ToInt16(ParamVal[2]);
            }
            //System settings

            else if (Lst[IndexLst].Name == CmdName.GETDeviceName.ToString())
            {
                TXT_DeviceName.Text = Response;
            }
            else if (Lst[IndexLst].Name == CmdName.GETLine1_TrainCode.ToString())
            {
                if (Response == "ON")
                    Chk_TrainCode1.Checked = true;
                else
                    Chk_TrainCode1.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GETLine1_OptimizeBrightness.ToString())
            {
                if (Response == "ON")
                    Chk_OptimizeBrightness1.Checked = true;
                else
                    Chk_OptimizeBrightness1.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GETLine1_SetMatchString.ToString())
            {
                if (Response == "ON")
                    Chk_SetMatchString1.Checked = true;
                else
                    Chk_SetMatchString1.Checked = false;
            }
            //
            else if (Lst[IndexLst].Name == CmdName.GET3SecBtnPressAct_TrainCode.ToString())
            {
                if (Response == "ON")
                    Chk_TrainCode3.Checked = true;
                else
                    Chk_TrainCode3.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GET3SecBtnPressAct_OptimizeBrightness.ToString())
            {
                if (Response == "ON")
                    Chk_OptimizeBrightness3.Checked = true;
                else
                    Chk_OptimizeBrightness3.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GET3SecBtnPressAct_SetMatchString.ToString())
            {
                if (Response == "ON")
                    Chk_SetMatchString3.Checked = true;
                else
                    Chk_SetMatchString3.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GETDisableReaderBtn.ToString())
            {
                if (Response == "ON") //
                    Chk_DisableReaderButton.Checked = false;
                else
                    Chk_DisableReaderButton.Checked = true;
            }
            else if (Lst[IndexLst].Name == CmdName.GETSymbologyReverse.ToString())
            {
                string str = Response;
                LstSortingPriority[0].Reverse = Response;
            }
            else if (Lst[IndexLst].Name == CmdName.GETImageReverse.ToString())
            {
                string str = Response;
                LstSortingPriority[1].Reverse = Response;
            }
            else if (Lst[IndexLst].Name == CmdName.GETVerticleReverse.ToString())
            {
                string str = Response;
                LstSortingPriority[2].Reverse = Response;
            }
            else if (Lst[IndexLst].Name == CmdName.GETHorizontalReverse.ToString())
            {
                string str = Response;
                LstSortingPriority[3].Reverse = Response;
            }
            else if (Lst[IndexLst].Name == CmdName.GETMulticodeSortPriority.ToString())
            {
                string str = Response;
                ParamVal = Response.Split(default(string[]), 4, StringSplitOptions.RemoveEmptyEntries);
                AddToListBox_SymbologySetting(ParamVal);
            }
            //System Setting-outputs
            else if (Lst[IndexLst].Name == CmdName.GETOPReservedForExtIllumination_Line0.ToString())
            {
                string str = Response;
                if (str == "ON")
                {
                    Chkoutput0.Checked = true;
                    PNLActionLine0.Enabled = false;
                }
                else
                    Chkoutput0.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GETOPReservedForExtIllumination_Line1.ToString())
            {
                string str = Response;
                if (str == "ON")
                {
                    Chk_Ouput1.Checked = true;
                    PNLActionLine1.Enabled = false;
                }
                else
                    Chk_Ouput1.Checked = false;
            }
            else if (Lst[IndexLst].Name == CmdName.GETOutputEvents_Line0.ToString())
            {
                string str = Response;
                ParamVal = Response.Split(default(string[]), 6, StringSplitOptions.RemoveEmptyEntries);

                //For Read
                if (Convert.ToInt16(ParamVal[0]) == 0)
                    Chk_EventRead0.Checked = false;
                else
                    Chk_EventRead0.Checked = true;

                //For No Read
                if (Convert.ToInt16(ParamVal[1]) == 0)
                    Chk_EventNoRead0.Checked = false;
                else
                    Chk_EventNoRead0.Checked = true;

                //For Event validation failure
                if (Convert.ToInt16(ParamVal[2]) == 0)
                    Chk_EventValidationFailure0.Checked = false;
                else
                    Chk_EventValidationFailure0.Checked = true;

                //For Event Trigger Overrun
                if (Convert.ToInt16(ParamVal[3]) == 0)
                    Chk_TriggerOverrun0.Checked = false;
                else
                    Chk_TriggerOverrun0.Checked = true;

                //For Event Buffer Overflow
                if (Convert.ToInt16(ParamVal[4]) == 0)
                    Chk_BufferOverflow0.Checked = false;
                else
                    Chk_BufferOverflow0.Checked = true;
            }
            else if (Lst[IndexLst].Name == CmdName.GETOutputEvents_Line1.ToString())
            {
                string str = Response;
                ParamVal = Response.Split(default(string[]), 6, StringSplitOptions.RemoveEmptyEntries);
                //For Read
                if (Convert.ToInt16(ParamVal[0]) == 0)
                    Chk_EventRead1.Checked = false;
                else
                    Chk_EventRead1.Checked = true;

                //For No Read
                if (Convert.ToInt16(ParamVal[1]) == 0)
                    Chk_EventNoRead1.Checked = false;
                else
                    Chk_EventNoRead1.Checked = true;

                //For Event validation failure
                if (Convert.ToInt16(ParamVal[2]) == 0)
                    Chk_EventValidationFailure1.Checked = false;
                else
                    Chk_EventValidationFailure1.Checked = true;

                //For Event Trigger Overrun
                if (Convert.ToInt16(ParamVal[3]) == 0)
                    Chk_TriggerOverrun1.Checked = false;
                else
                    Chk_TriggerOverrun1.Checked = true;

                //For Event Buffer Overflow
                if (Convert.ToInt16(ParamVal[4]) == 0)
                    Chk_BufferOverflow1.Checked = false;
                else
                    Chk_BufferOverflow1.Checked = true;
            }
            else if (Lst[IndexLst].Name == CmdName.GETOutputAction_Line0.ToString())
            {
                string str = Response;
                OPT_ActionOpen0.Checked = false;
                OPT_ActionClosed0.Checked = false;
                if (str == "0")
                    OPT_ActionOpen0.Checked = true;
                else
                    OPT_ActionClosed0.Checked = true;
            }
            else if (Lst[IndexLst].Name == CmdName.GETOutputAction_Line1.ToString())
            {
                string str = Response;
                OPT_ActionOpen1.Checked = false;
                OPT_ActionClosed1.Checked = false;
                if (str == "0")
                    OPT_ActionOpen1.Checked = true;
                else
                    OPT_ActionClosed1.Checked = true;
            }
            else if (Lst[IndexLst].Name == CmdName.GETPulseWidth_Line0.ToString())
            {
                TXT_Pulsewidth0.Text = Response;
            }
            else if (Lst[IndexLst].Name == CmdName.GETPulseWidth_Line1.ToString())
            {
                TXT_Pulsewidth1.Text = Response;
            }
            else if (Lst[IndexLst].Name == CmdName.GETEnableBeeperOnGoodRead.ToString())
            {
                string str = Response;
                ParamVal = Response.Split(default(string[]), 2, StringSplitOptions.RemoveEmptyEntries);
                if (ParamVal[0] == "1")
                    CHk_EnableBeeper.Checked = true;
            }
            else if (Lst[IndexLst].Name == CmdName.GETResultNoReadString.ToString())
            {
                TXT_NoReadOutput.Text = Response;
            }
            if (Convert.ToInt16(idCmd) - 1 == IndexLst)
            {
                Lst.Clear();
            }
        }
        private int ReturnIndex(string idCmd)
        {
            for (int i = 0; i <= Lst.Count - 1; i++)
            {
                if (Lst[i].ID == idCmd)
                {
                    return i;
                }
            }
            return -1;
        }

        private void SendCmd_LightCameraChangedEvent(object sender, EventArgs e)
        {
            string CmdToSend = "";
            if (Lst.Count > 0)
                return;

            switch (sender.GetType().Name)
            {
                case "TextBox":
                    TextBox m_CurText = (TextBox)sender;
                    if (m_CurText == TXT_Timeout)
                        CmdToSend = DMCC_Commands.SetDecoderTimeout + TXT_Timeout.Text;  //[0-10000]                   
                    else if (m_CurText == TXT_Interval)
                        CmdToSend = DMCC_Commands.SetCameraInterval + TXT_Interval.Text;//[17-1000]  
                    else if (m_CurText == TXT_AutomaticExpVal || m_CurText == TXT_ManualExposure)
                    {
                        if (Opt_AutomaticExposure.Checked == true)
                            ParamVal[0] = "ON";
                        else
                            ParamVal[0] = "OFF";
                        ParamVal[1] = TXT_AutomaticExpVal.Text;
                        ParamVal[2] = CMB_Exposure.SelectedIndex.ToString();
                        ParamVal[3] = TXT_ManualExposure.Text;
                        CmdToSend = PrepareCmd(DMCC_Commands.SetCameraExposure, ParamVal);
                    }
                    break;
                case "ComboBox":
                    ComboBox m_CurCombobox = (ComboBox)sender;
                    if (m_CurCombobox == CMB_TRIGGERTYPE)
                        CmdToSend = DMCC_Commands.SetTriggerType + CMB_TRIGGERTYPE.SelectedIndex;
                    else if (m_CurCombobox == Cmb_MaximumExposure) //Incomplte                   
                        CmdToSend = "";
                    else if (m_CurCombobox == CMB_Exposure)
                    {
                        if (Opt_AutomaticExposure.Checked == true)
                            ParamVal[0] = "ON";
                        else
                            ParamVal[0] = "OFF";
                        ParamVal[1] = TXT_AutomaticExpVal.Text;
                        ParamVal[2] = CMB_Exposure.SelectedIndex.ToString();
                        ParamVal[3] = TXT_ManualExposure.Text;
                        CmdToSend = PrepareCmd(DMCC_Commands.SetCameraExposure, ParamVal);
                    }
                    break;
                case "RadioButton":
                    RadioButton m_CurOptBtn = (RadioButton)sender;
                    if (m_CurOptBtn == Opt_AutomaticExposure || m_CurOptBtn == Opt_ManualExposure)
                    {
                        if (Opt_AutomaticExposure.Checked == true)
                            ParamVal[0] = "ON";
                        else
                            ParamVal[0] = "OFF";
                        ParamVal[1] = TXT_AutomaticExpVal.Text;
                        ParamVal[2] = CMB_Exposure.SelectedIndex.ToString();
                        ParamVal[3] = TXT_ManualExposure.Text;
                        CmdToSend = PrepareCmd(DMCC_Commands.SetCameraExposure, ParamVal);
                    }
                    break;
            }

            if (!string.IsNullOrEmpty(CmdToSend))
                sendCmd(CmdToSend);
        }
        private void SendCmd_SymbologyChangedEvent(object sender, EventArgs e)
        {
            string CmdToSend = "";
            if (Lst.Count > 0)
                return;

            switch (sender.GetType().Name)
            {
                case "TextBox":
                    TextBox m_CurText = (TextBox)sender;
                    break;
                case "ComboBox":
                    ComboBox m_CurCombobox = (ComboBox)sender;
                    break;
                case "RadioButton":
                    RadioButton m_CurOptBtn = (RadioButton)sender;
                    if (m_CurOptBtn == OPT_IDMAX)
                        CmdToSend = DMCC_Commands.Set2DALGORITHM_IDMAX;
                    else if (m_CurOptBtn == OPT_IDQuick)
                        CmdToSend = DMCC_Commands.Set2DALGORITHM_IDQuick;
                    break;
                case "NumericUpDown":
                    NumericUpDown m_CurNumericUpDown = (NumericUpDown)sender;
                    if (m_CurNumericUpDown == Num_NoOfCodes)
                        CmdToSend = DMCC_Commands.SETNoOfCode + Num_NoOfCodes.Value;
                    else if (m_CurNumericUpDown == NUM_DatamatrixNoOfCode)
                        CmdToSend = DMCC_Commands.SETDatamatrixMaxNoOFCode + NUM_DatamatrixNoOfCode.Value;
                    else if (m_CurNumericUpDown == NUM_QRNoOfCode)
                        CmdToSend = DMCC_Commands.SETQRCODEMaxNoOFCode + NUM_QRNoOfCode.Value;
                    else if (m_CurNumericUpDown == NUM_1DStackedPostalNoOfCode)
                        CmdToSend = DMCC_Commands.SET1DStackedPostalMaxNoOFCode + NUM_1DStackedPostalNoOfCode.Value;
                    break;
                case "CheckBox":
                    CheckBox m_CurCheckBox = (CheckBox)sender;
                    string SetParam = "OFF";
                    if (m_CurCheckBox.Checked == true)
                        SetParam = "ON";
                    else
                        SetParam = "OFF";
                    //2D Symbology
                    if (m_CurCheckBox == CHK_Datamatrix)
                        CmdToSend = DMCC_Commands.SetDATAMATRIX + SetParam;
                    if (m_CurCheckBox == CHK_QRCode)
                        CmdToSend = DMCC_Commands.SetQRCode + SetParam;

                    //1D Symbology
                    if (m_CurCheckBox == CHK_Code128)
                        CmdToSend = DMCC_Commands.SetCode128 + SetParam;
                    if (m_CurCheckBox == CHK_Code39)
                        CmdToSend = DMCC_Commands.SetCode39 + SetParam;
                    if (m_CurCheckBox == CHK_Interleaved2of5)
                        CmdToSend = DMCC_Commands.SetInterleaved2of5 + SetParam;
                    if (m_CurCheckBox == CHK_Pharmacode)
                        CmdToSend = DMCC_Commands.SetPharmacode + SetParam;
                    if (m_CurCheckBox == CHK_UPCEAN)
                        CmdToSend = DMCC_Commands.SetUpcEan + SetParam;
                    if (m_CurCheckBox == CHK_Code93)
                        CmdToSend = DMCC_Commands.SetCode93 + SetParam;
                    if (m_CurCheckBox == CHK_Codebar)
                        CmdToSend = DMCC_Commands.SetCodabar + SetParam;

                    //Stacked
                    if (m_CurCheckBox == CHK_PDF417)
                        CmdToSend = DMCC_Commands.SetPDF417 + SetParam;
                    if (m_CurCheckBox == CHK_MicroPDF417)
                        CmdToSend = DMCC_Commands.SetMicroPDF417 + SetParam;
                    if (m_CurCheckBox == CHK_Databar)
                        CmdToSend = DMCC_Commands.SetDatabar + SetParam;
                    if (m_CurCheckBox == CHK_EANUCCComposite)
                        CmdToSend = DMCC_Commands.SetEanUccComposite + SetParam;

                    //Postal
                    if (m_CurCheckBox == CHK_Postnet)
                        CmdToSend = DMCC_Commands.SetPostnet + SetParam;
                    if (m_CurCheckBox == CHK_Planet)
                        CmdToSend = DMCC_Commands.SetPlanet + SetParam;
                    //state code
                    if (m_CurCheckBox == CHK_JapanPost)
                        CmdToSend = DMCC_Commands.SetJapanPost + SetParam;
                    if (m_CurCheckBox == CHK_AustaliaPost)
                        CmdToSend = DMCC_Commands.SetAustraliaPost + SetParam;
                    if (m_CurCheckBox == CHK_UPC)
                        CmdToSend = DMCC_Commands.SetUPCPost + SetParam;
                    if (m_CurCheckBox == CHK_IntelligentMailBarcode)
                        CmdToSend = DMCC_Commands.SetIntelligentMailBarcode + SetParam;
                    //Multicode
                    if (m_CurCheckBox == CHK_PartialResult)
                        CmdToSend = DMCC_Commands.SETAllowPartialResult + SetParam;
                    break;
                case "ListBox":
                    ListBox m_CurListBox = (ListBox)sender;
                    if (m_CurListBox == LSTPriority)
                    {
                        //CmdToSend = DMCC_Commands.SETMulticodeSortPriority; 
                        SymbologyChangedEvent(sender, e);
                    }
                    break;
                case "RedGlowButton":
                    Red.Controls.Buttons.RedGlowButton m_CurButton = (Red.Controls.Buttons.RedGlowButton)sender;
                    if (m_CurButton == BTN_Up || m_CurButton == Btn_Down)
                    {
                        CmdToSend = DMCC_Commands.SETMulticodeSortPriority;
                        SortingPriority lst = new SortingPriority();

                        for (int i = 0; i <= LSTPriority.Items.Count - 1; i++)
                        {
                            //lst = (SortingPriority)LSTPriority.Items[i];
                            for (int j = 0; j <= LstSortingPriority.Count - 1; j++)
                            {
                                if (LSTPriority.Items[j].ToString() == LstSortingPriority[j].Name)
                                {
                                    lst = LstSortingPriority[j];
                                    break;
                                }
                            }
                            CmdToSend += " " + lst.ID;
                        }
                        if (!string.IsNullOrEmpty(CmdToSend))
                            sendCmd(CmdToSend);
                    }
                    break;
            }
            if (!string.IsNullOrEmpty(CmdToSend))
                sendCmd(CmdToSend);
        }
        private void SendCmd_SystemSettingChangedEvent(object sender, EventArgs e)
        {
            string CmdToSend = "";
            int flag = 0;
            string SetParam = "OFF";

            if (Lst.Count > 0)
                return;

            switch (sender.GetType().Name)
            {
                case "TextBox":
                    TextBox m_CurText = (TextBox)sender;
                    if (m_CurText == TXT_DeviceName)
                        CmdToSend = DMCC_Commands.SETDeviceName + "\"" + TXT_DeviceName.Text + "\"";
                    else if (m_CurText == TXT_NoReadOutput)
                        CmdToSend = DMCC_Commands.SETResultNoReadString + "\"" + TXT_NoReadOutput.Text + "\"";
                    else if (m_CurText == TXT_Pulsewidth0)
                        CmdToSend = DMCC_Commands.SETPulseWidth_Line0 + TXT_Pulsewidth0.Text;
                    else if (m_CurText == TXT_Pulsewidth1)
                        CmdToSend = DMCC_Commands.SETPulseWidth_Line1 + TXT_Pulsewidth1.Text;
                    break;
                case "CheckBox":
                    CheckBox m_CurCheckBox = (CheckBox)sender;
                    if (m_CurCheckBox.Checked == true)
                        SetParam = "ON";
                    else
                        SetParam = "OFF";
                    //2D Symbology
                    if (m_CurCheckBox == Chk_TrainCode1)
                        CmdToSend = DMCC_Commands.SETLine1_TrainCode + SetParam;
                    else if (m_CurCheckBox == Chk_OptimizeBrightness1)
                        CmdToSend = DMCC_Commands.SETLine1_OptimizeBrightness + SetParam;
                    else if (m_CurCheckBox == Chk_SetMatchString1)
                        CmdToSend = DMCC_Commands.SETLine1_SetMatchString + SetParam;

                    else if (m_CurCheckBox == Chk_TrainCode3)
                        CmdToSend = DMCC_Commands.SET3SecBtnPressAct_TrainCode + SetParam;
                    else if (m_CurCheckBox == Chk_OptimizeBrightness3)
                        CmdToSend = DMCC_Commands.SET3SecBtnPressAct_OptimizeBrightness + SetParam;
                    else if (m_CurCheckBox == Chk_SetMatchString3)
                        CmdToSend = DMCC_Commands.SET3SecBtnPressAct_SetMatchString + SetParam;

                    else if (m_CurCheckBox == Chk_DisableReaderButton)
                    {
                        if (m_CurCheckBox.Checked == true) // Enables or disables the button
                            SetParam = "OFF";
                        else
                            SetParam = "ON";
                        CmdToSend = DMCC_Commands.SETDisableReaderBtn + SetParam;
                    }
                    //outputs

                    else if (m_CurCheckBox == Chkoutput0) //need to check
                    {
                        //flag = 0; //open
                        PNLActionLine0.Enabled = true;
                        if (m_CurCheckBox.Checked == true) //close
                        {
                            //flag = 1;
                            PNLActionLine0.Enabled = false;
                        }
                        CmdToSend = DMCC_Commands.SETOPReservedForExtIllumination_Line0 + SetParam;
                    }
                    else if (m_CurCheckBox == Chk_Ouput1) //need to check
                    {
                        // flag = 0; //open
                        PNLActionLine1.Enabled = true;
                        if (m_CurCheckBox.Checked == true) //close
                        {
                            //flag = 1;
                            PNLActionLine1.Enabled = false;
                        }
                        CmdToSend = DMCC_Commands.SETOPReservedForExtIllumination_Line1 + SetParam;
                    }
                    else if (m_CurCheckBox == Chk_EventRead0 || m_CurCheckBox == Chk_EventNoRead0 || m_CurCheckBox == Chk_EventValidationFailure0 || m_CurCheckBox == Chk_TriggerOverrun0 || m_CurCheckBox == Chk_BufferOverflow0)
                    {
                        CmdToSend = DMCC_Commands.SETOutputEvents_Line0 + SetCmdOutputEvent_Line0();
                    }
                    else if (m_CurCheckBox == Chk_EventRead1 || m_CurCheckBox == Chk_EventNoRead1 || m_CurCheckBox == Chk_EventValidationFailure1 || m_CurCheckBox == Chk_TriggerOverrun1 || m_CurCheckBox == Chk_BufferOverflow1)
                    {
                        CmdToSend = DMCC_Commands.SETOutputEvents_Line1 + SetCmdOutputEvent_Line1();
                    }
                    else if (m_CurCheckBox == CHk_EnableBeeper)
                    {
                        // flag = 0;
                        if (m_CurCheckBox.Checked == true) //need to check
                            flag = 1;
                        CmdToSend = DMCC_Commands.SETEnableBeeperOnGoodRead + flag + " " + 1; //..1 is default param
                    }
                    break;
                case "RadioButton":
                    RadioButton m_CurRadioButton = (RadioButton)sender;

                    if (m_CurRadioButton == OPT_ActionOpen0 || m_CurRadioButton == OPT_ActionClosed0)
                    {
                        if (m_CurRadioButton == OPT_ActionOpen0 && m_CurRadioButton.Checked == true)
                            flag = 0;
                        else
                            flag = 1;
                        CmdToSend = DMCC_Commands.SETOutputAction_Line0 + flag;
                    }
                    else if (m_CurRadioButton == OPT_ActionOpen1 || m_CurRadioButton == OPT_ActionClosed1)
                    {
                        if (m_CurRadioButton == OPT_ActionOpen1 && m_CurRadioButton.Checked == true)
                            flag = 0;
                        else
                            flag = 1;
                        CmdToSend = DMCC_Commands.SETOutputAction_Line1 + flag;
                    }
                    break;
            }
            if (!string.IsNullOrEmpty(CmdToSend))
                sendCmd(CmdToSend);
        }

        public string SetCmdOutputEvent_Line0()///object sender
        {
            ParamVal = new string[6];
            if (Chk_EventRead0.Checked == true)
                ParamVal[0] = "1";
            else
                ParamVal[0] = "0";

            if (Chk_EventNoRead0.Checked == true)
                ParamVal[1] = "1";
            else
                ParamVal[1] = "0";

            if (Chk_EventValidationFailure0.Checked == true)
                ParamVal[2] = "1";
            else
                ParamVal[2] = "0";

            if (Chk_TriggerOverrun0.Checked == true)
                ParamVal[3] = "1";
            else
                ParamVal[3] = "0";

            if (Chk_BufferOverflow0.Checked == true)
                ParamVal[4] = "1";
            else
                ParamVal[4] = "0";
            ParamVal[5] = "1"; //to test...this is not used but need to add by default

            //return ParamVal;
            string str = "";
            for (int i = 0; i <= ParamVal.Length - 1; i++)
            {
                str = str + ParamVal[i];
                if (i != 5)
                    str = str + " ";
            }
            return str;
        }
        public string SetCmdOutputEvent_Line1()
        {
            ParamVal = new string[6];
            if (Chk_EventRead1.Checked == true)
                ParamVal[0] = "1";
            else
                ParamVal[0] = "0";

            if (Chk_EventNoRead1.Checked == true)
                ParamVal[1] = "1";
            else
                ParamVal[1] = "0";

            if (Chk_EventValidationFailure1.Checked == true)
                ParamVal[2] = "1";
            else
                ParamVal[2] = "0";

            if (Chk_TriggerOverrun1.Checked == true)
                ParamVal[3] = "1";
            else
                ParamVal[3] = "0";

            if (Chk_BufferOverflow1.Checked == true)
                ParamVal[4] = "1";
            else
                ParamVal[4] = "0";

            ParamVal[5] = "1"; //to test...this is not used but need to add by default

            //return ParamVal;
            string str = "";
            for (int i = 0; i <= ParamVal.Length - 1; i++)
            {
                str = str + ParamVal[i];
                if (i != 5)
                    str = str + " ";
            }
            return str;
        }
        #endregion EndGetSetCommandsAndRecieveResponce

        #region SymbologySetting
        List<SortingPriority> LstSortingPriority = new List<SortingPriority>();
        private void SortingProirityList()
        {
            SortingPriority SortingPriority = new SortingPriority();
            SortingPriority.ID = "0";
            SortingPriority.Name = DMSortingPriorityItems.Symbology; // "Data Matrix,QR Code,Barcode";
            LstSortingPriority.Add(SortingPriority);

            SortingPriority = new SortingPriority();
            SortingPriority.ID = "1";
            SortingPriority.Name = DMSortingPriorityItems.ImageOrder; // "Image Order";
            LstSortingPriority.Add(SortingPriority);

            SortingPriority = new SortingPriority();
            SortingPriority.ID = "2";
            SortingPriority.Name = DMSortingPriorityItems.VerticlePos;  //"Position (Top To Bottom)";
            LstSortingPriority.Add(SortingPriority);

            SortingPriority = new SortingPriority();
            SortingPriority.ID = "3";
            SortingPriority.Name = DMSortingPriorityItems.HorizontalPos; // "Position (Left To Right)";
            LstSortingPriority.Add(SortingPriority);
        }
        private void AddToListBox_SymbologySetting(string[] index)
        {
            SortingPriority SortingPriority = new SortingPriority();
            if (LSTPriority.Items.Count > 0)
                LSTPriority.Items.Clear();

            for (int i = 0; i <= index.Length - 1; i++)
            {
                SortingPriority = new SortingPriority();
                SortingPriority = LstSortingPriority[Convert.ToInt16(index[i])];
                LSTPriority.Items.Add(SortingPriority);
                LSTPriority.DisplayMember = "Name";
                LSTPriority.ValueMember = "ID";
                Manage_ListboxTextReverse(Convert.ToInt16(index[i]));
            }
        }
        public void Manage_ListboxTextReverse(int index) //index of list 
        {
            string Text = null;
            if (LstSortingPriority[index].Reverse == "OFF")
            {
                if (index == 0)
                    Text = DMSortingPriorityItems.Symbology; //"Data Matrix,QR Code,Barcode";            
                else if (index == 1)
                    Text = DMSortingPriorityItems.ImageOrder; //"Image Order";                
                else if (index == 2)
                    Text = DMSortingPriorityItems.VerticlePos; //"Position (Top To Bottom)";                
                else if (index == 3)
                    Text = DMSortingPriorityItems.HorizontalPos;  //"Position (Left To Right)";
            }
            else if (LstSortingPriority[index].Reverse == "ON")
            {
                if (index == 0)
                    Text = DMSortingPriorityItems.Symbology_Reverse;// "Barcode,QR Code,Data Matrix";
                else if (index == 1)
                    Text = DMSortingPriorityItems.ImageOrder_Reverse; // "Reverse Image Order";
                else if (index == 2)
                    Text = DMSortingPriorityItems.VerticlePos_Reverse; //"Position (Bottom To Top)";
                else if (index == 3)
                    Text = DMSortingPriorityItems.HorizontalPos_Reverse;  //"Position (Right To Left)";
            }
            if (!string.IsNullOrEmpty(Text))
            {
                for (int i = 0; i <= LSTPriority.Items.Count - 1; i++)
                {
                    SortingPriority lst = (SortingPriority)LSTPriority.Items[i];
                    if (LstSortingPriority[index].Name == lst.Name)
                    {
                        lst.Name = Text;
                        LSTPriority.Items.RemoveAt(i);
                        LSTPriority.Items.Insert(i, lst);
                        break;
                    }
                }
                LstSortingPriority[index].Name = Text;
            }
        }
        private void SymbologyChangedEvent(object sender, EventArgs e)
        {
            switch (sender.GetType().Name)
            {
                case "ListBox":
                    ListBox m_CurListBox = (ListBox)sender;
                    if (m_CurListBox == LSTPriority)
                    {
                        if (LSTPriority.SelectedIndex == 0)
                            BTN_Up.Enabled = false;
                        else
                            BTN_Up.Enabled = true;

                        if (LSTPriority.SelectedIndex == LSTPriority.Items.Count - 1)
                            Btn_Down.Enabled = false;
                        else
                            Btn_Down.Enabled = true;
                    }
                    break;
            }
        }
        private void BTN_Up_Click(object sender, EventArgs e)
        {
            // An item must be selected
            if (LSTPriority.SelectedItems.Count > 0)
            {
                object selected = LSTPriority.SelectedItem;
                int indx = LSTPriority.Items.IndexOf(selected);
                int totl = LSTPriority.Items.Count;
                // If the item is right at the top, throw it right down to the bottom
                if (indx == 0)
                {
                    LSTPriority.Items.Remove(selected);
                    LSTPriority.Items.Insert(totl - 1, selected);
                    LSTPriority.SetSelected(totl - 1, true);
                }
                // To move the selected item upwards in the listbox
                else
                {
                    LSTPriority.Items.Remove(selected);
                    LSTPriority.Items.Insert(indx - 1, selected);
                    LSTPriority.SetSelected(indx - 1, true);
                }
            }
            SendCmd_SymbologyChangedEvent(sender, e);
        }
        private void Btn_Reverse_Click(object sender, EventArgs e)
        {
            SortingPriority lst = new SortingPriority();
            string SendToCmd = "";
            if (LSTPriority.SelectedItems.Count > 0)
            {
                for (int i = 0; i <= LstSortingPriority.Count - 1; i++)
                {
                    if (LSTPriority.SelectedItem == LstSortingPriority[i]) //Name
                    {
                        lst = LstSortingPriority[i];
                        break;
                    }
                }
                if (lst.ID == "0")
                {
                    SendToCmd = DMCC_Commands.SETSymbologyReverse;
                    // m_Id = sendCmd(DMCC_Commands.GETSymbologyReverse);                  
                }
                else if (lst.ID == "1")
                {
                    SendToCmd = DMCC_Commands.SETImageReverse;
                    // m_Id = sendCmd(DMCC_Commands.GETImageReverse);                   
                }
                else if (lst.ID == "2")
                {
                    //m_Id = sendCmd(DMCC_Commands.GETVerticleReverse);
                    SendToCmd = DMCC_Commands.SETVerticleReverse;
                }
                else if (lst.ID == "3")
                {
                    SendToCmd = DMCC_Commands.SETHorizontalReverse;
                }
                if (LstSortingPriority[Convert.ToInt16(lst.ID)].Reverse == "ON")
                {
                    LstSortingPriority[Convert.ToInt16(lst.ID)].Reverse = "OFF";
                    SendToCmd += "OFF";
                }
                else
                {
                    LstSortingPriority[Convert.ToInt16(lst.ID)].Reverse = "ON";
                    SendToCmd += "ON";
                }
                Manage_ListboxTextReverse(Convert.ToInt16(lst.ID));
                if (!string.IsNullOrEmpty(SendToCmd))
                    sendCmd(SendToCmd);
            }
        }
        private void Btn_Down_Click(object sender, EventArgs e)
        {
            // An item must be selected
            if (LSTPriority.SelectedItems.Count > 0)
            {
                object selected = LSTPriority.SelectedItem;
                int indx = LSTPriority.Items.IndexOf(selected);
                int totl = LSTPriority.Items.Count;
                // If the item is last in the listbox, move it all the way to the top
                if (indx == totl - 1)
                {
                    LSTPriority.Items.Remove(selected);
                    LSTPriority.Items.Insert(0, selected);
                    LSTPriority.SetSelected(0, true);
                }
                // To move the selected item downwards in the listbox
                else
                {
                    LSTPriority.Items.Remove(selected);
                    LSTPriority.Items.Insert(indx + 1, selected);
                    LSTPriority.SetSelected(indx + 1, true);
                }
            }
            SendCmd_SymbologyChangedEvent(sender, e);
        }
        #endregion EndSymbologySetting


        public enum CmdName  //list of commands
        {
            //Get Light & Trigger setting
            GetTriggerType,
            GetDecoderTimeout,
            GetCameraInterval,
            GetCameraExposure,
            //SET Light & trigger setting
            SetTriggerType,
            SetDecoderTimeout,
            SetCameraInterval,
            SetCameraExposure,

            //Get General Symbology
            Get2DALGORITHM,
            GetDATAMATRIX,
            GetQRCode,

            GetCode128,
            GetCode39,
            GetInterleaved2of5,
            GetPharmacode,
            GetUpcEan,
            GetCode93,
            GetCodabar,

            GetPDF417,
            GetMicroPDF417,
            GetDatabar,
            GetEanUccComposite,

            GetPostnet,
            GetPlanet,
            GetJapanPost,
            GetAustraliaPost,
            GetUPCPost,
            GetIntelligentMailBarcode,

            //Set General Symbology
            Set2DALGORITHM_IDMAX,
            Set2DALGORITHM_IDQuick,

            SetDATAMATRIX,
            SetQRCode,

            SetCode128,
            SetCode39,
            SetInterleaved2of5,
            SetPharmacode,
            SetUpcEan,
            SetCode93,
            SetCodabar,

            SetPDF417,
            SetMicroPDF417,
            SetDatabar,
            SetEanUccComposite,

            SetPostnet,
            SetPlanet,
            SetJapanPost,
            SetAustraliaPost,
            SetUPCPost,
            SetIntelligentMailBarcode,

            //GEt Multicode Symbology
            GETNoOfCode,
            SETNoOfCode,
            GETAllowPartialResult,
            SETAllowPartialResult,
            GETMaxNoOFCode,
            SETDatamatrixMaxNoOFCode,
            SETQRCODEMaxNoOFCode,
            SET1DStackedPostalMaxNoOFCode,

            //System Setting
            GETLine1_TrainCode,
            GETLine1_OptimizeBrightness,
            GETLine1_SetMatchString,

            GET3SecBtnPressAct_TrainCode,
            GET3SecBtnPressAct_OptimizeBrightness,
            GET3SecBtnPressAct_SetMatchString,
            GETDisableReaderBtn,

            SETLine1_TrainCode,
            SETLine1_OptimizeBrightness,
            SETLine1_SetMatchString,

            SET3SecBtnPressAct_TrainCode,
            SET3SecBtnPressAct_OptimizeBrightness,
            SET3SecBtnPressAct_SetMatchString,
            SETDisableReaderBtn,

            GETDeviceName,
            SETDeviceName,

            //Ouputs

            GETOpReservedForExtILM0,
            GETEventRead0,
            GETEventNoRead0,
            GETEventValidationFailure0,
            GETEventTriggerOverrun0,
            GETEventBufferOverflow0,

            GETActionOpen0,
            GETActionClosed0,
            GETActionPulseWidth0,
            //
            SETOpReservedForExtILM0,
            SETEventRead0,
            SETEventNoRead0,
            SETEventValidationFailure0,
            SETEventTriggerOverrun0,
            SETEventBufferOverflow0,

            SETActionOpen0,
            SETActionClosed0,
            SETActionPulseWidth0,

            GETOpReservedForExtILM1,
            GETEventRead1,
            GETEventNoRead1,
            GETEventValidationFailure1,
            GETEventTriggerOverrun1,
            GETEventBufferOverflow1,

            GETActionOpen1,
            GETActionClosed1,
            GETActionPulseWidth1,
            //
            SETOpReservedForExtILM1,
            SETEventRead1,
            SETEventNoRead1,
            SETEventValidationFailure1,
            SETEventTriggerOverrun1,
            SETEventBufferOverflow1,

            SETActionOpen1,
            SETActionClosed1,
            SETActionPulseWidth1,

            GETEnableBeeperOnGoodRead,
            SETEnableBeeperOnGoodRead,

            GETMulticodeSortPriority,
            SETMulticodeSortPriority,

            GETImageReverse,
            SETImageReverse,

            SETSymbologyReverse,
            GETSymbologyReverse,

            SETVerticleReverse,
            GETVerticleReverse,

            SETHorizontalReverse,
            GETHorizontalReverse,

            //system setting
            GETOPReservedForExtIllumination_Line0,
            GETOPReservedForExtIllumination_Line1,

            GETOutputEvents_Line0,
            GETOutputEvents_Line1,

            GETOutputAction_Line0,
            GETOutputAction_Line1,

            GETPulseWidth_Line0,
            GETPulseWidth_Line1,

            //GETEnableBeeperOnGoodRead,
            GETResultNoReadString,

        }
    }
    class SortingPriority
    {
        public string _ID;
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string _Reverse;
        public string Reverse
        {
            get { return _Reverse; }
            set { _Reverse = value; }
        }
    }
    class NameList
    {
        public string _ID;
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }
}
