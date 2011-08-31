using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Voodoo.Business
{
    public class SysInfo
    {
        /// <summary>
        /// 系统是否开放
        /// </summary>
        public bool SystemOpen { get; set; }

        /// <summary>
        /// 站点名称
        /// </summary>
        public string SysTitle { get; set; }

        /// <summary>
        /// 版权信息
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// 宣传提成百分比
        /// </summary>
        public int SalerSalaryPercent { get; set; }

        /// <summary>
        /// 保洁员提成
        /// </summary>
        public int WorkerSalaryPercent { get; set; }
    }
}
