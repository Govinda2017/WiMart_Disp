using System;
using System.IO.Ports;
using System.Windows.Forms;
using WIMARTS.UTIL;

namespace RedCommunication.SERIAL
{
    /// <summary>
    /// Persistent settings
    /// </summary>
    public class ComSettings
    {
        string m_fileName = Application.StartupPath + "\\" + "com1x.ini";
        PortBase m_Port;
        public PortBase Port
        {
            get { return m_Port; }
            set { m_Port = value; }
        }
        PortOptions m_Option;

        public PortOptions Option
        {
            get { return m_Option; }
            set { m_Option = value; }
        }
        /// <summary>
        ///   Read the settings from disk. </summary>
        public bool Read()
        {
            try
            {
                IniFile ini = new IniFile(m_fileName);
                m_Port.PortName = ini.ReadValue("Port", "PortName", m_Port.PortName);
                m_Port.BaudRate = ini.ReadValue("Port", "BaudRate", m_Port.BaudRate);
                m_Port.DataBits = ini.ReadValue("Port", "DataBits", m_Port.DataBits);
                m_Port.Parity = (Parity)Enum.Parse(typeof(Parity), ini.ReadValue("Port", "Parity", m_Port.Parity.ToString()));
                m_Port.StopBits = (StopBits)Enum.Parse(typeof(StopBits), ini.ReadValue("Port", "StopBits", m_Port.StopBits.ToString()));
                m_Port.Handshake = (Handshake)Enum.Parse(typeof(Handshake), ini.ReadValue("Port", "Handshake", m_Port.Handshake.ToString()));

                m_Option.AppendToSend = (AppendType)Enum.Parse(typeof(AppendType), ini.ReadValue("Option", "AppendToSend", m_Option.AppendToSend.ToString()));
                m_Option.HexOutput = bool.Parse(ini.ReadValue("Option", "HexOutput", m_Option.HexOutput.ToString()));
                m_Option.MonoFont = bool.Parse(ini.ReadValue("Option", "MonoFont", m_Option.MonoFont.ToString()));
                m_Option.LocalEcho = bool.Parse(ini.ReadValue("Option", "LocalEcho", m_Option.LocalEcho.ToString()));
                m_Option.StayOnTop = bool.Parse(ini.ReadValue("Option", "StayOnTop", m_Option.StayOnTop.ToString()));
                m_Option.FilterUseCase = bool.Parse(ini.ReadValue("Option", "FilterUseCase", m_Option.FilterUseCase.ToString()));
                return true;
            }
            catch 
            {
                
            }
            return false;
		}

        /// <summary>
        ///   Write the settings to disk. </summary>
        public void Write()
        {
            string m_fileName = Application.StartupPath + "\\" + Port.PortName + "x.ini";
            IniFile ini = new IniFile(m_fileName);
            ini.WriteValue("Port", "PortName", Port.PortName);
            ini.WriteValue("Port", "BaudRate", Port.BaudRate);
            ini.WriteValue("Port", "DataBits", Port.DataBits);
            ini.WriteValue("Port", "Parity", Port.Parity.ToString());
            ini.WriteValue("Port", "StopBits", Port.StopBits.ToString());
            ini.WriteValue("Port", "Handshake", Port.Handshake.ToString());

            ini.WriteValue("Option", "AppendToSend", m_Option.AppendToSend.ToString());
            ini.WriteValue("Option", "HexOutput", m_Option.HexOutput.ToString());
            ini.WriteValue("Option", "MonoFont", m_Option.MonoFont.ToString());
            ini.WriteValue("Option", "LocalEcho", m_Option.LocalEcho.ToString());
			ini.WriteValue("Option", "StayOnTop", m_Option.StayOnTop.ToString());
			ini.WriteValue("Option", "FilterUseCase", m_Option.FilterUseCase.ToString());
		}

        public ComSettings()
        { 
            m_Port = new PortBase();
            m_Option = new PortOptions();
        }
        public ComSettings(string oPortName)
        {
            m_Port = new PortBase(oPortName);
            m_Option = new PortOptions();
        }
        public ComSettings(string SetFile,bool IsRead)
        {
            m_Port = new PortBase(SetFile);
            m_Option = new PortOptions();
            m_fileName = Application.StartupPath + "\\" + SetFile + "x.ini";
            if (IsRead == true)
            {
                Read();
            }
        }
	}       
    /// <summary> Port settings. </summary>
    public class PortBase
    {
        public string PortName = "COM1";
        public int BaudRate = 38400;
        //public int BaudRate = 19200;
        public int DataBits = 8;
        public System.IO.Ports.Parity Parity = System.IO.Ports.Parity.None;
        public System.IO.Ports.StopBits StopBits = System.IO.Ports.StopBits.One;
        public System.IO.Ports.Handshake Handshake = System.IO.Ports.Handshake.None;

        public PortBase()
        { 
        
        }
        public PortBase(string oPortName)
        {
            PortName = oPortName;
        }
    }

    /// <summary> Option settings. </summary>
    public class PortOptions
    {
        public  AppendType AppendToSend = AppendType.AppendCRLF;
        public  bool HexOutput = false;
        public  bool MonoFont = true;
        public  bool LocalEcho = true;
        public  bool StayOnTop = false;
		public  bool FilterUseCase = false;
		public  string LogFileName = "";
        public PortOptions()
        {
    
        }
	}
    public enum AppendType
    {
        AppendNothing,
        AppendCR,
        AppendLF,
        AppendCRLF
    }
}
