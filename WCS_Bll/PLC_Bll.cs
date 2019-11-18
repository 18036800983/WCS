using MyPLCDataview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tool;
using WCS_Model.XML;

namespace WCS_Bll
{
    public class PLC_Bll
    {
        public delegate void recodeStationLog(string name, string message, int b, bool showFlag);
        public static event recodeStationLog recodePLCStationMessage;
        public delegate void setStatusDg(string name, int index);
        public event setStatusDg setStatusEvent;
        int boltCurNumber = 1;//螺栓颗数
        public static bool tightMark = true;

        public void Init()
        {
            if (Xml_Tool.xml.LINE.Count > 0)
            {
                    SiemensPLCInit();
            }
        }

        #region siemens plc
        struct SiemensPLCParameter
        {
            public monitorAddress ma;
            public string itemValue;

            public SiemensPLCParameter(monitorAddress ma_, string itemValue_)   // 带参数的构造函数
            {
                ma = ma_;
                itemValue = itemValue_;
            }
        }
        public PLCFunction[] siemensPlc;
        /// <summary>
        /// plc init 
        /// </summary>
        public void SiemensPLCInit()
        {
            #region PLC连接初始化
            try
            {
                siemensPlc = new PLCFunction[Xml_Tool.xml.LINE.Count];
                foreach (var line in Xml_Tool.xml.LINE)
                {
                    new Thread(new ParameterizedThreadStart(ConnectSiemensPLC)) { IsBackground = true }.Start(line);
                }
            }
            catch (Exception ex)
            {
                recodePLCStationMessage(string.Empty, " PLC initialization error，" + ex.Message, 1, true);
            }
            #endregion
        }

        /// <summary>
        /// plc connect
        /// </summary>
        /// <param name="objLine"></param>
        private void ConnectSiemensPLC(object objLine)
        {
            var line = objLine as Xml_InfoConfig;
            try
            {
                while (!Xml_Tool.xml.SysConfig.offlineTest && !Ping(line.IP))
                {
                    recodePLCStationMessage(string.Empty, line.Name + "Network connection failed", 1, true);
                    Thread.Sleep(5000);
                }
                if (siemensPlc[line.Index] != null)
                {
                    siemensPlc[line.Index].DisconnectMonitor();
                    siemensPlc[line.Index].DisconnectPLC();
                }
                siemensPlc[line.Index] = new PLCFunction(line.IP)
                {
                    OffLine = Xml_Tool.xml.SysConfig.offlineTest,
                    ThreadCount = line.ThreaCount,
                    UpdateRate = line.UpdateRate,
                    CpuSlot = line.PLCSlot
                };
                siemensPlc[line.Index].connectPLC();
                siemensPlc[line.Index].eventDataChanged += new DataChanged(OnSiemensPLCDataChanged);
                siemensPlc[line.Index].eventErrorOccurred += new ErrorOccurred(OnSiemensEventShowError);
                var c = GetMtAddrList()[line.Name];
                siemensPlc[line.Index].monitor(c);
                new Thread(new ParameterizedThreadStart(SetLifebeat_siemens)) { IsBackground = true }.Start(line);
                recodePLCStationMessage(string.Empty, line.Name + " PLC connection succeeded", 0, true);
            }
            catch (Exception ex)
            {
                recodePLCStationMessage(string.Empty, line.Name + "Failed to start, try to link again after 10 seconds！" + ex.Message, 1, true);
                Thread.Sleep(8000);
                new Thread(new ParameterizedThreadStart(ConnectSiemensPLC)) { IsBackground = true }.Start(line);
            }
        }

        /// <summary>
        /// get all need monitor address
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<monitorAddress>> GetMtAddrList()
        {
            var infoNode = Xml_Tool.xdoc.Root.Element("InfoConfig");
            var dic = new Dictionary<string, List<monitorAddress>>();
            foreach (var lineElement in infoNode.Elements("line"))
            {
                var opcList = lineElement.Descendants("opcitem").ToList();

                List<monitorAddress> maList = new List<monitorAddress>();

                foreach (var item in opcList)
                {
                    Dictionary<string, string> para = new Dictionary<string, string>();
                    para.Add("line", item.Parent.Parent.Parent.Attribute("name").Value);
                    para.Add("station", item.Parent.Parent.Attribute("name").Value);
                    para.Add("type", item.Parent.Name.LocalName);
                    foreach (var at in item.Attributes())
                    {
                        para.Add(at.Name.LocalName, at.Value);
                    }
                    monitorAddress ma = new monitorAddress(item.Attribute("addr").Value, para);
                    maList.Add(ma);
                }
                dic.Add(lineElement.Attribute("name").Value, maList);
            }
            return dic;
        }

        /// <summary>
        /// heart beat
        /// </summary>
        private void SetLifebeat_siemens(object objLine)
        {
            var line = objLine as Xml_InfoConfig; PLCFunction plcLifebeat = null;
            try
            {
                plcLifebeat = new PLCFunction(line.IP)
                {
                    OffLine = Xml_Tool.xml.SysConfig.offlineTest,
                    CpuSlot = line.PLCSlot
                };
                plcLifebeat.connectPLC();
                var value = false;
                while (true)
                {
                    if (value)
                        setStatusEvent(line.Name, 1);
                    else
                        setStatusEvent(line.Name, 0);
                    siemensPlc[line.Index].Write(line.HeartBeatAddr, value);
                    value = !value;
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                recodePLCStationMessage(string.Empty, line.Name + "Write heartbeat error:" + ex.Message, 1, true);
                recodePLCStationMessage(string.Empty, line.Name + " The connection is broken and an attempt is made to reconnect...", 0, true);
                if (plcLifebeat != null)
                    plcLifebeat.DisconnectPLC();
                Thread.Sleep(2000);
                new Thread(new ParameterizedThreadStart(ConnectSiemensPLC)) { IsBackground = true }.Start(line);
            }
        }

        /// <summary>
        /// check the net
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        private bool Ping(string ip)
        {
            try
            {
                System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingOptions options = new System.Net.NetworkInformation.PingOptions();
                int timeout = 1000; // Timeout 时间，单位：毫秒  
                System.Net.NetworkInformation.PingReply reply = p.Send(ip, timeout);
                if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// plc data changed
        /// </summary>
        /// <param name="ma"></param>
        /// <param name="objValue"></param>
        private void OnSiemensPLCDataChanged(monitorAddress ma, object objValue)
        {
            string itemValue = objValue.ToString().Replace("\0", "");
            ThreadPool.QueueUserWorkItem(new WaitCallback(DealSiemensPLCEvent),
                new SiemensPLCParameter(ma, itemValue));
        }

        /// <summary>
        /// error event
        /// </summary>
        /// <param name="message"></param>
        private void OnSiemensEventShowError(string message)
        {
            DoErrorEvent(message);
        }
        #endregion

        #region business
        /// <summary>
        /// deal with error event
        /// </summary>
        /// <param name="message"></param>
        private void DoErrorEvent(string message)
        {
            try
            {
                recodePLCStationMessage(string.Empty, "Control word polling error：" + message, 1, true);
                return;
            }
            catch (Exception ex)
            {
                recodePLCStationMessage(string.Empty, "error：" + ex.Message, 1, true);
            }
        }

        /// <summary>
        /// deal with siemens plc event
        /// </summary>
        /// <param name="state"></param>
        public void DealSiemensPLCEvent(object state)
        {
            var para = (SiemensPLCParameter)state;
            var MA = para.ma;
            var itemValue = para.itemValue;
            var type = MA.Parameter["type"];
            var LineName = MA.Parameter["line"];
            var STName = MA.Parameter["station"];
            var OPCName = MA.Parameter["name"];
            var BackAddr = MA.Parameter["backaddr"];
            var lineObj = Xml_Tool.xml.LINE.Single(n => n.Name == LineName);
        }
        #endregion
    }
}
