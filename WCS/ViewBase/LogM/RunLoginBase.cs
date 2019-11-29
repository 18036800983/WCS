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
    public class RunLoginBase : ViewModelBase
    {
        #region 选中
        private WMS_Log_Model selectedRunLog;

        public WMS_Log_Model SelectedRunLog
        {
            get { return selectedRunLog; }
            set
            {
                selectedRunLog = value;
                OnPropertyChanged("SelectedRunLog");
            }
        }
        #endregion

        #region 列表
        private ObservableCollection<WMS_Log_Model> runLogList;

        public ObservableCollection<WMS_Log_Model> RunLogList
        {
            get
            {
                if (runLogList == null)
                {
                    runLogList = new ObservableCollection<WMS_Log_Model>();
                }
                return runLogList;
            }
            set
            {
                runLogList = value;
                OnPropertyChanged("RunLogList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displayRunLogList;

        public bool DisplayRunLogList
        {
            get { return displayRunLogList; }
            set
            {
                displayRunLogList = value;
                OnPropertyChanged("DisplayRunLogList");
            }
        }

        public void ShowRunLogList(bool show = true)
        {
            if (RunLogList.Count > 0)
            {
                DisplayRunLogList = show;
            }
            else
            {
                DisplayRunLogList = false;
            }
        }
        #endregion
    }
}
