using System;
using System.Text;

namespace WIMARTS.DB.BusinessObjects
{
	[Serializable()]
	public partial class UIDLineHolder
	{
		private int _ID;

		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

        private DateTime _Date;

        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }


		private string _UnitCode;

		public string UnitCode
		{
			get { return _UnitCode; }
			set { _UnitCode = value; }
		}

		private string _LineCode;

		public string LineCode
		{
			get { return _LineCode; }
			set { _LineCode = value; }
		}

		private Decimal _LastUID;

		public Decimal LastUID
		{
			get { return _LastUID; }
			set { _LastUID = value; }
		}

		private string _Remarks;

		public string Remarks
		{
			get { return _Remarks; }
			set { _Remarks = value; }
		}

		public UIDLineHolder()
		{ }

		public UIDLineHolder(int ID,DateTime Date, string UnitCode,string LineCode,Decimal LastUID,string Remarks)
		{
			this.ID = ID;
            this.Date = Date;
			this.UnitCode = UnitCode;
			this.LineCode = LineCode;
			this.LastUID = LastUID;
			this.Remarks = Remarks;
		}

        public override string ToString()
        {
            return "ID = " + ID.ToString() + ",Date=" + Date + ",UnitCode = " + UnitCode + ",LineCode = " + LineCode + ",LastUID = " + LastUID.ToString() + ",Remarks = " + Remarks;
        }

		public class IDComparer : System.Collections.Generic.IComparer<UIDLineHolder>
		{
			public SorterMode SorterMode;
			public IDComparer()
			{ }
			public IDComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<UIDLineHolder> Membres
			int System.Collections.Generic.IComparer<UIDLineHolder>.Compare(UIDLineHolder x, UIDLineHolder y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.ID.CompareTo(x.ID);
				}
				else
				{
					return x.ID.CompareTo(y.ID);
				}
			}
			#endregion
		}
		public class UnitCodeComparer : System.Collections.Generic.IComparer<UIDLineHolder>
		{
			public SorterMode SorterMode;
			public UnitCodeComparer()
			{ }
			public UnitCodeComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<UIDLineHolder> Membres
			int System.Collections.Generic.IComparer<UIDLineHolder>.Compare(UIDLineHolder x, UIDLineHolder y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.UnitCode.CompareTo(x.UnitCode);
				}
				else
				{
					return x.UnitCode.CompareTo(y.UnitCode);
				}
			}
			#endregion
		}
		public class LineCodeComparer : System.Collections.Generic.IComparer<UIDLineHolder>
		{
			public SorterMode SorterMode;
			public LineCodeComparer()
			{ }
			public LineCodeComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<UIDLineHolder> Membres
			int System.Collections.Generic.IComparer<UIDLineHolder>.Compare(UIDLineHolder x, UIDLineHolder y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.LineCode.CompareTo(x.LineCode);
				}
				else
				{
					return x.LineCode.CompareTo(y.LineCode);
				}
			}
			#endregion
		}
		public class LastUIDComparer : System.Collections.Generic.IComparer<UIDLineHolder>
		{
			public SorterMode SorterMode;
			public LastUIDComparer()
			{ }
			public LastUIDComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<UIDLineHolder> Membres
			int System.Collections.Generic.IComparer<UIDLineHolder>.Compare(UIDLineHolder x, UIDLineHolder y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.LastUID.CompareTo(x.LastUID);
				}
				else
				{
					return x.LastUID.CompareTo(y.LastUID);
				}
			}
			#endregion
		}
		public class RemarksComparer : System.Collections.Generic.IComparer<UIDLineHolder>
		{
			public SorterMode SorterMode;
			public RemarksComparer()
			{ }
			public RemarksComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<UIDLineHolder> Membres
			int System.Collections.Generic.IComparer<UIDLineHolder>.Compare(UIDLineHolder x, UIDLineHolder y)
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
