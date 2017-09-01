using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Reflection;
using iPRINT.PrintJob;
using iPRINT.DB.BusinessObjects;

namespace iPRINT.PrintJob
{
    public class PropHandler
    {
        public static object GetPropertyValue(JobInfo jb, string FldName)
        {
            if (string.IsNullOrEmpty(FldName) == true)
                return string.Empty;

            string retVal = string.Empty;
            object property = null;
             
            PropertyInfo propInfo = typeof(JobInfo).GetProperty(FldName);
            if (propInfo != null)
            {
                if (jb != null)
                {
                    property = propInfo.GetValue(jb, null);
                    return property;
                }
            }           
            return property;
        }
    }
}
