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
    public class ClientBase : ViewModelBase
    {
        #region 选中
        private WMS_Client_Model selectedClient;

        public WMS_Client_Model SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }
        #endregion

        #region 列表
        private ObservableCollection<WMS_Client_Model> clientList;

        public ObservableCollection<WMS_Client_Model> ClientList
        {
            get
            {
                if (clientList == null)
                {
                    clientList = new ObservableCollection<WMS_Client_Model>();
                }
                return clientList;
            }
            set
            {
                clientList = value;
                OnPropertyChanged("ClientList");
            }
        }
        #endregion

        #region 是否显示列表
        private bool displayClientList;

        public bool DisplayClientList
        {
            get { return displayClientList; }
            set
            {
                displayClientList = value;
                OnPropertyChanged("DisplayClientList");
            }
        }

        public void ShowClientList(bool show = true)
        {
            if (ClientList.Count > 0)
            {
                DisplayClientList = show;
            }
            else
            {
                DisplayClientList = false;
            }
        }
        #endregion
    }
}
