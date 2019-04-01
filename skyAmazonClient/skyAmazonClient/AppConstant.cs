using skyAmazonClient.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyAmazonClient
{
    class AppConstant
    {
        static string ddtUrl = ConfigUtils.GetAppConfig("ddtUrl");
        public static string clientLoginUrl = ddtUrl + "/account/clientLogin";
        public static string getConfigByKeyUrl = ddtUrl + "/config/getConfigByKeyUrl";
        public static string getCurrentUserShopUrl = ddtUrl + "/shop/getCurrentUserShop";
        public static string loginToken;
    }
}
