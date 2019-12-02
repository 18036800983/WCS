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
    public class PartmentViewModel : PartmentBase
    {
        public PartmentViewModel()
        {
            ShowPartmentTable();
        }
        /// <summary>
        /// 显示列表
        /// </summary>
        public void ShowPartmentTable()
        {
            foreach (var model in GetPartmentList())
            {
                PartmentList.Add(model);
            }
            ShowPartmentList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<WMS_Partment_Model> GetPartmentList()
        {
            List<WMS_Partment_Model> list = new List<WMS_Partment_Model>();
            DataTable dt = WMS_Partment_Bll.Select_Partment(string.Empty);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Partment_Model wms_Partment_Model = new WMS_Partment_Model
                {
                    PartmentNo = int.Parse(dt.Rows[i]["PartmentNo"].ToString()),
                    PartmentName = dt.Rows[i]["PartmentName"].ToString(),
                    CreatPerson = dt.Rows[i]["CreatPerson"].ToString(),
                    CreatTime = dt.Rows[i]["CreatTime"].ToString(),
                    ModifyPerson = dt.Rows[i]["ModifyPerson"].ToString(),
                    ModifyTime = dt.Rows[i]["ModifyTime"].ToString()
                };
                list.Add(wms_Partment_Model);
            }
            return list;
        }
    }
}
