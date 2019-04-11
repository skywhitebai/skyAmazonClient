using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace skyAmazonClient.SynTasks
{
    class InventorySynTask
    {
        public static Thread getThreadTask()
        {
            Thread thread = new Thread(new ThreadStart(
               synInventory));
            thread.IsBackground = true;
            return thread;
        }
        private static void synInventory()
        {
            while (true)
            {
                AppConstant.SynTaskInfo.InventoryTask.dealInfoAppend("同步开始");
                AppConstant.SynTaskInfo.InventoryTask.ExecuteTimes += 1;
                AppConstant.SynTaskInfo.InventoryTask.LastExecuteTime = DateTime.Now; 
                Thread.Sleep(TimeSpan.FromSeconds(1));
                AppConstant.SynTaskInfo.InventoryTask.dealInfoAppend("同步结束");
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }
}
