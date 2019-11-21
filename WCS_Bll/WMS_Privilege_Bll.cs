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
    public class WMS_Privilege_Bll : DB_Tool
    {
        /// <summary>
        /// 查询权限
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static DataTable Select_Privilege(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.ExecuteDataTable(WMS_Privilege_Dal.Select_Privilege(condition));
            }
        }

        /// <summary>
        /// 插入权限
        /// </summary>
        /// <param name="wms_Privilege_Model"></param>
        /// <returns></returns>
        public static int Insert_Privilege(WMS_Privilege_Model wms_Privilege_Model)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Privilege_Dal.Insert_Privilege(wms_Privilege_Model));
            }
        }

        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="wms_Privilege_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Update_Privilege(WMS_Privilege_Model wms_Privilege_Model, string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Privilege_Dal.Update_Privilege(wms_Privilege_Model,condition));
            }
        }

        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Delete_Privilege(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Privilege_Dal.Delete_Privilege(condition));
            }
        }
    }
}
