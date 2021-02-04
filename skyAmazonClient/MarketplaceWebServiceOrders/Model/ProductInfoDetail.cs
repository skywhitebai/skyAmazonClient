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
 * Product Info Detail
 * API Version: 2013-09-01
 * Library Version: 2021-01-06
 * Generated: Wed Jan 06 18:02:49 UTC 2021
 */


using System;
using System.Xml;
using MWSClientCsRuntime;

namespace MarketplaceWebServiceOrders.Model
{
    public class ProductInfoDetail : AbstractMwsObject
    {

        private decimal? _numberOfItems;

        /// <summary>
        /// Gets and sets the NumberOfItems property.
        /// </summary>
        public decimal NumberOfItems
        {
            get { return this._numberOfItems.GetValueOrDefault(); }
            set { this._numberOfItems = value; }
        }

        /// <summary>
        /// Sets the NumberOfItems property.
        /// </summary>
        /// <param name="numberOfItems">NumberOfItems property.</param>
        /// <returns>this instance.</returns>
        public ProductInfoDetail WithNumberOfItems(decimal numberOfItems)
        {
            this._numberOfItems = numberOfItems;
            return this;
        }

        /// <summary>
        /// Checks if NumberOfItems property is set.
        /// </summary>
        /// <returns>true if NumberOfItems property is set.</returns>
        public bool IsSetNumberOfItems()
        {
            return this._numberOfItems != null;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _numberOfItems = reader.Read<decimal?>("NumberOfItems");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("NumberOfItems", _numberOfItems);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2013-09-01", "ProductInfoDetail", this);
        }


        public ProductInfoDetail() : base()
        {
        }
    }
}
