using skyAmazonClient.Entity;
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
        internal static Entity.BaseResponse login(string userName, string password)
        {
            IDictionary<string, string> textParams = new Dictionary<string, string>();
            textParams.Add("userName", userName);
            textParams.Add("password", password);
            String resJson = new HttpUtils().DoPost("http://47.106.70.14/ddt/account/clientLogin", textParams);
            BaseResponse baseResponse = JsonNewtonsoft.FromJSON<BaseResponse>(resJson);
            return baseResponse;
        }
    }
}
