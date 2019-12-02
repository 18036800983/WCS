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
using Visifire.Charts;
using WCS_Bll;

namespace WCS.View.LogM
{
    /// <summary>
    /// ChartLogPage.xaml 的交互逻辑
    /// </summary>
    public partial class ChartLogPage : Page
    {
        public ChartLogPage()
        {
            InitializeComponent();
            //CreatChart(0, GetCharData("LogMessage"),"异常信息统计图",1, columnChart);
        }

        /// <summary>
        /// 获取运行日志XY值
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public Dictionary<string, Dictionary<string, string>> GetCharData(string columnName)
        {
            Dictionary<string, Dictionary<string, string>> dic = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, string> xyValue = new Dictionary<string, string>();
            DataTable dt = WMS_Log_Bll.XChart(columnName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string x = dt.Rows[i][columnName].ToString();
                string y = WMS_Log_Bll.YChart( columnName  + " = '" + x + "'" );
                xyValue.Add(x,y);
            }
            dic.Add("run",xyValue);
            return dic;
        }

        /// <summary>
        /// 分析图
        /// </summary>
        /// <param name="chartType"></param>
        /// <param name="dic"></param>
        /// <param name="titleValue"></param>
        /// <param name="XType"></param>
        public void CreatChart(int chartType, Dictionary<string, Dictionary<string, string>> dic, string titleValue, int XType,Grid dataGridName)
        {
            Chart chart = new Chart();

            chart.ScrollingEnabled = true;
            chart.View3D = false;

            Title title = new Title();
            title.Text = titleValue;
            chart.Titles.Add(title);

            if (XType == 3)
            {
                Axis axis = new Axis();
                axis.IntervalType = IntervalTypes.Seconds;
                axis.ValueFormatString = "MMdd hh:mm";
                axis.Interval = 60;
                chart.AxesX.Add(axis);
            }
            foreach (var series in dic)
            {
                DataSeries dataSeries = new DataSeries();
                dataSeries.RenderAs = (RenderAs)chartType;
                dataSeries.XValueType = (ChartValueTypes)XType;
                DataPoint dataPoint;
                foreach (var data in series.Value)
                {
                    dataPoint = new DataPoint();
                    dataPoint.XValue = data.Key;
                    dataPoint.YValue = Double.Parse(data.Value);
                    dataSeries.DataPoints.Add(dataPoint);
                }
                chart.Series.Add(dataSeries);
            }
            dataGridName.Children.Add(chart);
        }
    }
}
