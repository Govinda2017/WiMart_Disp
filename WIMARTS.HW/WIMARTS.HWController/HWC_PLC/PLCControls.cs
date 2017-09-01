using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedXML;
using System.IO;

namespace rcs.CONTROLS
{
    public static class PLCSettings
    {
        public static List<PLCControls> Read(string filePath)
        {
            List<PLCControls> lstPLCControls = new List<PLCControls>();

            if (!System.IO.File.Exists(filePath))
            {
                lstPLCControls = DefaultCreate();
            }
            else
                lstPLCControls = GenericXmlSerializer<List<PLCControls>>.Deserialize(filePath);
            return lstPLCControls;
        }
        public static bool Write(List<PLCControls> lstPLCControls, string filePath)
        {
            string dir = Path.GetDirectoryName(filePath);

            if (Directory.Exists(dir) == false)
                Directory.CreateDirectory(dir);
           
            GenericXmlSerializer<List<PLCControls>>.Serialize(lstPLCControls, filePath);
            return true;
        }
        private static List<PLCControls> DefaultCreate()
        {
            List<PLCControls> lstPLCControls = new List<PLCControls>();

            PLCControls obj = new PLCControls();
            obj.ComponentParam = "TCP";
            obj.Register = "127.0.0.1";
            obj.RegisterValue = 399;
            obj.Remark = string.Empty;
            obj.MinValue = 0;
            obj.MaxValue = 0;
            lstPLCControls.Add(obj);

            return lstPLCControls;
        }

    }

    public class PLCnRUN_if
    {
        public enum RunAction
        {
            CloseMe,

            plc_CONNECTED,
            plc_DISCONNECTED,

            plc_FBUpdate_CamSenserCount,
            plc_FBUpdate_SoftUpdateCount,
            plc_FBUpdate_EjeSenserCount,
            plc_FBUpdate_MachineStatus,
            plc_FBUpdate_InputStatus,
            plc_FBUpdate_OutputStatus,

            plc_DataUpdate,
            plc_HMIInputStatusUpdate,

            plc_ConveyorStart,
            plc_ConveyorStop,
            plc_ConveyorClear,
            plc_ConveyorFreeMove,

            plc_TillDateCount,
            plc_LogDisplay,
        }

    }

    public class RedEventArgs : EventArgs
    {
        public PLCnRUN_if.RunAction action;
        public string RegisterNo;
        public long RegisterValue;
        //public string cmd;
    }

    public class PLCControls
    {
        #region XML PROPERTY

        string _ComponentParam = string.Empty;
        public string ComponentParam
        {
            get { return _ComponentParam; }
            set { _ComponentParam = value; }
        }

        string _Register = "0000";
        public string Register
        {
            get { return _Register; }
            set { _Register = value; }
        }

        decimal _RegisterValue = 0;
        public decimal RegisterValue
        {
            get { return _RegisterValue; }
            set { _RegisterValue = value; }
        }

        string _Remark = string.Empty;
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        decimal _MinValue = 0;
        public decimal MinValue
        {
            get { return _MinValue; }
            set { _MinValue = value; }
        }

        decimal _MaxValue = 0;
        public decimal MaxValue
        {
            get { return _MaxValue; }
            set { _MaxValue = value; }
        }

        #endregion XML PROPERTY

        public PLCControls()
        {

        }
    }

    public enum MCComponent
    {
        Printer,
        Vision,
        RejectionMarker,
        RejectionMechanism,
        RejectionConfirmationSensor,
        AcceptedConfirmationSensor,


    }
}
