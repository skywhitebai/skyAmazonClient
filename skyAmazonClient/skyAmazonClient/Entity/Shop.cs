using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skyAmazonClient.Entity
{
    class Shop
    {
        private Int32 id;

        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        private String shopName;

        public String ShopName
        {
            get { return shopName; }
            set { shopName = value; }
        }

        private String shopUrl;

        public String ShopUrl
        {
            get { return shopUrl; }
            set { shopUrl = value; }
        }

        private String sellerId;

        public String SellerId
        {
            get { return sellerId; }
            set { sellerId = value; }
        }

        private String mwsAuthToken;

        public String MwsAuthToken
        {
            get { return mwsAuthToken; }
            set { mwsAuthToken = value; }
        }

        private String clientIp;

        public String ClientIp
        {
            get { return clientIp; }
            set { clientIp = value; }
        }

        private String clientMacAddress;

        public String ClientMacAddress
        {
            get { return clientMacAddress; }
            set { clientMacAddress = value; }
        }

        private DateTime? orderLastUpDatedAfter;

        public DateTime? OrderLastUpDatedAfter
        {
            get { return orderLastUpDatedAfter; }
            set { orderLastUpDatedAfter = value; }
        }

        private Boolean status;

        public Boolean Status
        {
            get { return status; }
            set { status = value; }
        }
        private string shopMarketplaceId;

        public string ShopMarketplaceId
        {
            get { return shopMarketplaceId; }
            set { shopMarketplaceId = value; }
        }
        private DateTime? inventoryQueryStartDateTime;

        public DateTime? InventoryQueryStartDateTime
        {
            get { return inventoryQueryStartDateTime; }
            set { inventoryQueryStartDateTime = value; }
        }
    }
}
