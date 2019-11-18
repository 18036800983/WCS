using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS_Dal
{
    public class WMS_PutOut_Dal
    {

        /// <summary>
        /// 查询出库
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Select_PutOut(string condition)
        {
            string _selectSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _selectSql = "SELECT [ShelfNo],[PutOutNo],[SN]" 
                    + ",[OrderNo],[PutOutType],[Status],[PutOutTime]" 
                    + " FROM [WMS].[dbo].[WMS_PutOut]";
            }
            else
            {
                _selectSql = "SELECT [ShelfNo],[PutOutNo],[SN]"
                    + ",[OrderNo],[PutOutType],[Status],[PutOutTime]"
                    + " FROM [WMS].[dbo].[WMS_PutOut] WHERE " + condition;
            }
            return _selectSql;
        }

        /// <summary>
        /// 插入出库
        /// </summary>
        /// <param name="wms_PutOut_Model"></param>
        /// <returns></returns>
        public static string Insert_PutOut(WMS_PutOut_Model wms_PutOut_Model)
        {
            string _insertSql = "INSERT INTO [WMS].[dbo].[WMS_PutOut]" 
                + "([ShelfNo],[PutOutNo],[SN],[OrderNo],[PutOutType]" 
                + ",[Status],[PutOutTime])VALUES('" + wms_PutOut_Model.ShelfNo 
                + "','" + wms_PutOut_Model.PutOutNo + "','" 
                + wms_PutOut_Model.SN + "','" + wms_PutOut_Model.OrderNo 
                + "','" + wms_PutOut_Model.PutOutType 
                + "','" + wms_PutOut_Model.Status + "','" 
                + wms_PutOut_Model.PutOutTime + "')";
            return _insertSql;
        }

        /// <summary>
        /// 更新出库
        /// </summary>
        /// <param name="wms_PutOut_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Update_PutOut(WMS_PutOut_Model wms_PutOut_Model,string condition)
        {
            string _updateSql = "UPDATE [WMS].[dbo].[WMS_PutOut] " 
                + "SET[ShelfNo] = '" + wms_PutOut_Model.ShelfNo 
                + "',[PutOutNo] = '" + wms_PutOut_Model.PutOutNo 
                + "',[SN] = '" + wms_PutOut_Model.SN 
                + "',[OrderNo] = '" + wms_PutOut_Model.OrderNo 
                + "',[PutOutType] = '" + wms_PutOut_Model.PutOutType 
                + "',[Status] = '" + wms_PutOut_Model.Status 
                + "',[PutOutTime] = '" + wms_PutOut_Model.PutOutTime 
                + "' WHERE " + condition;
            return _updateSql;
        }

        /// <summary>
        /// 删除出库
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Delete_PutOut(string condition)
        {
            string _deleteSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_PutOut]";
            }
            else
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_PutOut] WHERE " + condition;
            }
            return _deleteSql;
        }
    }
}
