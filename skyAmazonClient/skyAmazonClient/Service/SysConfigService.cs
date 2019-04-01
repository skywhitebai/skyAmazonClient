using skyAmazonClient.Entity;
using skyCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyAmazonClient.Service
{
    class SysConfigService
    {

        internal static string getConfigByKey(string key)
        {
            IDictionary<string, string> textParams = new Dictionary<string, string>();
            textParams.Add("keyName", key);
            textParams.Add("loginToken", AppConstant.loginToken);
            String resJson = new HttpUtils().DoPost(AppConstant.getConfigByKeyUrl, textParams);
            BaseResponse<String> baseResponse = JsonNewtonsoft.FromJSON<BaseResponse<String>>(resJson);
            if (baseResponse.isSuccessd())
            {
               return baseResponse.Data;
            }
            return null;
        }
    }
}
