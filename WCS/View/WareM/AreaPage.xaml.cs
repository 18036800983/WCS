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
    /// AreaPage.xaml 的交互逻辑
    /// </summary>
    public partial class AreaPage : Page
    {
        WMS_Area_Model wms_Area_Model = new WMS_Area_Model();
        AreaBase areaBase = new AreaBase();
        int editFlag = 0;//可编辑标签
        string areaName = string.Empty;
        List<string> selectAreaName = new List<string>();
        public AreaPage()
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
            AreaDataGrid.IsReadOnly = false;
            AreaDataGrid.CanUserAddRows = true;
        }

        /// <summary>
        /// 编辑按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Edit_Click(object sender, RoutedEventArgs e)
        {
            editFlag = 2;
            AreaDataGrid.IsReadOnly = false;
            AreaDataGrid.CanUserAddRows = false;
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var no in selectAreaName)
            {
                WMS_Area_Bll.Delete_Area(" AreaName = '" + no + "'");
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
                WMS_Area_Bll.Insert_Area(wms_Area_Model);
            }
            else if (editFlag == 2)
            {
                WMS_Area_Bll.Update_Area(wms_Area_Model, " AreaName = '" + areaName + "'");
            }
            editFlag = 0;
            Page_Frush();
            AreaDataGrid.CanUserAddRows = false;
            AreaDataGrid.IsReadOnly = true;
        }

        /// <summary>
        /// 搜索按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Search_Click(object sender, RoutedEventArgs e)
        {
            areaBase.AreaList.Clear();
            List<WMS_Area_Model> list = new List<WMS_Area_Model>();
            DataTable dt = WMS_Area_Bll.Select_Area(" AreaName = '" + SearchText.Text.Trim() + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Area_Model wMS_Area_Model = new WMS_Area_Model
                {
                    AreaName = dt.Rows[i]["AreaName"].ToString(),
                    AreaNo = dt.Rows[i]["AreaNo"].ToString(),
                    WarehouseNo = dt.Rows[i]["WarehouseNo"].ToString(),
                    Remark = dt.Rows[i]["Remark"].ToString(),
                    CreatPerson = dt.Rows[i]["CreatPerson"].ToString(),
                    CreatTime = dt.Rows[i]["CreatTime"].ToString(),
                    ModifyPerson = dt.Rows[i]["ModifyPerson"].ToString(),
                    ModifyTime = dt.Rows[i]["ModifyTime"].ToString()
                };
                list.Add(wMS_Area_Model);
            }
            foreach (var model in list)
            {
                areaBase.AreaList.Add(model);
            }
            this.AreaDataGrid.ItemsSource = areaBase.AreaList;
        }

        /// <summary>
        /// 编辑事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AreaDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            wms_Area_Model = e.Row.Item as WMS_Area_Model;
            areaName = wms_Area_Model.AreaName;
        }

        /// <summary>
        /// 选中框事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox dg = sender as CheckBox;
            string areaName = dg.Tag.ToString();
            var bl = dg.IsChecked;
            if (bl == true)
            {
                selectAreaName.Add(areaName);
            }
            else
            {
                selectAreaName.Remove(areaName);
            }
        }

        /// <summary>
        /// 实时界面数据刷新
        /// </summary>
        private void Page_Frush()
        {
            areaBase.AreaList.Clear();
            foreach (var model in AreaViewModel.GetAreaList())
            {
                areaBase.AreaList.Add(model);
            }
            this.AreaDataGrid.ItemsSource = areaBase.AreaList;
        }
    }
}
