using GlobalGateway.FirstData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace GlobalGateway
{
    public class Merchant
    {
        private readonly string _gatewayId;
        private readonly string _password;
        private readonly string _keyId;
        private readonly string _hmac;
        private readonly bool _isDemo;

        private const string ProdUrl = "https://api.globalgatewaye4.firstdata.com/transaction/v12";
        private const string TestUrl = "https://api.demo.globalgatewaye4.firstdata.com/transaction/v12";


        public Merchant(string gatewayId, string password, string hmac, string keyId, bool isDemo = true)
        {
            _gatewayId = gatewayId;
            _password = password;
            _hmac = hmac;
            _keyId = keyId;
            _isDemo = isDemo;
        }

        public MerchantResponse Charge(int orderId, string cardHoldersName, string cardNumber, decimal amount,
            int expirationMonth, int expirationYear, int ccv, string address, string city, string state, string zip)
        {
            var client = new ServiceSoapClient(new BasicHttpBinding(BasicHttpSecurityMode.Transport),
                new EndpointAddress(_isDemo ? TestUrl : ProdUrl));
            client.ChannelFactory.Endpoint.Behaviors.Add(new HmacHeaderBehaivour(_hmac, _keyId));

            TransactionResult result = client.SendAndCommit(new Transaction
            {
                ExactID = _gatewayId,
                Password = _password,
                Transaction_Type = "00",
                Card_Number = cardNumber,
                CardHoldersName = cardHoldersName,
                DollarAmount = amount.ToString("F"),
                Expiry_Date = string.Format("{0:D2}{1}", expirationMonth, expirationYear),
                Customer_Ref = orderId.ToString(),
                VerificationStr1 = string.Format("{0}|{1}|{2}|{3}|US", address, zip, city, state),
                VerificationStr2 = ccv.ToString()
            });
            var response = new MerchantResponse
            {
                IsTransactionApproved = result.Transaction_Approved,
                IsError = result.Transaction_Error
            };
            if (!result.Transaction_Approved && !result.Transaction_Error)
            {
                response.Message = string.Format("Error {0}: {1}", result.Bank_Resp_Code, result.Bank_Message);
            }
            if (!result.Transaction_Approved && result.Transaction_Error)
            {
                response.Message = string.Format("Error {0}: {1}", result.EXact_Resp_Code, result.EXact_Message);
            }
            if (result.Transaction_Approved)
            {
                response.Message = result.Authorization_Num;
            }
            return response;
        }

    }
}