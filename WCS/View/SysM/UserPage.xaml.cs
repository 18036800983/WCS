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
    /// UserPage.xaml 的交互逻辑
    /// </summary>
    public partial class UserPage : Page
    {
        UserBase userBase = new UserBase();
        WMS_User_Model wMS_User_Model = new WMS_User_Model();
        int editFlag = 0;//可编辑标签
        string loginName = string.Empty;
        List<string> selectLoginName = new List<string>();
        public UserPage()
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
            UserDataGrid.IsReadOnly = false;
            UserDataGrid.CanUserAddRows = true;
        }

        /// <summary>
        /// 编辑按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Edit_Click(object sender, RoutedEventArgs e)
        {
            editFlag = 2;
            UserDataGrid.IsReadOnly = false;
            UserDataGrid.CanUserAddRows = false;
        }

        /// <summary>
        /// 删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var name in selectLoginName)
            {
                WMS_User_Bll.Delete_User(" LoginName = '" + name + "'");
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
                WMS_User_Bll.Insert_User(wMS_User_Model);
            }
            else if (editFlag == 2)
            {
                WMS_User_Bll.Update_User(wMS_User_Model, " LoginName = '" + wMS_User_Model.LoginName + "'");
            }
            editFlag = 0;
            Page_Frush();
            UserDataGrid.CanUserAddRows = false;
            UserDataGrid.IsReadOnly = true;
        }

        /// <summary>
        /// 搜索按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Search_Click(object sender, RoutedEventArgs e)
        {
            userBase.UserList.Clear();
            List<WMS_User_Model> list = new List<WMS_User_Model>();
            DataTable dt = WMS_User_Bll.Select_User(" LoginName = '" + SearchText.Text.Trim() + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_User_Model wms_User_Model = new WMS_User_Model
                {
                    LoginName = dt.Rows[i]["LoginName"].ToString(),
                    LoginPassword = dt.Rows[i]["LoginPassword"].ToString(),
                    PrivilegeLevel = dt.Rows[i]["PrivilegeLevel"].ToString(),
                    CreatPerson = dt.Rows[i]["CreatPerson"].ToString(),
                    CreatTime = dt.Rows[i]["CreatTime"].ToString(),
                    ModifyPerson = dt.Rows[i]["ModifyPerson"].ToString(),
                    ModifyTime = dt.Rows[i]["ModifyTime"].ToString()
                };
                list.Add(wms_User_Model);
            }
            foreach (var model in list)
            {
                userBase.UserList.Add(model);
            }
            this.UserDataGrid.ItemsSource = userBase.UserList;
        }

        /// <summary>
        /// 编辑事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            wMS_User_Model = e.Row.Item as WMS_User_Model;
            loginName = wMS_User_Model.LoginName;
        }

        /// <summary>
        /// 选中框事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox dg = sender as CheckBox;
            string loginName = dg.Tag.ToString();
            var bl = dg.IsChecked;
            if (bl == true)
            {
                selectLoginName.Add(loginName);
            }
            else
            {
                selectLoginName.Remove(loginName);
            }
        }

        /// <summary>
        /// 实时界面数据刷新
        /// </summary>
        private void Page_Frush()
        {
            userBase.UserList.Clear();
            foreach (var model in UserViewModel.GetUserList())
            {
                userBase.UserList.Add(model);
            }
            this.UserDataGrid.ItemsSource = userBase.UserList;
        }
    }
}
