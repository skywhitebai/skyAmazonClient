using skyAmazonClient.Entity;
using skyAmazonClient.util;
using skyCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyAmazonClient.Service
{
    class AccountService
    {
        static String clientLoginUrl = ConfigUtils.GetAppConfig("");
        internal static Entity.BaseResponse<CurrentUserInfo> login(string userName, string password)
        {
            IDictionary<string, string> textParams = new Dictionary<string, string>();
            textParams.Add("userName", userName);
            textParams.Add("password", password);
            String resJson = new HttpUtils().DoPost(AppConstant.clientLoginUrl, textParams);
            BaseResponse<CurrentUserInfo> baseResponse = JsonNewtonsoft.FromJSON<BaseResponse<CurrentUserInfo>>(resJson);
            return baseResponse;
        }
    }
}
