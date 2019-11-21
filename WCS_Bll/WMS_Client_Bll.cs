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
    public class WMS_Client_Bll : DB_Tool
    {
        /// <summary>
        /// 查询客户
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static DataTable Select_Client(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.ExecuteDataTable(WMS_Client_Dal.Select_Client(condition));
            }
        }

        /// <summary>
        /// 插入客户
        /// </summary>
        /// <param name="wms_Client_Model"></param>
        /// <returns></returns>
        public static int Insert_Client(WMS_Client_Model wms_Client_Model)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Client_Dal.Insert_Client(wms_Client_Model));
            }
        }

        /// <summary>
        /// 更新客户
        /// </summary>
        /// <param name="wms_Client_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Update_Client(WMS_Client_Model wms_Client_Model, string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Client_Dal.Update_Client(wms_Client_Model,condition));
            }
        }

        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Delete_Client(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Client_Dal.Delete_Client(condition));
            }
        }
    }
}
