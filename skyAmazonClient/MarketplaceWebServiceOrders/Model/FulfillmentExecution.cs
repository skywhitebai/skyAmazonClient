/*******************************************************************************
 * Copyright 2009-2021 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Fulfillment Execution
 * API Version: 2013-09-01
 * Library Version: 2021-01-06
 * Generated: Wed Jan 06 18:02:49 UTC 2021
 */


using System;
using System.Xml;
using MWSClientCsRuntime;

namespace MarketplaceWebServiceOrders.Model
{
    public class FulfillmentExecution : AbstractMwsObject
    {

        private string _fulfillmentSupplySourceId;

        /// <summary>
        /// Gets and sets the FulfillmentSupplySourceId property.
        /// </summary>
        public string FulfillmentSupplySourceId
        {
            get { return this._fulfillmentSupplySourceId; }
            set { this._fulfillmentSupplySourceId = value; }
        }

        /// <summary>
        /// Sets the FulfillmentSupplySourceId property.
        /// </summary>
        /// <param name="fulfillmentSupplySourceId">FulfillmentSupplySourceId property.</param>
        /// <returns>this instance.</returns>
        public FulfillmentExecution WithFulfillmentSupplySourceId(string fulfillmentSupplySourceId)
        {
            this._fulfillmentSupplySourceId = fulfillmentSupplySourceId;
            return this;
        }

        /// <summary>
        /// Checks if FulfillmentSupplySourceId property is set.
        /// </summary>
        /// <returns>true if FulfillmentSupplySourceId property is set.</returns>
        public bool IsSetFulfillmentSupplySourceId()
        {
            return this._fulfillmentSupplySourceId != null;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _fulfillmentSupplySourceId = reader.Read<string>("FulfillmentSupplySourceId");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("FulfillmentSupplySourceId", _fulfillmentSupplySourceId);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2013-09-01", "FulfillmentExecution", this);
        }


        public FulfillmentExecution() : base()
        {
        }
    }
}
