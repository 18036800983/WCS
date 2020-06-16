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
    public class RunLoginViewModel: RunLoginBase
    {
        public static int totalPages;
        public static int page = 1;
        public static string showColumn = "LogID,LogType,LogLocation,LogLevel,LogMessage,LogTime";
        public static string tabName = "WMS_Log";
        public static string strCondition = " LogType = 'run'";
        public static string ascColumn = "LogID";                            //排序的字段名 (即 order by column asc/desc)
        public static int bitOrderType = 0;                                   //排序的类型 (0为升序,1为降序)
        public static string pkColumn = "LogID";
        public static int sizePage = 20;

        public RunLoginViewModel()
        {
            ShowRunLogTable();
        }
        /// <summary>
        /// 显示列表
        /// </summary>
        public void ShowRunLogTable()
        {
            foreach (var model in GetRunLogList())
            {
                RunLogList.Add(model);
            }
            ShowRunLogList();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public static List<WMS_Log_Model> GetRunLogList()
        {
            List<WMS_Log_Model> list = new List<WMS_Log_Model>();
            DataTable totalDt = WMS_Log_Bll.Select_Log(" LogType = 'run'");
            totalPages = totalDt.Rows.Count % sizePage == 0 ? (totalDt.Rows.Count / sizePage) : (totalDt.Rows.Count / sizePage) + 1;

            DataTable dt = PagerHelper.PagerTable(page,sizePage,showColumn,tabName,strCondition,ascColumn,bitOrderType,pkColumn);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Log_Model wms_Log_Model = new WMS_Log_Model
                {
                    LogID = int.Parse(dt.Rows[i]["LogID"].ToString()),
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
