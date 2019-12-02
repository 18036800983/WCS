using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS.ViewBase.SysM;
using WCS_Bll;
using WCS_Model.DB;

namespace WCS.ViewModel.SysM
{
    public class PermissionViewModel: PermissionBase
    {
        public PermissionViewModel()
        {
            ShowPrivilegeTable();
        }
        /// <summary>
        /// 显示列表
        /// </summary>
        public void ShowPrivilegeTable()
        {
            foreach (var model in GetPrivilegeList())
            {
                PrivilegeList.Add(model);
            }
            ShowPrivilegeList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<WMS_Privilege_Model> GetPrivilegeList()
        {
            List<WMS_Privilege_Model> list = new List<WMS_Privilege_Model>();
            DataTable dt = WMS_Privilege_Bll.Select_Privilege(string.Empty);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Privilege_Model wms_Privilege_Model = new WMS_Privilege_Model
                {
                    PrivilegeNo = int.Parse(dt.Rows[i]["PrivilegeNo"].ToString()),
                    PrivilegeName = dt.Rows[i]["PrivilegeName"].ToString()
                };
                list.Add(wms_Privilege_Model);
            }
            return list;
        }
    }
}
