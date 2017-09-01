using System;
using System.Data.SqlClient;
using System.Diagnostics;
using WIMARTS.UTIL;
using WIMARTS.UTIL.SystemIntegrity;
using System.IO;
using System.Collections.Generic;
using RedXML;

namespace WIMARTS.DB.Connection
{
    public class CreateDbConnection
    {
        public static string AppStartUpPath = string.Empty;
        public string GetConnectionString()
        {
            try
            {
                if (string.IsNullOrEmpty(DbConnectionConfig.mDbConfig.Database))
                {
                    if (!string.IsNullOrEmpty(AppStartUpPath)) DbConnectionConfig.LoadConection();
                    else DbConnectionConfig.LoadConection(AppStartUpPath);
                }

                SqlConnectionStringBuilder sqlconn = new SqlConnectionStringBuilder();
                sqlconn.DataSource = DbConnectionConfig.mDbConfig.DataSourcePath;
                sqlconn.UserID = DbConnectionConfig.mDbConfig.UserName;
                sqlconn.Password = SimpleEncrypt.Decrypt(DbConnectionConfig.mDbConfig.Password);
                sqlconn.InitialCatalog = DbConnectionConfig.mDbConfig.Database;

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = sqlconn.ConnectionString;
                sqlconn.MultipleActiveResultSets = true;
                sqlconn.PersistSecurityInfo = true;
                return sqlconn.ConnectionString;
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
                return string.Empty;
            }
        }
    }
    public class DbConnectionConfig
    {
        private string _DataSourcePath;

        public string DataSourcePath
        {
            get { return _DataSourcePath; }
            set { _DataSourcePath = value; }
        }

        private string _Database;

        public string Database
        {
            get { return _Database; }
            set { _Database = value; }
        }

        private string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private static List<DbConnectionConfig> LstDbConn = new List<DbConnectionConfig>();
        public static DbConnectionConfig mDbConfig = new DbConnectionConfig();

        public static string GetFilePath(string AppStartUpPath)
        {
            FileInfo fi = new FileInfo(WIMARTS.UTIL.SettingsPath.DBConnection);

            string DirectoryName = AppStartUpPath + WIMARTS.UTIL.SettingsPath.InnerDir;
            if (Directory.Exists(DirectoryName) == false)
                Directory.CreateDirectory(DirectoryName);
            string FileName = DirectoryName + "\\" + fi.Name;
            return FileName;
        }

        public static List<DbConnectionConfig> LoadConection(string StartUpPath) //For set up installation
        {
            //"\\TnT_DBConfig.bin";        
            //string FileName = UTILS.SettingsPath.DBConnection;

            string FileName = GetFilePath(StartUpPath);
            if (File.Exists(FileName))   //SettingsPath.LabelDataSetup))
            {
                LstDbConn = GenericXmlSerializer<List<DbConnectionConfig>>.Deserialize(FileName); //SettingsPath.LabelDataSetup
                mDbConfig = LstDbConn[0];
            }
            return LstDbConn;
        }
        public static List<DbConnectionConfig> LoadConection() //For Current Activated File
        {
            try
            {
                string FileName = WIMARTS.UTIL.SettingsPath.DBConnection;
                if (File.Exists(FileName))  
                {
                    LstDbConn = GenericXmlSerializer<List<DbConnectionConfig>>.Deserialize(FileName); //SettingsPath.LabelDataSetup
                    mDbConfig = LstDbConn[0];
                }
                return LstDbConn;
            }
            catch (FileNotFoundException ex)
            {
                throw ex;
            }
        }

        public static void saveConnections(string AppStartUpPath, List<DbConnectionConfig> Lst)
        {
            string FileName = GetFilePath(AppStartUpPath);
            LstDbConn = Lst;
            GenericXmlSerializer<List<DbConnectionConfig>>.Serialize(LstDbConn, FileName);//UTILS.SettingsPath.DBConnection);
            mDbConfig = LstDbConn[0];
        }

        private static bool CheckDatabaseExists(SqlConnection tmpConn, string databaseName)
        {
            string sqlCreateDBQuery;
            bool result = false;

            try
            {
                //tmpConn = new SqlConnection("server=" + tmpConn.DataSource + ";Trusted_Connection=yes");

                sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name= '{0}'", databaseName);

                using (tmpConn)
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
                    {
                        tmpConn.Open();
                        int databaseID = (int)sqlCmd.ExecuteScalar();
                        tmpConn.Close();
                        result = (databaseID > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                result = false;
            }
            return result;
        }
        public static bool CheckSQLDB()
        {
            if (string.IsNullOrEmpty(DbConnectionConfig.mDbConfig.Database) == true)
                return false;

            SqlConnectionStringBuilder sqlconn = new SqlConnectionStringBuilder();
            sqlconn.DataSource = DbConnectionConfig.mDbConfig.DataSourcePath;
            sqlconn.UserID = DbConnectionConfig.mDbConfig.UserName;
            sqlconn.Password = SimpleEncrypt.Decrypt(DbConnectionConfig.mDbConfig.Password);
            sqlconn.InitialCatalog = DbConnectionConfig.mDbConfig.Database;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = sqlconn.ConnectionString;
            return CheckDatabaseExists(con, DbConnectionConfig.mDbConfig.Database);
        }

    }

    public class SimpleEncrypt
    {
        static int key = 25;
        public static string Encrypt(string inString)
        {
            string outString = string.Empty;

            Random rnd = new Random(DateTime.Now.Millisecond);

            foreach (char ch in inString)
            {
                char newCh = (char)(ch + key);
                outString += newCh;
                int rndNum = rnd.Next(60, 125);
                char rndCh = (char)rndNum;
                outString += rndCh;
            }
            return outString;
        }
        public static string Decrypt(string inString)
        {
            string outString = string.Empty;
            bool isSkip = false;
            foreach (char ch in inString)
            {
                if (isSkip == false)
                {
                    char newCh = (char)(ch - key);
                    outString += newCh;
                    isSkip = true;
                }
                else
                {
                    isSkip = false;
                }
            }
            return outString;
        }
    }
}
