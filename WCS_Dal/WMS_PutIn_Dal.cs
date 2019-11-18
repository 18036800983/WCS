using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS_Dal
{
    public class WMS_PutIn_Dal
    {

        /// <summary>
        /// 查询入库
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Select_PutIn(string condition)
        {
            string _selectSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _selectSql = "SELECT [ShelfNo],[PutInNo],[SN],[OrderNo]"
                    + ",[PutInType],[Status],[PutInTime] FROM [WMS].[dbo].[WMS_PutIn]";
            }
            else
            {
                _selectSql = "SELECT [ShelfNo],[PutInNo],[SN],[OrderNo]"
                    + ",[PutInType],[Status],[PutInTime] FROM " 
                    + "[WMS].[dbo].[WMS_PutIn] WHERE " + condition;
            }
            return _selectSql;
        }

        /// <summary>
        /// 插入入库
        /// </summary>
        /// <returns></returns>
        public static string Insert_PutIn(WMS_PutIn_Model wms_PutIn_Model)
        {
            string _insertSql = "INSERT INTO [WMS].[dbo].[WMS_PutIn]" 
                + "([ShelfNo],[PutInNo],[SN],[OrderNo],[PutInType]" 
                + ",[Status],[PutInTime])VALUES('" + wms_PutIn_Model.ShelfNo 
                + "','" + wms_PutIn_Model.PutInNo + "','" + wms_PutIn_Model.SN 
                + "','" + wms_PutIn_Model.OrderNo + "','" + wms_PutIn_Model.PutInType 
                + "','" + wms_PutIn_Model.Status + "','" + wms_PutIn_Model.PutInTime 
                + "')";
            return _insertSql;
        }

        /// <summary>
        /// 更新入库
        /// </summary>
        /// <returns></returns>
        public static string Update_PutIn(WMS_PutIn_Model wms_PutIn_Model,string condition)
        {
            string _updateSql = "UPDATE [WMS].[dbo].[WMS_PutIn]" 
                + "SET[ShelfNo] = '" + wms_PutIn_Model.ShelfNo 
                + "',[PutInNo] = '" + wms_PutIn_Model.PutInNo 
                + "',[SN] = '" + wms_PutIn_Model.SN 
                + "',[OrderNo] = '" + wms_PutIn_Model.OrderNo 
                + "',[PutInType] = '" + wms_PutIn_Model.PutInType 
                + "',[Status] = '" + wms_PutIn_Model.Status 
                + "',[PutInTime] = '" + wms_PutIn_Model.PutInTime 
                + "' WHERE " + condition;
            return _updateSql;
        }

        /// <summary>
        /// 删除入库
        /// </summary>
        /// <returns></returns>
        public static string Delete_PutIn(string condition)
        {
            string _deleteSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_PutIn]";
            }
            else
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_PutIn] WHERE " + condition;
            }
            return _deleteSql;
        }
    }
}
