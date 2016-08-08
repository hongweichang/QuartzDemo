using Quartz.Impl;
using Quartz.Simpl;
using Quartz.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartz.netConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            XMLSchedulingDataProcessor processor = new XMLSchedulingDataProcessor(new SimpleTypeLoadHelper());

 
            //1.首先创建一个作业调度池
            ISchedulerFactory schedf = new StdSchedulerFactory();
            IScheduler sched = schedf.GetScheduler();

            

            //2.创建出来一个具体的作业
           // IJobDetail job = JobBuilder.Create<JobDemo>().Build();


            //3.创建并配置一个触发器
           // ISimpleTrigger trigger = WithIntervalInSeconds();
          

            //4.加入作业调度池中
            // sched.ScheduleJob(job, trigger);



            #region 读取xml文件,去掉,2,3,4

            processor.ProcessFileAndScheduleJobs(AppDomain.CurrentDomain.BaseDirectory+"quartz_jobs.xml", sched);


            //Stream s = new StreamReader(AppDomain.CurrentDomain.BaseDirectory+"quartz_jobs.xml").BaseStream;
            //processor.ProcessStream(s, null);
            //processor.ScheduleJobs(sched);

            #endregion 

            //5.开始运行
            sched.Start();
            Console.ReadKey();


        }

        //多少秒执行一次
        public  static ISimpleTrigger WithIntervalInSeconds()
        {
            ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create()
          .WithSimpleSchedule(x => x.WithIntervalInSeconds(1)   //WithIntervalInSeconds  每多少秒执行一次
              .RepeatForever()).Build();


            return trigger;
        }


        //我想让他每三秒执行一次，一共执行100次，开始执行时间设定在当前时间，结束时间我设定在2小时后，不过100次执行完没2小时候都不再执行
        public static ISimpleTrigger EndTaskWhenHours()
        {
            //NextGivenSecondDate：如果第一个参数为null则表名当前时间往后推迟2秒的时间点。

            DateTimeOffset startTime = DateBuilder.NextGivenSecondDate(DateTime.Now.AddSeconds(1), 2);
            DateTimeOffset endTime = DateBuilder.NextGivenSecondDate(DateTime.Now.AddHours(2), 3);
            //创建并配置一个触发器
            ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create().StartAt(startTime).EndAt(endTime)
                                        .WithSimpleSchedule(x => x.WithIntervalInSeconds(3).WithRepeatCount(100))
                                        .Build();

            return trigger;
        
        }







    }
}
