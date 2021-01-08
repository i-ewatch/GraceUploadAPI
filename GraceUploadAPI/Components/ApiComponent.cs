using GraceUploadAPI.Methods;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GraceUploadAPI.Components
{
    public partial class ApiComponent : Field4Component
    {
        public ApiComponent()
        {
            InitializeComponent();
        }

        public ApiComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        /// <summary>
        /// 上傳方法
        /// </summary>
        private APIMethod APIMethod = new APIMethod();
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        private string ErrorStr { get; set; }
        /// <summary>
        /// 初始旗標
        /// </summary>
        private bool FirstFlag { get; set; } = false;
        public DateTime AITime { get; set; }
        protected override void AfterMyWorkStateChanged(object sender, EventArgs e)
        {
            if (myWorkState)
            {
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
                        TimeSpan AItimespan = DateTime.Now.Subtract(AITime);
                        if (AI64Module != null && AItimespan.TotalSeconds >=60)
                        {
                            ErrorStr = "AI上傳發生錯誤";
                            APIMethod.Send_AI(AI64Module);
                            AITime = DateTime.Now;
                        }
                        if (StateModules.Count > 0)
                        {
                            ErrorStr = "狀態上傳發生錯誤";
                            if (FirstFlag)
                            {
                                APIMethod.Send_State_Multiple(StateModules);
                            }
                            else
                            {
                                APIMethod.Send_State_Web_Multiple(StateModules);
                                FirstFlag = true;
                            }
                            StateModules.Clear();
                        }
                        ReadTime = DateTime.Now;
                    }
                    catch (ThreadAbortException) { }
                    catch (Exception ex)
                    {
                        ReadTime = DateTime.Now;
                        Log.Error(ex, $"API上傳失敗 原因: {ErrorStr}");
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
