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
    public class WMS_Character_Bll : DB_Tool
    {
        /// <summary>
        /// 查询角色
        /// </summary>
        /// <returns></returns>
        public static DataTable Select_Character(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.ExecuteDataTable(WMS_Character_Dal.Select_Character(condition));
            }
        }

        /// <summary>
        /// 插入角色
        /// </summary>
        /// <returns></returns>
        public static int Insert_Character(WMS_Character_Model wms_Character_Model)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Character_Dal.Insert_Character(wms_Character_Model));
            }
        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <returns></returns>
        public static int Update_Character(WMS_Character_Model wms_Character_Model, string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Character_Dal.Update_Character(wms_Character_Model,condition));
            }
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <returns></returns>
        public static int Delete_Character(string condition)
        {
            using (var con = GetOpenConnection())
            {
                return con.Execute(WMS_Character_Dal.Delete_Character(condition));
            }
        }
    }
}
