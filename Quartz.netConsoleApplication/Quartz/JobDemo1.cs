using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartz.netConsoleApplication
{
    class JobDemo1 : IJob
    {
        /// <summary>
        /// 这里是作业调度每次定时执行方法
        /// </summary>
        /// <param name="context"></param>
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("第二个job执行: " + DateTime.Now.ToLocalTime().ToString());
        }
    }
}
