using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedXML;
using System.Diagnostics;

namespace WIMARTS.UTIL
{
    //TBD:Add this in iCodemGr project
    public enum VdSourceType
    {
        NONE,
        RedUidGen,
        RedCSVGen,
        ExcelGen,
        XmlGen,
        DbStoreGen,
        RedSSCCGen,
        SerialNo,
        ReadFromHW
    }
    public class VariableDataInfo
    {
        //private string _FieldName;
        //public string FieldName
        //{
        //    get { return _FieldName; }
        //    set { _FieldName = value; }
        //}


        //it contains DLL
        private string _SourceDll;

        public string SourceDll
        {
            get { return _SourceDll; }
            set { _SourceDll = value; }
        }

        /// <summary>
        /// SourceFldName will be refered in Template XML,This is class type in Dll
        /// </summary>
        private VdSourceType _vdSourceType;
        public VdSourceType vdSourceType
        {
            get { return _vdSourceType; }
            set { _vdSourceType = value; }
        }  

        public static List<VariableDataInfo> lstVariableDataInfo;
        public static List<VariableDataInfo> LoadVariableDataInfo()
        {
            //Xml=xml;
            string filspath = SettingsPath.VeriableDataInfo;
            if (!System.IO.File.Exists(filspath))
            {
                lstVariableDataInfo = LoadDefaultInfo();
                GenericXmlSerializer<List<VariableDataInfo>>.Serialize(lstVariableDataInfo, filspath);
            }
            else
                lstVariableDataInfo = GenericXmlSerializer<List<VariableDataInfo>>.Deserialize(filspath);
            return lstVariableDataInfo;
        }

        private static List<VariableDataInfo> LoadDefaultInfo()
        {
            List<VariableDataInfo> lst = new List<VariableDataInfo>();
            VariableDataInfo vInfo = new VariableDataInfo();
            vInfo.SourceDll = "WIMARTS.RedUidGen";
            vInfo.vdSourceType = VdSourceType.RedUidGen;
            lst.Add(vInfo);

            vInfo = new VariableDataInfo();
            vInfo.SourceDll = "WIMARTS.ExcelGen";
            vInfo.vdSourceType = VdSourceType.ExcelGen;
            lst.Add(vInfo);

            vInfo = new VariableDataInfo();
            vInfo.SourceDll = "WIMARTS.RedCSVGen";
            vInfo.vdSourceType = VdSourceType.RedCSVGen;
            lst.Add(vInfo);

            vInfo = new VariableDataInfo();
            vInfo.SourceDll = "WIMARTS.DbStoreGen";
            vInfo.vdSourceType = VdSourceType.DbStoreGen;
            lst.Add(vInfo);

            vInfo = new VariableDataInfo();
            vInfo.SourceDll = "WIMARTS.RedSSCCGen";
            vInfo.vdSourceType = VdSourceType.RedSSCCGen;
            lst.Add(vInfo);

            vInfo = new VariableDataInfo();
            vInfo.SourceDll = "WIMARTS.SerialNo";
            vInfo.vdSourceType = VdSourceType.SerialNo;
            lst.Add(vInfo);

            vInfo = new VariableDataInfo();
            vInfo.SourceDll = "WIMARTS.ReadFromHW";
            vInfo.vdSourceType = VdSourceType.ReadFromHW;
            lst.Add(vInfo);

            return lst;
        }

        public static VdSourceType ConvertVDSourceType(string SourceFld)
        {
            VdSourceType vd = VdSourceType.NONE;
            try
            {
                vd = (VdSourceType)Enum.Parse(typeof(VdSourceType), SourceFld);
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}:{1},{2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
            return vd;
        }

        public static VariableDataInfo Get(VdSourceType vdSourceType)
        {
            if (lstVariableDataInfo.Count == 0)
                return null;
            VariableDataInfo vdInfo = lstVariableDataInfo.Find(itm => itm.vdSourceType == vdSourceType);
            return vdInfo;
        }

         public static bool isMultiDataSource(string SourceFldName)
        {
            if (SourceFldName == VdSourceType.RedCSVGen.ToString())
                return true;
            return false;
        }
    }
}
