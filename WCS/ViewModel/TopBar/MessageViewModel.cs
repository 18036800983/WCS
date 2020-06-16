using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS.ViewBase.TopBar;
using WCS_Bll;
using WCS_Model.DB;

namespace WCS.ViewModel.TopBar
{
    public class MessageViewModel : Messagebase
    {
        public MessageViewModel()
        {
            ShowErrorLogTable();
        }
        /// <summary>
        /// 显示列表
        /// </summary>
        public void ShowErrorLogTable()
        {
            foreach (var model in GetErrorLogList())
            {
                ErrorLogList.Add(model);
            }
            ShowErrorLogList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<WMS_Log_Model> GetErrorLogList()
        {
            List<WMS_Log_Model> list = new List<WMS_Log_Model>();
            DataTable dt = WMS_Log_Bll.Select_Log(" LogType = 'run' and LogLevel = 2");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Log_Model wms_Log_Model = new WMS_Log_Model
                {
                    LogType = dt.Rows[i]["LogType"].ToString(),
                    LogLocation = dt.Rows[i]["LogLocation"].ToString(),
                    LogMessage = dt.Rows[i]["LogMessage"].ToString()
                };
                list.Add(wms_Log_Model);
            }
            return list;
        }
    }
}
