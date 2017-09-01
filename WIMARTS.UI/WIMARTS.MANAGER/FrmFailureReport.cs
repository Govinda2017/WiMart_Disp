using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iPRINT.DB.BLL;

namespace iPRINT.MANAGER
{
    public partial class FrmFailureReport : Form
    {
        BLLManager bllMgr;

        public FrmFailureReport()
        {
            InitializeComponent();
            bllMgr = new BLLManager();
        }

        private void FrmFailureReport_Load(object sender, EventArgs e)
        {
            //dgvDataReport.DataSource = bllMgr.ItemDetailsBLL.GetFIFOFailedProducts();
            //dgvFailedItems.DataSource = bllMgr.ItemDetailsBLL.GetFIFOFailedItems();
        }

        private void FrmFailureReport_Shown(object sender, EventArgs e)
        {

        }
    }
}
