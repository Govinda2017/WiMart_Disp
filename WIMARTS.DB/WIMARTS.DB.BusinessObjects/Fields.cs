using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml.Serialization;

namespace WIMARTS.DB.BusinessObjects
{
    [Serializable()]
    public class Field
    {
        public string NAME { get; set; }
        public string TITLE { get; set; }
        public string VALUE { get; set; }
        public SqlDbType DBTYPE { get; set; }
        //TBD:at insertion need to check these fields..
        public bool ISNULLABLE { get; set; }
        public int MAXLENGTH { get; set; }
        public int NUMERIC_SCALE { get; set; }


        public static bool compare(string str1, string str2)
        {
            bool hassimilar = false;

            if (str1 != null && str2 != null)
            {
                hassimilar = (String.Compare(str1.Trim(), str2.Trim(), StringComparison.CurrentCultureIgnoreCase) == 0);
            }

            return hassimilar;
        }
        public static string CreateFldName(string title)
        {
            return title.Trim().Replace(" ", "_");
        }
        public static SqlDbType ConvertSqlDbType(string dbtype)
        {

            if (compare(SqlDbType.BigInt.ToString(), dbtype))
                return SqlDbType.BigInt;

            else if (compare(SqlDbType.Binary.ToString(), dbtype))
                return SqlDbType.Binary;

            else if (compare(SqlDbType.Bit.ToString(), dbtype))
                return SqlDbType.Bit;

            else if (compare(SqlDbType.Char.ToString(), dbtype))
                return SqlDbType.Char;

            if (compare(SqlDbType.Date.ToString(), dbtype))
                return SqlDbType.Date;

            if (compare(SqlDbType.DateTime.ToString(), dbtype))
                return SqlDbType.DateTime;

            if (compare(SqlDbType.DateTime.ToString(), dbtype))
                return SqlDbType.DateTime2;

            if (compare(SqlDbType.DateTimeOffset.ToString(), dbtype))
                return SqlDbType.DateTimeOffset;

            if (compare(SqlDbType.Decimal.ToString(), dbtype))
                return SqlDbType.Decimal;

            if (compare(SqlDbType.Float.ToString(), dbtype))
                return SqlDbType.Float;

            if (compare(SqlDbType.Image.ToString(), dbtype))
                return SqlDbType.Image;

            if (compare(SqlDbType.Int.ToString(), dbtype))
                return SqlDbType.Int;

            if (compare(SqlDbType.Money.ToString(), dbtype))
                return SqlDbType.Money;

            if (compare(SqlDbType.NChar.ToString(), dbtype))
                return SqlDbType.NChar;

            if (compare(SqlDbType.NText.ToString(), dbtype))
                return SqlDbType.NText;

            if (compare(SqlDbType.NVarChar.ToString(), dbtype))
                return SqlDbType.NVarChar;

            if (compare(SqlDbType.Real.ToString(), dbtype))
                return SqlDbType.Real;

            if (compare(SqlDbType.SmallDateTime.ToString(), dbtype))
                return SqlDbType.SmallDateTime;

            if (compare(SqlDbType.SmallInt.ToString(), dbtype))
                return SqlDbType.SmallInt;

            if (compare(SqlDbType.SmallMoney.ToString(), dbtype))
                return SqlDbType.SmallMoney;

            if (compare(SqlDbType.Structured.ToString(), dbtype))
                return SqlDbType.Structured;

            if (compare(SqlDbType.Text.ToString(), dbtype))
                return SqlDbType.Text;

            if (compare(SqlDbType.Time.ToString(), dbtype))
                return SqlDbType.Time;

            if (compare(SqlDbType.Timestamp.ToString(), dbtype))
                return SqlDbType.Timestamp;

            if (compare(SqlDbType.TinyInt.ToString(), dbtype))
                return SqlDbType.TinyInt;

            if (compare(SqlDbType.Udt.ToString(), dbtype))
                return SqlDbType.Udt;

            if (compare(SqlDbType.UniqueIdentifier.ToString(), dbtype))
                return SqlDbType.UniqueIdentifier;

            if (compare(SqlDbType.VarBinary.ToString(), dbtype))
                return SqlDbType.VarBinary;

            if (compare(SqlDbType.VarChar.ToString(), dbtype))
                return SqlDbType.VarChar;

            if (compare(SqlDbType.Variant.ToString(), dbtype))
                return SqlDbType.Variant;

            if (compare(SqlDbType.Xml.ToString(), dbtype))
                return SqlDbType.Xml;
            else
                return SqlDbType.NVarChar;
        }
        public static bool isString(SqlDbType dtype)
        {
            switch (dtype)
            {
                case SqlDbType.Char:
                    return true;
                case SqlDbType.NChar:
                    return true;
                case SqlDbType.NText:
                    return true;
                case SqlDbType.NVarChar:
                    return true;
                case SqlDbType.Text:
                    return true;
                case SqlDbType.VarChar:
                    return true;
                default:
                    return false;
            }
        }
        public static bool isNumeric(SqlDbType  dtype)
        { 
            switch (dtype)
            { 
                case SqlDbType.Bit:
                    return true; 
                case SqlDbType.Decimal:
                    return true;
                case SqlDbType.Float:
                    return true;
                case SqlDbType.Int:
                    return true;    
                case SqlDbType.SmallInt:
                    return true;  
                case SqlDbType.TinyInt:
                    return true;
                default:
                    return false;
            }
        }
        public static bool isDatetime(SqlDbType dtype)
        {
            switch (dtype)
            {
                case SqlDbType.Date:
                    return true;
                case SqlDbType.DateTime:
                    return true;
                case SqlDbType.DateTime2:
                    return true;
                case SqlDbType.DateTimeOffset:
                    return true;
                case SqlDbType.SmallDateTime:
                    return true;
                //case SqlDbType.Time:
                //    break;
                //case SqlDbType.Timestamp:
                //    break;
                default:
                    return false;
            }

        }
        public static bool hasDbTypeMajorLength(SqlDbType dtype)
        {
            switch (dtype)
            {
                case SqlDbType.Binary:
                    return true;
                case SqlDbType.Char:
                    return true;
                case SqlDbType.DateTime2:
                    return true;
                case SqlDbType.DateTimeOffset:
                    return true;
                case SqlDbType.Decimal:
                    return true;
                case SqlDbType.NChar:
                    return true;
                case SqlDbType.NVarChar:
                    return true;
                case SqlDbType.Time:
                    return true;
                case SqlDbType.VarBinary:
                    return true;
                case SqlDbType.VarChar:
                    return true;
                default:
                    return false;
            }
        }

        public static bool hasDbTypeMinorLength(SqlDbType dtype)
        {
            switch (dtype)
            {
                case SqlDbType.Decimal:
                    return true;
                default:
                    return false;
            }
        }

        public static object getDefaultValue(SqlDbType sqlDbType)
        {
            if (isNumeric(sqlDbType))
                return 0;
            else if (isDatetime(sqlDbType))
                return "GETDATE()";
            else if (isString(sqlDbType))
                return "''";
            return null;
        }
    }
}
