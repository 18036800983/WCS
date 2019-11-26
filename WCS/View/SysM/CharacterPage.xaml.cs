using System;
using System.Collections.Generic;
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
        int judge = 0;
        public CharacterPage()
        {
            InitializeComponent();
        }

        private void DMButton_Add_Click(object sender, RoutedEventArgs e)
        {
            judge = 1;
            CharacterDataDrid.CanUserAddRows = true;
        }

        private void DMButton_Edit_Click(object sender, RoutedEventArgs e)
        {
            WMS_Character_Bll.Insert_Character(wMS_Character_Model);
            judge = 0;          //重新回到编辑状态
            this.CharacterDataDrid.ItemsSource = characterBase.CharacterList;
            CharacterDataDrid.CanUserAddRows = false;     //因为完成了添加操作 所以设置DataGrid不能自动生成新行了
        }

        private void DMButton_Delete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var name in selectLoginName)
            {
                WMS_Character_Bll.Delete_Character(" LoginName = '" + name + "'");
            }

            foreach (var model in CharacterViewModel.GetCharacterList())
            {
                characterBase.CharacterList.Add(model);
            }

            this.CharacterDataDrid.ItemsSource = characterBase.CharacterList;
        }

        private void CharacterDataDrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            wMS_Character_Model = e.Row.Item as WMS_Character_Model;        //获取该行的记录
            if (judge == 1)                                          //如果是添加状态就保存该行的值到lstInformation中  这样我们就完成了新行值的获取
            {
                characterBase.CharacterList.Add(wMS_Character_Model);
            }
            else
            {
                characterBase.CharacterList.Add(wMS_Character_Model);            //如果是编辑状态就执行更新操作  更新操作最简单，因为你直接可以在DataGrid里面进行编辑，编辑完成后执行这个事件就完成更新操作了
            }
        }

        List<string> selectLoginName = new List<string>();  //保存选中要删除行的FID值
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox dg = sender as CheckBox;
            string loginName = dg.Tag.ToString();   //获取该行的FID
            var bl = dg.IsChecked;
            if (bl == true)
            {
                selectLoginName.Add(loginName);         //如果选中就保存FID
            }
            else
            {
                selectLoginName.Remove(loginName);  //如果选中取消就删除里面的FID
            }
        }
    }
}
