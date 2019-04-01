using MarketplaceWebServiceOrders;
using MarketplaceWebServiceOrders.Model;
using skyAmazonClient.Entity;
using skyCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        string sellerId = "A2MPQIZC358GVX";
        string mwsAuthToken = "amzn.mws.6eb25106-576e-b4b6-f9d2-ef9a6e342bac";
        DateTime lastUpdatedAfter;
        string shopMarketplaceId="ATVPDKIKX0DER";
        MarketplaceWebServiceOrders.MarketplaceWebServiceOrders client;
        public void synOrder(int shopId,string sellerId, string mwsAuthToken,DateTime? lastUpdatedAfter)
        {
            this.sellerId = sellerId;
            this.mwsAuthToken = mwsAuthToken;
            this.lastUpdatedAfter = lastUpdatedAfter.Value;

            MarketplaceWebServiceOrdersConfig config = new MarketplaceWebServiceOrdersConfig();
            config.ServiceURL = serviceURL;
            client = new MarketplaceWebServiceOrdersClient(accessKey, secretKey, appName, appVersion, config);

            ListOrdersResponse listOrdersResponse = InvokeListOrders();
            foreach (Order order in listOrdersResponse.ListOrdersResult.Orders)
            {
                dealOrder(shopId, order);
            }
            if (String.IsNullOrEmpty(listOrdersResponse.ListOrdersResult.NextToken))
            {
                return ;
            }
            ListOrdersByNextTokenResponse listOrdersByNextTokenResponse = InvokeListOrdersByNextToken(listOrdersResponse.ListOrdersResult.NextToken);
            while (true)
            {
                foreach (Order order in listOrdersByNextTokenResponse.ListOrdersByNextTokenResult.Orders)
                {
                    dealOrder(shopId, order);
                }
                if (String.IsNullOrEmpty(listOrdersByNextTokenResponse.ListOrdersByNextTokenResult.NextToken))
                {
                    return ;
                }
                listOrdersByNextTokenResponse = InvokeListOrdersByNextToken(listOrdersByNextTokenResponse.ListOrdersByNextTokenResult.NextToken);
            } 
        }
        private void dealOrder(int shopId,Order order)
        {
            Console.WriteLine("dealOrder AmazonOrderId: " + order.AmazonOrderId);
            List<OrderItem> orderItems = getOrderItems(order.AmazonOrderId);
            String orderItemsJson = JsonNewtonsoft.ToJSON(order);
            String orderJson = JsonNewtonsoft.ToJSON(order);
            saveOrder(shopId, orderJson, orderItemsJson); 

        }
        private void saveOrder(int shopId, string orderJson, string orderItemsJson)
        {
            IDictionary<string, string> textParams = new Dictionary<string, string>();
            textParams.Add("shopId", shopId.ToString());
            textParams.Add("orderJson", orderJson);
            textParams.Add("orderItemsJson", orderItemsJson);
            textParams.Add("loginToken", AppConstant.loginToken);
            String resJson = new HttpUtils().DoPost(AppConstant.clientLoginUrl, textParams);
            BaseResponse<Object> baseResponse = JsonNewtonsoft.FromJSON<BaseResponse<Object>>(resJson);
        }
        private List<OrderItem> getOrderItems(String amazonOrderId)
        {
            ListOrderItemsResponse listOrderItemsResponse = InvokeListOrderItems(amazonOrderId);
            List<OrderItem> orderItems = new List<OrderItem>();
            foreach (OrderItem orderItem in listOrderItemsResponse.ListOrderItemsResult.OrderItems)
            {
                orderItems.Add(orderItem);
            }
            if (String.IsNullOrEmpty(listOrderItemsResponse.ListOrderItemsResult.NextToken))
            {
                return orderItems;
            }
            ListOrderItemsByNextTokenResponse listOrderItemsByNextTokenResponse=InvokeListOrderItemsByNextToken(listOrderItemsResponse.ListOrderItemsResult.NextToken);
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
                listOrderItemsByNextTokenResponse = InvokeListOrderItemsByNextToken(listOrderItemsByNextTokenResponse.ListOrderItemsByNextTokenResult.NextToken);
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
