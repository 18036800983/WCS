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
    public class WMS_Production_Bll : DB_Tool
    {
        /// <summary>
        /// 查询产品
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static DataTable Select_Production(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.ExecuteDataTable(WMS_Production_Dal.Select_Production(condition));
            }
        }

        /// <summary>
        /// 插入产品
        /// </summary>
        /// <param name="wms_Production_Model"></param>
        /// <returns></returns>
        public static int Insert_Production(WMS_Production_Model wms_Production_Model)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Production_Dal.Insert_Production(wms_Production_Model));
            }
        }

        /// <summary>
        /// 更新产品
        /// </summary>
        /// <param name="wms_Production_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Update_Production(WMS_Production_Model wms_Production_Model, string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Production_Dal.Update_Production(wms_Production_Model,condition));
            }
        }

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Delete_Production(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Production_Dal.Delete_Production(condition));
            }
        }
    }
}
