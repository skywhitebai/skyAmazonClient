/*******************************************************************************
 * Copyright 2009-2019 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"); 
 *
 * You may not use this file except in compliance with the License. 
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * Seller Review Enrollment Payment Event
 * API Version: 2015-05-01
 * Library Version: 2019-02-25
 * Generated: Wed Mar 13 08:17:08 PDT 2019
 */


using System;
using System.Xml;
using MWSClientCsRuntime;

namespace MWSFinancesService.Model
{
    public class SellerReviewEnrollmentPaymentEvent : AbstractMwsObject
    {

        private DateTime? _postedDate;
        private string _enrollmentId;
        private string _parentASIN;
        private FeeComponent _feeComponent;
        private ChargeComponent _chargeComponent;
        private Currency _totalAmount;

        /// <summary>
        /// Gets and sets the PostedDate property.
        /// </summary>
        public DateTime PostedDate
        {
            get { return this._postedDate.GetValueOrDefault(); }
            set { this._postedDate = value; }
        }

        /// <summary>
        /// Sets the PostedDate property.
        /// </summary>
        /// <param name="postedDate">PostedDate property.</param>
        /// <returns>this instance.</returns>
        public SellerReviewEnrollmentPaymentEvent WithPostedDate(DateTime postedDate)
        {
            this._postedDate = postedDate;
            return this;
        }

        /// <summary>
        /// Checks if PostedDate property is set.
        /// </summary>
        /// <returns>true if PostedDate property is set.</returns>
        public bool IsSetPostedDate()
        {
            return this._postedDate != null;
        }

        /// <summary>
        /// Gets and sets the EnrollmentId property.
        /// </summary>
        public string EnrollmentId
        {
            get { return this._enrollmentId; }
            set { this._enrollmentId = value; }
        }

        /// <summary>
        /// Sets the EnrollmentId property.
        /// </summary>
        /// <param name="enrollmentId">EnrollmentId property.</param>
        /// <returns>this instance.</returns>
        public SellerReviewEnrollmentPaymentEvent WithEnrollmentId(string enrollmentId)
        {
            this._enrollmentId = enrollmentId;
            return this;
        }

        /// <summary>
        /// Checks if EnrollmentId property is set.
        /// </summary>
        /// <returns>true if EnrollmentId property is set.</returns>
        public bool IsSetEnrollmentId()
        {
            return this._enrollmentId != null;
        }

        /// <summary>
        /// Gets and sets the ParentASIN property.
        /// </summary>
        public string ParentASIN
        {
            get { return this._parentASIN; }
            set { this._parentASIN = value; }
        }

        /// <summary>
        /// Sets the ParentASIN property.
        /// </summary>
        /// <param name="parentASIN">ParentASIN property.</param>
        /// <returns>this instance.</returns>
        public SellerReviewEnrollmentPaymentEvent WithParentASIN(string parentASIN)
        {
            this._parentASIN = parentASIN;
            return this;
        }

        /// <summary>
        /// Checks if ParentASIN property is set.
        /// </summary>
        /// <returns>true if ParentASIN property is set.</returns>
        public bool IsSetParentASIN()
        {
            return this._parentASIN != null;
        }

        /// <summary>
        /// Gets and sets the FeeComponent property.
        /// </summary>
        public FeeComponent FeeComponent
        {
            get { return this._feeComponent; }
            set { this._feeComponent = value; }
        }

        /// <summary>
        /// Sets the FeeComponent property.
        /// </summary>
        /// <param name="feeComponent">FeeComponent property.</param>
        /// <returns>this instance.</returns>
        public SellerReviewEnrollmentPaymentEvent WithFeeComponent(FeeComponent feeComponent)
        {
            this._feeComponent = feeComponent;
            return this;
        }

        /// <summary>
        /// Checks if FeeComponent property is set.
        /// </summary>
        /// <returns>true if FeeComponent property is set.</returns>
        public bool IsSetFeeComponent()
        {
            return this._feeComponent != null;
        }

        /// <summary>
        /// Gets and sets the ChargeComponent property.
        /// </summary>
        public ChargeComponent ChargeComponent
        {
            get { return this._chargeComponent; }
            set { this._chargeComponent = value; }
        }

        /// <summary>
        /// Sets the ChargeComponent property.
        /// </summary>
        /// <param name="chargeComponent">ChargeComponent property.</param>
        /// <returns>this instance.</returns>
        public SellerReviewEnrollmentPaymentEvent WithChargeComponent(ChargeComponent chargeComponent)
        {
            this._chargeComponent = chargeComponent;
            return this;
        }

        /// <summary>
        /// Checks if ChargeComponent property is set.
        /// </summary>
        /// <returns>true if ChargeComponent property is set.</returns>
        public bool IsSetChargeComponent()
        {
            return this._chargeComponent != null;
        }

        /// <summary>
        /// Gets and sets the TotalAmount property.
        /// </summary>
        public Currency TotalAmount
        {
            get { return this._totalAmount; }
            set { this._totalAmount = value; }
        }

        /// <summary>
        /// Sets the TotalAmount property.
        /// </summary>
        /// <param name="totalAmount">TotalAmount property.</param>
        /// <returns>this instance.</returns>
        public SellerReviewEnrollmentPaymentEvent WithTotalAmount(Currency totalAmount)
        {
            this._totalAmount = totalAmount;
            return this;
        }

        /// <summary>
        /// Checks if TotalAmount property is set.
        /// </summary>
        /// <returns>true if TotalAmount property is set.</returns>
        public bool IsSetTotalAmount()
        {
            return this._totalAmount != null;
        }


        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _postedDate = reader.Read<DateTime?>("PostedDate");
            _enrollmentId = reader.Read<string>("EnrollmentId");
            _parentASIN = reader.Read<string>("ParentASIN");
            _feeComponent = reader.Read<FeeComponent>("FeeComponent");
            _chargeComponent = reader.Read<ChargeComponent>("ChargeComponent");
            _totalAmount = reader.Read<Currency>("TotalAmount");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("PostedDate", _postedDate);
            writer.Write("EnrollmentId", _enrollmentId);
            writer.Write("ParentASIN", _parentASIN);
            writer.Write("FeeComponent", _feeComponent);
            writer.Write("ChargeComponent", _chargeComponent);
            writer.Write("TotalAmount", _totalAmount);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("http://mws.amazonservices.com/Finances/2015-05-01", "SellerReviewEnrollmentPaymentEvent", this);
        }


        public SellerReviewEnrollmentPaymentEvent() : base()
        {
        }
    }
}
