﻿//    Copyright 2016 SnapMD, Inc.
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//        http://www.apache.org/licenses/LICENSE-2.0
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using Newtonsoft.Json.Linq;
using SnapMD.VirtualCare.ApiModels;
using SnapMD.VirtualCare.ApiModels.Payments;
using SnapMD.VirtualCare.Sdk.Models;
using SnapMD.VirtualCare.Sdk.Interfaces;

namespace SnapMD.VirtualCare.Sdk
{
    public class PaymentsApi : ApiCall
    {
        public PaymentsApi(string baseUrl, string bearerToken, int hospitalId, string developerId, string apiKey, IWebClient webClient)
            : base(baseUrl, webClient, bearerToken, developerId, apiKey)
        {
            HospitalId = hospitalId;
        }

        public PaymentsApi(string baseUrl, int hospitalId, IWebClient webClient)
            : base(baseUrl, webClient)
        {
            HospitalId = hospitalId;
        }

        public int HospitalId { get; private set; }

        public ApiResponseV2<CimCustomer> GetCustomerProfile(int? patientUserId)
        {
            //fixed to match the unit test
            var result = MakeCall<ApiResponseV2<CimCustomer>>(string.Format("v2/patients/{0}/payments", patientUserId));
            return result;
        }

        public ApiResponseV2<PaymentProfilePostResult> RegisterProfile(object paymentData)
        {
            var result = Post<ApiResponseV2<PaymentProfilePostResult>>(string.Format("v2/patients/payments"), paymentData);
            return result;
        }

        public ApiResponseV2<bool> GetPaymentStatus(int consultationId)
        {
            var result = MakeCall<ApiResponseV2<bool>>(string.Format("v2/patients/copay/{0}/paymentstatus", consultationId));
            return result;
        }
    }
}