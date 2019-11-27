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
    /// CharacterPage.xaml 的交互逻辑
    /// </summary>
    public partial class CharacterPage : Page
    {
        CharacterBase characterBase = new CharacterBase();
        WMS_Character_Model wMS_Character_Model = new WMS_Character_Model();
        int editFlag = 0;//可编辑标签
        string loginName = string.Empty;
        public CharacterPage()
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
            CharacterDataDrid.IsReadOnly = false;
            CharacterDataDrid.CanUserAddRows = true;
        }

        /// <summary>
        /// 编辑按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Edit_Click(object sender, RoutedEventArgs e)
        {
            editFlag = 2;
            CharacterDataDrid.IsReadOnly = false;
            CharacterDataDrid.CanUserAddRows = false;
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
                WMS_Character_Bll.Delete_Character(" LoginName = '" + name + "'");
            }
            Page_Frush();
        }

        /// <summary>
        /// 编辑文本最后一列结束事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharacterDataDrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            wMS_Character_Model = e.Row.Item as WMS_Character_Model;
            loginName = wMS_Character_Model.LoginName;
        }

        List<string> selectLoginName = new List<string>();  

        /// <summary>
        /// CheckBox绑定事件
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
        /// 保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Save_Click(object sender, RoutedEventArgs e)
        {
            if (editFlag == 1)
            {
                WMS_Character_Bll.Insert_Character(wMS_Character_Model);
            }
            else if (editFlag == 2)
            {
                WMS_Character_Bll.Update_Character(wMS_Character_Model, " LoginName = '" + wMS_Character_Model.LoginName + "'");
            }
            editFlag = 0;
            Page_Frush();
            CharacterDataDrid.CanUserAddRows = false;
            CharacterDataDrid.IsReadOnly = true;
        }

        /// <summary>
        /// 搜索按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DMButton_Search_Click(object sender, RoutedEventArgs e)
        {
            characterBase.CharacterList.Clear();
            List<WMS_Character_Model> list = new List<WMS_Character_Model>();
            DataTable dt = WMS_Character_Bll.Select_Character(" LoginName = '" + SearchText.Text.Trim() + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                WMS_Character_Model wms_Character_Model = new WMS_Character_Model
                {
                    LoginName = dt.Rows[i]["LoginName"].ToString(),
                    UserName = dt.Rows[i]["UserName"].ToString(),
                    PartmentNo = int.Parse(dt.Rows[i]["PartmentNo"].ToString()),
                    UserPrivilege = dt.Rows[i]["UserPrivilege"].ToString(),
                    CreatPerson = dt.Rows[i]["CreatPerson"].ToString(),
                    CreatTime = dt.Rows[i]["CreatTime"].ToString(),
                    ModifyPerson = dt.Rows[i]["ModifyPerson"].ToString(),
                    ModifyTime = dt.Rows[i]["ModifyTime"].ToString()
                };
                list.Add(wms_Character_Model);
            }
            foreach (var model in list)
            {
                characterBase.CharacterList.Add(model);
            }
            this.CharacterDataDrid.ItemsSource = characterBase.CharacterList;
        }

        /// <summary>
        /// 实时界面数据刷新
        /// </summary>
        private void Page_Frush()
        {
            characterBase.CharacterList.Clear();
            foreach (var model in CharacterViewModel.GetCharacterList())
            {
                characterBase.CharacterList.Add(model);
            }
            this.CharacterDataDrid.ItemsSource = characterBase.CharacterList;
        }
    }
}
