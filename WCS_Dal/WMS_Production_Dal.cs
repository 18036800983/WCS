using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS_Dal
{
    public class WMS_Production_Dal
    {
        /// <summary>
        /// 查询产品
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Select_Production(string condition)
        {
            string _selectSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _selectSql = "SELECT [ProductionNo],[ProductionName]" 
                    + ",[LocationNo],[WarehouseNo],[CreatPerson]" 
                    + ",[CreatTime],[ModifyPerson],[ModifyTime]" 
                    + "FROM [WMS].[dbo].[WMS_Production]";
            }
            else
            {
                _selectSql = "SELECT [ProductionNo],[ProductionName]"
                    + ",[LocationNo],[WarehouseNo],[CreatPerson]"
                    + ",[CreatTime],[ModifyPerson],[ModifyTime]"
                    + "FROM [WMS].[dbo].[WMS_Production] WHERE " + condition;
            }
            return _selectSql;
        }

        /// <summary>
        /// 插入产品
        /// </summary>
        /// <param name="wms_Production_Model"></param>
        /// <returns></returns>
        public static string Insert_Production(WMS_Production_Model wms_Production_Model)
        {
            string _insertSql = "INSERT INTO [WMS].[dbo].[WMS_Production]" 
                + "([ProductionNo],[ProductionName],[LocationNo],[WarehouseNo]" 
                + ",[CreatPerson],[CreatTime],[ModifyPerson],[ModifyTime])" 
                + "VALUES('" + wms_Production_Model.ProductionNo 
                + "','" + wms_Production_Model.ProductionName + "','" 
                + wms_Production_Model.LocationNo + "','" 
                + wms_Production_Model.WarehouseNo + "','" + wms_Production_Model.CreatPerson 
                + "','" + wms_Production_Model.CreatTime + "','" + wms_Production_Model.ModifyPerson 
                + "','" + wms_Production_Model.ModifyTime + "')";
            return _insertSql;
        }

        /// <summary>
        /// 更新产品
        /// </summary>
        /// <param name="wms_Production_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Update_Production(WMS_Production_Model wms_Production_Model,string condition)
        {
            string _updateSql = "UPDATE [WMS].[dbo].[WMS_Production]" 
                + "SET[ProductionNo] = '" + wms_Production_Model.ProductionNo 
                + "',[ProductionName] = '" + wms_Production_Model.ProductionName 
                + "',[LocationNo] = '" + wms_Production_Model.LocationNo 
                + "',[WarehouseNo] = '" + wms_Production_Model.WarehouseNo 
                + "',[CreatPerson] = '" + wms_Production_Model.CreatPerson 
                + "',[CreatTime] = '" + wms_Production_Model.CreatTime 
                + "',[ModifyPerson] = '" + wms_Production_Model.ModifyPerson 
                + "',[ModifyTime] = '" + wms_Production_Model.ModifyTime 
                + "' WHERE " + condition;
            return _updateSql;
        }

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Delete_Production(string condition)
        {
            string _deleteSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Production]";
            }
            else
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Production] WHERE " + condition;
            }
            return _deleteSql;
        }
    }
}
