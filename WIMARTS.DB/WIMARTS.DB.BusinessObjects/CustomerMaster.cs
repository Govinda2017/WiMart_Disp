using System;
using System.Text;

namespace WIMARTS.DB.BusinessObjects
{
	[Serializable()]
	public partial class CustomerMaster
	{
		private int _CustID;

		public int CustID
		{
			get { return _CustID; }
			set { _CustID = value; }
		}

		private string _CustName;

		public string CustName
		{
			get { return _CustName; }
			set { _CustName = value; }
		}

		private string _EmailID;

		public string EmailID
		{
			get { return _EmailID; }
			set { _EmailID = value; }
		}

		private string _PhoneNum;

		public string PhoneNum
		{
			get { return _PhoneNum; }
			set { _PhoneNum = value; }
		}

		private string _WebSite;

		public string WebSite
		{
			get { return _WebSite; }
			set { _WebSite = value; }
		}

		private string _AddrLine;

		public string AddrLine
		{
			get { return _AddrLine; }
			set { _AddrLine = value; }
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

		public CustomerMaster()
		{ }

		public CustomerMaster(int CustID,string CustName,string EmailID,string PhoneNum,string WebSite,string AddrLine,string City,string Pincode,DateTime LUDate,int LUBy,string Remarks)
		{
			this.CustID = CustID;
			this.CustName = CustName;
			this.EmailID = EmailID;
			this.PhoneNum = PhoneNum;
			this.WebSite = WebSite;
			this.AddrLine = AddrLine;
			this.City = City;
			this.Pincode = Pincode;
			this.LUDate = LUDate;
			this.LUBy = LUBy;
			this.Remarks = Remarks;
		}

		public override string ToString()
		{
			return "CustID = " + CustID.ToString() + ",CustName = " + CustName + ",EmailID = " + EmailID + ",PhoneNum = " + PhoneNum + ",WebSite = " + WebSite + ",AddrLine = " + AddrLine + ",City = " + City + ",Pincode = " + Pincode + ",LUDate = " + LUDate.ToString() + ",LUBy = " + LUBy.ToString() + ",Remarks = " + Remarks;
		}

		public class CustIDComparer : System.Collections.Generic.IComparer<CustomerMaster>
		{
			public SorterMode SorterMode;
			public CustIDComparer()
			{ }
			public CustIDComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CustomerMaster> Membres
			int System.Collections.Generic.IComparer<CustomerMaster>.Compare(CustomerMaster x, CustomerMaster y)
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
		public class CustNameComparer : System.Collections.Generic.IComparer<CustomerMaster>
		{
			public SorterMode SorterMode;
			public CustNameComparer()
			{ }
			public CustNameComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CustomerMaster> Membres
			int System.Collections.Generic.IComparer<CustomerMaster>.Compare(CustomerMaster x, CustomerMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.CustName.CompareTo(x.CustName);
				}
				else
				{
					return x.CustName.CompareTo(y.CustName);
				}
			}
			#endregion
		}
		public class EmailIDComparer : System.Collections.Generic.IComparer<CustomerMaster>
		{
			public SorterMode SorterMode;
			public EmailIDComparer()
			{ }
			public EmailIDComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CustomerMaster> Membres
			int System.Collections.Generic.IComparer<CustomerMaster>.Compare(CustomerMaster x, CustomerMaster y)
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
		public class PhoneNumComparer : System.Collections.Generic.IComparer<CustomerMaster>
		{
			public SorterMode SorterMode;
			public PhoneNumComparer()
			{ }
			public PhoneNumComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CustomerMaster> Membres
			int System.Collections.Generic.IComparer<CustomerMaster>.Compare(CustomerMaster x, CustomerMaster y)
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
		public class WebSiteComparer : System.Collections.Generic.IComparer<CustomerMaster>
		{
			public SorterMode SorterMode;
			public WebSiteComparer()
			{ }
			public WebSiteComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CustomerMaster> Membres
			int System.Collections.Generic.IComparer<CustomerMaster>.Compare(CustomerMaster x, CustomerMaster y)
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
		public class AddrLineComparer : System.Collections.Generic.IComparer<CustomerMaster>
		{
			public SorterMode SorterMode;
			public AddrLineComparer()
			{ }
			public AddrLineComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CustomerMaster> Membres
			int System.Collections.Generic.IComparer<CustomerMaster>.Compare(CustomerMaster x, CustomerMaster y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.AddrLine.CompareTo(x.AddrLine);
				}
				else
				{
					return x.AddrLine.CompareTo(y.AddrLine);
				}
			}
			#endregion
		}
		public class CityComparer : System.Collections.Generic.IComparer<CustomerMaster>
		{
			public SorterMode SorterMode;
			public CityComparer()
			{ }
			public CityComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CustomerMaster> Membres
			int System.Collections.Generic.IComparer<CustomerMaster>.Compare(CustomerMaster x, CustomerMaster y)
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
		public class PincodeComparer : System.Collections.Generic.IComparer<CustomerMaster>
		{
			public SorterMode SorterMode;
			public PincodeComparer()
			{ }
			public PincodeComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CustomerMaster> Membres
			int System.Collections.Generic.IComparer<CustomerMaster>.Compare(CustomerMaster x, CustomerMaster y)
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
		public class LUDateComparer : System.Collections.Generic.IComparer<CustomerMaster>
		{
			public SorterMode SorterMode;
			public LUDateComparer()
			{ }
			public LUDateComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CustomerMaster> Membres
			int System.Collections.Generic.IComparer<CustomerMaster>.Compare(CustomerMaster x, CustomerMaster y)
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
		public class LUByComparer : System.Collections.Generic.IComparer<CustomerMaster>
		{
			public SorterMode SorterMode;
			public LUByComparer()
			{ }
			public LUByComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CustomerMaster> Membres
			int System.Collections.Generic.IComparer<CustomerMaster>.Compare(CustomerMaster x, CustomerMaster y)
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
		public class RemarksComparer : System.Collections.Generic.IComparer<CustomerMaster>
		{
			public SorterMode SorterMode;
			public RemarksComparer()
			{ }
			public RemarksComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<CustomerMaster> Membres
			int System.Collections.Generic.IComparer<CustomerMaster>.Compare(CustomerMaster x, CustomerMaster y)
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
