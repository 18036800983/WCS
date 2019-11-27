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
    public class BarcodeRuleBase : ViewModelBase
    {
        #region 选中
        private WMS_Barcode_Model selectedBarcode;

        public WMS_Barcode_Model SelectedBarcode
        {
            get { return selectedBarcode; }
            set
            {
                selectedBarcode = value;
                OnPropertyChanged("SelectedBarcode");
            }
        }
        #endregion

        #region 列表
        private ObservableCollection<WMS_Barcode_Model> barcodeList;

        public ObservableCollection<WMS_Barcode_Model> BarcodeList
        {
            get
            {
                if (barcodeList == null)
                {
                    barcodeList = new ObservableCollection<WMS_Barcode_Model>();
                }
                return barcodeList;
            }
            set
            {
                barcodeList = value;
                OnPropertyChanged("BarcodeList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displayBarcodeList;

        public bool DisplayBarcodeList
        {
            get { return displayBarcodeList; }
            set
            {
                displayBarcodeList = value;
                OnPropertyChanged("DisplayBarcodeList");
            }
        }

        public void ShowBarcodeList(bool show = true)
        {
            if (BarcodeList.Count > 0)
            {
                DisplayBarcodeList = show;
            }
            else
            {
                DisplayBarcodeList = false;
            }
        }
        #endregion
    }
}
