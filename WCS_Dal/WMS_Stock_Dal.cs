using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS_Dal
{
    public class WMS_Stock_Dal
    {

        /// <summary>
        /// 查询库存
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Select_Stock(string condition)
        {
            string _selectSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _selectSql = "SELECT [ShelfNo],[AreaNo],[WarehouseNo]"
                    + ",[SN],[ProductionNo],[PutInNo] FROM [WMS].[dbo].[WMS_Stock]";
            }
            else
            {
                _selectSql = "SELECT [ShelfNo],[AreaNo],[WarehouseNo]"
                    + ",[SN],[ProductionNo],[PutInNo] FROM [WMS].[dbo].[WMS_Stock] WHERE " + condition;
            }
            return _selectSql;
        }

        /// <summary>
        /// 插入库存
        /// </summary>
        /// <param name="wms_Stock_Model"></param>
        /// <returns></returns>
        public static string Insert_Stock(WMS_Stock_Model wms_Stock_Model)
        {
            string _insertSql = "INSERT INTO [WMS].[dbo].[WMS_Stock]" 
                + "([ShelfNo],[AreaNo],[WarehouseNo],[SN],[ProductionNo]" 
                + ",[PutInNo])VALUES('" + wms_Stock_Model.ShelfNo 
                + "','" + wms_Stock_Model.AreaNo + "','" 
                + wms_Stock_Model.WarehouseNo + "','" 
                + wms_Stock_Model.SN + "','" + wms_Stock_Model.ProductionNo 
                + "','" + wms_Stock_Model.PutInNo + "')";
            return _insertSql;
        }

        /// <summary>
        /// 更新库存
        /// </summary>
        /// <param name="wms_Stock_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Update_Stock(WMS_Stock_Model wms_Stock_Model,string condition)
        {
            string _updateSql = "UPDATE [WMS].[dbo].[WMS_Stock]" 
                + "SET[ShelfNo] = '" + wms_Stock_Model.ShelfNo 
                + "',[AreaNo] = '" + wms_Stock_Model.AreaNo 
                + "',[WarehouseNo] = '" + wms_Stock_Model.WarehouseNo 
                + "',[SN] = '" + wms_Stock_Model.SN 
                + "',[ProductionNo] = '" + wms_Stock_Model.ProductionNo 
                + "',[PutInNo] = '" + wms_Stock_Model.PutInNo 
                + "' WHERE " + condition;
            return _updateSql;
        }

        /// <summary>
        /// 删除库存
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Delete_Stock(string condition)
        {
            string _deleteSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Stock]";
            }
            else
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Stock] WHERE " + condition;
            }
            return _deleteSql;
        }
    }
}
