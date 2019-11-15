using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS_Model.DB
{
    public class WMS_Shelf_Model : ViewModelBase
    {
        private string shelfName;

        private string shelfNo;

        private string areaNo;

        private string warehouseNo;

        private string remark;

        private string creatPerson;

        private string creatTime;

        private string modifyPerson;

        private string modifyTime;

        /// <summary>
        /// 货架名称
        /// </summary>
        public string ShelfName
        {
            get => shelfName;
            set { shelfName = value; OnPropertyChanged("ShelfName"); }
        }

        /// <summary>
        /// 货架编号
        /// </summary>
        public string ShelfNo
        {
            get => shelfNo;
            set { shelfNo = value; OnPropertyChanged("ShelfNo"); }
        }

        /// <summary>
        /// 区域编号
        /// </summary>
        public string AreaNo
        {
            get => areaNo;
            set { areaNo = value; OnPropertyChanged("AreaNo"); }
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
        /// 备注
        /// </summary>
        public string Remark
        {
            get => remark;
            set { remark = value; OnPropertyChanged("Remark"); }
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
