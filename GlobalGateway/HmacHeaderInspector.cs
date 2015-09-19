using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Xml;

namespace GlobalGateway
{
    class HmacHeaderInspector : IClientMessageInspector
    {
        private readonly string _hmac;
        private readonly string _keyId;

        public HmacHeaderInspector(string hmac, string keyId)
        {
            _hmac = hmac;
            _keyId = keyId;
        }
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
            request = buffer.CreateMessage();
            Message msg = buffer.CreateMessage();
            ASCIIEncoding encoder = new ASCIIEncoding();

            var sb = new StringBuilder();
            var xmlWriter = XmlWriter.Create(sb, new XmlWriterSettings
            {
                OmitXmlDeclaration = true
            });
            var writer = XmlDictionaryWriter.CreateDictionaryWriter(xmlWriter);
            msg.WriteStartEnvelope(writer);
            msg.WriteStartBody(writer);
            msg.WriteBodyContents(writer);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            writer.Flush();

            string body = sb.ToString().Replace(" />", "/>");

            byte[] xmlByte = encoder.GetBytes(body);
            SHA1CryptoServiceProvider sha1Crypto = new SHA1CryptoServiceProvider();
            string hash = BitConverter.ToString(sha1Crypto.ComputeHash(xmlByte)).Replace("-", "");
            string hashedContent = hash.ToLower();

            //assign values to hashing and header variables
            string time = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string hashData = "POST\ntext/xml; charset=utf-8\n" + hashedContent + "\n" + time + "\n/transaction/v12";
            //hmac sha1 hash with key + hash_data
            HMAC hmacSha1 = new HMACSHA1(Encoding.UTF8.GetBytes(_hmac)); //key
            byte[] hmacData = hmacSha1.ComputeHash(Encoding.UTF8.GetBytes(hashData)); //data
            //base64 encode on hmac_data
            string base64Hash = Convert.ToBase64String(hmacData);

            HttpRequestMessageProperty httpRequestMessage;
            object httpRequestMessageObject;

            if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out httpRequestMessageObject))
            {
                httpRequestMessage = httpRequestMessageObject as HttpRequestMessageProperty;
                httpRequestMessage.Headers["X-GGe4-Content-SHA1"] = hashedContent;
                httpRequestMessage.Headers["X-GGe4-Date"] = time;
                httpRequestMessage.Headers["Authorization"] = "GGE4_API " + _keyId + ":" + base64Hash;
            }
            else
            {
                httpRequestMessage = new HttpRequestMessageProperty();
                httpRequestMessage.Headers["X-GGe4-Content-SHA1"] = hashedContent;
                httpRequestMessage.Headers["X-GGe4-Date"] = time;
                httpRequestMessage.Headers["Authorization"] = "GGE4_API " + _keyId + ":" + base64Hash;
                request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage);
            }
            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }
    }
}