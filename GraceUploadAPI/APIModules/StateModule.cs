using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraceUploadAPI.APIModules
{
    public class StateModule
    {
        private string _ttime = DateTime.Now.ToString("yyyyMMddHHmmssFF");
        /// <summary>
        /// 時間
        /// </summary>
        public string ttime
        {
            get { return _ttime; }
            set
            {
                if (value.Length > 16)
                    _ttime = value.Substring(0, 16);
                else
                    _ttime = value;
            }
        }
        /// <summary>
        /// 案場編號
        /// </summary>
        public string CaseNo { get; set; }
        /// <summary>
        /// 狀態編號
        /// </summary>
        public int StateNo { get; set; }
        /// <summary>
        /// 狀態
        /// </summary>
        public bool state { get; set; }
    }
}
