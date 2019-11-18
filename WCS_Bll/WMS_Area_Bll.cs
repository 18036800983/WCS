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
    public class WMS_Area_Bll : DB_Tool
    {
        /// <summary>
        /// 查询库区
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static DataTable Select_Area(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.ExecuteDataTable(WMS_Area_Dal.Select_Area(condition));
            }
        }

        /// <summary>
        /// 添加库区
        /// </summary>
        /// <param name="wms_Area_Model"></param>
        /// <returns></returns>
        public static int Insert_Area(WMS_Area_Model wms_Area_Model)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Area_Dal.Insert_Area(wms_Area_Model));
            }
        }

        /// <summary>
        /// 修改库区
        /// </summary>
        /// <param name="wms_Area_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Update_Area(WMS_Area_Model wms_Area_Model, string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Area_Dal.Update_Area(wms_Area_Model, condition));
            }
        }

        /// <summary>
        /// 删除库区
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Delete_Area(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Area_Dal.Delete_Area( condition));
            }
        }
    }
}
