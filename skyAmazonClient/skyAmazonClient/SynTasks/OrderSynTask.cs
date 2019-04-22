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
    class OrderSynTask
    {
        public static Thread getThreadTask()
        {
            Thread thread = new Thread(synOrder);
            thread.IsBackground = true;
            return thread;
        }
        private static void synOrder()
        {
            while (true)
            {
                AppConstant.SynTaskInfo.OrderTask.dealInfoAppend("同步开始");
                AppConstant.SynTaskInfo.OrderTask.ExecuteTimes += 1;
                AppConstant.SynTaskInfo.OrderTask.LastExecuteTime = DateTime.Now;
                doSynOrder();
                AppConstant.SynTaskInfo.OrderTask.dealInfoAppend("同步结束等待" + AppConstant.synOrderSleepTimeMinute + "分钟");
                Thread.Sleep(TimeSpan.FromMinutes(AppConstant.synOrderSleepTimeMinute));
            }
        }
        static void doSynOrder()
        {
            try
            {
                //获取订单信息
                new OrderService().synOrder(AppConstant.currentUserShop);
            }
            catch (Exception ex)
            {
                AppConstant.SynTaskInfo.OrderTask.dealInfoAppend("异常:" + ex.Message);
            }
        }
    }
}
