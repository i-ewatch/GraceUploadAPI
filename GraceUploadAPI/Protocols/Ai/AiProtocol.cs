using GraceUploadAPI.Configuration;
using Modbus.Device;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraceUploadAPI.Protocols.Ai
{
    public class AiProtocol : AiData
    {
        public override void ReadData(List<Device> devices, ModbusMaster master)
        {
            int DeviceIndex = 0;
            int Index = 0;
            #region 第一部分
            try
            {
                ushort[] Part1Value1 = master.ReadInputRegisters(devices[DeviceIndex].ID, 0, 80);
                ushort[] Part1Value2 = master.ReadHoldingRegisters(devices[DeviceIndex].ID, 120, 30);
                AI64Module.ttime = DateTime.Now.ToString("yyyyMMddHHmmss");
                AI64Module.CaseNo = CaseNo;
                AI64Module.Ai1 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai2 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai3 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai4 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai5 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai6 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                _ = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai7 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                _ = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                _ = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai8 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai9 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai10 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai11 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai12 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai13 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai14 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai15 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai16 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai17 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai18 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai19 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai20 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai21 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai22 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                _ = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai23 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                _ = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai24 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                _ = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai25 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai26 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                _ = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai27 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai28 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai29 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai30 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai31 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai32 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index])); Index += 2;
                AI64Module.Ai33 = Convert.ToDecimal(MathClass.work16to754(Part1Value1[Index + 1], Part1Value1[Index]));
                Index = 0;
                AI64Module.Ai34 = Convert.ToDecimal(MathClass.work16to754(Part1Value2[Index + 1], Part1Value2[Index])); Index += 2;
                AI64Module.Ai35 = Convert.ToDecimal(MathClass.work16to754(Part1Value2[Index + 1], Part1Value2[Index])); Index += 2;
                AI64Module.Ai36 = Convert.ToDecimal(MathClass.work16to754(Part1Value2[Index + 1], Part1Value2[Index])); Index += 2;
                AI64Module.Ai37 = Convert.ToDecimal(MathClass.work16to754(Part1Value2[Index + 1], Part1Value2[Index])); Index += 2;
                AI64Module.Ai38 = Convert.ToDecimal(MathClass.work16to754(Part1Value2[Index + 1], Part1Value2[Index])); Index += 2;
                AI64Module.Ai39 = Convert.ToDecimal(MathClass.work16to754(Part1Value2[Index + 1], Part1Value2[Index])); Index += 2;
                AI64Module.Ai40 = Convert.ToDecimal(MathClass.work16to754(Part1Value2[Index + 1], Part1Value2[Index])); Index += 2;
                AI64Module.Ai41 = Convert.ToDecimal(MathClass.work16to754(Part1Value2[Index + 1], Part1Value2[Index])); Index += 2;
                AI64Module.Ai42 = Convert.ToDecimal(MathClass.work16to754(Part1Value2[Index + 1], Part1Value2[Index])); Index += 2;
                AI64Module.Ai43 = Convert.ToDecimal(MathClass.work16to754(Part1Value2[Index + 1], Part1Value2[Index])); Index += 2;
                AI64Module.Ai44 = Convert.ToDecimal(MathClass.work16to754(Part1Value2[Index + 1], Part1Value2[Index])); Index += 2;
                AI64Module.Ai45 = Convert.ToDecimal(MathClass.work16to754(Part1Value2[Index + 1], Part1Value2[Index])); Index += 2;
                AI64Module.Ai46 = Convert.ToDecimal(MathClass.work16to754(Part1Value2[Index + 1], Part1Value2[Index])); Index += 2;
                AI64Module.Ai47 = Convert.ToDecimal(MathClass.work16to754(Part1Value2[Index + 1], Part1Value2[Index])); Index += 2;
                AI64Module.Ai48 = Convert.ToDecimal(MathClass.work16to754(Part1Value2[Index + 1], Part1Value2[Index]));
                DeviceIndex++;
            }
            catch (Exception ex)
            {
                ConnectionFlag = false;
                Log.Error(ex,$"AI數值第一部分讀取錯誤 ID: {devices[DeviceIndex].ID}");
            }
            #endregion
            #region 第二部分
            try
            {
                Index = 0;
                ushort[] Part2Value1 = master.ReadInputRegisters(devices[DeviceIndex].ID, 0, 34);
                AI64Module.Ai49 = Convert.ToDecimal(MathClass.work16to754(Part2Value1[Index + 1], Part2Value1[Index])); Index += 2;
                AI64Module.Ai50 = Convert.ToDecimal(MathClass.work16to754(Part2Value1[Index + 1], Part2Value1[Index])); Index += 2;
                AI64Module.Ai51 = Convert.ToDecimal(MathClass.work16to754(Part2Value1[Index + 1], Part2Value1[Index])); Index += 2;
                _ = Convert.ToDecimal(MathClass.work16to754(Part2Value1[Index + 1], Part2Value1[Index])); Index += 2;
                AI64Module.Ai52 = Convert.ToDecimal(MathClass.work16to754(Part2Value1[Index + 1], Part2Value1[Index])); Index += 2;
                AI64Module.Ai53 = Convert.ToDecimal(MathClass.work16to754(Part2Value1[Index + 1], Part2Value1[Index])); Index += 2;
                AI64Module.Ai54 = Convert.ToDecimal(MathClass.work16to754(Part2Value1[Index + 1], Part2Value1[Index])); Index += 2;
                _ = Convert.ToDecimal(MathClass.work16to754(Part2Value1[Index + 1], Part2Value1[Index])); Index += 2;
                _ = Convert.ToDecimal(MathClass.work16to754(Part2Value1[Index + 1], Part2Value1[Index])); Index += 2;
                _ = Convert.ToDecimal(MathClass.work16to754(Part2Value1[Index + 1], Part2Value1[Index])); Index += 2;
                _ = Convert.ToDecimal(MathClass.work16to754(Part2Value1[Index + 1], Part2Value1[Index])); Index += 2;
                _ = Convert.ToDecimal(MathClass.work16to754(Part2Value1[Index + 1], Part2Value1[Index])); Index += 2;
                _ = Convert.ToDecimal(MathClass.work16to754(Part2Value1[Index + 1], Part2Value1[Index])); Index += 2;
                AI64Module.Ai55 = Convert.ToDecimal(MathClass.work16to754(Part2Value1[Index + 1], Part2Value1[Index])); Index += 2;
                AI64Module.Ai56 = Convert.ToDecimal(MathClass.work16to754(Part2Value1[Index + 1], Part2Value1[Index])); Index += 2;
                AI64Module.Ai57 = Convert.ToDecimal(MathClass.work16to754(Part2Value1[Index + 1], Part2Value1[Index])); Index += 2;
                AI64Module.Ai58 = Convert.ToDecimal(MathClass.work16to754(Part2Value1[Index + 1], Part2Value1[Index]));
                ConnectionFlag = true;
            }
            catch (Exception ex) 
            {
                ConnectionFlag = false;
                Log.Error(ex, $"AI數值第二部分讀取錯誤 ID: {devices[DeviceIndex].ID}");
            }
            #endregion
        }
    }
}
