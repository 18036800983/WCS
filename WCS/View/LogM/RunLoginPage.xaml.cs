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
using WCS.ViewModel.LogM;
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
        string curpage = "0";
        public RunLoginPage()
        {
            InitializeComponent();
            curpage = RunLoginViewModel.page.ToString();
            CurPage.Text = "        " + curpage + "     " + "/     " + RunLoginViewModel.totalPages;
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

        /// <summary>
        /// 获得第一页是各个数据
        /// </summary>
        public void FrushPage()
        {
            curpage = RunLoginViewModel.page.ToString();

            CurPage.Text = "        " + curpage + "     " + "/     " + RunLoginViewModel.totalPages;

            this.RunLogDataGrid.ItemsSource = RunLoginViewModel.GetRunLogList();
        }

        /// <summary>
        /// 切换控件状态
        /// </summary>
        public void CheckContrlStatus()
        {
            if (RunLoginViewModel.page == 0 || RunLoginViewModel.totalPages == 1)
            {
                FirstPage.IsEnabled = false;
                previousPage.IsEnabled = false;
                NextPage.IsEnabled = false;
                EndPage.IsEnabled = false;
            }
            else if (RunLoginViewModel.page == 1 && RunLoginViewModel.page != RunLoginViewModel.totalPages)
            {
                FirstPage.IsEnabled = false;
                previousPage.IsEnabled = false;
                NextPage.IsEnabled = true;
                EndPage.IsEnabled = true;
            }
            else if (RunLoginViewModel.page == RunLoginViewModel.totalPages && RunLoginViewModel.totalPages != 1)
            {
                FirstPage.IsEnabled = true;
                previousPage.IsEnabled = true;
                NextPage.IsEnabled = false;
                EndPage.IsEnabled = false;
            }
            else
            {
                FirstPage.IsEnabled = true;
                previousPage.IsEnabled = true;
                NextPage.IsEnabled = true;
                EndPage.IsEnabled = true;
            }
        }

        private void FirstPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RunLoginViewModel.page = 1;
                //RunLoginViewModel.GetRunLogList();
                CheckContrlStatus();
                FrushPage();
            }
            catch (Exception ex)
            {
                //Log.InformationLog.Info("跳到首页事件 ：" + ex);
            }
        }

        private void previousPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RunLoginViewModel.page != 1)
                {
                    RunLoginViewModel.page--;
                    //RunLoginViewModel.GetRunLogList();
                    CheckContrlStatus();
                    FrushPage();
                }
            }
            catch (Exception ex)
            {
                //Log.InformationLog.Info("上一页事件 ：" + ex);
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RunLoginViewModel.page != RunLoginViewModel.totalPages)
                {
                    RunLoginViewModel.page++;
                    //RunLoginViewModel.GetRunLogList();
                    CheckContrlStatus();
                    FrushPage();
                }
            }
            catch (Exception ex)
            {
                //Log.InformationLog.Info("下一页事件 ：" + ex);
            }
        }

        private void EndPage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RunLoginViewModel.page = RunLoginViewModel.totalPages;
                //RunLoginViewModel.GetRunLogList();
                CheckContrlStatus();
                FrushPage();
            }
            catch (Exception ex)
            {
                //Log.InformationLog.Info("跳到尾页事件 ：" + ex);
            }
        }
    }
}
