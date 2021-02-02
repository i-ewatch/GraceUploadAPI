using GraceUploadAPI.Protocols.Ai;
using GraceUploadAPI.Protocols.State;
using Modbus.Device;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraceUploadAPI.Components
{
    public partial class TcpComponent : Field4Component
    {
        public TcpComponent()
        {
            InitializeComponent();
        }

        public TcpComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        protected override void AfterMyWorkStateChanged(object sender, EventArgs e)
        {
            if (myWorkState)
            {
                AiProtocol aiProtocol = new AiProtocol() { CaseNo = GateWaySetting.CaseNo };
                AbsProtocols.Add(aiProtocol);
                StateProtocol stateProtocol = new StateProtocol() { CaseNo = GateWaySetting.CaseNo };
                AbsProtocols.Add(stateProtocol);
                ReadThread = new Thread(Analysis);
                ReadThread.Start();
            }
            else
            {
                if (ReadThread != null)
                {
                    ReadThread.Abort();
                }
            }
        }
        private void Analysis()
        {
            while (myWorkState)
            {
                TimeSpan timeSpan = DateTime.Now.Subtract(ReadTime);
                if (timeSpan.TotalSeconds >= 1)
                {
                    try
                    {
                        using (TcpClient tcp = new TcpClient(GateWaySetting.Gateways[0].Location, GateWaySetting.Gateways[0].Rate))
                        {
                            ModbusMaster ModbusMaster = ModbusIpMaster.CreateIp(tcp);
                            ModbusMaster.Transport.Retries = 3;
                            ModbusMaster.Transport.ReadTimeout = 1000;
                            ModbusMaster.Transport.WriteTimeout = 1000;
                            foreach (var item in AbsProtocols)
                            {
                                item.ReadData(GateWaySetting.Gateways[0].Devices, ModbusMaster);
                                Thread.Sleep(10);
                            }
                            if (AbsProtocols[0].ConnectionFlag)
                            {
                                AI64Module = ((AiProtocol)AbsProtocols[0]).AI64Module;
                            }
                            else
                            {
                                AI64Module = null;
                            }
                            StateModules = ((StateProtocol)AbsProtocols[1]).StateModules;
                            ReadTime = DateTime.Now;
                        }
                    }
                    catch (ThreadAbortException) { }
                    catch (Exception ex)
                    {
                        ReadTime = DateTime.Now;
                        Log.Error(ex, $"通訊失敗 IP:{GateWaySetting.Gateways[0].Location} Port:{GateWaySetting.Gateways[0].Rate} ");
                    }
                }
                else
                {
                    Thread.Sleep(80);
                }
            }
        }
    }
}
