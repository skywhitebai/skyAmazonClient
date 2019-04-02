using MarketplaceWebServiceOrders;
using MarketplaceWebServiceOrders.Model;
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
    class OrderService
    {
        string accessKey = AppConstant.amazonAccessKey;
        string secretKey = AppConstant.amazonSecretKey;
        string appName = "skyddt";
        string appVersion = "1.0";
        string serviceURL = "https://mws.amazonservices.com";
        string sellerId ;
        string mwsAuthToken ;
        Int32 shopId;
        DateTime lastUpdatedAfter;
        string shopMarketplaceId;
        MarketplaceWebServiceOrders.MarketplaceWebServiceOrders client;
        public void synOrder(Shop shop)
        {
            if (shop.OrderLastUpDatedAfter == null)
            {
                shop.OrderLastUpDatedAfter = AppConstant.lastUpdatedAfter;
            }
            if (lastUpdatedAfter == null)
            {
                this.lastUpdatedAfter = shop.OrderLastUpDatedAfter.Value;
            }
            this.sellerId = shop.SellerId;
            this.mwsAuthToken = shop.MwsAuthToken;
            shopId = shop.Id;
            shopMarketplaceId = shop.ShopMarketplaceId;
            MarketplaceWebServiceOrdersConfig config = new MarketplaceWebServiceOrdersConfig();
            config.ServiceURL = serviceURL;
            client = new MarketplaceWebServiceOrdersClient(accessKey, secretKey, appName, appVersion, config);

            ListOrdersResponse listOrdersResponse = getListOrders();
            if (listOrdersResponse == null)
            {
                return;
            }
            foreach (Order order in listOrdersResponse.ListOrdersResult.Orders)
            {
                dealOrder(shopId, order);
            }
            if (String.IsNullOrEmpty(listOrdersResponse.ListOrdersResult.NextToken))
            {
                return ;
            }
            ListOrdersByNextTokenResponse listOrdersByNextTokenResponse = getListOrdersByNextToken(listOrdersResponse.ListOrdersResult.NextToken);
            if (listOrdersByNextTokenResponse == null)
            {
                return;
            }
            while (true)
            {
                foreach (Order order in listOrdersByNextTokenResponse.ListOrdersByNextTokenResult.Orders)
                {
                    dealOrder(shopId, order);
                }
                if (String.IsNullOrEmpty(listOrdersByNextTokenResponse.ListOrdersByNextTokenResult.NextToken))
                {
                    return;
                }
                listOrdersByNextTokenResponse = getListOrdersByNextToken(listOrdersByNextTokenResponse.ListOrdersByNextTokenResult.NextToken);
                if (listOrdersByNextTokenResponse == null)
                {
                    return;
                }
            } 
        }

        private ListOrdersByNextTokenResponse getListOrdersByNextToken(string nextToken)
        {
            try
            {
                return InvokeListOrdersByNextToken(nextToken);;
            }
            catch (Exception ex)
            {
                if (ex.Message == "Request is throttled")
                {
                    Console.WriteLine("getListOrdersByNextToken Request is throttled: Sleep " + AppConstant.orderSleepTimeMinute + "minute");
                    Thread.Sleep(TimeSpan.FromMinutes(AppConstant.orderSleepTimeMinute));
                    return getListOrdersByNextToken(nextToken);
                }
                else
                {
                    return null;
                }
            }
        }

        private ListOrdersResponse getListOrders()
        {
            try
            {
                return InvokeListOrders();
            }
            catch (Exception ex)
            {
                if (ex.Message == "Request is throttled")
                {
                    Console.WriteLine("getListOrders Request is throttled: Sleep " + AppConstant.orderSleepTimeMinute+"minute");
                    Thread.Sleep(TimeSpan.FromMinutes(AppConstant.orderSleepTimeMinute));
                    return getListOrders();
                }
                else
                {
                    return null;
                }
            }
        }
        private void dealOrder(int shopId,Order order)
        {
            Console.WriteLine("dealOrder AmazonOrderId: " + order.AmazonOrderId);
            List<OrderItem> orderItems = getOrderItems(order.AmazonOrderId);
            String orderItemsJson = JsonNewtonsoft.ToJSON(orderItems);
            String orderJson = JsonNewtonsoft.ToJSON(order);
            saveOrder(shopId, orderJson, orderItemsJson);
            ShopService.updateLastUpdatedAfter(shopId, order.LastUpdateDate);
            lastUpdatedAfter = order.LastUpdateDate;
        }
        private void saveOrder(int shopId, string orderJson, string orderItemsJson)
        {
            IDictionary<string, string> textParams = new Dictionary<string, string>();
            textParams.Add("shopId", shopId.ToString());
            textParams.Add("orderJson", orderJson);
            textParams.Add("orderItemsJson", orderItemsJson);
            textParams.Add("loginToken", AppConstant.loginToken);
            String resJson = new HttpUtils().DoPost(AppConstant.saveOrderUrl, textParams);
            BaseResponse<Object> baseResponse = JsonNewtonsoft.FromJSON<BaseResponse<Object>>(resJson);
        }
        private List<OrderItem> getOrderItems(String amazonOrderId)
        {
            ListOrderItemsResponse listOrderItemsResponse = getListOrderItems(amazonOrderId);
            if (listOrderItemsResponse == null)
            {
                return null;
            }
            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (OrderItem orderItem in listOrderItemsResponse.ListOrderItemsResult.OrderItems)
            {
                orderItems.Add(orderItem);
            }
            if (String.IsNullOrEmpty(listOrderItemsResponse.ListOrderItemsResult.NextToken))
            {
                return orderItems;
            }
            ListOrderItemsByNextTokenResponse listOrderItemsByNextTokenResponse = getListOrderItemsByNextToken(listOrderItemsResponse.ListOrderItemsResult.NextToken);
            if (listOrderItemsByNextTokenResponse == null)
            {
                return null;
            }
            while (true)
            {
                foreach (OrderItem orderItem in listOrderItemsByNextTokenResponse.ListOrderItemsByNextTokenResult.OrderItems)
                {
                    orderItems.Add(orderItem);
                }
                if (String.IsNullOrEmpty(listOrderItemsByNextTokenResponse.ListOrderItemsByNextTokenResult.NextToken))
                {
                    return orderItems;
                }
                listOrderItemsByNextTokenResponse = getListOrderItemsByNextToken(listOrderItemsByNextTokenResponse.ListOrderItemsByNextTokenResult.NextToken);
                if (listOrderItemsByNextTokenResponse == null)
                {
                    return null;
                } 
            }
        }

        private ListOrderItemsByNextTokenResponse getListOrderItemsByNextToken(string nextToken)
        {
            try
            {
                return InvokeListOrderItemsByNextToken(nextToken);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Request is throttled")
                {
                    Console.WriteLine("getListOrderItemsByNextToken Request is throttled: Sleep " + AppConstant.orderItemSleepTimeSecond + "second");
                    Thread.Sleep(TimeSpan.FromMinutes(AppConstant.orderItemSleepTimeSecond));
                    return getListOrderItemsByNextToken(nextToken);
                }
                else
                {
                    return null;
                }
            }
        }

        private ListOrderItemsResponse getListOrderItems(string amazonOrderId)
        {
            try
            {
                return InvokeListOrderItems(amazonOrderId);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Request is throttled")
                {
                    Console.WriteLine("getListOrderItems Request is throttled: Sleep " + AppConstant.orderItemSleepTimeSecond + "second");
                    Thread.Sleep(TimeSpan.FromMinutes(AppConstant.orderItemSleepTimeSecond));
                    return getListOrderItems(amazonOrderId);
                }
                else
                {
                    return null;
                }
            }
        }
        private GetOrderResponse InvokeGetOrder()
        {
            // Create a request.
            GetOrderRequest request = new GetOrderRequest();
            request.SellerId = sellerId;
            request.MWSAuthToken = mwsAuthToken;
            List<string> amazonOrderId = new List<string>();
            request.AmazonOrderId = amazonOrderId;
            return this.client.GetOrder(request);
        }
        private ListOrdersResponse InvokeListOrders()
        {
            // Create a request.
            ListOrdersRequest request = new ListOrdersRequest();
            request.SellerId = sellerId;
            request.MWSAuthToken = mwsAuthToken;
            request.LastUpdatedAfter = lastUpdatedAfter;
            List<string> orderStatus = new List<string>();
            request.OrderStatus = orderStatus;
            List<string> marketplaceId = new List<string>();
            marketplaceId.Add(shopMarketplaceId);
            request.MarketplaceId = marketplaceId;
            List<string> fulfillmentChannel = new List<string>();
            request.FulfillmentChannel = fulfillmentChannel;
            List<string> paymentMethod = new List<string>();
            request.PaymentMethod = paymentMethod;
            decimal maxResultsPerPage = 30;//订单商品30个请求数量，所以这里设置30个
            request.MaxResultsPerPage = maxResultsPerPage;
            List<string> tfmShipmentStatus = new List<string>();
            request.TFMShipmentStatus = tfmShipmentStatus;
            List<string> easyShipShipmentStatus = new List<string>();
            request.EasyShipShipmentStatus = easyShipShipmentStatus;
            return this.client.ListOrders(request);
        }

        public ListOrdersByNextTokenResponse InvokeListOrdersByNextToken(string nextToken)
        {
            // Create a request.
            ListOrdersByNextTokenRequest request = new ListOrdersByNextTokenRequest();
            request.SellerId = sellerId;
            request.MWSAuthToken = mwsAuthToken;
            request.NextToken = nextToken;
            return this.client.ListOrdersByNextToken(request);
        }
        public ListOrderItemsResponse InvokeListOrderItems(string amazonOrderId)
        {
            ListOrderItemsRequest request = new ListOrderItemsRequest();
            request.SellerId = sellerId;
            request.MWSAuthToken = mwsAuthToken;
            request.AmazonOrderId = amazonOrderId;
            return this.client.ListOrderItems(request);
        }

        public ListOrderItemsByNextTokenResponse InvokeListOrderItemsByNextToken(string nextToken)
        {
            ListOrderItemsByNextTokenRequest request = new ListOrderItemsByNextTokenRequest();
            request.SellerId = sellerId;
            request.MWSAuthToken = mwsAuthToken;
            request.NextToken = nextToken;
            return this.client.ListOrderItemsByNextToken(request);
        }

    }
}
