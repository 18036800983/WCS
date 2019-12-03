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
using WCS.ViewBase.WareM;
using WCS.ViewModel.WareM;
using WCS_Bll;
using WCS_Model.DB;

namespace WCS.View.WareM
{
    /// <summary>
    /// OutWarehousePage.xaml 的交互逻辑
    /// </summary>
    public partial class OutWarehousePage : Page
    {
        WMS_PutOut_Model wms_PutOut_Model = new WMS_PutOut_Model();
        OutWarehouseBase putOutBase = new OutWarehouseBase();
        int editFlag = 0;//可编辑标签
        string snName = string.Empty;
        List<string> selectSnName = new List<string>();
        public OutWarehousePage()
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
            PutOutDataGrid.IsReadOnly = false;
            PutOutDataGrid.CanUserAddRows = true;
        }

        /// <summary>
        /// 编辑按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Edit_Click(object sender, RoutedEventArgs e)
        {
            editFlag = 2;
            PutOutDataGrid.IsReadOnly = false;
            PutOutDataGrid.CanUserAddRows = false;
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var no in selectSnName)
            {
                WMS_PutOut_Bll.Delete_PutOut(" SN = '" + no + "'");
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
                WMS_PutOut_Bll.Insert_PutOut(wms_PutOut_Model);
            }
            else if (editFlag == 2)
            {
                WMS_PutOut_Bll.Update_PutOut(wms_PutOut_Model, " SN = '" + snName + "'");
            }
            editFlag = 0;
            Page_Frush();
            PutOutDataGrid.CanUserAddRows = false;
            PutOutDataGrid.IsReadOnly = true;
        }

        /// <summary>
        /// 搜索按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Search_Click(object sender, RoutedEventArgs e)
        {
            putOutBase.PutOutList.Clear();
            List<WMS_PutOut_Model> list = new List<WMS_PutOut_Model>();
            DataTable dt = WMS_PutOut_Bll.Select_PutOut(" SN = '" + SearchText.Text.Trim() + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_PutOut_Model wMS_PutOut_Model = new WMS_PutOut_Model
                {
                    ShelfNo = dt.Rows[i]["ShelfNo"].ToString(),
                    PutOutNo = dt.Rows[i]["PutInNo"].ToString(),
                    SN = dt.Rows[i]["SN"].ToString(),
                    OrderNo = dt.Rows[i]["OrderNo"].ToString(),
                    PutOutType = dt.Rows[i]["PutInType"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    PutOutTime = dt.Rows[i]["PutInTime"].ToString()
                };
                list.Add(wMS_PutOut_Model);
            }
            foreach (var model in list)
            {
                putOutBase.PutOutList.Add(model);
            }
            this.PutOutDataGrid.ItemsSource = putOutBase.PutOutList;
        }

        /// <summary>
        /// 编辑事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PutOutDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            wms_PutOut_Model = e.Row.Item as WMS_PutOut_Model;
            snName = wms_PutOut_Model.SN;
        }

        /// <summary>
        /// 选中框事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox dg = sender as CheckBox;
            string sn = dg.Tag.ToString();
            var bl = dg.IsChecked;
            if (bl == true)
            {
                selectSnName.Add(sn);
            }
            else
            {
                selectSnName.Remove(sn);
            }
        }

        /// <summary>
        /// 实时界面数据刷新
        /// </summary>
        private void Page_Frush()
        {
            putOutBase.PutOutList.Clear();
            foreach (var model in OutWarehouseViewModel.GetPutOutList())
            {
                putOutBase.PutOutList.Add(model);
            }
            this.PutOutDataGrid.ItemsSource = putOutBase.PutOutList;
        }
    }
}
