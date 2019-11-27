using DMSkin.Core.MVVM;
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
    public class CharacterViewModel : CharacterBase
    {
        public CharacterViewModel()
        {
            ShowCharacterTable();
        }

        /// <summary>
        /// 显示角色列表
        /// </summary>
        public void ShowCharacterTable()
        {
            foreach (var model in GetCharacterList())
            {
                CharacterList.Add(model);
            }
            ShowCharacterList();
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public static List<WMS_Character_Model> GetCharacterList()
        {
            List<WMS_Character_Model> list = new List<WMS_Character_Model>();
            DataTable dt = WMS_Character_Bll.Select_Character(string.Empty);
            for (int i = 0;i < dt.Rows.Count;i++)
            {
                WMS_Character_Model wms_Character_Model = new WMS_Character_Model
                {
                    LoginName = dt.Rows[i]["LoginName"].ToString(),
                    UserName = dt.Rows[i]["UserName"].ToString(),
                    PartmentNo = int.Parse(dt.Rows[i]["PartmentNo"].ToString()),
                    UserPrivilege = dt.Rows[i]["UserPrivilege"].ToString(),
                    CreatPerson = dt.Rows[i]["CreatPerson"].ToString(),
                    CreatTime = dt.Rows[i]["CreatTime"].ToString(),
                    ModifyPerson = dt.Rows[i]["ModifyPerson"].ToString(),
                    ModifyTime = dt.Rows[i]["ModifyTime"].ToString()
                };
                list.Add(wms_Character_Model);
            }
            return list;
        }
    }
}
