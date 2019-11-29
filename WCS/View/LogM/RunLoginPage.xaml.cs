using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WCS.ViewBase.LogM;
using WCS_Bll;
using WCS_Model.DB;

namespace WCS.View.LogM
{
    /// <summary>
    /// RunLoginPage.xaml 的交互逻辑
    /// </summary>
    public partial class RunLoginPage : Page
    {
        RunLoginBase runLogBase = new RunLoginBase();
        public RunLoginPage()
        {
            InitializeComponent();
        }

        private void DMButton_Search_Click(object sender, RoutedEventArgs e)
        {
            runLogBase.RunLogList.Clear();
            List<WMS_Log_Model> list = new List<WMS_Log_Model>();
            DataTable dt = WMS_Log_Bll.Select_Log(" LogType = 'run' and LogTime like '%"
                + SearchText_Time.Text + "%' and LogLocation like '%" + SearchText_Location.Text
                + "%' and LogMessage like '%" + SearchText_Message.Text + "%' and LogLevel like '%"
                + SearchText_Level.Text + "%'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Log_Model wMS_SysLog_Model = new WMS_Log_Model
                {
                    LogTime = dt.Rows[i]["LogTime"].ToString(),
                    LogType = dt.Rows[i]["LogType"].ToString(),
                    LogLocation = dt.Rows[i]["LogLocation"].ToString(),
                    LogMessage = dt.Rows[i]["LogMessage"].ToString(),
                    LogLevel = int.Parse(dt.Rows[i]["LogLevel"].ToString())
                };
                list.Add(wMS_SysLog_Model);
            }
            foreach (var model in list)
            {
                runLogBase.RunLogList.Add(model);
            }
            this.RunLogDataGrid.ItemsSource = runLogBase.RunLogList;
        }
    }
}
