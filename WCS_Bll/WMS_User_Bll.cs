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
    public class WMS_User_Bll : DB_Tool
    {
        /// <summary>
        /// 查询用户
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static DataTable Select_User(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.ExecuteDataTable(WMS_User_Dal.Select_User(condition));
            }
        }

        /// <summary>
        /// 插入用户
        /// </summary>
        /// <param name="wms_User_Model"></param>
        /// <returns></returns>
        public static int Insert_User(WMS_User_Model wms_User_Model)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_User_Dal.Insert_User(wms_User_Model));
            }
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="wms_User_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Update_User(WMS_User_Model wms_User_Model, string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_User_Dal.Update_User(wms_User_Model,condition));
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Delete_User(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_User_Dal.Delete_User(condition));
            }
        }
    }
}
