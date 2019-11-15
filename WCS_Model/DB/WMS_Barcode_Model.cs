using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS_Model.DB
{
    public class WMS_Barcode_Model : ViewModelBase
    {
        private int barcodeLength;

        private string barcodeRule;

        private string productionNo;

        private string creatPerson;

        private string creatTime;

        private string modifyPerson;

        private string modifyTime;

        /// <summary>
        /// 条码长度
        /// </summary>
        public int BarcodeLength
        {
            get => barcodeLength;
            set { barcodeLength = value; OnPropertyChanged("BarcodeLength"); }
        }

        /// <summary>
        /// 条码规则
        /// </summary>
        public string BarcodeRule
        {
            get => barcodeRule;
            set { barcodeRule = value; OnPropertyChanged("BarcodeRule"); }
        }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductionNo
        {
            get => productionNo;
            set { productionNo = value; OnPropertyChanged("ProductionNo"); }
        }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreatPerson
        {
            get => creatPerson;
            set { creatPerson = value; OnPropertyChanged("CreatPerson"); }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreatTime
        {
            get => creatTime;
            set { creatTime = value; OnPropertyChanged("CreatTime"); }
        }

        /// <summary>
        /// 修改人
        /// </summary>
        public string ModifyPerson
        {
            get => modifyPerson;
            set { modifyPerson = value; OnPropertyChanged("ModifyPerson"); }
        }

        /// <summary>
        /// 修改时间
        /// </summary>
        public string ModifyTime
        {
            get => modifyTime;
            set { modifyTime = value; OnPropertyChanged("ModifyTime"); }
        }
    }
}
