using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS.ViewBase.LogM
{
    public class LoginLogBase : ViewModelBase
    {
        #region 选中
        private WMS_Log_Model selectedLoginLog;

        public WMS_Log_Model SelectedLoginLog
        {
            get { return selectedLoginLog; }
            set
            {
                selectedLoginLog = value;
                OnPropertyChanged("SelectedLoginLog");
            }
        }
        #endregion

        #region 列表
        private ObservableCollection<WMS_Log_Model> loginLogList;

        public ObservableCollection<WMS_Log_Model> LoginLogList
        {
            get
            {
                if (loginLogList == null)
                {
                    loginLogList = new ObservableCollection<WMS_Log_Model>();
                }
                return loginLogList;
            }
            set
            {
                loginLogList = value;
                OnPropertyChanged("LoginLogList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displayLoginLogList;

        public bool DisplayLoginLogList
        {
            get { return displayLoginLogList; }
            set
            {
                displayLoginLogList = value;
                OnPropertyChanged("DisplayLoginLogList");
            }
        }

        public void ShowLoginLogList(bool show = true)
        {
            if (LoginLogList.Count > 0)
            {
                DisplayLoginLogList = show;
            }
            else
            {
                DisplayLoginLogList = false;
            }
        }
        #endregion
    }
}
