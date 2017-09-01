using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMARTS.DB.BLL;
using WIMARTS.DB.BusinessObjects;

namespace WIMARTS.DB.HELPER
{
    public class DbHelper
    {
        public BLLManager DBManager = new BLLManager();

        //public string GetDataXML(List<Field> lstField)
        //{
        //    string xml = "<Table>";
        //    foreach (Field item in lstField)
        //    {
        //        xml += "<Field>";
        //        xml += "<Title>" + item.TITLE + "</Title>";
        //        xml += "<NAME>" + item.NAME + "</NAME>";
        //        xml += "<DBTYPE>" + item.DBTYPE + "</DBTYPE>";
        //        xml += "<VALUE>" + item.VALUE + "</VALUE>"; 
        //        xml += "</Field>";
        //    }
        //    xml += "</Table>";
        //    return xml;
        //}
    }
}
