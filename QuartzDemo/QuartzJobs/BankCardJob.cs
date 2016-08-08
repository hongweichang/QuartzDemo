using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzDemo.QuartzJobs
{
    public sealed class BankCardJob : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(BankCardJob));

        public void Execute(IJobExecutionContext context)
        {
            _logger.InfoFormat("代扣成功执行");
        }
    }
}
