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
    public class WMS_Supplier_Bll : DB_Tool
    {
        /// <summary>
        /// 查询供应商
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static DataTable Select_Supplier(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.ExecuteDataTable(WMS_Supplier_Dal.Select_Supplier(condition));
            }
        }

        /// <summary>
        /// 插入供应商
        /// </summary>
        /// <param name="wms_Supplier_Model"></param>
        /// <returns></returns>
        public static int Insert_Supplier(WMS_Supplier_Model wms_Supplier_Model)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Supplier_Dal.Insert_Supplier(wms_Supplier_Model));
            }
        }

        /// <summary>
        /// 更新供应商
        /// </summary>
        /// <param name="wms_Supplier_Model"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Update_Supplier(WMS_Supplier_Model wms_Supplier_Model, string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Supplier_Dal.Update_Supplier(wms_Supplier_Model, condition));
            }
        }

        /// <summary>
        /// 删除供应商
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static int Delete_Supplier(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Supplier_Dal.Delete_Supplier(condition));
            }
        }
    }
}
