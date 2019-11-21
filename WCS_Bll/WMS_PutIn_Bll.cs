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
    public class WMS_PutIn_Bll : DB_Tool
    {
        /// <summary>
        /// 查询入库
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static DataTable Select_PutIn(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.ExecuteDataTable(WMS_PutIn_Dal.Select_PutIn(condition));
            }
        }

        /// <summary>
        /// 插入入库
        /// </summary>
        /// <returns></returns>
        public static int Insert_PutIn(WMS_PutIn_Model wms_PutIn_Model)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_PutIn_Dal.Insert_PutIn(wms_PutIn_Model));
            }
        }

        /// <summary>
        /// 更新入库
        /// </summary>
        /// <returns></returns>
        public static int Update_PutIn(WMS_PutIn_Model wms_PutIn_Model, string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_PutIn_Dal.Update_PutIn(wms_PutIn_Model,condition));
            }
        }

        /// <summary>
        /// 删除入库
        /// </summary>
        /// <returns></returns>
        public static int Delete_PutIn(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_PutIn_Dal.Delete_PutIn(condition));
            }
        }
    }
}
