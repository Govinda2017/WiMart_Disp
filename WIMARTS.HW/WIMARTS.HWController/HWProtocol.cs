using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WIMARTS.HWController
{
    internal class HWCommands
    {
        ///COMMANDS
        ///<SHT><CommandTag><Data><EHT>
        ///$FE$01$00$FF
        ///

        //Start & ENd Header Tags
        public static string SHT = "$FE"; //#
        public static string EHT = "$FF"; //$

        //DATA SETTING Cmds
        public static string DRESET = "$01";
        public static string DMODESTART = "$02";
        public static string DCAMTRIGGER = "$03";
        public static string DCAMPULSE = "$04";
        public static string DCONDIR = "$05";//0:Rev;1:FWD
        public static string DERRACT = "$06";//0:NoAction; 1:Stop; 2:Reverse

        //HWC Cmds
        public static string CCAMTRIGGER = "$15";
        public static string CEJTRIGGER = "$16";
        public static string CERRORSTOPINDIC = "$17";
        public static string CSTARTBTNPRESS = "$18";

        //App Online Cmds
        public static string ASTARTINSP = "$29";
        public static string ASTOPINSP = "$2A";
        public static string ACAMRESPONSE = "$2B";

        //App Test Mode Cmds
        public static string TMODESTART = "$3D";
        public static string TCAMTRIGGER = "$3E";
        public static string TCAMPULSE = "$3F";
        public static string TCAMSTART = "$40";
        public static string TCAMSTOP = "$41";
        public static string TSTARTCONV = "$42";
        public static string TSTOPCONV = "$43";
        public static string TSTARTBUZZ = "$44";
        public static string TSTOPBUZZ = "$45";
        public static string TBTCTETON = "$46";
        //   public static 
        public static string CURRENTMODEEXIT = "$64";
    }
}