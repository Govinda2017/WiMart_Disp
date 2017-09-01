using System;
using System.Text;

namespace WIMARTS.DB.BusinessObjects
{
	[Serializable()]
	public partial class RoleMaster
	{
		private int _RoleID;

		public int RoleID
		{
			get { return _RoleID; }
			set { _RoleID = value; }
		}

		private string _Name;

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		private string _Remarks;

		public string Remarks
		{
			get { return _Remarks; }
			set { _Remarks = value; }
		}

		public RoleMaster()
		{ }

		public RoleMaster(int RoleID,string Name,string Remarks)
		{
			this.RoleID = RoleID;
			this.Name = Name;
			this.Remarks = Remarks;
		}

		public override string ToString()
		{
			return "RoleID = " + RoleID.ToString() + ",Name = " + Name + ",Remarks = " + Remarks;
		}

		public class RoleIDComparer : System.Collections.Generic.IComparer<RoleMaster>
		{
			public SorterMode SorterMode;
			public RoleIDComparer()
			{ }
			public RoleIDComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<RoleMaster> Membres
			int System.Collections.Generic.IComparer<RoleMaster>.Compare(RoleMaster x, RoleMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.RoleID.CompareTo(x.RoleID);
				}
				else
				{
					return x.RoleID.CompareTo(y.RoleID);
				}
			}
			#endregion
		}
		public class NameComparer : System.Collections.Generic.IComparer<RoleMaster>
		{
			public SorterMode SorterMode;
			public NameComparer()
			{ }
			public NameComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<RoleMaster> Membres
			int System.Collections.Generic.IComparer<RoleMaster>.Compare(RoleMaster x, RoleMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.Name.CompareTo(x.Name);
				}
				else
				{
					return x.Name.CompareTo(y.Name);
				}
			}
			#endregion
		}
		public class RemarksComparer : System.Collections.Generic.IComparer<RoleMaster>
		{
			public SorterMode SorterMode;
			public RemarksComparer()
			{ }
			public RemarksComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<RoleMaster> Membres
			int System.Collections.Generic.IComparer<RoleMaster>.Compare(RoleMaster x, RoleMaster y)
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
