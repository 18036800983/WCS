using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WCS.Manager;
using WCS.Model;

namespace WCS.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region 页面切换
        //private Page currentPage = PageManager.PageEmpty;

        ///// <summary>
        ///// 当前页面
        ///// </summary>
        //public Page CurrentPage
        //{
        //    get { return currentPage; }
        //    set
        //    {
        //        currentPage = value;
        //        OnPropertyChanged("CurrentPage");
        //    }
        //}

        //private LeftMenu selectMenu;
        ///// <summary>
        ///// 选中的菜单
        ///// </summary>
        //public LeftMenu SelectMenu
        //{
        //    get { return selectMenu; }
        //    set
        //    {
        //        selectMenu = value;
        //        switch (selectMenu)
        //        {
        //            case LeftMenu.Home:
        //                CurrentPage = PageManager.PageEmpty;
        //                break;
        //            //跳转到本地音乐
        //            case LeftMenu.LocalMusic:
        //                CurrentPage = PageManager.PageLocalMusic;
        //                break;
        //            case LeftMenu.DownLoad:
        //                CurrentPage = PageManager.PageDownLoad;
        //                break;
        //            case LeftMenu.CloudMusic:
        //                CurrentPage = PageManager.PageCloudMusic;
        //                break;
        //            case LeftMenu.Collection:
        //                CurrentPage = PageManager.PageCollection;
        //                break;
        //        }
        //        OnPropertyChanged("SelectMenu");
        //    }
        //}
        #endregion
    }
}
