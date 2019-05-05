using FBAInventoryServiceMWS.Model;
using skyAmazonClient.Entity;
using skyAmazonClient.Service;
using skyAmazonClient.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace skyAmazonClient
{
    class AppConstant
    {
        static string ddtUrl = ConfigUtils.GetAppConfig("ddtUrl");
        public static string clientLoginUrl = ddtUrl + "/account/clientLogin";
        public static string getConfigByKeyUrl = ddtUrl + "/config/getConfigByKey";
        public static string getCurrentUserShopUrl = ddtUrl + "/shop/getCurrentUserShop";

        public static string loginToken;
        public static DateTime? lastUpdatedAfter = new DateTime(1995, 1, 1);
        public static DateTime? inventoryQueryStartDateTime = new DateTime(1995, 1, 1);
        public static string amazonAccessKey = SysConfigService.getConfigByKey("amazonAccessKey");
        public static string amazonSecretKey = SysConfigService.getConfigByKey("amazonSecretKey");
        public static string sellerId;
        public static string mwsAuthToken;
        public static string saveOrderUrl = ddtUrl + "/order/saveOrder";
        public static string updateOrderLastUpdatedAfterUrl = ddtUrl + "/shop/updateOrderLastUpdatedAfter";
        public static string updateInventoryQueryStartDateTimeUrl = ddtUrl + "/shop/updateInventoryQueryStartDateTime";
        public static string saveInventoryUrl = ddtUrl + "/inventory/saveInventory";


        public static long sleepTime = 60 * 1000;
        public static double orderSleepTimeMinute = 3;
        public static double orderItemSleepTimeSecond = 30;
        public static double synOrderSleepTimeMinute = 30;
        public static List<string> dealInfo = new List<string>();
        public static Thread threadSynOrder;
        public static Thread threadShowDealInfo;
        public static Shop currentUserShop;
        public static CurrentUserInfo currentUserInfo;
        public static Thread threadBindLvTask;
        public const String synOrderTaskName = "订单同步";
        public const String synInventoryTaskName = "库存同步";
        public static double synInventoryTimeHour = 12;

        internal static void dealInfoAppend(string dealInfoAppend)
        {
            if (dealInfo.Count > 20)
            {
                dealInfo.RemoveAt(0);
            }
            String info = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + dealInfoAppend;
            dealInfo.Add(info);
            Console.WriteLine(info);
        }
        public class SynTaskInfo
        {
            /// <summary>
            /// 订单同步任务
            /// </summary>
            private static SynTask orderTask;

            public static SynTask OrderTask
            {
                get { return SynTaskInfo.orderTask; }
                set
                {
                    if (SynTaskInfo.orderTask != null && SynTaskInfo.orderTask.ExecuteThread != null)
                    {
                        SynTaskInfo.orderTask.ExecuteThread.Abort();
                    }
                    SynTaskInfo.orderTask = value;
                }
            }
            /// <summary>
            /// 库存同步任务
            /// </summary>
            private static SynTask inventoryTask;

            public static SynTask InventoryTask
            {
                get { return SynTaskInfo.inventoryTask; }
                set
                {
                    if (SynTaskInfo.inventoryTask != null && SynTaskInfo.inventoryTask.ExecuteThread != null)
                    {
                        SynTaskInfo.inventoryTask.ExecuteThread.Abort();
                    }
                    SynTaskInfo.inventoryTask = value;
                }
            }
        }

        internal static double getSleepTimeMinute()
        {
            Random ran = new Random();
            int num = ran.Next(1, 10);
            return (Double)num;
        }

        internal static double getRequestIsThrottledSleepTimeMinute()
        {
            Random ran = new Random();
            int num = ran.Next(5, 10);
            return (Double)num;
        }

        internal static double getInventorySynIntervalMinute()
        {
            Random ran = new Random();
            int max = 600;
            int min = 30;
            if (currentUserShop != null && currentUserShop.InventorySynIntervalMinute != null && currentUserShop.InventorySynIntervalMinute > min)
            {
                max = currentUserShop.InventorySynIntervalMinute.Value;
            }
            int num = ran.Next(min, max);
            return (Double)num;
        }

        internal static double getOrderSynIntervalMinute()
        {
            Random ran = new Random();
            int max = 60;
            int min = 20;
            if (currentUserShop != null && currentUserShop.OrderSynIntervalMinute != null && currentUserShop.OrderSynIntervalMinute > min)
            {
                max = currentUserShop.OrderSynIntervalMinute.Value;
            }
            int num = ran.Next(min, max);
            return (Double)num;
        }

        internal static decimal getOrderSynQuantity()
        {
            Random ran = new Random();
            int max = 50;
            int min = 20;
            if (currentUserShop != null && currentUserShop.OrderSynQuantity != null && currentUserShop.OrderSynQuantity > min)
            {
                max = currentUserShop.OrderSynQuantity.Value;
            }
            int num = ran.Next(min, max);
            return num;
        }
    }
}
