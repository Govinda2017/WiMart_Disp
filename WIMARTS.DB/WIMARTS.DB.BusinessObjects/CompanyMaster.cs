using System;
using System.Text;

namespace WIMARTS.DB.BusinessObjects
{
	[Serializable()]
	public partial class CompanyMaster
	{
		private int _CompanyID;

		public int CompanyID
		{
			get { return _CompanyID; }
			set { _CompanyID = value; }
		}

		private string _CompanyName;

		public string CompanyName
		{
			get { return _CompanyName; }
			set { _CompanyName = value; }
		}

		private Byte[] _Logo;

		public Byte[] Logo
		{
			get { return _Logo; }
			set { _Logo = value; }
		}

		private string _AddressLine;

		public string AddressLine
		{
			get { return _AddressLine; }
			set { _AddressLine = value; }
		}

		private string _City;

		public string City
		{
			get { return _City; }
			set { _City = value; }
		}

		private string _Pincode;

		public string Pincode
		{
			get { return _Pincode; }
			set { _Pincode = value; }
		}

		private string _PhoneNum;

		public string PhoneNum
		{
			get { return _PhoneNum; }
			set { _PhoneNum = value; }
		}

		private string _EmailID;

		public string EmailID
		{
			get { return _EmailID; }
			set { _EmailID = value; }
		}

		private string _WebSite;

		public string WebSite
		{
			get { return _WebSite; }
			set { _WebSite = value; }
		}

		private DateTime _LUDate;

		public DateTime LUDate
		{
			get { return _LUDate; }
			set { _LUDate = value; }
		}

		private int _LUBy;

		public int LUBy
		{
			get { return _LUBy; }
			set { _LUBy = value; }
		}

		private string _Remarks;

		public string Remarks
		{
			get { return _Remarks; }
			set { _Remarks = value; }
		}

		public CompanyMaster()
		{ }

		public CompanyMaster(int CompanyID,string CompanyName,Byte[] Logo,string AddressLine,string City,string Pincode,string PhoneNum,string EmailID,string WebSite,DateTime LUDate,int LUBy,string Remarks)
		{
			this.CompanyID = CompanyID;
			this.CompanyName = CompanyName;
			this.Logo = Logo;
			this.AddressLine = AddressLine;
			this.City = City;
			this.Pincode = Pincode;
			this.PhoneNum = PhoneNum;
			this.EmailID = EmailID;
			this.WebSite = WebSite;
			this.LUDate = LUDate;
			this.LUBy = LUBy;
			this.Remarks = Remarks;
		}

		public override string ToString()
		{
			return "CompanyID = " + CompanyID.ToString() + ",CompanyName = " + CompanyName + ",Logo = " + Logo.ToString() + ",AddressLine = " + AddressLine + ",City = " + City + ",Pincode = " + Pincode + ",PhoneNum = " + PhoneNum + ",EmailID = " + EmailID + ",WebSite = " + WebSite + ",LUDate = " + LUDate.ToString() + ",LUBy = " + LUBy.ToString() + ",Remarks = " + Remarks;
		}

		public class CompanyIDComparer : System.Collections.Generic.IComparer<CompanyMaster>
		{
			public SorterMode SorterMode;
			public CompanyIDComparer()
			{ }
			public CompanyIDComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CompanyMaster> Membres
			int System.Collections.Generic.IComparer<CompanyMaster>.Compare(CompanyMaster x, CompanyMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.CompanyID.CompareTo(x.CompanyID);
				}
				else
				{
					return x.CompanyID.CompareTo(y.CompanyID);
				}
			}
			#endregion
		}
		public class CompanyNameComparer : System.Collections.Generic.IComparer<CompanyMaster>
		{
			public SorterMode SorterMode;
			public CompanyNameComparer()
			{ }
			public CompanyNameComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CompanyMaster> Membres
			int System.Collections.Generic.IComparer<CompanyMaster>.Compare(CompanyMaster x, CompanyMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.CompanyName.CompareTo(x.CompanyName);
				}
				else
				{
					return x.CompanyName.CompareTo(y.CompanyName);
				}
			}
			#endregion
		}
		public class AddressLineComparer : System.Collections.Generic.IComparer<CompanyMaster>
		{
			public SorterMode SorterMode;
			public AddressLineComparer()
			{ }
			public AddressLineComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CompanyMaster> Membres
			int System.Collections.Generic.IComparer<CompanyMaster>.Compare(CompanyMaster x, CompanyMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.AddressLine.CompareTo(x.AddressLine);
				}
				else
				{
					return x.AddressLine.CompareTo(y.AddressLine);
				}
			}
			#endregion
		}
		public class CityComparer : System.Collections.Generic.IComparer<CompanyMaster>
		{
			public SorterMode SorterMode;
			public CityComparer()
			{ }
			public CityComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CompanyMaster> Membres
			int System.Collections.Generic.IComparer<CompanyMaster>.Compare(CompanyMaster x, CompanyMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.City.CompareTo(x.City);
				}
				else
				{
					return x.City.CompareTo(y.City);
				}
			}
			#endregion
		}
		public class PincodeComparer : System.Collections.Generic.IComparer<CompanyMaster>
		{
			public SorterMode SorterMode;
			public PincodeComparer()
			{ }
			public PincodeComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CompanyMaster> Membres
			int System.Collections.Generic.IComparer<CompanyMaster>.Compare(CompanyMaster x, CompanyMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.Pincode.CompareTo(x.Pincode);
				}
				else
				{
					return x.Pincode.CompareTo(y.Pincode);
				}
			}
			#endregion
		}
		public class PhoneNumComparer : System.Collections.Generic.IComparer<CompanyMaster>
		{
			public SorterMode SorterMode;
			public PhoneNumComparer()
			{ }
			public PhoneNumComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CompanyMaster> Membres
			int System.Collections.Generic.IComparer<CompanyMaster>.Compare(CompanyMaster x, CompanyMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.PhoneNum.CompareTo(x.PhoneNum);
				}
				else
				{
					return x.PhoneNum.CompareTo(y.PhoneNum);
				}
			}
			#endregion
		}
		public class EmailIDComparer : System.Collections.Generic.IComparer<CompanyMaster>
		{
			public SorterMode SorterMode;
			public EmailIDComparer()
			{ }
			public EmailIDComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CompanyMaster> Membres
			int System.Collections.Generic.IComparer<CompanyMaster>.Compare(CompanyMaster x, CompanyMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.EmailID.CompareTo(x.EmailID);
				}
				else
				{
					return x.EmailID.CompareTo(y.EmailID);
				}
			}
			#endregion
		}
		public class WebSiteComparer : System.Collections.Generic.IComparer<CompanyMaster>
		{
			public SorterMode SorterMode;
			public WebSiteComparer()
			{ }
			public WebSiteComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CompanyMaster> Membres
			int System.Collections.Generic.IComparer<CompanyMaster>.Compare(CompanyMaster x, CompanyMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.WebSite.CompareTo(x.WebSite);
				}
				else
				{
					return x.WebSite.CompareTo(y.WebSite);
				}
			}
			#endregion
		}
		public class LUDateComparer : System.Collections.Generic.IComparer<CompanyMaster>
		{
			public SorterMode SorterMode;
			public LUDateComparer()
			{ }
			public LUDateComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CompanyMaster> Membres
			int System.Collections.Generic.IComparer<CompanyMaster>.Compare(CompanyMaster x, CompanyMaster y)
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
		public class LUByComparer : System.Collections.Generic.IComparer<CompanyMaster>
		{
			public SorterMode SorterMode;
			public LUByComparer()
			{ }
			public LUByComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CompanyMaster> Membres
			int System.Collections.Generic.IComparer<CompanyMaster>.Compare(CompanyMaster x, CompanyMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.LUBy.CompareTo(x.LUBy);
				}
				else
				{
					return x.LUBy.CompareTo(y.LUBy);
				}
			}
			#endregion
		}
		public class RemarksComparer : System.Collections.Generic.IComparer<CompanyMaster>
		{
			public SorterMode SorterMode;
			public RemarksComparer()
			{ }
			public RemarksComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CompanyMaster> Membres
			int System.Collections.Generic.IComparer<CompanyMaster>.Compare(CompanyMaster x, CompanyMaster y)
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
