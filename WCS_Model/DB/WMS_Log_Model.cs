using DMSkin.Core.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCS_Model.DB
{
    public class WMS_Log_Model : ViewModelBase
    {
        private string logTime;

        private string logType;

        private string logLocation;

        private string logMessage;

        private int logLevel;

        /// <summary>
        /// 日志时间
        /// </summary>
        public string LogTime
        {
            get => logTime;
            set { logTime = value; OnPropertyChanged("LogTime"); }
        }

        /// <summary>
        /// 日志类型
        /// </summary>
        public string LogType
        {
            get => logType;
            set { logType = value; OnPropertyChanged("LogType"); }
        }

        /// <summary>
        /// 日志位置
        /// </summary>
        public string LogLocation
        {
            get => logLocation;
            set { logLocation = value; OnPropertyChanged("LogLocation"); }
        }

        /// <summary>
        /// 日志消息
        /// </summary>
        public string LogMessage
        {
            get => logMessage;
            set { logMessage = value; OnPropertyChanged("LogMessage"); }
        }

        /// <summary>
        /// 日志级别
        /// </summary>
        public int LogLevel
        {
            get => logLevel;
            set { logLevel = value; OnPropertyChanged("LogLevel"); }
        }
    }
}
