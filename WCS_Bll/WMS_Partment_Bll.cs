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
    public class WMS_Partment_Bll : DB_Tool
    {
        /// <summary>
        /// 查询部门
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static DataTable Select_Partment(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.ExecuteDataTable(WMS_Partment_Dal.Select_Partment(condition));
            }
        }

        /// <summary>
        /// 插入部门
        /// </summary>
        /// <param name="wms_Partment_Model"></param>
        /// <returns></returns>
        public static int Insert_Partment(WMS_Partment_Model wms_Partment_Model)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Partment_Dal.Insert_Partment(wms_Partment_Model));
            }
        }

        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="wms_Partment_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Update_Partment(WMS_Partment_Model wms_Partment_Model, string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Partment_Dal.Update_Partment(wms_Partment_Model,condition));
            }
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Delete_Partment(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Partment_Dal.Delete_Partment(condition));
            }
        }
    }
}
