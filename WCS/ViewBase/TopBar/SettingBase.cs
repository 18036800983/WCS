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
    public class SettingBase : ViewModelBase
    {
        #region 列表
        private ObservableCollection<WMS_DBConfig_Model> dbConfigList;

        public ObservableCollection<WMS_DBConfig_Model> DBConfigList
        {
            get
            {
                if (dbConfigList == null)
                {
                    dbConfigList = new ObservableCollection<WMS_DBConfig_Model>();
                }
                return dbConfigList;
            }
            set
            {
                dbConfigList = value;
                OnPropertyChanged("DBConfigList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displayDBConfigList;

        public bool DisplayDBConfigList
        {
            get { return displayDBConfigList; }
            set
            {
                displayDBConfigList = value;
                OnPropertyChanged("DisplayDBConfigList");
            }
        }

        public void ShowDBConfigList(bool show = true)
        {
            if (DBConfigList.Count > 0)
            {
                DisplayDBConfigList = show;
            }
            else
            {
                DisplayDBConfigList = false;
            }
        }
        #endregion
    }
}
