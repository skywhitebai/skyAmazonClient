using MarketplaceWebServiceOrders;
using MWSRecommendationsSectionService;
using MWSRecommendationsSectionService.Model;
using skyAmazonClient.Entity;
using skyCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyAmazonClient.Service
{
    /// <summary>
    /// 销售指导service
    /// </summary>
    class RecommendationsSectionService
    {
        string accessKey = AppConstant.amazonAccessKey;
        string secretKey = AppConstant.amazonSecretKey;
        string appName = "skyddt";
        string appVersion = "1.0";
        string serviceURL = "https://mws.amazonservices.com";
        string sellerId;
        string mwsAuthToken;
        Int32 shopId;
        string shopMarketplaceId;
        MWSRecommendationsSectionServiceClient client;
        public void synRecommendationsSection(Shop shop) {
            this.sellerId = shop.SellerId;
            this.mwsAuthToken = shop.MwsAuthToken;
            shopId = shop.Id;
            shopMarketplaceId = shop.ShopMarketplaceId;
            MWSRecommendationsSectionServiceConfig config = new MWSRecommendationsSectionServiceConfig();
            config.ServiceURL = serviceURL;
            client = new MWSRecommendationsSectionServiceClient(accessKey, secretKey, appName, appVersion, config);
            ListRecommendationsResponse listRecommendationsResponse = InvokeListRecommendations();
            String json = JsonNewtonsoft.ToJSON(listRecommendationsResponse);
            Console.Write(json);
        }


        private ListRecommendationsResponse InvokeListRecommendations()
        {
            // Create a request.
            ListRecommendationsRequest request = new ListRecommendationsRequest();
            request.MarketplaceId = shopMarketplaceId;
            request.MWSAuthToken = mwsAuthToken;
            request.SellerId = sellerId;
            string recommendationCategory = "Inventory";
            request.RecommendationCategory = recommendationCategory;
            List<CategoryQuery> categoryQueryList = new List<CategoryQuery>();
            request.CategoryQueryList = categoryQueryList;
            return this.client.ListRecommendations(request);
        }
    }
}
