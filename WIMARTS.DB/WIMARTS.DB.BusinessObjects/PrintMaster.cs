using System;
using System.Text;

namespace WIMARTS.DB.BusinessObjects
{
	[Serializable()]
	public partial class PrintMaster
	{
		private int _PrintID;

		public int PrintID
		{
			get { return _PrintID; }
			set { _PrintID = value; }
		}

		private int _ProdID;

		public int ProdID
		{
			get { return _ProdID; }
			set { _ProdID = value; }
		}

		private string _ProdCode;

		public string ProdCode
		{
			get { return _ProdCode; }
			set { _ProdCode = value; }
		}

		private string _ProdName;

		public string ProdName
		{
			get { return _ProdName; }
			set { _ProdName = value; }
		}

		private string _BatchName;

		public string BatchName
		{
			get { return _BatchName; }
			set { _BatchName = value; }
		}

        private DateTime _MfgDate;

        public DateTime MfgDate
        {
            get { return _MfgDate; }
            set { _MfgDate = value; }
        }


		private Decimal _MRP;

		public Decimal MRP
		{
			get { return _MRP; }
			set { _MRP = value; }
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

		private int _Status;

		public int Status
		{
			get { return _Status; }
			set { _Status = value; }
		}

		private Decimal _Quantity;

		public Decimal Quantity
		{
			get { return _Quantity; }
			set { _Quantity = value; }
		}

		private Nullable<Decimal> _GoodQty;

		public Nullable<Decimal> GoodQty
		{
			get { return _GoodQty; }
			set { _GoodQty = value; }
		}

		private Nullable<Decimal> _BadQty;

		public Nullable<Decimal> BadQty
		{
			get { return _BadQty; }
			set { _BadQty = value; }
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

		private string _Remarks;

		public string Remarks
		{
			get { return _Remarks; }
			set { _Remarks = value; }
		}

		public PrintMaster()
		{ }

		public PrintMaster(int PrintID,int ProdID,string ProdCode,string ProdName,string BatchName,DateTime MfgDate, Decimal MRP,string TemplateName,string Template,int Status,Decimal Quantity,Nullable<Decimal> GoodQty,Nullable<Decimal> BadQty,DateTime CreatedDate,DateTime LUDate,string Remarks)
		{
			this.PrintID = PrintID;
			this.ProdID = ProdID;
			this.ProdCode = ProdCode;
			this.ProdName = ProdName;
			this.BatchName = BatchName;
            this.MfgDate = MfgDate;
            this.MRP = MRP;
			this.TemplateName = TemplateName;
			this.Template = Template;
			this.Status = Status;
			this.Quantity = Quantity;
			this.GoodQty = GoodQty;
			this.BadQty = BadQty;
			this.CreatedDate = CreatedDate;
			this.LUDate = LUDate;
			this.Remarks = Remarks;
		}

        public override string ToString()
        {
            return "PrintID = " + PrintID.ToString() + ",ProdID = " + ProdID.ToString() + ",ProdCode = " + ProdCode + ",ProdName = " + ProdName + ",BatchName = " + BatchName + ",MfgDate=" + MfgDate + ",MRP = " + MRP.ToString() + ",TemplateName = " + TemplateName + ",Template = " + Template + ",Status = " + Status.ToString() + ",Quantity = " + Quantity.ToString() + ",GoodQty = " + GoodQty.ToString() + ",BadQty = " + BadQty.ToString() + ",CreatedDate = " + CreatedDate.ToString() + ",LUDate = " + LUDate.ToString() + ",Remarks = " + Remarks;
        }

		public class PrintIDComparer : System.Collections.Generic.IComparer<PrintMaster>
		{
			public SorterMode SorterMode;
			public PrintIDComparer()
			{ }
			public PrintIDComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<PrintMaster> Membres
			int System.Collections.Generic.IComparer<PrintMaster>.Compare(PrintMaster x, PrintMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.PrintID.CompareTo(x.PrintID);
				}
				else
				{
					return x.PrintID.CompareTo(y.PrintID);
				}
			}
			#endregion
		}
		public class ProdIDComparer : System.Collections.Generic.IComparer<PrintMaster>
		{
			public SorterMode SorterMode;
			public ProdIDComparer()
			{ }
			public ProdIDComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<PrintMaster> Membres
			int System.Collections.Generic.IComparer<PrintMaster>.Compare(PrintMaster x, PrintMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.ProdID.CompareTo(x.ProdID);
				}
				else
				{
					return x.ProdID.CompareTo(y.ProdID);
				}
			}
			#endregion
		}
		public class ProdCodeComparer : System.Collections.Generic.IComparer<PrintMaster>
		{
			public SorterMode SorterMode;
			public ProdCodeComparer()
			{ }
			public ProdCodeComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<PrintMaster> Membres
			int System.Collections.Generic.IComparer<PrintMaster>.Compare(PrintMaster x, PrintMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.ProdCode.CompareTo(x.ProdCode);
				}
				else
				{
					return x.ProdCode.CompareTo(y.ProdCode);
				}
			}
			#endregion
		}
		public class ProdNameComparer : System.Collections.Generic.IComparer<PrintMaster>
		{
			public SorterMode SorterMode;
			public ProdNameComparer()
			{ }
			public ProdNameComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<PrintMaster> Membres
			int System.Collections.Generic.IComparer<PrintMaster>.Compare(PrintMaster x, PrintMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.ProdName.CompareTo(x.ProdName);
				}
				else
				{
					return x.ProdName.CompareTo(y.ProdName);
				}
			}
			#endregion
		}
		public class BatchNameComparer : System.Collections.Generic.IComparer<PrintMaster>
		{
			public SorterMode SorterMode;
			public BatchNameComparer()
			{ }
			public BatchNameComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<PrintMaster> Membres
			int System.Collections.Generic.IComparer<PrintMaster>.Compare(PrintMaster x, PrintMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.BatchName.CompareTo(x.BatchName);
				}
				else
				{
					return x.BatchName.CompareTo(y.BatchName);
				}
			}
			#endregion
		}
		public class MRPComparer : System.Collections.Generic.IComparer<PrintMaster>
		{
			public SorterMode SorterMode;
			public MRPComparer()
			{ }
			public MRPComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<PrintMaster> Membres
			int System.Collections.Generic.IComparer<PrintMaster>.Compare(PrintMaster x, PrintMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.MRP.CompareTo(x.MRP);
				}
				else
				{
					return x.MRP.CompareTo(y.MRP);
				}
			}
			#endregion
		}
		public class TemplateNameComparer : System.Collections.Generic.IComparer<PrintMaster>
		{
			public SorterMode SorterMode;
			public TemplateNameComparer()
			{ }
			public TemplateNameComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<PrintMaster> Membres
			int System.Collections.Generic.IComparer<PrintMaster>.Compare(PrintMaster x, PrintMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.TemplateName.CompareTo(x.TemplateName);
				}
				else
				{
					return x.TemplateName.CompareTo(y.TemplateName);
				}
			}
			#endregion
		}
		public class TemplateComparer : System.Collections.Generic.IComparer<PrintMaster>
		{
			public SorterMode SorterMode;
			public TemplateComparer()
			{ }
			public TemplateComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<PrintMaster> Membres
			int System.Collections.Generic.IComparer<PrintMaster>.Compare(PrintMaster x, PrintMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.Template.CompareTo(x.Template);
				}
				else
				{
					return x.Template.CompareTo(y.Template);
				}
			}
			#endregion
		}
		public class StatusComparer : System.Collections.Generic.IComparer<PrintMaster>
		{
			public SorterMode SorterMode;
			public StatusComparer()
			{ }
			public StatusComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<PrintMaster> Membres
			int System.Collections.Generic.IComparer<PrintMaster>.Compare(PrintMaster x, PrintMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.Status.CompareTo(x.Status);
				}
				else
				{
					return x.Status.CompareTo(y.Status);
				}
			}
			#endregion
		}
		public class CreatedDateComparer : System.Collections.Generic.IComparer<PrintMaster>
		{
			public SorterMode SorterMode;
			public CreatedDateComparer()
			{ }
			public CreatedDateComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<PrintMaster> Membres
			int System.Collections.Generic.IComparer<PrintMaster>.Compare(PrintMaster x, PrintMaster y)
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
		public class LUDateComparer : System.Collections.Generic.IComparer<PrintMaster>
		{
			public SorterMode SorterMode;
			public LUDateComparer()
			{ }
			public LUDateComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<PrintMaster> Membres
			int System.Collections.Generic.IComparer<PrintMaster>.Compare(PrintMaster x, PrintMaster y)
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
		public class RemarksComparer : System.Collections.Generic.IComparer<PrintMaster>
		{
			public SorterMode SorterMode;
			public RemarksComparer()
			{ }
			public RemarksComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<PrintMaster> Membres
			int System.Collections.Generic.IComparer<PrintMaster>.Compare(PrintMaster x, PrintMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.Remarks.CompareTo(x.Remarks);
				}
				else
				{
					return x.Remarks.CompareTo(y.Remarks);
				}
			}
			#endregion
		}
	}
}
