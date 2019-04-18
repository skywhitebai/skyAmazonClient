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
 * MWS Merchant Fulfillment Service
 * API Version: 2015-06-01
 * Library Version: 2018-10-31
 * Generated: Mon Oct 22 23:32:31 UTC 2018
 */

using System;
using System.Net;
using MWSMerchantFulfillmentService.Model;
using MWSClientCsRuntime;

namespace MWSMerchantFulfillmentService
{

    /// <summary>
    /// Exception thrown by MWSMerchantFulfillmentService operations
    /// </summary>
    public class MWSMerchantFulfillmentServiceException : MwsException
    {

        public MWSMerchantFulfillmentServiceException(string message, HttpStatusCode statusCode)
            : base((int)statusCode, message, null, null, null, null) { }

        public MWSMerchantFulfillmentServiceException(string message)
            : base(0, message, null) { }

        public MWSMerchantFulfillmentServiceException(string message, HttpStatusCode statusCode, ResponseHeaderMetadata rhmd)
            : base((int)statusCode, message, null, null, null, rhmd) { }

        public MWSMerchantFulfillmentServiceException(Exception ex)
            : base(ex) { }

        public MWSMerchantFulfillmentServiceException(string message, Exception ex)
            : base(0, message, ex) { }

        public MWSMerchantFulfillmentServiceException(string message, HttpStatusCode statusCode, string errorCode,
            string errorType, string requestId, string xml, ResponseHeaderMetadata rhmd)
            : base((int)statusCode, message, errorCode, errorType, xml, rhmd) { }

        public new ResponseHeaderMetadata ResponseHeaderMetadata
        {
            get 
            { 
                MwsResponseHeaderMetadata baseRHMD = base.ResponseHeaderMetadata;
                if(baseRHMD != null)
                {
                    return new ResponseHeaderMetadata(baseRHMD); 
                }
                else
                {
                    return null;
                }
            }
        }

    }

}

