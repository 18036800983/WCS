using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS_Dal
{
    public class WMS_Shelf_Dal
    {

        /// <summary>
        /// 查询货架
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Select_Shelf(string condition)
        {
            string _selectSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _selectSql = "SELECT [ShelfName],[ShelfNo],[AreaNo]"
                    + ",[WarehouseNo],[Remark],[CreatPerson],[CreatTime]"
                    + ",[ModifyPerson],[ModifyTime] FROM [WMS].[dbo].[WMS_Shelf]";
            }
            else
            {
                _selectSql = "SELECT [ShelfName],[ShelfNo],[AreaNo]"
                    + ",[WarehouseNo],[Remark],[CreatPerson],[CreatTime]"
                    + ",[ModifyPerson],[ModifyTime] " 
                    + "FROM [WMS].[dbo].[WMS_Shelf] WHERE " + condition;
            }
            return _selectSql;
        }

        /// <summary>
        /// 插入货架
        /// </summary>
        /// <param name="wms_Shelf_Model"></param>
        /// <returns></returns>
        public static string Insert_Shelf(WMS_Shelf_Model wms_Shelf_Model)
        {
            string _insertSql = "INSERT INTO [WMS].[dbo].[WMS_Shelf]" 
                + "([ShelfName],[ShelfNo],[AreaNo],[WarehouseNo]" 
                + ",[Remark],[CreatPerson],[CreatTime],[ModifyPerson]" 
                + ",[ModifyTime]) VALUES('" + wms_Shelf_Model.ShelfName 
                + "','" + wms_Shelf_Model.ShelfNo + "','" 
                + wms_Shelf_Model.AreaNo + "','" + wms_Shelf_Model.WarehouseNo 
                + "','" + wms_Shelf_Model.Remark + "','" 
                + wms_Shelf_Model.CreatPerson + "','" 
                + wms_Shelf_Model.CreatTime + "','" + wms_Shelf_Model.ModifyPerson 
                + "','" + wms_Shelf_Model.ModifyTime + "')";
            return _insertSql;
        }

        /// <summary>
        /// 更新货架
        /// </summary>
        /// <param name="wms_Shelf_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Update_Shelf(WMS_Shelf_Model wms_Shelf_Model,string condition)
        {
            string _updateSql = "UPDATE [WMS].[dbo].[WMS_Shelf]" 
                + "SET[ShelfName] = '" + wms_Shelf_Model.ShelfName 
                + "',[ShelfNo] = '" + wms_Shelf_Model.ShelfNo 
                + "',[AreaNo] = '" + wms_Shelf_Model.AreaNo 
                + "',[WarehouseNo] = '" + wms_Shelf_Model.WarehouseNo 
                + "',[Remark] = '" + wms_Shelf_Model.Remark 
                + "',[CreatPerson] = '" + wms_Shelf_Model.CreatPerson 
                + "',[CreatTime] = '" + wms_Shelf_Model.CreatTime 
                + "',[ModifyPerson] = '" + wms_Shelf_Model.ModifyPerson 
                + "',[ModifyTime] = '" + wms_Shelf_Model.ModifyTime 
                + "' WHERE " + condition;
            return _updateSql;
        }

        /// <summary>
        /// 删除货架
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Delete_Shelf(string condition)
        {
            string _deleteSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Shelf]";
            }
            else
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_Shelf] WHERE " + condition;
            }
            return _deleteSql;
        }
    }
}
