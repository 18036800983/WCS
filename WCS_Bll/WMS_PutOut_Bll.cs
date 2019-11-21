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
    public class WMS_PutOut_Bll : DB_Tool
    {
        /// <summary>
        /// 查询出库
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static DataTable Select_PutOut(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.ExecuteDataTable(WMS_PutOut_Dal.Select_PutOut(condition));
            }
        }

        /// <summary>
        /// 插入出库
        /// </summary>
        /// <param name="wms_PutOut_Model"></param>
        /// <returns></returns>
        public static int Insert_PutOut(WMS_PutOut_Model wms_PutOut_Model)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_PutOut_Dal.Insert_PutOut(wms_PutOut_Model));
            }
        }

        /// <summary>
        /// 更新出库
        /// </summary>
        /// <param name="wms_PutOut_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Update_PutOut(WMS_PutOut_Model wms_PutOut_Model, string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_PutOut_Dal.Update_PutOut(wms_PutOut_Model,condition));
            }
        }

        /// <summary>
        /// 删除出库
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Delete_PutOut(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_PutOut_Dal.Delete_PutOut(condition));
            }
        }
    }
}
