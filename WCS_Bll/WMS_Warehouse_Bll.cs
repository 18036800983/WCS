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
    public class WMS_Warehouse_Bll : DB_Tool
    {
        /// <summary>
        /// 查询仓库
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static DataTable Select_Warehouse(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.ExecuteDataTable(WMS_Warehouse_Dal.Select_Warehouse(condition));
            }
        }

        /// <summary>
        /// 添加仓库
        /// </summary>
        /// <param name="wms_Warehouse_Model"></param>
        /// <returns></returns>
        public static int Insert_Warehouse(WMS_Warehouse_Model wms_Warehouse_Model)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Warehouse_Dal.Insert_Warehouse(wms_Warehouse_Model));
            }
        }

        /// <summary>
        /// 更新仓库
        /// </summary>
        /// <param name="wms_Warehouse_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Update_Warehouse(WMS_Warehouse_Model wms_Warehouse_Model, string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Warehouse_Dal.Update_Warehouse(wms_Warehouse_Model,condition));
            }
        }

        /// <summary>
        /// 删除仓库
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Delete_Warehouse(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Warehouse_Dal.Delete_Warehouse(condition));
            }
        }
    }
}
