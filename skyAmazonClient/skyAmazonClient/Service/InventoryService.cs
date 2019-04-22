using FBAInventoryServiceMWS;
using FBAInventoryServiceMWS.Model;
using skyAmazonClient.Entity;
using skyCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            ListInventorySupplyResponse response = InvokeListInventorySupply();
            Console.WriteLine(JsonNewtonsoft.ToJSON(response));
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
    }
}
