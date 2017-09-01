using System;
using System.Windows.Forms;
using rcs.CONTROLS;

namespace CondotCombiSys.Controls
{
    public partial class CtrlHMIParamSet : UserControl
    {
        #region Properties

        public int HMIOPParam_ID { get; set; }

        string _PLCParamCaption = "Parameter";
        public string PLCParamCaption
        {
            get { return _PLCParamCaption; }
            set
            {
                _PLCParamCaption = value;
                lblTestParam.Text = _PLCParamCaption;
            }
        }

        string _OperBtnNameOn = "ON";
        public string OperBtnNameOn
        {
            get { return _OperBtnNameOn; }
            set
            {
                _OperBtnNameOn = value;
                btnOn.Text = _OperBtnNameOn;
            }
        }

        string _OperBtnNameOff = "OFF";
        public string OperBtnNameOff
        {
            get { return _OperBtnNameOff; }
            set
            {
                _OperBtnNameOff = value;
                btnOff.Text = _OperBtnNameOff;
            }
        }

        #endregion Properties

        #region EVENTS

        public delegate bool delHMIParamSet(string deviceName);
        public event delHMIParamSet OnClickDevice;

        public delegate void delParamAction(int HMIOPParam_ID, string PLCParamCaption, Action action2Perform);
        public event delParamAction OnParamAction;

        #endregion EVENTS

        #region Control UI

        public CtrlHMIParamSet()
        {
            InitializeComponent();
        }

        private void CtrlHMIParamSet_Load(object sender, EventArgs e)
        {

        }
        private void CtrlHMIParamSet_Click(object sender, EventArgs e)
        {
            OnClickDevice(this.Name);
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            OnParamAction(this.HMIOPParam_ID, this.PLCParamCaption, Action.ON);
        }
        private void btnOff_Click(object sender, EventArgs e)
        {
            OnParamAction(this.HMIOPParam_ID, this.PLCParamCaption, Action.OFF);
        }

        #endregion Control UI

        public enum Action
        {
            ON,
            OFF,
        }
    }
}