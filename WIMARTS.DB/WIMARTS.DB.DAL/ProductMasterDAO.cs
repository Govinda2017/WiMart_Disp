using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using WIMARTS.DB.BusinessObjects;

namespace WIMARTS.DB.DAL
{
    public partial class ProductMasterDAO
    {
        public ProductMasterDAO()
        {
            DbProviderHelper.GetConnection();
        }
        public List<ProductMaster> GetProductMasters()
        {
            try
            {
                List<ProductMaster> lstProductMasters = new List<ProductMaster>();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTProductMasters", CommandType.StoredProcedure);
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    ProductMaster oProductMaster = new ProductMaster();
                    oProductMaster.ProdID = Convert.ToInt32(oDbDataReader["ProdID"]);
                    oProductMaster.Code = Convert.ToString(oDbDataReader["Code"]);
                    oProductMaster.Name = Convert.ToString(oDbDataReader["Name"]);

                    if (oDbDataReader["Unit"] != DBNull.Value)
                        oProductMaster.Unit = Convert.ToString(oDbDataReader["Unit"]);

                    if (oDbDataReader["Category"] != DBNull.Value)
                        oProductMaster.Category = Convert.ToString(oDbDataReader["Category"]);
                    oProductMaster.MRP = Convert.ToDecimal(oDbDataReader["MRP"]);
                    oProductMaster.Packsize = Convert.ToInt32(oDbDataReader["Packsize"]);

                    if (oDbDataReader["NetWeight"] != DBNull.Value)
                        oProductMaster.NetWeight = Convert.ToDecimal(oDbDataReader["NetWeight"]);

                    if (oDbDataReader["GrossWeight"] != DBNull.Value)
                        oProductMaster.GrossWeight = Convert.ToDecimal(oDbDataReader["GrossWeight"]);

                    if (oDbDataReader["OldItemCode"] != DBNull.Value)
                        oProductMaster.OldItemCode = Convert.ToString(oDbDataReader["OldItemCode"]);

                    if (oDbDataReader["ProductGroup"] != DBNull.Value)
                        oProductMaster.ProductGroup = Convert.ToString(oDbDataReader["ProductGroup"]);

                    if (oDbDataReader["Status"] != DBNull.Value)
                        oProductMaster.Status = Convert.ToBoolean(oDbDataReader["Status"]);
                    oProductMaster.CreatedDate = Convert.ToDateTime(oDbDataReader["CreatedDate"]);
                    oProductMaster.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);

                    if (oDbDataReader["Remarks"] != DBNull.Value)
                        oProductMaster.Remarks = Convert.ToString(oDbDataReader["Remarks"]);
                    lstProductMasters.Add(oProductMaster);
                }
                oDbDataReader.Close();
                return lstProductMasters;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ProductMaster GetProductMaster(int ProdID)
        {
            try
            {
                ProductMaster oProductMaster = new ProductMaster();
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("SELECTProductMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProdID", DbType.Int32, ProdID));
                DbDataReader oDbDataReader = DbProviderHelper.ExecuteReader(oDbCommand);
                while (oDbDataReader.Read())
                {
                    oProductMaster.ProdID = Convert.ToInt32(oDbDataReader["ProdID"]);
                    oProductMaster.Code = Convert.ToString(oDbDataReader["Code"]);
                    oProductMaster.Name = Convert.ToString(oDbDataReader["Name"]);

                    if (oDbDataReader["Unit"] != DBNull.Value)
                        oProductMaster.Unit = Convert.ToString(oDbDataReader["Unit"]);

                    if (oDbDataReader["Category"] != DBNull.Value)
                        oProductMaster.Category = Convert.ToString(oDbDataReader["Category"]);
                    oProductMaster.MRP = Convert.ToDecimal(oDbDataReader["MRP"]);
                    oProductMaster.Packsize = Convert.ToInt32(oDbDataReader["Packsize"]);

                    if (oDbDataReader["NetWeight"] != DBNull.Value)
                        oProductMaster.NetWeight = Convert.ToDecimal(oDbDataReader["NetWeight"]);

                    if (oDbDataReader["GrossWeight"] != DBNull.Value)
                        oProductMaster.GrossWeight = Convert.ToDecimal(oDbDataReader["GrossWeight"]);

                    if (oDbDataReader["OldItemCode"] != DBNull.Value)
                        oProductMaster.OldItemCode = Convert.ToString(oDbDataReader["OldItemCode"]);

                    if (oDbDataReader["ProductGroup"] != DBNull.Value)
                        oProductMaster.ProductGroup = Convert.ToString(oDbDataReader["ProductGroup"]);

                    if (oDbDataReader["Status"] != DBNull.Value)
                        oProductMaster.Status = Convert.ToBoolean(oDbDataReader["Status"]);
                    oProductMaster.CreatedDate = Convert.ToDateTime(oDbDataReader["CreatedDate"]);
                    oProductMaster.LUDate = Convert.ToDateTime(oDbDataReader["LUDate"]);

                    if (oDbDataReader["Remarks"] != DBNull.Value)
                        oProductMaster.Remarks = Convert.ToString(oDbDataReader["Remarks"]);
                }
                oDbDataReader.Close();
                return oProductMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int AddProductMaster(ProductMaster oProductMaster)
        {
            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("INSERTOrUPDATEProductMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Code", DbType.String, oProductMaster.Code));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Name", DbType.String, oProductMaster.Name));
                if (oProductMaster.Unit != null)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Unit", DbType.String, oProductMaster.Unit));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Unit", DbType.String, DBNull.Value));
                if (oProductMaster.Category != null)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Category", DbType.String, oProductMaster.Category));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Category", DbType.String, DBNull.Value));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@MRP", DbType.Decimal, oProductMaster.MRP));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Packsize", DbType.Int32, oProductMaster.Packsize));
                if (oProductMaster.NetWeight.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@NetWeight", DbType.Decimal, oProductMaster.NetWeight));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@NetWeight", DbType.Decimal, DBNull.Value));
                if (oProductMaster.GrossWeight.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GrossWeight", DbType.Decimal, oProductMaster.GrossWeight));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GrossWeight", DbType.Decimal, DBNull.Value));
                if (oProductMaster.OldItemCode != null)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@OldItemCode", DbType.String, oProductMaster.OldItemCode));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@OldItemCode", DbType.String, DBNull.Value));
                if (oProductMaster.ProductGroup != null)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProductGroup", DbType.String, oProductMaster.ProductGroup));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProductGroup", DbType.String, DBNull.Value));
                if (oProductMaster.Status.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Boolean, oProductMaster.Status));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Boolean, DBNull.Value));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CreatedDate", DbType.DateTime, oProductMaster.CreatedDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate", DbType.DateTime, oProductMaster.LUDate));
                if (oProductMaster.Remarks != null)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks", DbType.String, oProductMaster.Remarks));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks", DbType.String, DBNull.Value));

                return Convert.ToInt32(DbProviderHelper.ExecuteScalar(oDbCommand));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateProductMaster(ProductMaster oProductMaster)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("UPDATEProductMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Code", DbType.String, oProductMaster.Code));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Name", DbType.String, oProductMaster.Name));
                if (oProductMaster.Unit != null)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Unit", DbType.String, oProductMaster.Unit));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Unit", DbType.String, DBNull.Value));
                if (oProductMaster.Category != null)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Category", DbType.String, oProductMaster.Category));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Category", DbType.String, DBNull.Value));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@MRP", DbType.Decimal, oProductMaster.MRP));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Packsize", DbType.Int32, oProductMaster.Packsize));
                if (oProductMaster.NetWeight.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@NetWeight", DbType.Decimal, oProductMaster.NetWeight));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@NetWeight", DbType.Decimal, DBNull.Value));
                if (oProductMaster.GrossWeight.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GrossWeight", DbType.Decimal, oProductMaster.GrossWeight));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@GrossWeight", DbType.Decimal, DBNull.Value));
                if (oProductMaster.OldItemCode != null)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@OldItemCode", DbType.String, oProductMaster.OldItemCode));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@OldItemCode", DbType.String, DBNull.Value));
                if (oProductMaster.ProductGroup != null)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProductGroup", DbType.String, oProductMaster.ProductGroup));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProductGroup", DbType.String, DBNull.Value));
                if (oProductMaster.Status.HasValue)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Boolean, oProductMaster.Status));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Status", DbType.Boolean, DBNull.Value));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@CreatedDate", DbType.DateTime, oProductMaster.CreatedDate));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@LUDate", DbType.DateTime, oProductMaster.LUDate));
                if (oProductMaster.Remarks != null)
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks", DbType.String, oProductMaster.Remarks));
                else
                    oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@Remarks", DbType.String, DBNull.Value));
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProdID", DbType.Int32, oProductMaster.ProdID));
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int RemoveProductMaster(ProductMaster oProductMaster)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETEProductMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProdID", DbType.Int32, oProductMaster.ProdID));
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int RemoveProductMaster(int ProdID)
        {

            try
            {
                DbCommand oDbCommand = DbProviderHelper.CreateCommand("DELETEProductMaster", CommandType.StoredProcedure);
                oDbCommand.Parameters.Add(DbProviderHelper.CreateParameter("@ProdID", DbType.Int32, ProdID));
                return DbProviderHelper.ExecuteNonQuery(oDbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
