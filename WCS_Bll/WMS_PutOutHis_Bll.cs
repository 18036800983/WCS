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
    public class WMS_PutOutHis_Bll : DB_Tool
    {
        /// <summary>
        /// 查询出库
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static DataTable Select_PutOutHis(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.ExecuteDataTable(WMS_PutOutHis_Dal.Select_PutOutHis(condition));
            }
        }

        /// <summary>
        /// 插入出库
        /// </summary>
        /// <param name="wms_PutOut_Model"></param>
        /// <returns></returns>
        public static int Insert_PutOutHis(WMS_PutOutHis_Model wms_PutOutHis_Model)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_PutOutHis_Dal.Insert_PutOutHis(wms_PutOutHis_Model));
            }
        }

        /// <summary>
        /// 更新出库
        /// </summary>
        /// <param name="wms_PutOut_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Update_PutOutHis(WMS_PutOutHis_Model wms_PutOutHis_Model, string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_PutOutHis_Dal.Update_PutOutHis(wms_PutOutHis_Model,condition));
            }
        }

        /// <summary>
        /// 删除出库
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Delete_PutOutHis(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_PutOutHis_Dal.Delete_PutOutHis(condition));
            }
        }
    }
}
