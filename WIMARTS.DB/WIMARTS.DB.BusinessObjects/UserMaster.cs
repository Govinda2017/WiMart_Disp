using System;
using System.Text;

namespace WIMARTS.DB.BusinessObjects
{
	[Serializable()]
	public partial class UserMaster
	{
		private int _UserID;

		public int UserID
		{
			get { return _UserID; }
			set { _UserID = value; }
		}

		private string _Name;

		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		private string _Password;

		public string Password
		{
			get { return _Password; }
			set { _Password = value; }
		}

		private int _RoleID;

		public int RoleID
		{
			get { return _RoleID; }
			set { _RoleID = value; }
		}

		private bool _Active;

		public bool Active
		{
			get { return _Active; }
			set { _Active = value; }
		}

		private Nullable<DateTime> _LastUpdatedDate;

		public Nullable<DateTime> LastUpdatedDate
		{
			get { return _LastUpdatedDate; }
			set { _LastUpdatedDate = value; }
		}

		private Nullable<int> _LastUpdatedBy;

		public Nullable<int> LastUpdatedBy
		{
			get { return _LastUpdatedBy; }
			set { _LastUpdatedBy = value; }
		}

		public UserMaster()
		{ }

		public UserMaster(int UserID,string Name,string Password,int RoleID,bool Active,Nullable<DateTime> LastUpdatedDate,Nullable<int> LastUpdatedBy)
		{
			this.UserID = UserID;
			this.Name = Name;
			this.Password = Password;
			this.RoleID = RoleID;
			this.Active = Active;
			this.LastUpdatedDate = LastUpdatedDate;
			this.LastUpdatedBy = LastUpdatedBy;
		}

		public override string ToString()
		{
			return "UserID = " + UserID.ToString() + ",Name = " + Name + ",Password = " + Password + ",RoleID = " + RoleID.ToString() + ",Active = " + Active.ToString() + ",LastUpdatedDate = " + LastUpdatedDate.ToString() + ",LastUpdatedBy = " + LastUpdatedBy.ToString();
		}

		public class UserIDComparer : System.Collections.Generic.IComparer<UserMaster>
		{
			public SorterMode SorterMode;
			public UserIDComparer()
			{ }
			public UserIDComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<UserMaster> Membres
			int System.Collections.Generic.IComparer<UserMaster>.Compare(UserMaster x, UserMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.UserID.CompareTo(x.UserID);
				}
				else
				{
					return x.UserID.CompareTo(y.UserID);
				}
			}
			#endregion
		}
		public class NameComparer : System.Collections.Generic.IComparer<UserMaster>
		{
			public SorterMode SorterMode;
			public NameComparer()
			{ }
			public NameComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<UserMaster> Membres
			int System.Collections.Generic.IComparer<UserMaster>.Compare(UserMaster x, UserMaster y)
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
		public class PasswordComparer : System.Collections.Generic.IComparer<UserMaster>
		{
			public SorterMode SorterMode;
			public PasswordComparer()
			{ }
			public PasswordComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<UserMaster> Membres
			int System.Collections.Generic.IComparer<UserMaster>.Compare(UserMaster x, UserMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.Password.CompareTo(x.Password);
				}
				else
				{
					return x.Password.CompareTo(y.Password);
				}
			}
			#endregion
		}
		public class RoleIDComparer : System.Collections.Generic.IComparer<UserMaster>
		{
			public SorterMode SorterMode;
			public RoleIDComparer()
			{ }
			public RoleIDComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<UserMaster> Membres
			int System.Collections.Generic.IComparer<UserMaster>.Compare(UserMaster x, UserMaster y)
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
		public class ActiveComparer : System.Collections.Generic.IComparer<UserMaster>
		{
			public SorterMode SorterMode;
			public ActiveComparer()
			{ }
			public ActiveComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<UserMaster> Membres
			int System.Collections.Generic.IComparer<UserMaster>.Compare(UserMaster x, UserMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.Active.CompareTo(x.Active);
				}
				else
				{
					return x.Active.CompareTo(y.Active);
				}
			}
			#endregion
		}
	}
}
