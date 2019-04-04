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
        public static DateTime? lastUpdatedAfter=new DateTime(1995,1,1);
        public static string amazonAccessKey = SysConfigService.getConfigByKey("amazonAccessKey");
        public static string amazonSecretKey = SysConfigService.getConfigByKey("amazonSecretKey");
        public static string sellerId;
        public static string mwsAuthToken;
        public static string saveOrderUrl=ddtUrl + "/order/saveOrder";
        public static string updateOrderLastUpdatedAfterUrl = ddtUrl + "/shop/updateOrderLastUpdatedAfter";
        static AppConstant()
        {
            //clientLoginUrl = ddtUrl + "/account/clientLogin";
        }


        public static long sleepTime = 60 * 1000;
        public static double orderSleepTimeMinute = 3;
        public static double orderItemSleepTimeSecond = 30;
        public static double synOrderSleepTimeMinute=30;
        public static List<string> dealInfo=new List<string>();
        public static Thread threadSynOrder;
        public static Thread threadShowDealInfo;


        internal static void dealInfoAppend(string dealInfoAppend)
        {
           if(dealInfo.Count>20){
               dealInfo.RemoveAt(0);
           }            
            dealInfo.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":"+dealInfoAppend);
            Console.WriteLine(dealInfoAppend);
        }
    }
}
