using MySql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool;
using WCS_Dal;
using WCS_Model.DB;

namespace WCS_Bll
{
    public class WMS_Stock_Bll : DB_Tool
    {
        /// <summary>
        /// 查询库存
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static DataTable Select_Stock(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.ExecuteDataTable(WMS_Stock_Dal.Select_Stock(condition));
            }
        }

        /// <summary>
        /// 插入库存
        /// </summary>
        /// <param name="wms_Stock_Model"></param>
        /// <returns></returns>
        public static int Insert_Stock(WMS_Stock_Model wms_Stock_Model)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Stock_Dal.Insert_Stock(wms_Stock_Model));
            }
        }

        /// <summary>
        /// 更新库存
        /// </summary>
        /// <param name="wms_Stock_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Update_Stock(WMS_Stock_Model wms_Stock_Model, string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Stock_Dal.Update_Stock(wms_Stock_Model,condition));
            }
        }

        /// <summary>
        /// 删除库存
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Delete_Stock(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Stock_Dal.Delete_Stock(condition));
            }
        }
    }
}
