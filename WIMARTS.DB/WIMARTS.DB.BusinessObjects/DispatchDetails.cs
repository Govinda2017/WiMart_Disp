using System;
using System.Text;

namespace WIMARTS.DB.BusinessObjects
{
	[Serializable()]
	public partial class DispatchDetails
	{
		private int _DispDetailsID;

		public int DispDetailsID
		{
			get { return _DispDetailsID; }
			set { _DispDetailsID = value; }
		}

		private int _DispMasterID;

		public int DispMasterID
		{
			get { return _DispMasterID; }
			set { _DispMasterID = value; }
		}

        private string _ProdCode;

		public string ProdCode
		{
			get { return _ProdCode; }
			set { _ProdCode = value; }
		}

		private Decimal _QtytoDispatch;

		public Decimal QtytoDispatch
		{
			get { return _QtytoDispatch; }
			set { _QtytoDispatch = value; }
		}

        private Decimal _MinQty;

        public Decimal MinQty
        {
            get { return _MinQty; }
            set { _MinQty = value; }
        }

        private Decimal _MaxQty;

        public Decimal MaxQty
        {
            get { return _MaxQty; }
            set { _MaxQty = value; }
        }

        private Decimal _DispatchedQty;

        public Decimal DispatchedQty
        {
            get { return _DispatchedQty; }
            set { _DispatchedQty = value; }
        }

		private DateTime _CreatedDate;

		public DateTime CreatedDate
		{
			get { return _CreatedDate; }
			set { _CreatedDate = value; }
		}

		private DateTime _LUDate;

		public DateTime LUDate
		{
			get { return _LUDate; }
			set { _LUDate = value; }
		}

		private string _Remark;

		public string Remark
		{
			get { return _Remark; }
			set { _Remark = value; }
		}

		public DispatchDetails()
		{ }

		public DispatchDetails(int DispDetailsID,int DispMasterID,string ProdCode,Decimal QtytoDispatch,Decimal MaxQty,Decimal MinQty,  Decimal DispatchedQty, DateTime CreatedDate,DateTime LUDate,string Remark)
		{
			this.DispDetailsID = DispDetailsID;
			this.DispMasterID = DispMasterID;
			this.ProdCode = ProdCode;
			this.QtytoDispatch = QtytoDispatch;
            this.MaxQty = MaxQty;
            this.MinQty = MinQty;
            this.DispatchedQty = DispatchedQty;
			this.CreatedDate = CreatedDate;
			this.LUDate = LUDate;
			this.Remark = Remark;
		}

        public override string ToString()
        {
            return "DispDetailsID = " + DispDetailsID.ToString() + ",DispMasterID = " + DispMasterID.ToString() + ",ProdCode = " + ProdCode + ",QtytoDispatch = " + QtytoDispatch.ToString() + ",MaxQty=" + MaxQty.ToString() + ",MinQty=" + MinQty.ToString() + ",DispatchedQty=" + DispatchedQty.ToString() + ",CreatedDate = " + CreatedDate.ToString() + ",LUDate = " + LUDate.ToString() + ",Remark = " + Remark;
        }

		public class DispDetailsIDComparer : System.Collections.Generic.IComparer<DispatchDetails>
		{
			public SorterMode SorterMode;
			public DispDetailsIDComparer()
			{ }
			public DispDetailsIDComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchDetails> Membres
			int System.Collections.Generic.IComparer<DispatchDetails>.Compare(DispatchDetails x, DispatchDetails y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.DispDetailsID.CompareTo(x.DispDetailsID);
				}
				else
				{
					return x.DispDetailsID.CompareTo(y.DispDetailsID);
				}
			}
			#endregion
		}
		public class DispMasterIDComparer : System.Collections.Generic.IComparer<DispatchDetails>
		{
			public SorterMode SorterMode;
			public DispMasterIDComparer()
			{ }
			public DispMasterIDComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchDetails> Membres
			int System.Collections.Generic.IComparer<DispatchDetails>.Compare(DispatchDetails x, DispatchDetails y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.DispMasterID.CompareTo(x.DispMasterID);
				}
				else
				{
					return x.DispMasterID.CompareTo(y.DispMasterID);
				}
			}
			#endregion
		}
		
		public class QtytoDispatchComparer : System.Collections.Generic.IComparer<DispatchDetails>
		{
			public SorterMode SorterMode;
			public QtytoDispatchComparer()
			{ }
			public QtytoDispatchComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchDetails> Membres
			int System.Collections.Generic.IComparer<DispatchDetails>.Compare(DispatchDetails x, DispatchDetails y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.QtytoDispatch.CompareTo(x.QtytoDispatch);
				}
				else
				{
					return x.QtytoDispatch.CompareTo(y.QtytoDispatch);
				}
			}
			#endregion
		}
		public class DispatchedQtyComparer : System.Collections.Generic.IComparer<DispatchDetails>
		{
			public SorterMode SorterMode;
			public DispatchedQtyComparer()
			{ }
			public DispatchedQtyComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchDetails> Membres
			int System.Collections.Generic.IComparer<DispatchDetails>.Compare(DispatchDetails x, DispatchDetails y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.DispatchedQty.CompareTo(x.DispatchedQty);
				}
				else
				{
					return x.DispatchedQty.CompareTo(y.DispatchedQty);
				}
			}
			#endregion
		}
		public class CreatedDateComparer : System.Collections.Generic.IComparer<DispatchDetails>
		{
			public SorterMode SorterMode;
			public CreatedDateComparer()
			{ }
			public CreatedDateComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchDetails> Membres
			int System.Collections.Generic.IComparer<DispatchDetails>.Compare(DispatchDetails x, DispatchDetails y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.CreatedDate.CompareTo(x.CreatedDate);
				}
				else
				{
					return x.CreatedDate.CompareTo(y.CreatedDate);
				}
			}
			#endregion
		}
		public class LUDateComparer : System.Collections.Generic.IComparer<DispatchDetails>
		{
			public SorterMode SorterMode;
			public LUDateComparer()
			{ }
			public LUDateComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchDetails> Membres
			int System.Collections.Generic.IComparer<DispatchDetails>.Compare(DispatchDetails x, DispatchDetails y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.LUDate.CompareTo(x.LUDate);
				}
				else
				{
					return x.LUDate.CompareTo(y.LUDate);
				}
			}
			#endregion
		}
		public class RemarkComparer : System.Collections.Generic.IComparer<DispatchDetails>
		{
			public SorterMode SorterMode;
			public RemarkComparer()
			{ }
			public RemarkComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchDetails> Membres
			int System.Collections.Generic.IComparer<DispatchDetails>.Compare(DispatchDetails x, DispatchDetails y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.Remark.CompareTo(x.Remark);
				}
				else
				{
					return x.Remark.CompareTo(y.Remark);
				}
			}
			#endregion
		}
	}

    [Serializable()]
    public partial class CSVDispatchDetails
    {
     
        private string _ProdCode;

        public string ProdCode
        {
            get { return _ProdCode; }
            set { _ProdCode = value; }
        }
        private string _ProductName;

        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }

     
        private Decimal _Packsize;

        public Decimal Packsize
        {
            get { return _Packsize; }
            set { _Packsize = value; }
        }
        private Decimal _PlanQty;

        public Decimal PlanQty
        {
            get { return _PlanQty; }
            set { _PlanQty = value; }
        }
        private Decimal _LoadingSplipQty;

        public Decimal LoadingSplipQty
        {
            get { return _LoadingSplipQty; }
            set { _LoadingSplipQty = value; }
        }
        private Decimal _ScanneddQty;

        public Decimal ScanneddQty
        {
            get { return _ScanneddQty; }
            set { _ScanneddQty = value; }
        }

        private string _Difference;

        public string Difference
        {
            get { return _Difference; }
            set { _Difference = value; }
        }
        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        public CSVDispatchDetails()
        { }

        public CSVDispatchDetails(string ProductName, string ProdCode, Decimal Packsize, Decimal PlanQty, Decimal LoadingSlipQty, Decimal ScanneddQty, string Difference, string Remark)
        {
            this.ProductName = ProductName;
            this.ProdCode = ProdCode;
            this.Packsize = Packsize;
            this.PlanQty = PlanQty;
            this.LoadingSplipQty = LoadingSlipQty;            
            this.ScanneddQty = ScanneddQty;
            this.Difference = Difference;
            this.Remark = Difference;
           
        }

        public override string ToString()
        {
            return "ProductName = " + ProductName + ",ProdCode = " + ProdCode + ",Packsize=" + Packsize.ToString() + ",PlanQty = " + PlanQty.ToString() + ",LoadingSlipQty=" + LoadingSplipQty.ToString() + ",ScanneddQty=" + ScanneddQty.ToString() + ",Difference=" + Difference + ",Remark=" + Remark;
        }
    }


    [Serializable()]
    public partial class DetailsDispatchDetails
    {

        private string _ProductName;

        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }


        private string _ProdCode;

        public string ProdCode
        {
            get { return _ProdCode; }
            set { _ProdCode = value; }
        }

        private Decimal _Packsize;

        public Decimal Packsize
        {
            get { return _Packsize; }
            set { _Packsize = value; }
        }

        private Decimal _QtytoDispatch;

        public Decimal QtytoDispatch
        {
            get { return _QtytoDispatch; }
            set { _QtytoDispatch = value; }
        }

       

        private Decimal _DispatchedQty;

        public Decimal DispatchedQty
        {
            get { return _DispatchedQty; }
            set { _DispatchedQty = value; }
        }



        public DetailsDispatchDetails()
        { }

        public DetailsDispatchDetails(string ProductName, int Packsize, string ProdCode, Decimal QtytoDispatch,  Decimal DispatchedQty)
        {
         
            this.ProdCode = ProdCode;
            this.QtytoDispatch = QtytoDispatch;          
            this.DispatchedQty = DispatchedQty;
           
        }

        public override string ToString()
        {
            return "ProdCode = " + ProdCode + ",QtytoDispatch = " + QtytoDispatch.ToString() + ",Packsize=" + Packsize.ToString() + ",ProductName=" + ProductName.ToString() + ",DispatchedQty=" + DispatchedQty.ToString();
        }

    }
}
