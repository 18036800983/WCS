using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS_Dal
{
    public class WMS_Warehouse_Dal
    {
        /// <summary>
        /// 查询仓库
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Select_Warehouse(string condition)
        {
            string _selectSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _selectSql = "SELECT [WarehouseName],[WarehouseNo],[Remark]"
                    + ",[CreatPerson],[CreatTime],[ModifyPerson],[ModifyTime]"
                    + "FROM [WMS].[dbo].[WMS_Warehouse]";
            }
            else
            {
                _selectSql = "SELECT [WarehouseName],[WarehouseNo],[Remark]"
                    + ",[CreatPerson],[CreatTime],[ModifyPerson],[ModifyTime]"
                    + "FROM [WMS].[dbo].[WMS_Warehouse] WHERE " + condition;
            }
            return _selectSql;
        }

        /// <summary>
        /// 添加仓库
        /// </summary>
        /// <param name="wms_Warehouse_Model"></param>
        /// <returns></returns>
        public static string Insert_Warehouse(WMS_Warehouse_Model wms_Warehouse_Model)
        {
            string _insertSql = "INSERT INTO [WMS].[dbo].[WMS_Warehouse]" 
                + "([WarehouseName],[WarehouseNo],[Remark],[CreatPerson]" 
                + ",[CreatTime],[ModifyPerson],[ModifyTime])VALUES" 
                + "('" + wms_Warehouse_Model.WarehouseName 
                + "','" + wms_Warehouse_Model.WarehouseNo 
                + "','" + wms_Warehouse_Model.Remark 
                + "','" + wms_Warehouse_Model.CreatPerson 
                + "','" + wms_Warehouse_Model.CreatTime 
                + "','" + wms_Warehouse_Model.ModifyPerson 
                + "','" + wms_Warehouse_Model.ModifyTime + "')";
            return _insertSql;
        }

        /// <summary>
        /// 更新仓库
        /// </summary>
        /// <param name="wms_Warehouse_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Update_Warehouse(WMS_Warehouse_Model wms_Warehouse_Model, string condition)
        {
            string _updateSql = "UPDATE [WMS].[dbo].[WMS_Warehouse]" 
                + "SET[WarehouseName] = '" + wms_Warehouse_Model.WarehouseName 
                + "',[WarehouseNo] = '" + wms_Warehouse_Model.WarehouseNo 
                + "',[Remark] = '" + wms_Warehouse_Model.Remark 
                + "',[CreatPerson] = '" + wms_Warehouse_Model.CreatPerson 
                + "',[CreatTime] = '" + wms_Warehouse_Model.CreatTime 
                + "',[ModifyPerson] = '" + wms_Warehouse_Model.ModifyPerson 
                + "',[ModifyTime] = '" + wms_Warehouse_Model.ModifyTime 
                + "' WHERE " + condition;
            return _updateSql;
        }

        /// <summary>
        /// 删除仓库
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Delete_Warehouse(string condition)
        {
            string _deleteSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Warehouse]";
            }
            else
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Warehouse] WHERE " + condition;
            }
            return _deleteSql;
        }
    }
}
