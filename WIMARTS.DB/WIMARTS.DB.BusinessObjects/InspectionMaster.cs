using System;
using System.Text;

namespace WIMARTS.DB.BusinessObjects
{
	[Serializable()]
	public partial class InspectionMaster
	{
		private int _InspID;

		public int InspID
		{
			get { return _InspID; }
			set { _InspID = value; }
		}

		private string _BatchName;

		public string BatchName
		{
			get { return _BatchName; }
			set { _BatchName = value; }
		}

		private int _LineID;

		public int LineID
		{
			get { return _LineID; }
			set { _LineID = value; }
		}

		private int _Status;

		public int Status
		{
			get { return _Status; }
			set { _Status = value; }
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

		private string _Remark;

		public string Remark
		{
			get { return _Remark; }
			set { _Remark = value; }
		}

		public InspectionMaster()
		{ }

		public InspectionMaster(int InspID,string BatchName,int LineID,int Status,Nullable<Decimal> GoodQty,Nullable<Decimal> BadQty,DateTime CreatedDate,DateTime LUDate,string Remark)
		{
			this.InspID = InspID;
			this.BatchName = BatchName;
			this.LineID = LineID;
			this.Status = Status;
			this.GoodQty = GoodQty;
			this.BadQty = BadQty;
			this.CreatedDate = CreatedDate;
			this.LUDate = LUDate;
			this.Remark = Remark;
		}

		public override string ToString()
		{
			return "InspID = " + InspID.ToString() + ",BatchName = " + BatchName + ",LineID = " + LineID.ToString() + ",Status = " + Status.ToString() + ",GoodQty = " + GoodQty.ToString() + ",BadQty = " + BadQty.ToString() + ",CreatedDate = " + CreatedDate.ToString() + ",LUDate = " + LUDate.ToString() + ",Remark = " + Remark;
		}

		public class InspIDComparer : System.Collections.Generic.IComparer<InspectionMaster>
		{
			public SorterMode SorterMode;
			public InspIDComparer()
			{ }
			public InspIDComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<InspectionMaster> Membres
			int System.Collections.Generic.IComparer<InspectionMaster>.Compare(InspectionMaster x, InspectionMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.InspID.CompareTo(x.InspID);
				}
				else
				{
					return x.InspID.CompareTo(y.InspID);
				}
			}
			#endregion
		}
		public class BatchNameComparer : System.Collections.Generic.IComparer<InspectionMaster>
		{
			public SorterMode SorterMode;
			public BatchNameComparer()
			{ }
			public BatchNameComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<InspectionMaster> Membres
			int System.Collections.Generic.IComparer<InspectionMaster>.Compare(InspectionMaster x, InspectionMaster y)
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
		public class LineIDComparer : System.Collections.Generic.IComparer<InspectionMaster>
		{
			public SorterMode SorterMode;
			public LineIDComparer()
			{ }
			public LineIDComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<InspectionMaster> Membres
			int System.Collections.Generic.IComparer<InspectionMaster>.Compare(InspectionMaster x, InspectionMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.LineID.CompareTo(x.LineID);
				}
				else
				{
					return x.LineID.CompareTo(y.LineID);
				}
			}
			#endregion
		}
		public class StatusComparer : System.Collections.Generic.IComparer<InspectionMaster>
		{
			public SorterMode SorterMode;
			public StatusComparer()
			{ }
			public StatusComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<InspectionMaster> Membres
			int System.Collections.Generic.IComparer<InspectionMaster>.Compare(InspectionMaster x, InspectionMaster y)
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
		public class CreatedDateComparer : System.Collections.Generic.IComparer<InspectionMaster>
		{
			public SorterMode SorterMode;
			public CreatedDateComparer()
			{ }
			public CreatedDateComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<InspectionMaster> Membres
			int System.Collections.Generic.IComparer<InspectionMaster>.Compare(InspectionMaster x, InspectionMaster y)
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
		public class LUDateComparer : System.Collections.Generic.IComparer<InspectionMaster>
		{
			public SorterMode SorterMode;
			public LUDateComparer()
			{ }
			public LUDateComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<InspectionMaster> Membres
			int System.Collections.Generic.IComparer<InspectionMaster>.Compare(InspectionMaster x, InspectionMaster y)
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
		public class RemarkComparer : System.Collections.Generic.IComparer<InspectionMaster>
		{
			public SorterMode SorterMode;
			public RemarkComparer()
			{ }
			public RemarkComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<InspectionMaster> Membres
			int System.Collections.Generic.IComparer<InspectionMaster>.Compare(InspectionMaster x, InspectionMaster y)
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
}
