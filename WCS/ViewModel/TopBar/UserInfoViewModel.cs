using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS.ViewBase.TopBar;
using WCS.ViewModel.LoginM;
using WCS_Bll;
using WCS_Model.DB;

namespace WCS.ViewModel.TopBar
{
    public class UserInfoViewModel : UserInfoBase
    {
        public UserInfoViewModel()
        {
            ShowUserInfoTable();
        }
        /// <summary>
        /// 显示列表
        /// </summary>
        public void ShowUserInfoTable()
        {
            foreach (var model in GetUserInfoList())
            {
                UserInfoList.Add(model);
            }
            ShowUserInfoList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<WMS_Character_Model> GetUserInfoList()
        {
            List<WMS_Character_Model> list = new List<WMS_Character_Model>();
            DataTable dt = WMS_Character_Bll.Select_Character(" LoginName = '" + LoginViewModel.loginName + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Character_Model wMS_UserInfo_Model = new WMS_Character_Model
                {
                    LoginName = dt.Rows[i]["LoginName"].ToString(),
                    UserName = dt.Rows[i]["UserName"].ToString(),
                    PartmentNo = int.Parse(dt.Rows[i]["PartmentNo"].ToString())
                };
                list.Add(wMS_UserInfo_Model);
            }
            return list;
        }
    }
}
