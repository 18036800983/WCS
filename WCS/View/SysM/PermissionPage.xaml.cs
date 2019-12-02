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
    /// PermissionPage.xaml 的交互逻辑
    /// </summary>
    public partial class PermissionPage : Page
    {
        WMS_Privilege_Model wms_Privilege_Model = new WMS_Privilege_Model();
        PermissionBase permissionBase = new PermissionBase();
        int editFlag = 0;//可编辑标签
        int privilegeNo = 0;
        List<int> selectPrivilege = new List<int>();
        public PermissionPage()
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
            PrivilegeDataGrid.IsReadOnly = false;
            PrivilegeDataGrid.CanUserAddRows = true;
        }

        /// <summary>
        /// 编辑按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Edit_Click(object sender, RoutedEventArgs e)
        {
            editFlag = 2;
            PrivilegeDataGrid.IsReadOnly = false;
            PrivilegeDataGrid.CanUserAddRows = false;
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var name in selectPrivilege)
            {
                WMS_Privilege_Bll.Delete_Privilege(" PrivilegeNo = " + name);
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
                WMS_Privilege_Bll.Insert_Privilege(wms_Privilege_Model);
            }
            else if (editFlag == 2)
            {
                WMS_Privilege_Bll.Update_Privilege(wms_Privilege_Model, " PrivilegeNo = " + privilegeNo);
            }
            editFlag = 0;
            Page_Frush();
            PrivilegeDataGrid.CanUserAddRows = false;
            PrivilegeDataGrid.IsReadOnly = true;
        }

        /// <summary>
        /// 搜索按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Search_Click(object sender, RoutedEventArgs e)
        {
            permissionBase.PrivilegeList.Clear();
            List<WMS_Privilege_Model> list = new List<WMS_Privilege_Model>();
            DataTable dt = WMS_Privilege_Bll.Select_Privilege(" PrivilegeNo = " + int.Parse(SearchText.Text.Trim()));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Privilege_Model wMS_Privilege_Model = new WMS_Privilege_Model
                {
                    PrivilegeNo = int.Parse(dt.Rows[i]["PrivilegeNo"].ToString()),
                    PrivilegeName = dt.Rows[i]["PrivilegeName"].ToString()
                };
                list.Add(wMS_Privilege_Model);
            }
            foreach (var model in list)
            {
                permissionBase.PrivilegeList.Add(model);
            }
            this.PrivilegeDataGrid.ItemsSource = permissionBase.PrivilegeList;
        }

        /// <summary>
        /// 编辑事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrivilegeDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            wms_Privilege_Model = e.Row.Item as WMS_Privilege_Model;
            privilegeNo = wms_Privilege_Model.PrivilegeNo;
        }

        /// <summary>
        /// 选中框事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox dg = sender as CheckBox;
            string privilegeNo = dg.Tag.ToString();
            var bl = dg.IsChecked;
            if (bl == true)
            {
                selectPrivilege.Add(int.Parse(privilegeNo));
            }
            else
            {
                selectPrivilege.Remove(int.Parse(privilegeNo));
            }
        }

        /// <summary>
        /// 实时界面数据刷新
        /// </summary>
        private void Page_Frush()
        {
            permissionBase.PrivilegeList.Clear();
            foreach (var model in PermissionViewModel.GetPrivilegeList())
            {
                permissionBase.PrivilegeList.Add(model);
            }
            this.PrivilegeDataGrid.ItemsSource = permissionBase.PrivilegeList;
        }
    }
}
