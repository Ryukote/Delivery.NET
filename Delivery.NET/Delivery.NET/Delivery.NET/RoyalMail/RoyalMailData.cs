using Delivery.NET.Data;
using Delivery.NET.RoyalMail.Values.Requests;
using Delivery.NET.RoyalMail.Values.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace Delivery.NET.RoyalMail
{
    public class RoyalMailData
    {
        private IHttpClientFactory _factory;
        public RoyalMailData(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<TokenResponse> Authenticate(TokenRequest tokenRequest)
        {

            var deliveryClient = new DeliveryClient<TokenRequest, TokenResponse>(_factory);
            return await deliveryClient.SendDeliveryData(tokenRequest, RoyalEndpoints.token);
        }
    }
}
