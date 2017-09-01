using System.Reflection;

namespace WIMARTS.DISPATCH
{
    public enum AppCode
    {
        Printing = 1,
        Production = 2,
        Dispatch = 3,
    }

    public enum ComapanyCode
    {
        Nilons = 1,
    }

    public enum PlantCode
    {
        Utran = 1,
        Musali = 2,
        Dambhurni = 3,
    }    
    public static class RedAssemblyInfo
    {
        //public static string APPNAME = RedAssemblyInfo.Product;
       
        #region ASSEMBLY INFORMATION

        public static string Title
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }
        public static string Version
        {
            get
            {
                int major = Assembly.GetExecutingAssembly().GetName().Version.Major;
                int minor = Assembly.GetExecutingAssembly().GetName().Version.Minor;
                int build = Assembly.GetExecutingAssembly().GetName().Version.Build;
                //int revision = Assembly.GetExecutingAssembly().GetName().Version.Revision;
                
                string version = major + "." + minor + "." + build;
                return version;
                //return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        public static string VersionMain
        {
            get
            {
                int major = Assembly.GetExecutingAssembly().GetName().Version.Major;
                int minor = Assembly.GetExecutingAssembly().GetName().Version.Minor;

                string version = major + "-" + minor;
                return version;
            }
        }
        public static string Description
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }
        public static string Product
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "RTPL05";
                }
                if(string.IsNullOrEmpty(((AssemblyProductAttribute)attributes[0]).Product )== true)
                    return "RTPL05";
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }
        public static string Copyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        public static string Company
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }

        #endregion ASSEMBLY INFORMATION
    }
}
