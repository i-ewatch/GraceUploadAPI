using GraceUploadAPI.APIModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraceUploadAPI.Protocols.State
{
    public abstract class StateData : AbsProtocol
    {

        /// <summary>
        /// 狀態上傳資訊
        /// </summary>
        public List<StateModule> StateModules { get; set; } = new List<StateModule>();
        /// <summary>
        /// 狀態資訊
        /// </summary>
        public List<State> States { get; set; } = new List<State>();
    }
    public class State
    {
        public StateData StateData { get; set; }
        /// <summary>
        /// 軟體初始化旗標
        /// </summary>
        public bool FirstFlag { get; set; }
        public int StateNo { get; set; }
        public bool _state { get; set; } = false;
        public bool state
        {
            get { return _state; }
            set
            {
                if (value != _state || !FirstFlag)
                {
                    _state = value;
                    StateModule stateModule = new StateModule()
                    {
                        state = value,
                        StateNo = StateNo,
                        CaseNo = StateData.CaseNo,
                    };
                    StateData.StateModules.Add(stateModule);
                }
            }
        }
    }
}
