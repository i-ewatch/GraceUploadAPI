using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraceUploadAPI.Configuration
{
    public class GatewaySetting
    {
        /// <summary>
        /// 案場編號
        /// </summary>
        public string CaseNo { get; set; }
        /// <summary>
        /// 通訊通道資訊
        /// </summary>
        public List<Gateway> Gateways { get; set; } = new List<Gateway>();
    }
    public class Gateway
    {
        /// <summary>
        /// 通訊通道類型
        /// </summary>
        public int GatewayTypeEnum { get; set; }
        /// <summary>
        /// 通訊編號
        /// </summary>
        public int GatewayIndex { get; set; }
        /// <summary>
        /// 通訊通道
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 通訊Rate或Port
        /// </summary>
        public int Rate { get; set; }
        /// <summary>
        /// 設備資訊
        /// </summary>
        public List<Device> Devices { get; set; } = new List<Device>();
    }
    public class Device
    {
        /// <summary>
        /// 設備ID
        /// </summary>
        public byte ID { get; set; }
        /// <summary>
        /// 設備編號
        /// </summary>
        public int DeviceIndex { get; set; }
    }
}
