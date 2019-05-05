using FBAInventoryServiceMWS;
using FBAInventoryServiceMWS.Model;
using skyAmazonClient.Entity;
using skyCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace skyAmazonClient.Service
{
    class InventoryService
    {
        string accessKey = AppConstant.amazonAccessKey;
        string secretKey = AppConstant.amazonSecretKey;
        string appName = "skyddt";
        string appVersion = "1.0";
        string serviceURL = "https://mws.amazonservices.com";
        string sellerId;
        string mwsAuthToken;
        Int32 shopId;
        DateTime? inventoryQueryStartDateTime;
        string shopMarketplaceId;
        FBAInventoryServiceMWS.FBAInventoryServiceMWS client;
        public void syn(Shop shop)
        {
            if (shop.InventoryQueryStartDateTime == null)
            {
                shop.InventoryQueryStartDateTime = AppConstant.inventoryQueryStartDateTime;
            }

            if (inventoryQueryStartDateTime == null)
            {
                this.inventoryQueryStartDateTime = shop.InventoryQueryStartDateTime.Value;
            }
            this.sellerId = shop.SellerId;
            this.mwsAuthToken = shop.MwsAuthToken;
            shopId = shop.Id;
            shopMarketplaceId = shop.ShopMarketplaceId;
            FBAInventoryServiceMWSConfig config = new FBAInventoryServiceMWSConfig();
            config.ServiceURL = serviceURL;
            client = new FBAInventoryServiceMWSClient(accessKey, secretKey, appName, appVersion, config);
            doSyn();
            inventoryQueryStartDateTime =DateTime.Now.AddMinutes(-5);
            ShopService.updateInventoryQueryStartDateTime(shop.Id, inventoryQueryStartDateTime.Value);
        }

        private void doSyn()
        {
            ListInventorySupplyResponse listInventorySupplyResponse = getListInventorySupply();
            if (listInventorySupplyResponse == null)
            {
                return;
            }
            saveInventory(listInventorySupplyResponse.ListInventorySupplyResult.InventorySupplyList.member);
            if (String.IsNullOrEmpty(listInventorySupplyResponse.ListInventorySupplyResult.NextToken))
            {
                return;
            }
            ListInventorySupplyByNextTokenResponse listInventorySupplyByNextTokenResponse = getListInventorySupplyByNextToken(listInventorySupplyResponse.ListInventorySupplyResult.NextToken);
            if (listInventorySupplyByNextTokenResponse == null)
            {
                return;
            }
            while (true)
            {
                saveInventory(listInventorySupplyByNextTokenResponse.ListInventorySupplyByNextTokenResult.InventorySupplyList.member);
                if (String.IsNullOrEmpty(listInventorySupplyByNextTokenResponse.ListInventorySupplyByNextTokenResult.NextToken))
                {
                    return;
                }
                listInventorySupplyByNextTokenResponse = getListInventorySupplyByNextToken(listInventorySupplyByNextTokenResponse.ListInventorySupplyByNextTokenResult.NextToken);
                if (listInventorySupplyByNextTokenResponse == null)
                {
                    return;
                }
            }
        }

        private ListInventorySupplyResponse getListInventorySupply()
        {
            try
            {
                return InvokeListInventorySupply();
            }
            catch (Exception ex)
            {
                if (ex.Message == "Request is throttled")
                {
                    Double requestIsThrottledSleepTimeMinute = AppConstant.getRequestIsThrottledSleepTimeMinute();
                    String dealInfo = "getListInventorySupply Request is throttled: Sleep " + requestIsThrottledSleepTimeMinute + "minute";
                    AppConstant.SynTaskInfo.InventoryTask.dealInfoAppend(dealInfo);
                    Thread.Sleep(TimeSpan.FromMinutes(requestIsThrottledSleepTimeMinute));
                    return getListInventorySupply();
                }
                else
                {
                    AppConstant.SynTaskInfo.InventoryTask.dealInfoAppend("异常:" + ex.Message);
                    return null;
                }
            }
        }

        private ListInventorySupplyByNextTokenResponse getListInventorySupplyByNextToken(string nextToken)
        {
            try
            {
                return InvokeListInventorySupplyByNextToken(nextToken); ;
            }
            catch (Exception ex)
            {
                if (ex.Message == "Request is throttled")
                {
                    Double requestIsThrottledSleepTimeMinute = AppConstant.getRequestIsThrottledSleepTimeMinute();
                    String dealInfo = "getListInventorySupplyByNextToken Request is throttled: Sleep " + requestIsThrottledSleepTimeMinute + "minute";
                    AppConstant.SynTaskInfo.InventoryTask.dealInfoAppend(dealInfo);
                    Thread.Sleep(TimeSpan.FromMinutes(requestIsThrottledSleepTimeMinute));
                    return getListInventorySupplyByNextToken(nextToken);
                }
                else
                {
                    AppConstant.SynTaskInfo.InventoryTask.dealInfoAppend("异常:" + ex.Message);
                    return null;
                }
            }
        }

        private void saveInventory(List<InventorySupply> list)
        {
            IDictionary<string, string> textParams = new Dictionary<string, string>();
            textParams.Add("shopId", shopId.ToString());
            textParams.Add("inventoryJson", JsonNewtonsoft.ToJSON(list));
            textParams.Add("loginToken", AppConstant.loginToken);
            String resJson = new HttpUtils().DoPost(AppConstant.saveInventoryUrl, textParams);
            BaseResponse<Object> baseResponse = JsonNewtonsoft.FromJSON<BaseResponse<Object>>(resJson);
            AppConstant.SynTaskInfo.InventoryTask.SynDataNumber += list.Count;
            
        }
        public ListInventorySupplyResponse InvokeListInventorySupply()
        {
            // Create a request.
            ListInventorySupplyRequest request = new ListInventorySupplyRequest();
            request.SellerId = sellerId;
            request.MWSAuthToken = mwsAuthToken;
            //request.Marketplace = marketplace;
            request.MarketplaceId = shopMarketplaceId;
            SellerSkuList sellerSkus = new SellerSkuList();
            request.SellerSkus = sellerSkus;
            request.QueryStartDateTime = inventoryQueryStartDateTime.Value;            
            //request.ResponseGroup = responseGroup;
            return this.client.ListInventorySupply(request);
        }
        public ListInventorySupplyByNextTokenResponse InvokeListInventorySupplyByNextToken(string nextToken)
        {
            // Create a request.
            ListInventorySupplyByNextTokenRequest request = new ListInventorySupplyByNextTokenRequest();
            request.SellerId = sellerId;
            request.MWSAuthToken = mwsAuthToken;
            request.Marketplace = shopMarketplaceId;
            request.NextToken = nextToken;
            return this.client.ListInventorySupplyByNextToken(request);
        }
    }
}
