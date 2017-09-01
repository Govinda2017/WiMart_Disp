using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMARTS.UTIL;
using System.Windows.Forms;
using System.Drawing;

namespace WIMARTS.INSPECTION
{
    public delegate void HandleDatReceived(string sNewMessage);
    delegate void ProcessICMessage(string sNewMessage, bool IsSerialComm);  
       
    public interface IRedInspection
    {
        string deviceName { get; }     
        
        void Init();//string deviceName, string deviceAddress, string devicePort, PictureBox imgDispCtrl);
        bool Connect();
        bool Disconnect();

        void SubScribeDevice();
        void DeSubScribeDevice(); 
        bool IsConnected();
        event EventHandler OnInspectionFeedback;
    }

    public enum InspectionEVENTS
    {
        Connected,
        ResultArrived
    }

    public class InspectionArgs : EventArgs
    {
        public InspectionEVENTS rcvdEvent;
        public Bitmap ImageResult;
        public string Result;
        public string CodeType;
        public float DecodedTime;
    }
}
