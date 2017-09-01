using System;
using System.Text;

namespace WIMARTS.DB.BusinessObjects
{
	[Serializable()]
	public partial class TransporterDetails
	{
		private int _TransporterID;
		public int TransporterID
		{
			get { return _TransporterID; }
			set { _TransporterID = value; }
		}

		private string _TransporterName;
		public string TransporterName
		{
			get { return _TransporterName; }
			set { _TransporterName = value; }
		}

		private string _Address;
		public string Address
		{
			get { return _Address; }
			set { _Address = value; }
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

		public TransporterDetails()
		{ }
		public TransporterDetails(int TransporterID, string TransporterName, string Address, string City, string Pincode, string PhoneNum, string EmailID)
		{
			this.TransporterID = TransporterID;
			this.TransporterName = TransporterName;
			this.Address = Address;
			this.City = City;
			this.Pincode = Pincode;
			this.PhoneNum = PhoneNum;
			this.EmailID = EmailID;
		}

		public override string ToString()
		{
			return "TransporterID = " + TransporterID.ToString() + ",TransporterName = " + TransporterName + ",Address = " + Address + ",City = " + City + ",Pincode = " + Pincode + ",PhoneNum = " + PhoneNum + ",EmailID = " + EmailID;
		}

		public class TransporterIDComparer : System.Collections.Generic.IComparer<TransporterDetails>
		{
			public SorterMode SorterMode;
			public TransporterIDComparer()
			{ }
			public TransporterIDComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<TransporterDetails> Membres
			int System.Collections.Generic.IComparer<TransporterDetails>.Compare(TransporterDetails x, TransporterDetails y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.TransporterID.CompareTo(x.TransporterID);
				}
				else
				{
					return x.TransporterID.CompareTo(y.TransporterID);
				}
			}
			#endregion
		}
		public class TransporterNameComparer : System.Collections.Generic.IComparer<TransporterDetails>
		{
			public SorterMode SorterMode;
			public TransporterNameComparer()
			{ }
			public TransporterNameComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<TransporterDetails> Membres
			int System.Collections.Generic.IComparer<TransporterDetails>.Compare(TransporterDetails x, TransporterDetails y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.TransporterName.CompareTo(x.TransporterName);
				}
				else
				{
					return x.TransporterName.CompareTo(y.TransporterName);
				}
			}
			#endregion
		}
		public class AddressComparer : System.Collections.Generic.IComparer<TransporterDetails>
		{
			public SorterMode SorterMode;
			public AddressComparer()
			{ }
			public AddressComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<TransporterDetails> Membres
			int System.Collections.Generic.IComparer<TransporterDetails>.Compare(TransporterDetails x, TransporterDetails y)
			{
				if (SorterMode == SorterMode.Ascending)
				{
					return y.Address.CompareTo(x.Address);
				}
				else
				{
					return x.Address.CompareTo(y.Address);
				}
			}
			#endregion
		}
		public class CityComparer : System.Collections.Generic.IComparer<TransporterDetails>
		{
			public SorterMode SorterMode;
			public CityComparer()
			{ }
			public CityComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<TransporterDetails> Membres
			int System.Collections.Generic.IComparer<TransporterDetails>.Compare(TransporterDetails x, TransporterDetails y)
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
		public class PincodeComparer : System.Collections.Generic.IComparer<TransporterDetails>
		{
			public SorterMode SorterMode;
			public PincodeComparer()
			{ }
			public PincodeComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<TransporterDetails> Membres
			int System.Collections.Generic.IComparer<TransporterDetails>.Compare(TransporterDetails x, TransporterDetails y)
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
		public class PhoneNumComparer : System.Collections.Generic.IComparer<TransporterDetails>
		{
			public SorterMode SorterMode;
			public PhoneNumComparer()
			{ }
			public PhoneNumComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<TransporterDetails> Membres
			int System.Collections.Generic.IComparer<TransporterDetails>.Compare(TransporterDetails x, TransporterDetails y)
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
		public class EmailIDComparer : System.Collections.Generic.IComparer<TransporterDetails>
		{
			public SorterMode SorterMode;
			public EmailIDComparer()
			{ }
			public EmailIDComparer(SorterMode SorterMode)
			{
				this.SorterMode = SorterMode;
			}
			#region IComparer<TransporterDetails> Membres
			int System.Collections.Generic.IComparer<TransporterDetails>.Compare(TransporterDetails x, TransporterDetails y)
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

		public enum enumFlags
		{
			ALL,

			TransporterID,
			TransporterName,
			Address,
			City,
			Pincode,
			PhoneNum,
			EmailID,
		}
	}
}
