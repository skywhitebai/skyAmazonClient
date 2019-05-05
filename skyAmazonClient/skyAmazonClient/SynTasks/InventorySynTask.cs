using skyAmazonClient.Service;
using skyCommon;
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
                doSyn();
                Double synInventoryTimeMinutes = AppConstant.getInventorySynIntervalMinute();
                AppConstant.SynTaskInfo.InventoryTask.dealInfoAppend("同步结束等待" + synInventoryTimeMinutes + "分钟");
                Thread.Sleep(TimeSpan.FromHours(synInventoryTimeMinutes));
            }
        }
        static void doSyn()
        {
            try
            {
                //获取订单信息
                new InventoryService().syn(AppConstant.currentUserShop);
            }
            catch (Exception ex)
            {
                AppConstant.SynTaskInfo.InventoryTask.dealInfoAppend("异常:" + ex.Message);
            }
        }
    }
}
