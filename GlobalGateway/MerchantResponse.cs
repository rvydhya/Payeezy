using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobalGateway
{
    public class MerchantResponse
    {
        public bool IsTransactionApproved { get; set; }
        public bool IsError { get; set; }
        public string Message { get; set; }
    }
}
