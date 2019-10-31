using Delivery.NET.Data;
using Delivery.NET.RoyalMail.Exceptions;
using Delivery.NET.RoyalMail.Validations;
using Delivery.NET.RoyalMail.Values.Requests;
using Delivery.NET.RoyalMail.Values.Responses;
using System.Net.Http;
using System.Threading.Tasks;

namespace Delivery.NET.RoyalMail
{
    public class RoyalMailData
    {
        private IHttpClientFactory _factory;
        private AuthenticationValidation _authentication;
        public RoyalMailData(IHttpClientFactory factory)
        {
            _factory = factory;
            _authentication = new AuthenticationValidation();
        }

        public async Task<TokenResponse> Authenticate(TokenRequest tokenRequest)
        {
            var result = _authentication.Validate(tokenRequest);
            if (result.IsValid)
            {
                var deliveryClient = new DeliveryClient<TokenRequest, TokenResponse>(_factory);
                return await deliveryClient.SendDeliveryData(tokenRequest, RoyalEndpoints.token);
            }

            throw new RoyalMailAuthenticationDataException(RoyalConstants.RoyalMailAuthenticationDataException
                , result.Errors);
        }
    }
}
