using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS.ViewBase.BaseM;
using WCS_Bll;
using WCS_Model.DB;

namespace WCS.ViewModel.BaseM
{
    public class ClientViewModel : ClientBase
    {
        public ClientViewModel()
        {
            ShowClientTable();
        }
        /// <summary>
        /// 显示列表
        /// </summary>
        public void ShowClientTable()
        {
            foreach (var model in GetClienteList())
            {
                ClientList.Add(model);
            }
            ShowClientList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<WMS_Client_Model> GetClienteList()
        {
            List<WMS_Client_Model> list = new List<WMS_Client_Model>();
            DataTable dt = WMS_Client_Bll.Select_Client(string.Empty);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Client_Model wms_Client_Model = new WMS_Client_Model
                {
                    CompanyName = dt.Rows[i]["CompanyName"].ToString(),
                    ProductionName = dt.Rows[i]["ProductionName"].ToString(),
                    CreatPerson = dt.Rows[i]["CreatPerson"].ToString(),
                    CreatTime = dt.Rows[i]["CreatTime"].ToString(),
                    ModifyPerson = dt.Rows[i]["ModifyPerson"].ToString(),
                    ModifyTime = dt.Rows[i]["ModifyTime"].ToString()
                };
                list.Add(wms_Client_Model);
            }
            return list;
        }
    }
}
