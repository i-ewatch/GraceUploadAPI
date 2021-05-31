using GraceUploadAPI.Components;
using GraceUploadAPI.Configuration;
using GraceUploadAPI.Enums;
using GraceUploadAPI.Methods;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraceUploadAPI
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// API發送資訊
        /// </summary>
        private APISetting APISetting { get; set; }
        /// <summary>
        /// 通訊資訊
        /// </summary>
        private GatewaySetting GatewaySetting { get; set; }
        /// <summary>
        /// 通訊類型
        /// </summary>
        private GatewayTypeEnum GatewayTypeEnum { get; set; }
        /// <summary>
        /// 通訊物件
        /// </summary>
        private List<Field4Component> Field4Components = new List<Field4Component>();
        private ApiComponent ApiComponent { get; set; }
        public Form1()
        {
            InitializeComponent();
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File($"{AppDomain.CurrentDomain.BaseDirectory}\\log\\log-.txt",
            rollingInterval: RollingInterval.Day,
            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();        //宣告Serilog初始化

            GatewaySetting = InitialMethod.GatewayLoad();
            APISetting = InitialMethod.APILoad();
            if (GatewaySetting != null)
            {
                foreach (var item in GatewaySetting.Gateways)
                {
                    GatewayTypeEnum = (GatewayTypeEnum)item.GatewayTypeEnum;
                    switch (GatewayTypeEnum)
                    {
                        case GatewayTypeEnum.ModbusRTU:
                            {
                                SerialportComponent component = new SerialportComponent() { GateWaySetting = GatewaySetting, APISetting = APISetting };
                                component.MyWorkState = true;
                                Field4Components.Add(component);
                            }
                            break;
                        case GatewayTypeEnum.ModbusTCP:
                            {
                                TcpComponent component = new TcpComponent() { GateWaySetting = GatewaySetting, APISetting = APISetting };
                                component.MyWorkState = true;
                                Field4Components.Add(component);
                            }
                            break;
                    }
                }
                ApiComponent = new ApiComponent();
                ApiComponent.APISetting = APISetting;
                ApiComponent.MyWorkState = true;
                timer1.Interval = 1000;
                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ApiComponent.AI64Module = Field4Components[0].AI64Module;
            ApiComponent.StateModules = Field4Components[0].StateModules;
            Timelabel.Text = ApiComponent.ReadTime.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var item in Field4Components)
            {
                item.MyWorkState = false;
            }
            ApiComponent.MyWorkState = false;
            this.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Location = new Point(0, 0);
        }
    }
}
