using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;

namespace WIMARTS.DB.BLL
{
	public partial class BLLManager
    {
        public enum MasterStatus
        {
            All = -1,
            Created = 0,
            Running = 1,
            Abonden = 2,
            Completed = 3,
            CreatedOrAbonden = 4,
        }
        public enum DetailsStatus
        {
            All = -1,
            Created = 0,
            Scrapped = 1,
            Scanned = 2,
            Wasted = 3,
            Dispatched = 4,
            Archived = 5,
            NotDispatched=6, 
        }

        public enum Flag
        {
            MasterID = 0,
            ProdCode = 1,
            BatchName = 2,
            Status = 3,
        }

        public enum Roles
        {
            All = 0,
            Admin = 1,
            Superviser = 2,
            Operator = 3,
        }

        private CustomerMasterBLL _CustomerMasterBLL;

        public CustomerMasterBLL CustomerMasterBLL
        {
            get { return _CustomerMasterBLL; }
            set { _CustomerMasterBLL = value; }
        }

        private CompanyMasterBLL _CompanyMasterBLL;

        public CompanyMasterBLL CompanyMasterBLL
        {
            get { return _CompanyMasterBLL; }
            set { _CompanyMasterBLL = value; }
        }

		private RoleMasterBLL _RoleMasterBLL;

		public RoleMasterBLL RoleMasterBLL
		{
			get { return _RoleMasterBLL; }
			set { _RoleMasterBLL = value; }
		}

		private TemplateDesignsBLL _TemplateDesignsBLL;

		public TemplateDesignsBLL TemplateDesignsBLL
		{
			get { return _TemplateDesignsBLL; }
			set { _TemplateDesignsBLL = value; }
		}

		private UserMasterBLL _UserMasterBLL;

		public UserMasterBLL UserMasterBLL
		{
			get { return _UserMasterBLL; }
			set { _UserMasterBLL = value; }
		}

		private PrintMasterBLL _PrintMasterBLL;

		public PrintMasterBLL PrintMasterBLL
		{
			get { return _PrintMasterBLL; }
			set { _PrintMasterBLL = value; }
		}

		private DispatchMasterBLL _DispatchMasterBLL;

		public DispatchMasterBLL DispatchMasterBLL
		{
			get { return _DispatchMasterBLL; }
			set { _DispatchMasterBLL = value; }
		}

		private DispatchDetailsBLL _DispatchDetailsBLL;

		public DispatchDetailsBLL DispatchDetailsBLL
		{
			get { return _DispatchDetailsBLL; }
			set { _DispatchDetailsBLL = value; }
		}
    
		private ProductMasterBLL _ProductMasterBLL;

		public ProductMasterBLL ProductMasterBLL
		{
			get { return _ProductMasterBLL; }
			set { _ProductMasterBLL = value; }
		}

		private InspectionMasterBLL _InspectionMasterBLL;

		public InspectionMasterBLL InspectionMasterBLL
		{
			get { return _InspectionMasterBLL; }
			set { _InspectionMasterBLL = value; }
		}

        private ItemDetailsBLL _ItemDetailsBLL;

        public ItemDetailsBLL ItemDetailsBLL
        {
            get { return _ItemDetailsBLL; }
            set { _ItemDetailsBLL = value; }
        }

        private UIDLineHolderBLL _UIDLineHolderBLL;

        public UIDLineHolderBLL UIDLineHolderBLL
        {
            get { return _UIDLineHolderBLL; }
            set { _UIDLineHolderBLL = value; }
        }

        private TransporterDetailsBLL _TransporterDetailsBLL;

        public TransporterDetailsBLL TransporterDetailsBLL
        {
            get { return _TransporterDetailsBLL; }
            set { _TransporterDetailsBLL = value; }
        }

		public BLLManager()
		{
            CustomerMasterBLL = new BLL.CustomerMasterBLL();
            CompanyMasterBLL = new BLL.CompanyMasterBLL();
			RoleMasterBLL = new RoleMasterBLL();
			TemplateDesignsBLL = new TemplateDesignsBLL();
			UserMasterBLL = new UserMasterBLL();
			PrintMasterBLL = new PrintMasterBLL();
			DispatchMasterBLL = new DispatchMasterBLL();
			DispatchDetailsBLL = new DispatchDetailsBLL();
			ProductMasterBLL = new ProductMasterBLL();
			InspectionMasterBLL = new InspectionMasterBLL();
	        ItemDetailsBLL = new ItemDetailsBLL();
            UIDLineHolderBLL = new UIDLineHolderBLL();
            TransporterDetailsBLL = new TransporterDetailsBLL();
		}

        public bool CloseDB()
        {
            return DAL.DbProviderHelper.CloseConn();
        }

	}
}
