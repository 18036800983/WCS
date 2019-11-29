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
    public class SysLogBase : ViewModelBase
    {
        #region 选中
        private WMS_Log_Model selectedSysLog;

        public WMS_Log_Model SelectedSysLog
        {
            get { return selectedSysLog; }
            set
            {
                selectedSysLog = value;
                OnPropertyChanged("SelectedSysLog");
            }
        }
        #endregion

        #region 列表
        private ObservableCollection<WMS_Log_Model> sysLogList;

        public ObservableCollection<WMS_Log_Model> SysLogList
        {
            get
            {
                if (sysLogList == null)
                {
                    sysLogList = new ObservableCollection<WMS_Log_Model>();
                }
                return sysLogList;
            }
            set
            {
                sysLogList = value;
                OnPropertyChanged("SysLogList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displaySysLogList;

        public bool DisplaySysLogList
        {
            get { return displaySysLogList; }
            set
            {
                displaySysLogList = value;
                OnPropertyChanged("DisplaySysLogList");
            }
        }

        public void ShowSysLogList(bool show = true)
        {
            if (SysLogList.Count > 0)
            {
                DisplaySysLogList = show;
            }
            else
            {
                DisplaySysLogList = false;
            }
        }
        #endregion
    }
}
