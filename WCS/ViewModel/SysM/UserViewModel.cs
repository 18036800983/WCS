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
    public class UserViewModel : UserBase
    {
        public UserViewModel()
        {
            ShowUserTable();
        }

        /// <summary>
        /// 显示角色列表
        /// </summary>
        public void ShowUserTable()
        {
            foreach (var model in GetUserList())
            {
                UserList.Add(model);
            }
            ShowUserList();
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public static List<WMS_User_Model> GetUserList()
        {
            List<WMS_User_Model> list = new List<WMS_User_Model>();
            DataTable dt = WMS_User_Bll.Select_User(string.Empty);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_User_Model wms_User_Model = new WMS_User_Model
                {
                    LoginName = dt.Rows[i]["LoginName"].ToString(),
                    LoginPassword = dt.Rows[i]["LoginPassword"].ToString(),
                    PrivilegeLevel = dt.Rows[i]["PrivilegeLevel"].ToString(),
                    CreatPerson = dt.Rows[i]["CreatPerson"].ToString(),
                    CreatTime = dt.Rows[i]["CreatTime"].ToString(),
                    ModifyPerson = dt.Rows[i]["ModifyPerson"].ToString(),
                    ModifyTime = dt.Rows[i]["ModifyTime"].ToString()
                };
                list.Add(wms_User_Model);
            }
            return list;
        }
    }
}
