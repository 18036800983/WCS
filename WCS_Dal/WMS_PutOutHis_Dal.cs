using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS_Dal
{
    public class WMS_PutOutHis_Dal
    {
        /// <summary>
        /// 查询出库
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Select_PutOutHis(string condition)
        {
            string _selectSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _selectSql = "SELECT [ShelfNo],[PutOutNo],[SN]"
                    + ",[OrderNo],[PutOutType],[Status],[PutOutTime]"
                    + " FROM [WMS].[dbo].[WMS_PutOutHis]";
            }
            else
            {
                _selectSql = "SELECT [ShelfNo],[PutOutNo],[SN]"
                    + ",[OrderNo],[PutOutType],[Status],[PutOutTime]"
                    + " FROM [WMS].[dbo].[WMS_PutOutHis] WHERE " + condition;
            }
            return _selectSql;
        }

        /// <summary>
        /// 插入出库
        /// </summary>
        /// <param name="wms_PutOut_Model"></param>
        /// <returns></returns>
        public static string Insert_PutOutHis(WMS_PutOutHis_Model wms_PutOutHis_Model)
        {
            string _insertSql = "INSERT INTO [WMS].[dbo].[WMS_PutOutHis]"
                + "([ShelfNo],[PutOutNo],[SN],[OrderNo],[PutOutType]"
                + ",[Status],[PutOutTime])VALUES('" + wms_PutOutHis_Model.ShelfNo
                + "','" + wms_PutOutHis_Model.PutOutNo + "','"
                + wms_PutOutHis_Model.SN + "','" + wms_PutOutHis_Model.OrderNo
                + "','" + wms_PutOutHis_Model.PutOutType
                + "','" + wms_PutOutHis_Model.Status + "','"
                + wms_PutOutHis_Model.PutOutTime + "')";
            return _insertSql;
        }

        /// <summary>
        /// 更新出库
        /// </summary>
        /// <param name="wms_PutOut_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Update_PutOutHis(WMS_PutOutHis_Model wms_PutOutHis_Model, string condition)
        {
            string _updateSql = "UPDATE [WMS].[dbo].[WMS_PutOutHis] "
                + "SET[ShelfNo] = '" + wms_PutOutHis_Model.ShelfNo
                + "',[PutOutNo] = '" + wms_PutOutHis_Model.PutOutNo
                + "',[SN] = '" + wms_PutOutHis_Model.SN
                + "',[OrderNo] = '" + wms_PutOutHis_Model.OrderNo
                + "',[PutOutType] = '" + wms_PutOutHis_Model.PutOutType
                + "',[Status] = '" + wms_PutOutHis_Model.Status
                + "',[PutOutTime] = '" + wms_PutOutHis_Model.PutOutTime
                + "' WHERE " + condition;
            return _updateSql;
        }

        /// <summary>
        /// 删除出库
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string Delete_PutOutHis(string condition)
        {
            string _deleteSql = string.Empty;
            if (string.IsNullOrEmpty(condition))
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_PutOutHis]";
            }
            else
            {
                _deleteSql = "DELETE FROM [WMS].[dbo].[WMS_PutOutHis] WHERE " + condition;
            }
            return _deleteSql;
        }
    }
}
