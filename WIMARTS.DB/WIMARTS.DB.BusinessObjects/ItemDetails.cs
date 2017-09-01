using System;
using System.Text;

namespace WIMARTS.DB.BusinessObjects
{
    [Serializable()]
    public partial class ItemDetails
    {
        private int _DetailsID;

        public int DetailsID
        {
            get { return _DetailsID; }
            set { _DetailsID = value; }
        }

        private Nullable<int> _PrintID;

        public Nullable<int> PrintID
        {
            get { return _PrintID; }
            set { _PrintID = value; }
        }

        private Nullable<int> _InspID;

        public Nullable<int> InspID
        {
            get { return _InspID; }
            set { _InspID = value; }
        }

        private Nullable<int> _DispID;

        public Nullable<int> DispID
        {
            get { return _DispID; }
            set { _DispID = value; }
        }

        private Nullable<int> _DispLineID;

        public Nullable<int> DispLineID
        {
            get { return _DispLineID; }
            set { _DispLineID = value; }
        }

        private string _ProdCode;

        public string ProdCode
        {
            get { return _ProdCode; }
            set { _ProdCode = value; }
        }

        private string _BatchCode;

        public string BatchCode
        {
            get { return _BatchCode; }
            set { _BatchCode = value; }
        }

        private string _UIDCode;

        public string UIDCode
        {
            get { return _UIDCode; }
            set { _UIDCode = value; }
        }

        private int _Status;

        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private DateTime _CreatedDate;

        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }

        private Nullable<DateTime> _InspectedDate;

        public Nullable<DateTime> InspectedDate
        {
            get { return _InspectedDate; }
            set { _InspectedDate = value; }
        }

        private Nullable<DateTime> _DispatchedDate;

        public Nullable<DateTime> DispatchedDate
        {
            get { return _DispatchedDate; }
            set { _DispatchedDate = value; }
        }

        private DateTime _LUDate;

        public DateTime LUDate
        {
            get { return _LUDate; }
            set { _LUDate = value; }
        }

        public ItemDetails()
        { }

        public ItemDetails(int DetailsID, Nullable<int> PrintID, Nullable<int> InspID, Nullable<int> DispID, Nullable<int> DispLineID, string ProdCode, string BatchCode, string UIDCode, int Status, DateTime CreatedDate, Nullable<DateTime> InspectedDate, Nullable<DateTime> DispatchedDate, DateTime LUDate)
        {
            this.DetailsID = DetailsID;
            this.PrintID = PrintID;
            this.InspID = InspID;
            this.DispID = DispID;
            this.DispLineID = DispLineID;
            this.ProdCode = ProdCode;
            this.BatchCode = BatchCode;
            this.UIDCode = UIDCode;
            this.Status = Status;
            this.CreatedDate = CreatedDate;
            this.InspectedDate = InspectedDate;
            this.DispatchedDate = DispatchedDate;
            this.LUDate = LUDate;
        }

        public override string ToString()
        {
            return "DetailsID = " + DetailsID.ToString() + ",PrintID = " + PrintID.ToString() + ",InspID = " + InspID.ToString() + ",DispID = " + DispID.ToString() + ",DispLineID=" + DispLineID.ToString() + ",ProdCode = " + ProdCode + ",BatchCode = " + BatchCode + ",UIDCode = " + UIDCode + ",Status = " + Status.ToString() + ",CreatedDate = " + CreatedDate.ToString() + ",InspectedDate = " + InspectedDate.ToString() + ",DispatchedDate = " + DispatchedDate.ToString() + ",LUDate = " + LUDate.ToString();
        }

        public class PrintDetailsIDComparer : System.Collections.Generic.IComparer<ItemDetails>
        {
            public SorterMode SorterMode;
            public PrintDetailsIDComparer()
            { }
            public PrintDetailsIDComparer(SorterMode SorterMode)
            {
                this.SorterMode = SorterMode;
            }
            #region IComparer<ItemDetails> Membres
            int System.Collections.Generic.IComparer<ItemDetails>.Compare(ItemDetails x, ItemDetails y)
            {
                if (SorterMode == SorterMode.Ascending)
                {
                    return y.DetailsID.CompareTo(x.DetailsID);
                }
                else
                {
                    return x.DetailsID.CompareTo(y.DetailsID);
                }
            }
            #endregion
        }

        public class UIDCodeComparer : System.Collections.Generic.IComparer<ItemDetails>
        {
            public SorterMode SorterMode;
            public UIDCodeComparer()
            { }
            public UIDCodeComparer(SorterMode SorterMode)
            {
                this.SorterMode = SorterMode;
            }
            #region IComparer<ItemDetails> Membres
            int System.Collections.Generic.IComparer<ItemDetails>.Compare(ItemDetails x, ItemDetails y)
            {
                if (SorterMode == SorterMode.Ascending)
                {
                    return y.UIDCode.CompareTo(x.UIDCode);
                }
                else
                {
                    return x.UIDCode.CompareTo(y.UIDCode);
                }
            }
            #endregion
        }
        public class StatusComparer : System.Collections.Generic.IComparer<ItemDetails>
        {
            public SorterMode SorterMode;
            public StatusComparer()
            { }
            public StatusComparer(SorterMode SorterMode)
            {
                this.SorterMode = SorterMode;
            }
            #region IComparer<ItemDetails> Membres
            int System.Collections.Generic.IComparer<ItemDetails>.Compare(ItemDetails x, ItemDetails y)
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
        public class CreatedDateComparer : System.Collections.Generic.IComparer<ItemDetails>
        {
            public SorterMode SorterMode;
            public CreatedDateComparer()
            { }
            public CreatedDateComparer(SorterMode SorterMode)
            {
                this.SorterMode = SorterMode;
            }
            #region IComparer<ItemDetails> Membres
            int System.Collections.Generic.IComparer<ItemDetails>.Compare(ItemDetails x, ItemDetails y)
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
        public class LUDateComparer : System.Collections.Generic.IComparer<ItemDetails>
        {
            public SorterMode SorterMode;
            public LUDateComparer()
            { }
            public LUDateComparer(SorterMode SorterMode)
            {
                this.SorterMode = SorterMode;
            }
            #region IComparer<ItemDetails> Membres
            int System.Collections.Generic.IComparer<ItemDetails>.Compare(ItemDetails x, ItemDetails y)
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
    }
    [Serializable()]
    public partial class CSVItemDetails
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
        private string _BatchCode;

        public string BatchCode
        {
            get { return _BatchCode; }
            set { _BatchCode = value; }
        }

        private string _UIDCode;

        public string UIDCode
        {
            get { return _UIDCode; }
            set { _UIDCode = value; }
        }


        private Nullable<DateTime> _DispatchedDate;

        public Nullable<DateTime> DispatchedDate
        {
            get { return _DispatchedDate; }
            set { _DispatchedDate = value; }
        }
        public CSVItemDetails()
        { }
        public CSVItemDetails(string ProdCode, string BatchCode, string UIDCode,  Nullable<DateTime> DispatchedDate)
        {

            this.ProdCode = ProdCode;
            this.BatchCode = BatchCode;
            this.UIDCode = UIDCode;
            this.DispatchedDate = DispatchedDate;
        }

        public override string ToString()
        {
            return "ProdCode = " + ProdCode + ",BatchCode = " + BatchCode + ",UIDCode = " + UIDCode + ",DispatchedDate = " + DispatchedDate.ToString();
        }
    }
}
