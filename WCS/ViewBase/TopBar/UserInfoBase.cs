using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS.ViewBase.TopBar
{
    public class UserInfoBase : ViewModelBase
    {
        #region 列表
        private ObservableCollection<WMS_Character_Model> userInfoList;

        public ObservableCollection<WMS_Character_Model> UserInfoList
        {
            get
            {
                if (userInfoList == null)
                {
                    userInfoList = new ObservableCollection<WMS_Character_Model>();
                }
                return userInfoList;
            }
            set
            {
                userInfoList = value;
                OnPropertyChanged("UserInfoList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displayUserInfoList;

        public bool DisplayUserInfoList
        {
            get { return displayUserInfoList; }
            set
            {
                displayUserInfoList = value;
                OnPropertyChanged("DisplayUserInfoList");
            }
        }

        public void ShowUserInfoList(bool show = true)
        {
            if (UserInfoList.Count > 0)
            {
                DisplayUserInfoList = show;
            }
            else
            {
                DisplayUserInfoList = false;
            }
        }
        #endregion
    }
}
