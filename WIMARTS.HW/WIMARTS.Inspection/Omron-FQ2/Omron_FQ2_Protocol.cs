using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WIMARTS.INSPECTION
{
    class Omron_FQ2_Protocol
    {
        public static string Measure()
        {
            string cmd = string.Empty;
            cmd = Commands.SingleMeas + Commands.endTag;
            return cmd;
        }


        public static string GetScene()
        {
            string cmd = string.Empty;
            cmd = Commands.Scene + Commands.endTag;
            return cmd;
        }

        public static string SetScene(int scene)
        {
            string cmd = string.Empty;
            cmd = Commands.Scene + Commands.strSpace + scene + Commands.endTag;
            return cmd;
        }

        public static string StringOutputON(int Fld, string strCode, int enable)
        {
            string cmd = string.Empty;
            cmd = Commands.ItemData + Commands.strSpace + Fld + Commands.strSpace + strCode + Commands.strSpace + enable + Commands.endTag;
            return cmd;
        }

        //public static string CodeStringOutputON(int fld)
        //{
        //    string cmd = string.Empty;
        //    cmd = Commands.ItemData + Commands.strSpace + fld + Commands.strSpace + Commands.TCSTRON + Commands.strSpace + "1" + Commands.endTag;
        //    return cmd;
        //}
        //public static string OCRStringOutputON(int fld)
        //{
        //    string cmd = string.Empty;
        //    cmd = Commands.ItemData + Commands.strSpace + fld + Commands.strSpace + Commands.OCRSTRON + Commands.strSpace + "1" + Commands.endTag;
        //    return cmd;
        //}
      public class Commands
      {
            public static string strSpace = " ";
            public static string endTag = "$0D";

            public static string Scene = "S";//SCENE$0D

            public static string SingleMeas = "M";//M$0D
            public static string ContinuousMeas = "M /C";
            public static string EndMeas = "M /E";

            public static string ItemData = "ID";//GET::ID itm_Number Extrnl_Rfrnce$0D /ITEMDATA itm_Number Extrnl_Rfrnce$0D //////SET::ID itm_Number Extrnl_Rfrnce Enable/Disable$0D /ITEMDATA itm_Number Extrnl_Rfrnce Enable/Disable$0D
            public static string PositionData = "PD";//GET::PD itm_Number Extrnl_Rfrnce$0D /POSITIONDATA itm_Number Extrnl_Rfrnce$0D  /////GET::PD itm_Number Extrnl_Rfrnce Enable/Disable$0D /POSITIONDATA itm_Number Extrnl_Rfrnce Enable/Disable$0D

            public static string HWVersion = "VERGET/H";
            public static string SWVersion = "VERGET/S";


            public static string TCSTRON = "125";          
            public static string OCRSTRON = "138";
        }
    }
}
