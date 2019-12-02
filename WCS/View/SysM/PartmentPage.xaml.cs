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
using WCS.ViewBase.SysM;
using WCS.ViewModel.SysM;
using WCS_Bll;
using WCS_Model.DB;

namespace WCS.View.SysM
{
    /// <summary>
    /// PartmentPage.xaml 的交互逻辑
    /// </summary>
    public partial class PartmentPage : Page
    {
        WMS_Partment_Model wms_Partment_Model = new WMS_Partment_Model();
        PartmentBase partmentBase = new PartmentBase();
        int editFlag = 0;//可编辑标签
        int partmentNo = 0;
        List<int> selectPartmentNo = new List<int>();
        public PartmentPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 添加按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Add_Click(object sender, RoutedEventArgs e)
        {
            editFlag = 1;
            PartmentDataGrid.IsReadOnly = false;
            PartmentDataGrid.CanUserAddRows = true;
        }

        /// <summary>
        /// 编辑按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Edit_Click(object sender, RoutedEventArgs e)
        {
            editFlag = 2;
            PartmentDataGrid.IsReadOnly = false;
            PartmentDataGrid.CanUserAddRows = false;
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var name in selectPartmentNo)
            {
                WMS_Partment_Bll.Delete_Partment(" PartmentNo = " + name);
            }
            Page_Frush();
        }

        /// <summary>
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Save_Click(object sender, RoutedEventArgs e)
        {
            if (editFlag == 1)
            {
                WMS_Partment_Bll.Insert_Partment(wms_Partment_Model);
            }
            else if (editFlag == 2)
            {
                WMS_Partment_Bll.Update_Partment(wms_Partment_Model, " PartmentNo = " + partmentNo);
            }
            editFlag = 0;
            Page_Frush();
            PartmentDataGrid.CanUserAddRows = false;
            PartmentDataGrid.IsReadOnly = true;
        }

        /// <summary>
        /// 搜索按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Search_Click(object sender, RoutedEventArgs e)
        {
            partmentBase.PartmentList.Clear();
            List<WMS_Partment_Model> list = new List<WMS_Partment_Model>();
            DataTable dt = WMS_Partment_Bll.Select_Partment(" PartmentNo = " + int.Parse(SearchText.Text.Trim()));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Partment_Model wMS_Partment_Model = new WMS_Partment_Model
                {
                    PartmentNo = int.Parse(dt.Rows[i]["PartmentNo"].ToString()),
                    PartmentName = dt.Rows[i]["PartmentName"].ToString(),
                    CreatPerson = dt.Rows[i]["CreatPerson"].ToString(),
                    CreatTime = dt.Rows[i]["CreatTime"].ToString(),
                    ModifyPerson = dt.Rows[i]["ModifyPerson"].ToString(),
                    ModifyTime = dt.Rows[i]["ModifyTime"].ToString()
                };
                list.Add(wMS_Partment_Model);
            }
            foreach (var model in list)
            {
                partmentBase.PartmentList.Add(model);
            }
            this.PartmentDataGrid.ItemsSource = partmentBase.PartmentList;
        }

        /// <summary>
        /// 编辑框事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PartmentDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            wms_Partment_Model = e.Row.Item as WMS_Partment_Model;
            partmentNo = wms_Partment_Model.PartmentNo;
        }

        /// <summary>
        /// 选中框事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox dg = sender as CheckBox;
            string partmentNo = dg.Tag.ToString();
            var bl = dg.IsChecked;
            if (bl == true)
            {
                selectPartmentNo.Add(int.Parse(partmentNo));
            }
            else
            {
                selectPartmentNo.Remove(int.Parse(partmentNo));
            }
        }

        /// <summary>
        /// 实时界面数据刷新
        /// </summary>
        private void Page_Frush()
        {
            partmentBase.PartmentList.Clear();
            foreach (var model in PartmentViewModel.GetPartmentList())
            {
                partmentBase.PartmentList.Add(model);
            }
            this.PartmentDataGrid.ItemsSource = partmentBase.PartmentList;
        }
    }
}
