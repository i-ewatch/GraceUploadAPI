using GraceUploadAPI.Configuration;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraceUploadAPI.Methods
{
    public class InitialMethod
    {
        /// <summary>
        /// 初始路徑
        /// </summary>
        private static string MyWorkPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory;

        public static GatewaySetting GatewayLoad()
        {
            GatewaySetting setting = null;
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\Gateway.json";
            try
            {
                if (File.Exists(SettingPath))
                {
                    string json = File.ReadAllText(SettingPath, Encoding.UTF8);
                    setting = JsonConvert.DeserializeObject<GatewaySetting>(json);
                }
                else
                {
                    GatewaySetting Setting = new GatewaySetting()
                    {
                        CaseNo = "AAA0000000",
                        Gateways =
                        {
                            new Gateway ()
                            {
                                GatewayIndex = 0,
                                GatewayTypeEnum = 1,
                                Location= "127.0.0.1",
                                Rate = 502,
                                Devices  =
                                {
                                    new Device()
                                    {
                                        DeviceIndex= 0,
                                        ID =4,
                                    }
                                }
                            }
                        }
                    };
                    setting = Setting;
                    string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
                    File.WriteAllText(SettingPath, output);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, " Gateway資訊設定載入錯誤");
            }
            return setting;
        }
        public static APISetting APILoad()
        {
            APISetting setting = null;
            if (!Directory.Exists($"{MyWorkPath}\\stf"))
                Directory.CreateDirectory($"{MyWorkPath}\\stf");
            string SettingPath = $"{MyWorkPath}\\stf\\API.json";
            try
            {
                if (File.Exists(SettingPath))
                {
                    string json = File.ReadAllText(SettingPath, Encoding.UTF8);
                    setting = JsonConvert.DeserializeObject<APISetting>(json);
                }
                else
                {
                    APISetting Setting = new APISetting()
                    {
                        APIAddress ={
                            "http://ewatchapi.ai64.igrand.com.tw",
                            "http://220.130.205.123:1000/"
                        }
                    };
                    setting = Setting;
                    string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
                    File.WriteAllText(SettingPath, output);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, " Gateway資訊設定載入錯誤");
            }
            return setting;
        }
    }
}
