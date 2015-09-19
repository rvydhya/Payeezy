using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace GlobalGateway
{
    class HmacHeaderBehaivour : IEndpointBehavior
    {
        private readonly string _hmac;
        private readonly string _keyId;

        public HmacHeaderBehaivour(string hmac, string keyId)
        {
            _hmac = hmac;
            _keyId = keyId;
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new HmacHeaderInspector(_hmac, _keyId));
        }
    }
}
