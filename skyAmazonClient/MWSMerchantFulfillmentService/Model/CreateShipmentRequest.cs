/*******************************************************************************
 * Copyright 2009-2018 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Create Shipment Request
 * API Version: 2015-06-01
 * Library Version: 2018-10-31
 * Generated: Mon Oct 22 23:32:31 UTC 2018
 */


using System;
using System.Xml;
using MWSClientCsRuntime;

namespace MWSMerchantFulfillmentService.Model
{
    public class CreateShipmentRequest : AbstractMwsObject
    {

        private string _sellerId;
        private string _mwsAuthToken;
        private ShipmentRequestDetails _shipmentRequestDetails;
        private string _shippingServiceId;
        private string _shippingServiceOfferId;
        private string _hazmatType;

        /// <summary>
        /// Gets and sets the SellerId property.
        /// </summary>
        public string SellerId
        {
            get { return this._sellerId; }
            set { this._sellerId = value; }
        }

        /// <summary>
        /// Sets the SellerId property.
        /// </summary>
        /// <param name="sellerId">SellerId property.</param>
        /// <returns>this instance.</returns>
        public CreateShipmentRequest WithSellerId(string sellerId)
        {
            this._sellerId = sellerId;
            return this;
        }

        /// <summary>
        /// Checks if SellerId property is set.
        /// </summary>
        /// <returns>true if SellerId property is set.</returns>
        public bool IsSetSellerId()
        {
            return this._sellerId != null;
        }

        /// <summary>
        /// Gets and sets the MWSAuthToken property.
        /// </summary>
        public string MWSAuthToken
        {
            get { return this._mwsAuthToken; }
            set { this._mwsAuthToken = value; }
        }

        /// <summary>
        /// Sets the MWSAuthToken property.
        /// </summary>
        /// <param name="mwsAuthToken">MWSAuthToken property.</param>
        /// <returns>this instance.</returns>
        public CreateShipmentRequest WithMWSAuthToken(string mwsAuthToken)
        {
            this._mwsAuthToken = mwsAuthToken;
            return this;
        }

        /// <summary>
        /// Checks if MWSAuthToken property is set.
        /// </summary>
        /// <returns>true if MWSAuthToken property is set.</returns>
        public bool IsSetMWSAuthToken()
        {
            return this._mwsAuthToken != null;
        }

        /// <summary>
        /// Gets and sets the ShipmentRequestDetails property.
        /// </summary>
        public ShipmentRequestDetails ShipmentRequestDetails
        {
            get { return this._shipmentRequestDetails; }
            set { this._shipmentRequestDetails = value; }
        }

        /// <summary>
        /// Sets the ShipmentRequestDetails property.
        /// </summary>
        /// <param name="shipmentRequestDetails">ShipmentRequestDetails property.</param>
        /// <returns>this instance.</returns>
        public CreateShipmentRequest WithShipmentRequestDetails(ShipmentRequestDetails shipmentRequestDetails)
        {
            this._shipmentRequestDetails = shipmentRequestDetails;
            return this;
        }

        /// <summary>
        /// Checks if ShipmentRequestDetails property is set.
        /// </summary>
        /// <returns>true if ShipmentRequestDetails property is set.</returns>
        public bool IsSetShipmentRequestDetails()
        {
            return this._shipmentRequestDetails != null;
        }

        /// <summary>
        /// Gets and sets the ShippingServiceId property.
        /// </summary>
        public string ShippingServiceId
        {
            get { return this._shippingServiceId; }
            set { this._shippingServiceId = value; }
        }

        /// <summary>
        /// Sets the ShippingServiceId property.
        /// </summary>
        /// <param name="shippingServiceId">ShippingServiceId property.</param>
        /// <returns>this instance.</returns>
        public CreateShipmentRequest WithShippingServiceId(string shippingServiceId)
        {
            this._shippingServiceId = shippingServiceId;
            return this;
        }

        /// <summary>
        /// Checks if ShippingServiceId property is set.
        /// </summary>
        /// <returns>true if ShippingServiceId property is set.</returns>
        public bool IsSetShippingServiceId()
        {
            return this._shippingServiceId != null;
        }

        /// <summary>
        /// Gets and sets the ShippingServiceOfferId property.
        /// </summary>
        public string ShippingServiceOfferId
        {
            get { return this._shippingServiceOfferId; }
            set { this._shippingServiceOfferId = value; }
        }

        /// <summary>
        /// Sets the ShippingServiceOfferId property.
        /// </summary>
        /// <param name="shippingServiceOfferId">ShippingServiceOfferId property.</param>
        /// <returns>this instance.</returns>
        public CreateShipmentRequest WithShippingServiceOfferId(string shippingServiceOfferId)
        {
            this._shippingServiceOfferId = shippingServiceOfferId;
            return this;
        }

        /// <summary>
        /// Checks if ShippingServiceOfferId property is set.
        /// </summary>
        /// <returns>true if ShippingServiceOfferId property is set.</returns>
        public bool IsSetShippingServiceOfferId()
        {
            return this._shippingServiceOfferId != null;
        }

        /// <summary>
        /// Gets and sets the HazmatType property.
        /// </summary>
        public string HazmatType
        {
            get { return this._hazmatType; }
            set { this._hazmatType = value; }
        }

        /// <summary>
        /// Sets the HazmatType property.
        /// </summary>
        /// <param name="hazmatType">HazmatType property.</param>
        /// <returns>this instance.</returns>
        public CreateShipmentRequest WithHazmatType(string hazmatType)
        {
            this._hazmatType = hazmatType;
            return this;
        }

        /// <summary>
        /// Checks if HazmatType property is set.
        /// </summary>
        /// <returns>true if HazmatType property is set.</returns>
        public bool IsSetHazmatType()
        {
            return this._hazmatType != null;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _sellerId = reader.Read<string>("SellerId");
            _mwsAuthToken = reader.Read<string>("MWSAuthToken");
            _shipmentRequestDetails = reader.Read<ShipmentRequestDetails>("ShipmentRequestDetails");
            _shippingServiceId = reader.Read<string>("ShippingServiceId");
            _shippingServiceOfferId = reader.Read<string>("ShippingServiceOfferId");
            _hazmatType = reader.Read<string>("HazmatType");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("SellerId", _sellerId);
            writer.Write("MWSAuthToken", _mwsAuthToken);
            writer.Write("ShipmentRequestDetails", _shipmentRequestDetails);
            writer.Write("ShippingServiceId", _shippingServiceId);
            writer.Write("ShippingServiceOfferId", _shippingServiceOfferId);
            writer.Write("HazmatType", _hazmatType);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/MerchantFulfillment/2015-06-01", "CreateShipmentRequest", this);
        }

    public CreateShipmentRequest (string sellerId,ShipmentRequestDetails shipmentRequestDetails,string shippingServiceId) : base() {
        this._sellerId = sellerId;
        this._shipmentRequestDetails = shipmentRequestDetails;
        this._shippingServiceId = shippingServiceId;
    }

        public CreateShipmentRequest() : base()
        {
        }
    }
}
