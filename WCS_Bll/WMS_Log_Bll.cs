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
    public class WMS_Log_Bll : DB_Tool
    {
        /// <summary>
        /// 日志查询
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static DataTable Select_Log(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.ExecuteDataTable(WMS_Log_Dal.Select_Log(condition));
            }
        }

        /// <summary>
        /// 日志插入
        /// </summary>
        /// <param name="wMS_Log_Model"></param>
        /// <returns></returns>
        public static int Inseert_Log(WMS_Log_Model wMS_Log_Model)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Log_Dal.Inseert_Log(wMS_Log_Model)) ;
            }
        }

        /// <summary>
        /// 日志更新
        /// </summary>
        /// <param name="wMS_Log_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Update_Log(WMS_Log_Model wMS_Log_Model, string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Log_Dal.Update_Log(wMS_Log_Model, condition));
            }
        }

        /// <summary>
        /// 日志删除
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Delete_Log(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Log_Dal.Delete_Log(condition));
            }
        }
    }
}
