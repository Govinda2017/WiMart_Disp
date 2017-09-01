using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iPRINT.DB.BusinessObjects;
using System.Drawing;

namespace iPRINT.PrintJob
{
    public enum JobPrintMode
    {
        Batch = 0,
        ProductionCycle,
        Job        
    }

    public enum Jobstatus
    {
        Created=0, 
        Running,
        Closed
    }

    public class JobInfo
    {  
        private Decimal _JobID;

        public Decimal JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }

        private Decimal _ProdID;

        public Decimal ProdID
        {
            get { return _ProdID; }
            set { _ProdID  = value; }
        }

        private int _PrintDtlsID;

        public int PrintDtlsID
        {
            get { return _PrintDtlsID; }
            set { _PrintDtlsID = value; }
        }

        private string _BatchName;

        public string BatchName
        {
            get { return _BatchName; }
            set { _BatchName = value; }
        }

        private string _printerName;

        public string PrinterName
        {
            get { return _printerName; }
            set { _printerName = value; }
        }

        private string _ProdName;

        public string ProdName
        {
            get { return _ProdName; }
            set { _ProdName = value; }
        }

        private string _ProdCode;

        public string ProdCode
        {
            get { return _ProdCode; }
            set { _ProdCode = value; }
        }

        private string _Category;

        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }   

        private decimal _MRP;

        public decimal MRP
        {
            get { return _MRP; }
            set { _MRP = value; }
        }

        private DateTime _MfgDate;

        public DateTime MfgDate
        {
            get { return _MfgDate; }
            set { _MfgDate = value; }
        }

        private Nullable<DateTime> _ExpDate;

        public Nullable<DateTime> ExpDate
        {
            get { return _ExpDate; }
            set { _ExpDate = value; }
        }

        private string _GTIN;

        public string GTIN
        {
            get { return _GTIN; }
            set { _GTIN = value; }
        }

        private string _TemplateName;

        public string TemplateName
        {
            get { return _TemplateName; }
            set { _TemplateName = value; }
        }

        private string _Template;

        public string Template
        {
            get { return _Template; }
            set { _Template = value; }
        }

        private decimal _Quantity;

        public decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        private string _CompanyName;
        public string CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }

        private string _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
    
        private byte[] _Logo;
        public byte[] Logo
        {
            get { return _Logo; }
            set { _Logo = value; }
        }

        /// <summary>
        /// Here purpose of this object in ,if in case fields are get added in jobdetails table in future,
        /// so only needs to update bussiness objects as it is required,no need to make any change in jobInfo class.
        /// </summary>



      
    }
}
