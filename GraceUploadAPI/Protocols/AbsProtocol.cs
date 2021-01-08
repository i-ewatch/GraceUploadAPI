using GraceUploadAPI.Configuration;
using MathLibrary;
using Modbus.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraceUploadAPI.Protocols
{
    public abstract class AbsProtocol
    {
        public MathClass MathClass { get; set; } = new MathClass();
        /// <summary>
        /// 案場編號
        /// </summary>
        public string CaseNo { get; set; }
        /// <summary>
        /// 通訊編號
        /// </summary>
        public int GatewayIndex { get; set; }
        /// <summary>
        /// 設備編號
        /// </summary>
        public int DeviceIndex { get; set; }
        /// <summary>
        /// 通訊讀取
        /// </summary>
        public virtual void ReadData(List<Device> devices,ModbusMaster master) { }
    }
}
