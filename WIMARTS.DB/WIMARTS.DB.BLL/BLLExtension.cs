using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;
using WIMARTS.DB.DAL;

namespace WIMARTS.DB.BLL
{
    public partial class UserMasterBLL
    {

        public DataTable GetUserMasterList(int RoleID, int UserID)
        {
            try
            {
                int i = 1;
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("UserID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Active");
                List<UserMaster> list = new List<UserMaster>();
                if (RoleID == 1)
                    list = UserMasterDAO.GetUserMasters();
                else
                    list.Add(UserMasterDAO.GetUserMaster(UserID));
                foreach (UserMaster UserMaster in list)
                {
                    dr = dt.NewRow();
                    dr[0] = UserMaster.UserID;
                    dr[1] = UserMaster.Name;
                    dr[2] = UserMaster.Active;
                    dt.Rows.Add(dr);
                    i++;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Boolean IsUserNameExist(string LoginName)
        {
            List<UserMaster> list = UserMasterDAO.GetUserMasters();
            return list.FindAll(x => x.Name == LoginName).Count > 0;
        }

        public List<UserMaster> GetActiveUsers(int RoleID)
        {
            List<UserMaster> list = UserMasterDAO.GetUserMasters();
            list = list.FindAll(x => x.Active == true);
            if (RoleID != 0)
            {
                list = list.FindAll(x => x.RoleID == RoleID);
            }
            return list;
        }
    }

    public partial class CustomerMasterBLL
    {
        public DataTable GetCustomerMasterList()
        {
            try
            {
                int i = 1;
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("CustID");
                dt.Columns.Add("Name");
                dt.Columns.Add("PhoneNumber");
                List<CustomerMaster> list = CustomerMasterDAO.GetCustomerMasters();
                foreach (CustomerMaster CustomerMaster in list)
                {
                    dr = dt.NewRow();
                    dr[0] = CustomerMaster.CustID;
                    dr[1] = CustomerMaster.CustName;
                    dr[2] = CustomerMaster.PhoneNum;
                    dt.Rows.Add(dr);
                    i++;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCustomerMastersDS(int MasterID)
        {
            try
            {
                return CustomerMasterDAO.GetCustomerMastersDS(MasterID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CustomerMaster GetCustomerMasterCSV(int MasterID)
        {
            try
            {
                return CustomerMasterDAO.GetCustomerMasterCSV(MasterID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public partial class CompanyMasterBLL
    {
        public DataTable GetCompanyMasterList()
        {
            try
            {
                int i = 1;
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("CompanyID");
                dt.Columns.Add("CompanyName");
                dt.Columns.Add("PhoneNumber");
                dt.Columns.Add("EmailID");
                List<CompanyMaster> list = CompanyMasterDAO.GetCompanyMasters();
                foreach (CompanyMaster CompanyMaster in list)
                {
                    dr = dt.NewRow();
                    dr[0] = CompanyMaster.CompanyID;
                    dr[1] = CompanyMaster.CompanyName;
                    dr[2] = CompanyMaster.PhoneNum;
                    dr[3] = CompanyMaster.EmailID;
                    dt.Rows.Add(dr);
                    i++;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetCompanyMasterDS()
        {
            try
            {
                return CompanyMasterDAO.GetCompanyMastersDS();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public partial class ProductMasterBLL
    {
        public enum Flag
        {
            ID = 0,
            Code = 1,
            Name = 2,
        }
        public DataSet GetProductSummary()
        {
            try
            {
                return ProductMasterDAO.GetProductSummary();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetProductDataset()
        {
            try
            {
                return ProductMasterDAO.GetProductDataset();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetProductDetail(int prodID)
        {
            try
            {
                return ProductMasterDAO.GetProductDetail(prodID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ProductMaster GetProductMaster(Flag flag, string Value)
        {
            try
            {
                return ProductMasterDAO.GetProductMaster((int)flag, Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public partial class PrintMasterBLL
    {
        public enum Flag
        {
            OnlyDates = 0,
            Product = 1,
        }

        public DataSet GetPrintMasterDataset()
        {
            try
            {
                return PrintMasterDAO.GetPrintMastersDataset();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetPrintMasterDS(int PrintID)
        {
            try
            {
                return PrintMasterDAO.GetPrintMasterDS(PrintID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetPrintMasterDS(Flag flag, DateTime FromDate, DateTime ToDate, string ProdID)
        {
            try
            {
                return PrintMasterDAO.GetPrintMasterDS((int)flag, FromDate, ToDate, ProdID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetPrintMasterBtnDate(Flag flag, DateTime FromDate, DateTime ToDate, string ProdID)
        {
            try
            {
                return PrintMasterDAO.GetPrintMastersBtnDate((int)flag, FromDate, ToDate, ProdID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetPrintMasterTop5()
        {
            try
            {
                try
                {
                    int i = 1;
                    DataTable dt = new DataTable();
                    DataRow dr;
                    dt.Columns.Add("Code");
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Batch");
                    dt.Columns.Add("Date");
                    dt.Columns.Add("Quantity");
                    List<PrintMaster> lstPrint = PrintMasterDAO.GetPrintMasterTop5();
                    foreach (PrintMaster oPrint in lstPrint)
                    {
                        dr = dt.NewRow();
                        dr[0] = oPrint.ProdCode;
                        dr[1] = oPrint.ProdName;
                        dr[2] = oPrint.BatchName;
                        dr[3] = oPrint.MfgDate;
                        dr[4] = oPrint.Quantity;
                        dt.Rows.Add(dr);
                        i++;
                    }
                    return dt;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateStatus(PrintMaster oPrintMaster)
        {
            try
            {
                return PrintMasterDAO.UpdateStatus(oPrintMaster);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateQuantity(PrintMaster oPrintMaster)
        {
            try
            {
                return PrintMasterDAO.UpdateQuantity(oPrintMaster);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

    public partial class RoleMasterBLL
    {


    }
    public partial class TemplateDesignsBLL
    {
        public int RemoveTemplateDesigns(string oTemplateDesigns)
        {
            try
            {
                return TemplateDesignsDAO.RemoveTemplateDesigns(oTemplateDesigns);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int RemoveTemplateDesigns(TemplateDesigns oTemplateDesigns)
        {
            try
            {
                return TemplateDesignsDAO.RemoveTemplateDesigns(oTemplateDesigns);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public partial class UserMasterBLL
    {
        public UserMaster UserSignIn(int UserID, string pwd)
        {
            try
            {
                return UserMasterDAO.UserSignIn(UserID, pwd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public partial class InspectionMasterBLL
    {
        public DataSet GetInspectionMastersDataset()
        {
            try
            {
                return InspectionMasterDAO.GetInspectionMastersDataset(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetInspectionMasterDS(int InspID)
        {
            try
            {
                return InspectionMasterDAO.GetInspectionMasterDS(InspID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetInspectionMasterDS(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                return InspectionMasterDAO.GetInspectionMasterDS(FromDate, ToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateStatus(InspectionMaster oInspectionMaster)
        {
            try
            {
                return InspectionMasterDAO.UpdateStatus(oInspectionMaster);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateQuantity(InspectionMaster oInspectionMaster)
        {
            try
            {
                return InspectionMasterDAO.UpdateQuantity(oInspectionMaster);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public partial class DispatchMasterBLL
    {
        public enum Flag
        {
            MasterID = 1,
            MasterIDs = 2,
            GDN = 3,
            VehicleNo = 4,
            Driver = 5,
            Line = 6,
            DispatchDate = 7,
        }
        public DataSet GetDispatchMDatasetByValue(Flag flag, string Value)
        {
            try
            {
                return DispatchMasterDAO.GetDispatchMDatasetByValue((int)flag, Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DispatchMaster> GetDispatchListByValue(Flag flag, string Value)
        {
            try
            {
                return DispatchMasterDAO.GetDispatchListByValue((int)flag, Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateStatus(DispatchMaster oDispatchMaster)
        {
            try
            {
                return DispatchMasterDAO.UpdateStatus(oDispatchMaster);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateQuantity(DispatchMaster oDispatchMaster)
        {
            try
            {
                return DispatchMasterDAO.UpdateQuantity(oDispatchMaster);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetDispatchMasterList(BLLManager.MasterStatus Flag)
        {
            try
            {
                int i = 1;
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("DispMasterID");
                dt.Columns.Add("GDN");
                dt.Columns.Add("VehicleNo");
                List<DispatchMaster> list = DispatchMasterDAO.GetDispatchMasters((int)Flag);
                foreach (DispatchMaster DispatchMaster in list)
                {
                    dr = dt.NewRow();
                    dr[0] = DispatchMaster.DispMasterID;
                    dr[1] = DispatchMaster.GDN;
                    dr[2] = DispatchMaster.VehicleNo;
                    dt.Rows.Add(dr);
                    i++;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
    }
    public partial class DispatchDetailsBLL
    {
        public enum Flag
        {
            All = -1,
            Master = 0,
            MultiMaster = 1,
        }
        public DataSet GetDailyDispatch(DateTime Fromdate, DateTime ToDate)
        {
            try
            {
                return DispatchDetailsDAO.GetDailyDispatch(Fromdate, ToDate); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetDispatchDsDataset()
        {
            try
            {
                return DispatchDetailsDAO.GetDispatchDsDataset(); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetDispatchDetailsByDispMasterDS(Flag Flag, string DispMasterID)
        {
            try
            {
                return DispatchDetailsDAO.GetDispatchDetailsByDispMasterDS((int)Flag, DispMasterID); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DispatchDetails> GetDispatchDetailsByDispMaster(Flag Flag, string DispMasterID)
        {
            try
            {
                return DispatchDetailsDAO.GetDispatchDetailsByDispMaster((int)Flag, DispMasterID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DetailsDispatchDetails> GetDetailsDispatchDetailsByDispMaster(Flag Flag, string DispMasterID)
        {
            try
            {
                return DispatchDetailsDAO.GetDetailsDispatchDetailsByDispMaster((int)Flag, DispMasterID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CSVDispatchDetails> GetCSVDispatchDetailsByDispMaster(Flag Flag, string DispMasterID)
        {
            try
            {
                return DispatchDetailsDAO.GetCSVDispatchDetailsByDispMaster((int)Flag, DispMasterID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateDispatchedQty(DispatchDetails oDispatchDetails)
        {
            try
            {
                return DispatchDetailsDAO.UpdateDispatchedQty(oDispatchDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    public partial class ItemDetailsBLL
    {
        public enum Flag
        {
            All = -1,
            Status = 0,
            ProdCode = 1,
            ProdCodenStatus = 2,
            BatchCode = 3,
            BatchCodenStatus = 4,
            PrintID = 5,
            InspID = 6,
            DispID = 7,
            LastItem = 8,
        }

        public enum ItemDate
        {
            Print = 1,
            Inspect = 2,
            Dispatch = 3,
        }

        public enum Report
        {
            PProduct = 1,
            PBatch = 2,
            IProduct = 3,
            IBatch = 4,
            DProduct = 5,
            DBatch = 6,
        }

        public DataSet GetItemDetailsReport(Report Flag, int LineID, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                return ItemDetailsDAO.GetItemDetailsReport((int)Flag, LineID, FromDate, ToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetItemDetailsReportCount(Report Flag, int LineID, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                return ItemDetailsDAO.GetItemDetailsReportCount((int)Flag, LineID, FromDate, ToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetItemDetailsDS(Flag flag, BLLManager.DetailsStatus Status, string Value)
        {
            try
            {
                return ItemDetailsDAO.GetItemDetailsDS((int)flag, (int)Status, Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetItemDetailsQuantityDS(int Quantity, BLLManager.DetailsStatus Status, string Value)
        {
            try
            {
                return ItemDetailsDAO.GetItemDetailsQuantityDS(Quantity, (int)Status, Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ItemDetails> GetItemDetailsQuantity(int Quantity, BLLManager.DetailsStatus Status, string Value)
        {
            try
            {
                return ItemDetailsDAO.GetItemDetailsQuantity(Quantity, (int)Status, Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetItemDetailsDateDS(ItemDate flag, int LineID, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                return ItemDetailsDAO.GetItemDetailsDateDS((int)flag, LineID, FromDate, ToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetItemDetailsDateDSCount(ItemDate flag, int LineID, DateTime FromDate, DateTime ToDate)
        {
            try
            {
                return ItemDetailsDAO.GetItemDetailsDateDSCount((int)flag, LineID, FromDate, ToDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ItemDetails> GetItemDetailss(Flag flag, BLLManager.DetailsStatus Status, string Value)
        {
            try
            {
                return ItemDetailsDAO.GetItemDetailss((int)flag, (int)Status, Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CSVItemDetails> GetCSVItemDetailss(Flag flag, BLLManager.DetailsStatus Status, string Value)
        {
            try
            {
                return ItemDetailsDAO.GetCSVItemDetailss((int)flag, (int)Status, Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ItemDetails GetItemDetails(Flag flag, BLLManager.DetailsStatus Status, string Value)
        {
            try
            {
                return ItemDetailsDAO.GetItemDetails((int)flag, (int)Status, Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ItemDetails GetItemDetails(BLLManager.DetailsStatus Status, string UIDCode)
        {
            try
            {
                return ItemDetailsDAO.GetItemDetails((int)Status, UIDCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ItemDetails GetItemDetailsBtnDays(BLLManager.DetailsStatus Status, int Days, string UIDCode)
        {
            try
            {
                return ItemDetailsDAO.GetItemDetailsBtnDays((int)Status, Days, UIDCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateInspectionStatus(ItemDetails oItemDetails)
        {
            try
            {
                return ItemDetailsDAO.UpdateInspectionStatus(oItemDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateDispatchStatus(ItemDetails oItemDetails)
        {
            try
            {
                return ItemDetailsDAO.UpdateDispatchStatus(oItemDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> GetItemDetailsUIDs(Flag flag, BLLManager.DetailsStatus Status, string Value)
        {
            try
            {
                return ItemDetailsDAO.GetItemDetailsUIDs((int)flag, (int)Status, Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public partial class TransporterDetailsBLL
    {
        public DataTable GetTransporterDetailsDT()
        {
            try
            {
                int i = 1;
                DataTable dt = new DataTable();
                DataRow dr;
                dt.Columns.Add("TransporterID");
                dt.Columns.Add("Name");
                dt.Columns.Add("PhoneNumber");
                List<TransporterDetails> list = TransporterDetailsDAO.GetTransporterDetailsList();
                foreach (TransporterDetails TransporterDetails in list)
                {
                    dr = dt.NewRow();
                    dr[0] = TransporterDetails.TransporterID;
                    dr[1] = TransporterDetails.TransporterName;
                    dr[2] = TransporterDetails.PhoneNum;
                    dt.Rows.Add(dr);
                    i++;
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}