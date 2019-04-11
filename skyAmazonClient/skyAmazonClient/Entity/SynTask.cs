using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace skyAmazonClient.Entity
{
    /// <summary>
    /// 数据同步任务
    /// </summary>
    class SynTask
    {
        public static string statusEnable="启用";
        public static string statusDisable="停用";
        /// <summary>
        /// 任务名称
        /// </summary>
        String taskName;

        public String TaskName
        {
            get { return taskName; }
            set { taskName = value; }
        }
        /// <summary>
        /// 最后执行时间
        /// </summary>
        DateTime? lastExecuteTime;

        public DateTime? LastExecuteTime
        {
            get { return lastExecuteTime; }
            set { lastExecuteTime = value; }
        }
        /// <summary>
        /// 执行次数
        /// </summary>
        long executeTimes;

        public long ExecuteTimes
        {
            get { return executeTimes; }
            set { executeTimes = value; }
        }
        long synDataNumber;
        /// <summary>
        /// 同步数据数量
        /// </summary>
        public long SynDataNumber
        {
            get { return synDataNumber; }
            set { synDataNumber = value; }
        }
        Thread executeThread;

        public Thread ExecuteThread
        {
            get { return executeThread; }
            set { executeThread = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        String status;

        public String Status
        {
            get { return status; }
            set { status = value; }
        }
        private List<String> dealInfoList=new List<string>();

        public List<String> DealInfoList
        {
            get { return dealInfoList; }
            set { dealInfoList = value; }
        }
        internal void dealInfoAppend(string dealInfoAppend)
        {
            if (dealInfoList.Count > 20)
            {
                dealInfoList.RemoveAt(0);
            }
            String info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + dealInfoAppend;
            dealInfoList.Add(info);
            Console.WriteLine(info);
        }
    }
}
