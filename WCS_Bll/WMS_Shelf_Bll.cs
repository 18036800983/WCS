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
    public class WMS_Shelf_Bll : DB_Tool
    {
        /// <summary>
        /// 查询货架
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static DataTable Select_Shelf(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.ExecuteDataTable(WMS_Shelf_Dal.Select_Shelf(condition));
            }
        }

        /// <summary>
        /// 插入货架
        /// </summary>
        /// <param name="wms_Shelf_Model"></param>
        /// <returns></returns>
        public static int Insert_Shelf(WMS_Shelf_Model wms_Shelf_Model)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Shelf_Dal.Insert_Shelf(wms_Shelf_Model));
            }
        }

        /// <summary>
        /// 更新货架
        /// </summary>
        /// <param name="wms_Shelf_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Update_Shelf(WMS_Shelf_Model wms_Shelf_Model, string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Shelf_Dal.Update_Shelf(wms_Shelf_Model,condition));
            }
        }

        /// <summary>
        /// 删除货架
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Delete_Shelf(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Shelf_Dal.Delete_Shelf(condition));
            }
        }
    }
}
