using GraceUploadAPI.APIModules;
using GraceUploadAPI.Configuration;
using GraceUploadAPI.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraceUploadAPI.Components
{
    public class Field4Component : Component
    {
        #region 啟動初始設定
        public Field4Component()
        {
            OnMyWorkStateChanged += new MyWorkStateChanged(AfterMyWorkStateChanged);
        }
        protected void WhenMyWorkStateChange()
        {
            OnMyWorkStateChanged?.Invoke(this, null);
        }
        public delegate void MyWorkStateChanged(object sender, EventArgs e);
        public event MyWorkStateChanged OnMyWorkStateChanged;
        /// <summary>
        /// 系統工作路徑
        /// </summary>
        protected readonly string WorkPath = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// 通訊功能啟動判斷旗標
        /// </summary>
        protected bool myWorkState;
        /// <summary>
        /// 通訊功能啟動旗標
        /// </summary>
        public bool MyWorkState
        {
            get { return myWorkState; }
            set
            {
                if (value != myWorkState)
                {
                    myWorkState = value;
                    WhenMyWorkStateChange();
                }
            }
        }
        /// <summary>
        /// 執行續工作狀態改變觸發事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void AfterMyWorkStateChanged(object sender, EventArgs e) { }
        #endregion

        /// <summary>
        /// 總通訊JSON物件
        /// </summary>
        public GatewaySetting GateWaySetting { get; set; }
        /// <summary>
        /// 上傳數值
        /// </summary>
        public AI64Module AI64Module { get; set; }
        /// <summary>
        /// 狀態上傳資訊
        /// </summary>
        public List<StateModule> StateModules { get; set; } = new List<StateModule>();
        /// <summary>
        /// 最後讀取時間
        /// </summary>
        public DateTime ReadTime { get; set; }
        /// <summary>
        /// 通訊執行緒
        /// </summary>
        public Thread ReadThread { get; set; }
        /// <summary>
        /// 通訊數值
        /// </summary>
        public List<AbsProtocol> AbsProtocols { get; set; } = new List<AbsProtocol>();
    }
}
