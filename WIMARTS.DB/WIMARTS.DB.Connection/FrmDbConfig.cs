using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using WIMARTS.UTIL;
using WIMARTS.UTIL.SystemIntegrity;
using System.Data;
using System.Data.Sql;
namespace WIMARTS.DB.Connection
{
    public partial class FrmDbConfig : Form
    {
        string AppStartUpPath = string.Empty;
        public FrmDbConfig(string DirName)
        {
            InitializeComponent();
            AppStartUpPath = DirName;
        }

        private void FrmDbConfig_Load(object sender, EventArgs e)
        {
            LoadServerNames();
            ReadSettings(AppStartUpPath);
        }

        private string DataBaseName = "WIMARTS";
        private void ReadSettings(string DirName)
        {
            if (string.IsNullOrEmpty(DbConnectionConfig.mDbConfig.Database))
            {
                DbConnectionConfig.LoadConection(DirName);
            }
            if (string.IsNullOrEmpty(DbConnectionConfig.mDbConfig.Database))
            {
                TXT_DbName.Text = DataBaseName;
                return;
            }

            cmbServerNames.Text = DbConnectionConfig.mDbConfig.DataSourcePath;
            TXT_DbName.Text = DbConnectionConfig.mDbConfig.Database;
            TXT_UserName.Text = DbConnectionConfig.mDbConfig.UserName;
            TXT_PWD.Text = SimpleEncrypt.Decrypt(DbConnectionConfig.mDbConfig.Password);
        }
        private void BTN_SaveHWSysConfig_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbServerNames.Text))
            {
                MessageBox.Show("PLEASE Enter Database Server");
                return;
            }
            else if (string.IsNullOrEmpty(TXT_DbName.Text))
            {
                MessageBox.Show("PLEASE Enter Database Name");
                return;
            }
            else if (string.IsNullOrEmpty(TXT_UserName.Text))
            {
                MessageBox.Show("PLEASE Enter User Name");
                return;
            }
            else if (string.IsNullOrEmpty(TXT_PWD.Text))
            {
                MessageBox.Show("PLEASE Enter Password");
                return;
            }
            try
            {
                List<DbConnectionConfig> lst = new List<DbConnectionConfig>();

                DbConnectionConfig db = new DbConnectionConfig();
                db.DataSourcePath = cmbServerNames.Text;
                db.Database = TXT_DbName.Text;
                db.UserName = TXT_UserName.Text;
                string strEncrypt = SimpleEncrypt.Encrypt(TXT_PWD.Text);
                db.Password = strEncrypt;
                lst.Add(db);
                //MessageBox.Show(AppStartUpPath);
                DbConnectionConfig.saveConnections(AppStartUpPath, lst);
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);

            }
            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
            //Application.Exit();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            TXT_DbName.Enabled = true;
        }

        private void LoadServerNames()
        {
            string myServer = Environment.MachineName;

            DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
            for (int i = 0; i < servers.Rows.Count; i++)
            {
                if (myServer == servers.Rows[i]["ServerName"].ToString()) ///// used to get the servers in the local machine////
                {
                    if ((servers.Rows[i]["InstanceName"] as string) != null)
                        cmbServerNames.Items.Add(servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"]);
                    else
                        cmbServerNames.Items.Add(servers.Rows[i]["ServerName"]);
                }
            }
        }
    }
}