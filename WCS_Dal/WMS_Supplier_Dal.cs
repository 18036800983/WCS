using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS_Dal
{
    public class WMS_Supplier_Dal
    {
        /// <summary>
        /// 查询供应商
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Select_Supplier(string condition)
        {
            string _selectSupplier = string.Empty;
            if (!string.IsNullOrEmpty(condition))
            {
                _selectSupplier = "SELECT [CompanyName]"
                    + ",[PartName],[CreatPerson],[CreatTime]"
                    + ",[ModifyPerson],[ModifyTime] FROM [WMS].[dbo].[WMS_Supplier] Where " + condition;
            }
            else
            {
                _selectSupplier = "SELECT [CompanyName]"
                    + ",[PartName],[CreatPerson],[CreatTime]"
                    + ",[ModifyPerson],[ModifyTime] FROM [WMS].[dbo].[WMS_Supplier]";
            }
            return _selectSupplier;
        }

        /// <summary>
        /// 插入供应商
        /// </summary>
        /// <param name="wms_Supplier_Model"></param>
        /// <returns></returns>
        public static string Insert_Supplier(WMS_Supplier_Model wms_Supplier_Model)
        {
            string _insertSql = "INSERT INTO [WMS].[dbo].[WMS_Supplier]"
                + "([CompanyName],[PartName],[CreatPerson]"
                + ",[CreatTime],[ModifyPerson],[ModifyTime])"
                + "VALUES('" + wms_Supplier_Model.CompanyName
                + "','" + wms_Supplier_Model.PartName
                + "','" + wms_Supplier_Model.CreatPerson
                + "','" + wms_Supplier_Model.CreatTime
                + "','" + wms_Supplier_Model.ModifyPerson
                + "','" + wms_Supplier_Model.ModifyTime + "')";
            return _insertSql;
        }

        /// <summary>
        /// 更新供应商
        /// </summary>
        /// <param name="wms_Supplier_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Update_Supplier(WMS_Supplier_Model wms_Supplier_Model, string condition)
        {
            string _updateSql = "UPDATE [WMS].[dbo].[WMS_Supplier]"
                + "SET[CompanyName] = '" + wms_Supplier_Model.CompanyName
                + "',[PartName] = '" + wms_Supplier_Model.PartName
                + "',[CreatPerson] = '" + wms_Supplier_Model.CreatPerson
                + "',[CreatTime] = '" + wms_Supplier_Model.CreatTime
                + "',[ModifyPerson] = '" + wms_Supplier_Model.ModifyPerson
                + "',[ModifyTime] = '" + wms_Supplier_Model.ModifyTime
                + "' WHERE " + condition;
            return _updateSql;
        }

        /// <summary>
        /// 删除供应商
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Delete_Supplier(string condition)
        {
            string _deleteSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Supplier]";
            }
            else
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Supplier] Where " + condition;
            }
            return _deleteSql;
        }
    }
}
