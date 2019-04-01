﻿using skyAmazonClient.Service;
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
        public static string getConfigByKeyUrl = ddtUrl + "/config/getConfigByKey";
        public static string getCurrentUserShopUrl = ddtUrl + "/shop/getCurrentUserShop";
        public static string loginToken;
        public static DateTime? lastUpdatedAfter=new DateTime(1995,1,1);
        public static string amazonAccessKey = SysConfigService.getConfigByKey("amazonAccessKey");
        public static string amazonSecretKey = SysConfigService.getConfigByKey("amazonSecretKey");
        public static string sellerId;
        public static string mwsAuthToken;
        static AppConstant()
        {
            clientLoginUrl = ddtUrl + "/account/clientLogin";
        }
    }
}