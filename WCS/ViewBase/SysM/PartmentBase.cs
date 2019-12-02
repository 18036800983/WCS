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
    public class PartmentBase : ViewModelBase
    {
        #region 选中
        private WMS_Partment_Model selectedPartment;

        public WMS_Partment_Model SelectedPartment
        {
            get { return selectedPartment; }
            set
            {
                selectedPartment = value;
                OnPropertyChanged("SelectedPartment");
            }
        }
        #endregion

        #region 列表
        private ObservableCollection<WMS_Partment_Model> partmentList;

        public ObservableCollection<WMS_Partment_Model> PartmentList
        {
            get
            {
                if (partmentList == null)
                {
                    partmentList = new ObservableCollection<WMS_Partment_Model>();
                }
                return partmentList;
            }
            set
            {
                partmentList = value;
                OnPropertyChanged("PartmentList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displayPartmentList;

        public bool DisplayPartmentList
        {
            get { return displayPartmentList; }
            set
            {
                displayPartmentList = value;
                OnPropertyChanged("DisplayPartmentList");
            }
        }

        public void ShowPartmentList(bool show = true)
        {
            if (PartmentList.Count > 0)
            {
                DisplayPartmentList = show;
            }
            else
            {
                DisplayPartmentList = false;
            }
        }
        #endregion
    }
}
