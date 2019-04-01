using skyAmazonClient.Entity;
using skyCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyAmazonClient.Service
{
    class ShopService
    {
        internal static BaseResponse<Shop> getCurrentUserShop()
        {
            String macAddress = GetSystemInfo.getMacAddr_Local();
            string loginToken = AppConstant.loginToken;
            if (String.IsNullOrEmpty(macAddress))
            {
                return BaseResponse<Shop>.failMessage("macAddress不能为空");
            }
            if (String.IsNullOrEmpty(loginToken))
            {
                return BaseResponse<Shop>.failMessage("loginToken不能为空");
            }
            IDictionary<string, string> textParams = new Dictionary<string, string>();
            textParams.Add("macAddress", macAddress);
            textParams.Add("loginToken", loginToken);
            string resJson = new HttpUtils().DoPost(AppConstant.getCurrentUserShopUrl, textParams);
            BaseResponse<Shop> baseResponse = JsonNewtonsoft.FromJSON<BaseResponse<Shop>>(resJson);
            return baseResponse;
        }
    }
}
