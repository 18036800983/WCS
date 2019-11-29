using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCS_Model.DB;

namespace WCS.ViewBase.BaseM
{
    public class SupplierBase : ViewModelBase
    {
        #region 选中
        private WMS_Supplier_Model selectedSupplier;

        public WMS_Supplier_Model SelectedSupplier
        {
            get { return selectedSupplier; }
            set
            {
                selectedSupplier = value;
                OnPropertyChanged("SelectedSupplier");
            }
        }
        #endregion

        #region 列表
        private ObservableCollection<WMS_Supplier_Model> supplierList;

        public ObservableCollection<WMS_Supplier_Model> SupplierList
        {
            get
            {
                if (supplierList == null)
                {
                    supplierList = new ObservableCollection<WMS_Supplier_Model>();
                }
                return supplierList;
            }
            set
            {
                supplierList = value;
                OnPropertyChanged("SupplierList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displaySupplierList;

        public bool DisplaySupplierList
        {
            get { return displaySupplierList; }
            set
            {
                displaySupplierList = value;
                OnPropertyChanged("DisplaySupplierList");
            }
        }

        public void ShowSupplierList(bool show = true)
        {
            if (SupplierList.Count > 0)
            {
                DisplaySupplierList = show;
            }
            else
            {
                DisplaySupplierList = false;
            }
        }
        #endregion
    }
}
