using GraceUploadAPI.Protocols.Ai;
using GraceUploadAPI.Protocols.State;
using Modbus.Device;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraceUploadAPI.Components
{
    public partial class SerialportComponent : Field4Component
    {
        public SerialportComponent()
        {
            InitializeComponent();
        }

        public SerialportComponent(IContainer container)
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
                if (timeSpan.TotalSeconds >= 5)
                {
                    try
                    {
                        #region Rs485通訊功能初始化
                        try
                        {
                            if (SerialPort == null)
                            {
                                SerialPort = new SerialPort();
                            }
                            if (!SerialPort.IsOpen)
                            {
                                SerialPort.PortName = GateWaySetting.Gateways[0].Location;
                                SerialPort.BaudRate = GateWaySetting.Gateways[0].Rate;
                                SerialPort.DataBits = 8;
                                SerialPort.StopBits = StopBits.One;
                                SerialPort.Parity = Parity.None;
                                SerialPort.Open();
                            }
                        }
                        catch (ArgumentException)
                        {
                            Log.Error("通訊埠設定有誤");
                        }
                        catch (InvalidOperationException)
                        {
                            Log.Error("通訊埠被占用");
                        }
                        catch (IOException)
                        {
                            Log.Error("通訊埠無效");
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex, "通訊埠發生不可預期的錯誤。");
                        }
                        #endregion
                        if (SerialPort.IsOpen)
                        {
                            ModbusMaster ModbusMaster = ModbusSerialMaster.CreateRtu(SerialPort);
                            ModbusMaster.Transport.Retries = 3;
                            ModbusMaster.Transport.ReadTimeout = 500;
                            ModbusMaster.Transport.WriteTimeout = 500;
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
                        Log.Error(ex, $"通訊失敗 COM:{GateWaySetting.Gateways[0].Location} Rate:{GateWaySetting.Gateways[0].Rate} ");
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
