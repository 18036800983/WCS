using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS.ViewBase.SysM
{
    public class UserBase : ViewModelBase
    {
        #region 选中
        private WMS_User_Model selectedUser;

        public WMS_User_Model SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }
        #endregion

        #region 列表
        private ObservableCollection<WMS_User_Model> userList;

        public ObservableCollection<WMS_User_Model> UserList
        {
            get
            {
                if (userList == null)
                {
                    userList = new ObservableCollection<WMS_User_Model>();
                }
                return userList;
            }
            set
            {
                userList = value;
                OnPropertyChanged("UserList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displayUserList;

        public bool DisplayUserList
        {
            get { return displayUserList; }
            set
            {
                displayUserList = value;
                OnPropertyChanged("DisplayUserList");
            }
        }

        public void ShowUserList(bool show = true)
        {
            if (UserList.Count > 0)
            {
                DisplayUserList = show;
            }
            else
            {
                DisplayUserList = false;
            }
        }
        #endregion
    }
}
