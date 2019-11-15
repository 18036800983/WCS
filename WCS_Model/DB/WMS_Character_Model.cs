using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS_Model.DB
{
    public class WMS_Character_Model : ViewModelBase
    {
        private string loginName;

        private string userName;

        private int partmentNo;

        private string userPrivilege;

        private string creatPerson;

        private string creatTime;

        private string modifyPerson;

        private string modifyTime;

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName
        {
            get => loginName;
            set { loginName = value; OnPropertyChanged("LoginName"); }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get => userName;
            set { userName = value; OnPropertyChanged("UserName"); }
        }

        /// <summary>
        /// 部门编号
        /// </summary>
        public int PartmentNo
        {
            get => partmentNo;
            set { partmentNo = value; OnPropertyChanged("PartmentNo"); }
        }

        /// <summary>
        /// 用户权限
        /// </summary>
        public string UserPrivilege
        {
            get => userPrivilege;
            set { userPrivilege = value; OnPropertyChanged("UserPrivilege"); }
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
