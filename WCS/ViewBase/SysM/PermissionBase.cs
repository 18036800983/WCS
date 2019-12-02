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
    public class PermissionBase : ViewModelBase
    {
        #region 选中
        private WMS_Privilege_Model selectedPrivilege;

        public WMS_Privilege_Model SelectedPrivilege
        {
            get { return selectedPrivilege; }
            set
            {
                selectedPrivilege = value;
                OnPropertyChanged("SelectedPrivilege");
            }
        }
        #endregion

        #region 列表
        private ObservableCollection<WMS_Privilege_Model> privilegeList;

        public ObservableCollection<WMS_Privilege_Model> PrivilegeList
        {
            get
            {
                if (privilegeList == null)
                {
                    privilegeList = new ObservableCollection<WMS_Privilege_Model>();
                }
                return privilegeList;
            }
            set
            {
                privilegeList = value;
                OnPropertyChanged("PrivilegeList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displayPrivilegeList;

        public bool DisplayPrivilegeList
        {
            get { return displayPrivilegeList; }
            set
            {
                displayPrivilegeList = value;
                OnPropertyChanged("DisplayPrivilegeList");
            }
        }

        public void ShowPrivilegeList(bool show = true)
        {
            if (PrivilegeList.Count > 0)
            {
                DisplayPrivilegeList = show;
            }
            else
            {
                DisplayPrivilegeList = false;
            }
        }
        #endregion
    }
}
