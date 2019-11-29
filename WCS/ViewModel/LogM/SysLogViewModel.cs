using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS.ViewBase.LogM;
using WCS_Bll;
using WCS_Model.DB;

namespace WCS.ViewModel.LogM
{
    public class SysLogViewModel : SysLogBase
    {
        public SysLogViewModel()
        {
            ShowSysLogTable();
        }
        /// <summary>
        /// 显示列表
        /// </summary>
        public void ShowSysLogTable()
        {
            foreach (var model in GetSysLogList())
            {
                SysLogList.Add(model);
            }
            ShowSysLogList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<WMS_Log_Model> GetSysLogList()
        {
            List<WMS_Log_Model> list = new List<WMS_Log_Model>();
            DataTable dt = WMS_Log_Bll.Select_Log(" LogType = 'sys'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Log_Model wms_Log_Model = new WMS_Log_Model
                {
                    LogTime = dt.Rows[i]["LogTime"].ToString(),
                    LogType = dt.Rows[i]["LogType"].ToString(),
                    LogLocation = dt.Rows[i]["LogLocation"].ToString(),
                    LogMessage = dt.Rows[i]["LogMessage"].ToString(),
                    LogLevel = int.Parse(dt.Rows[i]["LogLevel"].ToString())
                };
                list.Add(wms_Log_Model);
            }
            return list;
        }
    }
}
