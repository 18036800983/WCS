using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS_Model.DB
{
    public class WMS_Production_Model : ViewModelBase
    {
        private string productionNo;

        private string productionName;

        private string locationNo;

        private string warehouseNo;

        private string creatPerson;

        private string creatTime;

        private string modifyPerson;

        private string modifyTime;

        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductionNo
        {
            get => productionNo;
            set { productionNo = value; OnPropertyChanged("ProductionNo"); }
        }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductionName
        {
            get => productionName;
            set { productionName = value; OnPropertyChanged("ProductionName"); }
        }

        /// <summary>
        /// 库区编号
        /// </summary>
        public string LocationNo
        {
            get => locationNo;
            set { locationNo = value; OnPropertyChanged("LocationNo"); }
        }

        /// <summary>
        /// 仓库编号
        /// </summary>
        public string WarehouseNo
        {
            get => warehouseNo;
            set { warehouseNo = value; OnPropertyChanged("WarehouseNo"); }
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
