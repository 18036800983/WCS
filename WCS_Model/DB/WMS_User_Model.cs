using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS_Model.DB
{
    public class WMS_User_Model : ViewModelBase
    {
        private string loginName;

        private string loginPassword;

        private string privilegeLevel;

        private string creatPerson;

        private string creatTime;

        private string modifyPerson;

        private string modifyTime;

        /// <summary>
        /// 登录名称
        /// </summary>
        public string LoginName
        {
            get => loginName;
            set { loginName = value; OnPropertyChanged("LoginName"); }
        }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string LoginPassword
        {
            get => loginPassword;
            set { loginPassword = value; OnPropertyChanged("LoginPassword"); }
        }

        /// <summary>
        /// 权限等级
        /// </summary>
        public string PrivilegeLevel
        {
            get => privilegeLevel;
            set { privilegeLevel = value; OnPropertyChanged("PrivilegeLevel"); }
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
