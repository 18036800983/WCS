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
    public class Messagebase : ViewModelBase
    {
        #region 列表
        private ObservableCollection<WMS_Log_Model> errorLogList;

        public ObservableCollection<WMS_Log_Model> ErrorLogList
        {
            get
            {
                if (errorLogList == null)
                {
                    errorLogList = new ObservableCollection<WMS_Log_Model>();
                }
                return errorLogList;
            }
            set
            {
                errorLogList = value;
                OnPropertyChanged("ErrorLogList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displayErrorLogList;

        public bool DisplayErrorLogList
        {
            get { return displayErrorLogList; }
            set
            {
                displayErrorLogList = value;
                OnPropertyChanged("DisplayErrorLogList");
            }
        }

        public void ShowErrorLogList(bool show = true)
        {
            if (ErrorLogList.Count > 0)
            {
                DisplayErrorLogList = show;
            }
            else
            {
                DisplayErrorLogList = false;
            }
        }
        #endregion
    }
}
