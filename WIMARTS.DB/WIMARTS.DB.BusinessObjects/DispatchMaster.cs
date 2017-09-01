using System;
using System.Text;

namespace WIMARTS.DB.BusinessObjects
{
	[Serializable()]
	public partial class DispatchMaster
	{
		private int _DispMasterID;
		public int DispMasterID
		{
			get { return _DispMasterID; }
			set { _DispMasterID = value; }
		}

		private string _GDN;
		public string GDN
		{
			get { return _GDN; }
			set { _GDN = value; }
		}

		private int _CustID;
		public int CustID
		{
			get { return _CustID; }
			set { _CustID = value; }
		}

		private Nullable<int> _TransporterID;
		public Nullable<int> TransporterID
		{
			get { return _TransporterID; }
			set { _TransporterID = value; }
		}

		private string _VehicleNo;
		public string VehicleNo
		{
			get { return _VehicleNo; }
			set { _VehicleNo = value; }
		}

		private string _DriverName;
		public string DriverName
		{
			get { return _DriverName; }
			set { _DriverName = value; }
		}

		private int _LineID;
		public int LineID
		{
			get { return _LineID; }
			set { _LineID = value; }
		}

		private int _DispType;
		public int DispType
		{
			get { return _DispType; }
			set { _DispType = value; }
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

		private DateTime _DispatchDate;
		public DateTime DispatchDate
		{
			get { return _DispatchDate; }
			set { _DispatchDate = value; }
		}

		private int _CreatedBy;
		public int CreatedBy
		{
			get { return _CreatedBy; }
			set { _CreatedBy = value; }
		}

		private DateTime _CreatedDate;
		public DateTime CreatedDate
		{
			get { return _CreatedDate; }
			set { _CreatedDate = value; }
		}

		private Nullable<DateTime> _StartedAt;
		public Nullable<DateTime> StartedAt
		{
			get { return _StartedAt; }
			set { _StartedAt = value; }
		}

		private Nullable<DateTime> _CompletedAt;
		public Nullable<DateTime> CompletedAt
		{
			get { return _CompletedAt; }
			set { _CompletedAt = value; }
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

		public DispatchMaster()
		{ }
		public DispatchMaster(int DispMasterID, string GDN, int CustID,Nullable<int> TransporterID, string VehicleNo, string DriverName, int LineID, int DispType, int Status, Decimal Quantity,Nullable<Decimal> GoodQty,Nullable<Decimal> BadQty, DateTime DispatchDate, int CreatedBy, DateTime CreatedDate,Nullable<DateTime> StartedAt,Nullable<DateTime> CompletedAt, DateTime LUDate, string Remarks)
		{
			this.DispMasterID = DispMasterID;
			this.GDN = GDN;
			this.CustID = CustID;
			this.TransporterID = TransporterID;
			this.VehicleNo = VehicleNo;
			this.DriverName = DriverName;
			this.LineID = LineID;
			this.DispType = DispType;
			this.Status = Status;
			this.Quantity = Quantity;
			this.GoodQty = GoodQty;
			this.BadQty = BadQty;
			this.DispatchDate = DispatchDate;
			this.CreatedBy = CreatedBy;
			this.CreatedDate = CreatedDate;
			this.StartedAt = StartedAt;
			this.CompletedAt = CompletedAt;
			this.LUDate = LUDate;
			this.Remarks = Remarks;
		}

		public override string ToString()
		{
			return "DispMasterID = " + DispMasterID.ToString() + ",GDN = " + GDN + ",CustID = " + CustID.ToString() + ",TransporterID = " + TransporterID.ToString() + ",VehicleNo = " + VehicleNo + ",DriverName = " + DriverName + ",LineID = " + LineID.ToString() + ",DispType = " + DispType.ToString() + ",Status = " + Status.ToString() + ",Quantity = " + Quantity.ToString() + ",GoodQty = " + GoodQty.ToString() + ",BadQty = " + BadQty.ToString() + ",DispatchDate = " + DispatchDate.ToString() + ",CreatedBy = " + CreatedBy.ToString() + ",CreatedDate = " + CreatedDate.ToString() + ",StartedAt = " + StartedAt.ToString() + ",CompletedAt = " + CompletedAt.ToString() + ",LUDate = " + LUDate.ToString() + ",Remarks = " + Remarks;
		}

		public class DispMasterIDComparer : System.Collections.Generic.IComparer<DispatchMaster>
		{
			public SorterMode SorterMode;
			public DispMasterIDComparer()
			{ }
			public DispMasterIDComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchMaster> Membres
			int System.Collections.Generic.IComparer<DispatchMaster>.Compare(DispatchMaster x, DispatchMaster y)
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
		public class GDNComparer : System.Collections.Generic.IComparer<DispatchMaster>
		{
			public SorterMode SorterMode;
			public GDNComparer()
			{ }
			public GDNComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchMaster> Membres
			int System.Collections.Generic.IComparer<DispatchMaster>.Compare(DispatchMaster x, DispatchMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.GDN.CompareTo(x.GDN);
				}
				else
				{
					return x.GDN.CompareTo(y.GDN);
				}
			}
			#endregion
		}
		public class CustIDComparer : System.Collections.Generic.IComparer<DispatchMaster>
		{
			public SorterMode SorterMode;
			public CustIDComparer()
			{ }
			public CustIDComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchMaster> Membres
			int System.Collections.Generic.IComparer<DispatchMaster>.Compare(DispatchMaster x, DispatchMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.CustID.CompareTo(x.CustID);
				}
				else
				{
					return x.CustID.CompareTo(y.CustID);
				}
			}
			#endregion
		}
		public class VehicleNoComparer : System.Collections.Generic.IComparer<DispatchMaster>
		{
			public SorterMode SorterMode;
			public VehicleNoComparer()
			{ }
			public VehicleNoComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchMaster> Membres
			int System.Collections.Generic.IComparer<DispatchMaster>.Compare(DispatchMaster x, DispatchMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.VehicleNo.CompareTo(x.VehicleNo);
				}
				else
				{
					return x.VehicleNo.CompareTo(y.VehicleNo);
				}
			}
			#endregion
		}
		public class DriverNameComparer : System.Collections.Generic.IComparer<DispatchMaster>
		{
			public SorterMode SorterMode;
			public DriverNameComparer()
			{ }
			public DriverNameComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchMaster> Membres
			int System.Collections.Generic.IComparer<DispatchMaster>.Compare(DispatchMaster x, DispatchMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.DriverName.CompareTo(x.DriverName);
				}
				else
				{
					return x.DriverName.CompareTo(y.DriverName);
				}
			}
			#endregion
		}
		public class LineIDComparer : System.Collections.Generic.IComparer<DispatchMaster>
		{
			public SorterMode SorterMode;
			public LineIDComparer()
			{ }
			public LineIDComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchMaster> Membres
			int System.Collections.Generic.IComparer<DispatchMaster>.Compare(DispatchMaster x, DispatchMaster y)
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
		public class DispTypeComparer : System.Collections.Generic.IComparer<DispatchMaster>
		{
			public SorterMode SorterMode;
			public DispTypeComparer()
			{ }
			public DispTypeComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchMaster> Membres
			int System.Collections.Generic.IComparer<DispatchMaster>.Compare(DispatchMaster x, DispatchMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.DispType.CompareTo(x.DispType);
				}
				else
				{
					return x.DispType.CompareTo(y.DispType);
				}
			}
			#endregion
		}
		public class StatusComparer : System.Collections.Generic.IComparer<DispatchMaster>
		{
			public SorterMode SorterMode;
			public StatusComparer()
			{ }
			public StatusComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchMaster> Membres
			int System.Collections.Generic.IComparer<DispatchMaster>.Compare(DispatchMaster x, DispatchMaster y)
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
		public class QuantityComparer : System.Collections.Generic.IComparer<DispatchMaster>
		{
			public SorterMode SorterMode;
			public QuantityComparer()
			{ }
			public QuantityComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchMaster> Membres
			int System.Collections.Generic.IComparer<DispatchMaster>.Compare(DispatchMaster x, DispatchMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.Quantity.CompareTo(x.Quantity);
				}
				else
				{
					return x.Quantity.CompareTo(y.Quantity);
				}
			}
			#endregion
		}
		public class DispatchDateComparer : System.Collections.Generic.IComparer<DispatchMaster>
		{
			public SorterMode SorterMode;
			public DispatchDateComparer()
			{ }
			public DispatchDateComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchMaster> Membres
			int System.Collections.Generic.IComparer<DispatchMaster>.Compare(DispatchMaster x, DispatchMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.DispatchDate.CompareTo(x.DispatchDate);
				}
				else
				{
					return x.DispatchDate.CompareTo(y.DispatchDate);
				}
			}
			#endregion
		}
		public class CreatedByComparer : System.Collections.Generic.IComparer<DispatchMaster>
		{
			public SorterMode SorterMode;
			public CreatedByComparer()
			{ }
			public CreatedByComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchMaster> Membres
			int System.Collections.Generic.IComparer<DispatchMaster>.Compare(DispatchMaster x, DispatchMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.CreatedBy.CompareTo(x.CreatedBy);
				}
				else
				{
					return x.CreatedBy.CompareTo(y.CreatedBy);
				}
			}
			#endregion
		}
		public class CreatedDateComparer : System.Collections.Generic.IComparer<DispatchMaster>
		{
			public SorterMode SorterMode;
			public CreatedDateComparer()
			{ }
			public CreatedDateComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchMaster> Membres
			int System.Collections.Generic.IComparer<DispatchMaster>.Compare(DispatchMaster x, DispatchMaster y)
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
		public class LUDateComparer : System.Collections.Generic.IComparer<DispatchMaster>
		{
			public SorterMode SorterMode;
			public LUDateComparer()
			{ }
			public LUDateComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchMaster> Membres
			int System.Collections.Generic.IComparer<DispatchMaster>.Compare(DispatchMaster x, DispatchMaster y)
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
		public class RemarksComparer : System.Collections.Generic.IComparer<DispatchMaster>
		{
			public SorterMode SorterMode;
			public RemarksComparer()
			{ }
			public RemarksComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<DispatchMaster> Membres
			int System.Collections.Generic.IComparer<DispatchMaster>.Compare(DispatchMaster x, DispatchMaster y)
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

		public enum enumFlags
		{
			ALL,

			DispMasterID,
			GDN,
			CustID,
			TransporterID,
			VehicleNo,
			DriverName,
			LineID,
			DispType,
			Status,
			Quantity,
			GoodQty,
			BadQty,
			DispatchDate,
			CreatedBy,
			CreatedDate,
			StartedAt,
			CompletedAt,
			LUDate,
			Remarks,
		}
	}
}
