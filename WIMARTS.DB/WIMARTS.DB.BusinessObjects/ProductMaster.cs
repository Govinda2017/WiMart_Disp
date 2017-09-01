using System;
using System.Text;

namespace WIMARTS.DB.BusinessObjects
{
    [Serializable()]
    public partial class ProductMaster
    {
        private int _ProdID;

        public int ProdID
        {
            get { return _ProdID; }
            set { _ProdID = value; }
        }

        private string _Code;

        public string Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Unit;

        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }

        private string _Category;

        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }

        private Decimal _MRP;

        public Decimal MRP
        {
            get { return _MRP; }
            set { _MRP = value; }
        }

        private int _Packsize;

        public int Packsize
        {
            get { return _Packsize; }
            set { _Packsize = value; }
        }

        private Nullable<Decimal> _NetWeight;

        public Nullable<Decimal> NetWeight
        {
            get { return _NetWeight; }
            set { _NetWeight = value; }
        }

        private Nullable<Decimal> _GrossWeight;

        public Nullable<Decimal> GrossWeight
        {
            get { return _GrossWeight; }
            set { _GrossWeight = value; }
        }

        private string _OldItemCode;

        public string OldItemCode
        {
            get { return _OldItemCode; }
            set { _OldItemCode = value; }
        }

        private string _ProductGroup;

        public string ProductGroup
        {
            get { return _ProductGroup; }
            set { _ProductGroup = value; }
        }

        private Nullable<bool> _Status;

        public Nullable<bool> Status
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

        public ProductMaster()
        { }

        public ProductMaster(int ProdID, string Code, string Name, string Unit, string Category, Decimal MRP, int Packsize, Nullable<Decimal> NetWeight, Nullable<Decimal> GrossWeight, string OldItemCode, string ProductGroup, Nullable<bool> Status, DateTime CreatedDate, DateTime LUDate, string Remarks)
        {
            this.ProdID = ProdID;
            this.Code = Code;
            this.Name = Name;
            this.Unit = Unit;
            this.Category = Category;
            this.MRP = MRP;
            this.Packsize = Packsize;
            this.NetWeight = NetWeight;
            this.GrossWeight = GrossWeight;
            this.OldItemCode = OldItemCode;
            this.ProductGroup = ProductGroup;
            this.Status = Status;
            this.CreatedDate = CreatedDate;
            this.LUDate = LUDate;
            this.Remarks = Remarks;
        }

        public override string ToString()
        {
            return "ProdID = " + ProdID.ToString() + ",Code = " + Code + ",Name = " + Name + ",Unit = " + Unit + ",Category = " + Category + ",MRP = " + MRP.ToString() + ",Packsize = " + Packsize.ToString() + ",NetWeight = " + NetWeight.ToString() + ",GrossWeight = " + GrossWeight.ToString() + ",OldItemCode = " + OldItemCode + ",ProductGroup = " + ProductGroup + ",Status = " + Status.ToString() + ",CreatedDate = " + CreatedDate.ToString() + ",LUDate = " + LUDate.ToString() + ",Remarks = " + Remarks;
        }

        public class ProdIDComparer : System.Collections.Generic.IComparer<ProductMaster>
        {
            public SorterMode SorterMode;
            public ProdIDComparer()
            { }
            public ProdIDComparer(SorterMode SorterMode)
            {
                this.SorterMode = SorterMode;
            }
            #region IComparer<ProductMaster> Membres
            int System.Collections.Generic.IComparer<ProductMaster>.Compare(ProductMaster x, ProductMaster y)
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
        public class CodeComparer : System.Collections.Generic.IComparer<ProductMaster>
        {
            public SorterMode SorterMode;
            public CodeComparer()
            { }
            public CodeComparer(SorterMode SorterMode)
            {
                this.SorterMode = SorterMode;
            }
            #region IComparer<ProductMaster> Membres
            int System.Collections.Generic.IComparer<ProductMaster>.Compare(ProductMaster x, ProductMaster y)
            {
                if (SorterMode == SorterMode.Ascending)
                {
                    return y.Code.CompareTo(x.Code);
                }
                else
                {
                    return x.Code.CompareTo(y.Code);
                }
            }
            #endregion
        }
        public class NameComparer : System.Collections.Generic.IComparer<ProductMaster>
        {
            public SorterMode SorterMode;
            public NameComparer()
            { }
            public NameComparer(SorterMode SorterMode)
            {
                this.SorterMode = SorterMode;
            }
            #region IComparer<ProductMaster> Membres
            int System.Collections.Generic.IComparer<ProductMaster>.Compare(ProductMaster x, ProductMaster y)
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
        public class UnitComparer : System.Collections.Generic.IComparer<ProductMaster>
        {
            public SorterMode SorterMode;
            public UnitComparer()
            { }
            public UnitComparer(SorterMode SorterMode)
            {
                this.SorterMode = SorterMode;
            }
            #region IComparer<ProductMaster> Membres
            int System.Collections.Generic.IComparer<ProductMaster>.Compare(ProductMaster x, ProductMaster y)
            {
                if (SorterMode == SorterMode.Ascending)
                {
                    return y.Unit.CompareTo(x.Unit);
                }
                else
                {
                    return x.Unit.CompareTo(y.Unit);
                }
            }
            #endregion
        }
        public class CategoryComparer : System.Collections.Generic.IComparer<ProductMaster>
        {
            public SorterMode SorterMode;
            public CategoryComparer()
            { }
            public CategoryComparer(SorterMode SorterMode)
            {
                this.SorterMode = SorterMode;
            }
            #region IComparer<ProductMaster> Membres
            int System.Collections.Generic.IComparer<ProductMaster>.Compare(ProductMaster x, ProductMaster y)
            {
                if (SorterMode == SorterMode.Ascending)
                {
                    return y.Category.CompareTo(x.Category);
                }
                else
                {
                    return x.Category.CompareTo(y.Category);
                }
            }
            #endregion
        }
        public class MRPComparer : System.Collections.Generic.IComparer<ProductMaster>
        {
            public SorterMode SorterMode;
            public MRPComparer()
            { }
            public MRPComparer(SorterMode SorterMode)
            {
                this.SorterMode = SorterMode;
            }
            #region IComparer<ProductMaster> Membres
            int System.Collections.Generic.IComparer<ProductMaster>.Compare(ProductMaster x, ProductMaster y)
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
        public class PacksizeComparer : System.Collections.Generic.IComparer<ProductMaster>
        {
            public SorterMode SorterMode;
            public PacksizeComparer()
            { }
            public PacksizeComparer(SorterMode SorterMode)
            {
                this.SorterMode = SorterMode;
            }
            #region IComparer<ProductMaster> Membres
            int System.Collections.Generic.IComparer<ProductMaster>.Compare(ProductMaster x, ProductMaster y)
            {
                if (SorterMode == SorterMode.Ascending)
                {
                    return y.Packsize.CompareTo(x.Packsize);
                }
                else
                {
                    return x.Packsize.CompareTo(y.Packsize);
                }
            }
            #endregion
        }
        public class OldItemCodeComparer : System.Collections.Generic.IComparer<ProductMaster>
        {
            public SorterMode SorterMode;
            public OldItemCodeComparer()
            { }
            public OldItemCodeComparer(SorterMode SorterMode)
            {
                this.SorterMode = SorterMode;
            }
            #region IComparer<ProductMaster> Membres
            int System.Collections.Generic.IComparer<ProductMaster>.Compare(ProductMaster x, ProductMaster y)
            {
                if (SorterMode == SorterMode.Ascending)
                {
                    return y.OldItemCode.CompareTo(x.OldItemCode);
                }
                else
                {
                    return x.OldItemCode.CompareTo(y.OldItemCode);
                }
            }
            #endregion
        }
        public class ProductGroupComparer : System.Collections.Generic.IComparer<ProductMaster>
        {
            public SorterMode SorterMode;
            public ProductGroupComparer()
            { }
            public ProductGroupComparer(SorterMode SorterMode)
            {
                this.SorterMode = SorterMode;
            }
            #region IComparer<ProductMaster> Membres
            int System.Collections.Generic.IComparer<ProductMaster>.Compare(ProductMaster x, ProductMaster y)
            {
                if (SorterMode == SorterMode.Ascending)
                {
                    return y.ProductGroup.CompareTo(x.ProductGroup);
                }
                else
                {
                    return x.ProductGroup.CompareTo(y.ProductGroup);
                }
            }
            #endregion
        }
        public class CreatedDateComparer : System.Collections.Generic.IComparer<ProductMaster>
        {
            public SorterMode SorterMode;
            public CreatedDateComparer()
            { }
            public CreatedDateComparer(SorterMode SorterMode)
            {
                this.SorterMode = SorterMode;
            }
            #region IComparer<ProductMaster> Membres
            int System.Collections.Generic.IComparer<ProductMaster>.Compare(ProductMaster x, ProductMaster y)
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
        public class LUDateComparer : System.Collections.Generic.IComparer<ProductMaster>
        {
            public SorterMode SorterMode;
            public LUDateComparer()
            { }
            public LUDateComparer(SorterMode SorterMode)
            {
                this.SorterMode = SorterMode;
            }
            #region IComparer<ProductMaster> Membres
            int System.Collections.Generic.IComparer<ProductMaster>.Compare(ProductMaster x, ProductMaster y)
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
        public class RemarksComparer : System.Collections.Generic.IComparer<ProductMaster>
        {
            public SorterMode SorterMode;
            public RemarksComparer()
            { }
            public RemarksComparer(SorterMode SorterMode)
            {
                this.SorterMode = SorterMode;
            }
            #region IComparer<ProductMaster> Membres
            int System.Collections.Generic.IComparer<ProductMaster>.Compare(ProductMaster x, ProductMaster y)
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
