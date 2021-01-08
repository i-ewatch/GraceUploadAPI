using GraceUploadAPI.APIModules;
using GraceUploadAPI.Configuration;
using Modbus.Device;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraceUploadAPI.Protocols.State
{
    public class StateProtocol : StateData
    {
        public override void ReadData(List<Device> devices, ModbusMaster master)
        {
            int DeviceIndex = 0;
            int stateNo = 0;
            if (States.Count == 0)
            {
                #region 第一部分
                try
                {
                    bool[] Part1value1 = master.ReadInputs(devices[DeviceIndex].ID, 105, 1);
                    State state1 = new State() { StateData = this, StateNo = stateNo}; stateNo++;
                    States.Add(state1);
                    bool[] Part1value2 = master.ReadInputs(devices[DeviceIndex].ID, 113, 1);
                    State state2 = new State() { StateNo = stateNo, StateData = this }; stateNo++;
                    States.Add(state2);
                    bool[] Part1value3 = master.ReadInputs(devices[DeviceIndex].ID, 121, 1);
                    State state3 = new State() { StateNo = stateNo, StateData = this }; stateNo++;
                    States.Add(state3);
                    bool[] Part1value4 = master.ReadInputs(devices[DeviceIndex].ID, 129, 1);
                    State state4 = new State() { StateNo = stateNo,  StateData = this }; stateNo++;
                    States.Add(state4);
                    bool[] Part1value5 = master.ReadInputs(devices[DeviceIndex].ID, 137, 1);
                    State state5 = new State() { StateNo = stateNo,  StateData = this }; stateNo++;
                    States.Add(state5);
                    bool[] Part1value6 = master.ReadInputs(devices[DeviceIndex].ID, 257, 1);
                    State state6 = new State() { StateNo = stateNo,  StateData = this }; stateNo++;
                    States.Add(state6);
                    bool[] Part1value7 = master.ReadInputs(devices[DeviceIndex].ID, 273, 1);
                    State state7 = new State() { StateNo = stateNo, StateData = this }; stateNo++;
                    States.Add(state7);
                    bool[] Part1value8 = master.ReadInputs(devices[DeviceIndex].ID, 305, 1);
                    State state8 = new State() { StateNo = stateNo,  StateData = this }; stateNo++;
                    States.Add(state8);
                    bool[] Part1value9 = master.ReadInputs(devices[DeviceIndex].ID, 353, 1);
                    State state9 = new State() { StateNo = stateNo, StateData = this }; stateNo++;
                    States.Add(state9);
                    bool[] Part1value10 = master.ReadInputs(devices[DeviceIndex].ID, 369, 1);
                    State state10 = new State() { StateNo = stateNo,  StateData = this }; stateNo++;
                    States.Add(state10);
                    bool[] Part1value11 = master.ReadInputs(devices[DeviceIndex].ID, 401, 1);
                    State state11 = new State() { StateNo = stateNo,  StateData = this }; stateNo++;
                    States.Add(state11);
                    state1.state = Part1value1[0];
                    state2.state = Part1value2[0];
                    state3.state = Part1value3[0];
                    state4.state = Part1value4[0];
                    state5.state = Part1value5[0];
                    state6.state = Part1value6[0];
                    state7.state = Part1value7[0];
                    state8.state = Part1value8[0];
                    state9.state = Part1value9[0];
                    state10.state = Part1value10[0];
                    state11.state = Part1value11[0];
                    state1.FirstFlag = true;
                    state2.FirstFlag = true;
                    state3.FirstFlag = true;
                    state4.FirstFlag = true;
                    state5.FirstFlag = true;
                    state6.FirstFlag = true;
                    state7.FirstFlag = true;
                    state8.FirstFlag = true;
                    state9.FirstFlag = true;
                    state10.FirstFlag = true;
                    state11.FirstFlag = true;
                    DeviceIndex++;
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"狀態數值第一部分讀取錯誤 ID: {devices[DeviceIndex].ID}");
                }
                #endregion

                #region 第二部分
                try
                {
                    bool[] Part2value1 = master.ReadInputs(devices[DeviceIndex].ID, 121, 1);
                    State state12 = new State() { StateNo = stateNo,  StateData = this }; stateNo++;
                    States.Add(state12);
                    bool[] Part2value2 = master.ReadInputs(devices[DeviceIndex].ID, 129, 1);
                    State state13 = new State() { StateNo = stateNo,  StateData = this }; stateNo++;
                    States.Add(state13);
                    bool[] Part2value3 = master.ReadInputs(devices[DeviceIndex].ID, 137, 1);
                    State state14 = new State() { StateNo = stateNo,  StateData = this }; stateNo++;
                    States.Add(state14);
                    bool[] Part2value4 = master.ReadInputs(devices[DeviceIndex].ID, 145, 1);
                    State state15 = new State() { StateNo = stateNo,  StateData = this }; stateNo++;
                    States.Add(state15);
                    bool[] Part2value5 = master.ReadInputs(devices[DeviceIndex].ID, 153, 1);
                    State state16 = new State() { StateNo = stateNo,  StateData = this }; stateNo++;
                    States.Add(state16);
                    bool[] Part2value6 = master.ReadInputs(devices[DeviceIndex].ID, 161, 1);
                    State state17 = new State() { StateNo = stateNo,  StateData = this }; stateNo++;
                    States.Add(state17);
                    bool[] Part2value7 = master.ReadInputs(devices[DeviceIndex].ID, 169, 1);
                    State state18 = new State() { StateNo = stateNo, StateData = this }; stateNo++;
                    States.Add(state18);
                    bool[] Part2value8 = master.ReadInputs(devices[DeviceIndex].ID, 209, 1);
                    State state19 = new State() { StateNo = stateNo,  StateData = this }; stateNo++;
                    States.Add(state19);
                    bool[] Part2value9 = master.ReadInputs(devices[DeviceIndex].ID, 233, 1);
                    State state20 = new State() { StateNo = stateNo,  StateData = this }; stateNo++;
                    States.Add(state20);
                    bool[] Part2value10 = master.ReadInputs(devices[DeviceIndex].ID, 241, 1);
                    State state21 = new State() { StateNo = stateNo,  StateData = this }; stateNo++;
                    States.Add(state21);
                    bool[] Part2value11 = master.ReadInputs(devices[DeviceIndex].ID, 265, 1);
                    State state22 = new State() { StateNo = stateNo, StateData = this }; stateNo++;
                    States.Add(state22);
                    bool[] Part2value12 = master.ReadInputs(devices[DeviceIndex].ID, 273, 1);
                    State state23 = new State() { StateNo = stateNo, StateData = this }; stateNo++;
                    States.Add(state23);
                    bool[] Part2value13 = master.ReadInputs(devices[DeviceIndex].ID, 305, 1);
                    State state24 = new State() { StateNo = stateNo,  StateData = this };
                    States.Add(state24);
                    state12.state = Part2value1[0];
                    state13.state = Part2value2[0];
                    state14.state = Part2value3[0];
                    state15.state = Part2value4[0];
                    state16.state = Part2value5[0];
                    state17.state = Part2value6[0];
                    state18.state = Part2value7[0];
                    state19.state = Part2value8[0];
                    state20.state = Part2value9[0];
                    state21.state = Part2value10[0];
                    state22.state = Part2value11[0];
                    state23.state = Part2value12[0];
                    state24.state = Part2value13[0];
                    state12.FirstFlag = true;
                    state13.FirstFlag = true;
                    state14.FirstFlag = true;
                    state15.FirstFlag = true;
                    state16.FirstFlag = true;
                    state17.FirstFlag = true;
                    state18.FirstFlag = true;
                    state19.FirstFlag = true;
                    state20.FirstFlag = true;
                    state21.FirstFlag = true;
                    state22.FirstFlag = true;
                    state23.FirstFlag = true;
                    state24.FirstFlag = true;
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"狀態數值第二部分讀取錯誤 ID: {devices[DeviceIndex].ID}");
                }
                #endregion
            }
            else
            {
                #region 第一部分
                try
                {
                    bool[] Part1value1 = master.ReadInputs(devices[DeviceIndex].ID, 105, 1);
                    States[stateNo].state = Part1value1[0]; stateNo++;
                    bool[] Part1value2 = master.ReadInputs(devices[DeviceIndex].ID, 113, 1);
                    States[stateNo].state = Part1value2[0]; stateNo++;
                    bool[] Part1value3 = master.ReadInputs(devices[DeviceIndex].ID, 121, 1);
                    States[stateNo].state = Part1value3[0]; stateNo++;
                    bool[] Part1value4 = master.ReadInputs(devices[DeviceIndex].ID, 129, 1);
                    States[stateNo].state = Part1value4[0]; stateNo++;
                    bool[] Part1value5 = master.ReadInputs(devices[DeviceIndex].ID, 137, 1);
                    States[stateNo].state = Part1value5[0]; stateNo++;
                    bool[] Part1value6 = master.ReadInputs(devices[DeviceIndex].ID, 257, 1);
                    States[stateNo].state = Part1value6[0]; stateNo++;
                    bool[] Part1value7 = master.ReadInputs(devices[DeviceIndex].ID, 273, 1);
                    States[stateNo].state = Part1value7[0]; stateNo++;
                    bool[] Part1value8 = master.ReadInputs(devices[DeviceIndex].ID, 305, 1);
                    States[stateNo].state = Part1value8[0]; stateNo++;
                    bool[] Part1value9 = master.ReadInputs(devices[DeviceIndex].ID, 353, 1);
                    States[stateNo].state = Part1value9[0]; stateNo++;
                    bool[] Part1value10 = master.ReadInputs(devices[DeviceIndex].ID, 369, 1);
                    States[stateNo].state = Part1value10[0]; stateNo++;
                    bool[] Part1value11 = master.ReadInputs(devices[DeviceIndex].ID, 401, 1);
                    States[stateNo].state = Part1value11[0]; stateNo++;
                    DeviceIndex++;
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"狀態數值第一部分讀取錯誤 ID: {devices[DeviceIndex].ID}");
                }
                #endregion

                #region 第二部分
                try
                {
                    bool[] Part2value1 = master.ReadInputs(devices[DeviceIndex].ID, 121, 1);
                    States[stateNo].state = Part2value1[0]; stateNo++;
                    bool[] Part2value2 = master.ReadInputs(devices[DeviceIndex].ID, 129, 1);
                    States[stateNo].state = Part2value2[0]; stateNo++;
                    bool[] Part2value3 = master.ReadInputs(devices[DeviceIndex].ID, 137, 1);
                    States[stateNo].state = Part2value3[0]; stateNo++;
                    bool[] Part2value4 = master.ReadInputs(devices[DeviceIndex].ID, 145, 1);
                    States[stateNo].state = Part2value4[0]; stateNo++;
                    bool[] Part2value5 = master.ReadInputs(devices[DeviceIndex].ID, 153, 1);
                    States[stateNo].state = Part2value5[0]; stateNo++;
                    bool[] Part2value6 = master.ReadInputs(devices[DeviceIndex].ID, 161, 1);
                    States[stateNo].state = Part2value6[0]; stateNo++;
                    bool[] Part2value7 = master.ReadInputs(devices[DeviceIndex].ID, 169, 1);
                    States[stateNo].state = Part2value7[0]; stateNo++;
                    bool[] Part2value8 = master.ReadInputs(devices[DeviceIndex].ID, 209, 1);
                    States[stateNo].state = Part2value8[0]; stateNo++;
                    bool[] Part2value9 = master.ReadInputs(devices[DeviceIndex].ID, 233, 1);
                    States[stateNo].state = Part2value9[0]; stateNo++;
                    bool[] Part2value10 = master.ReadInputs(devices[DeviceIndex].ID, 241, 1);
                    States[stateNo].state = Part2value10[0]; stateNo++;
                    bool[] Part2value11 = master.ReadInputs(devices[DeviceIndex].ID, 265, 1);
                    States[stateNo].state = Part2value11[0]; stateNo++;
                    bool[] Part2value12 = master.ReadInputs(devices[DeviceIndex].ID, 273, 1);
                    States[stateNo].state = Part2value12[0]; stateNo++;
                    bool[] Part2value13 = master.ReadInputs(devices[DeviceIndex].ID, 305, 1);
                    States[stateNo].state = Part2value13[0];
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"狀態數值第二部分讀取錯誤 ID: {devices[DeviceIndex].ID}");
                }
                #endregion
            }
        }
    }
}
