using Delivery.NET.Contracts;

namespace Delivery.NET.RoyalMail.Values.Responses
{
    /// <summary>
    /// This is the data that Royal Mail returns if authentication is success.
    /// </summary>
    public class TokenResponse : IDeliveryResponseData
    {
        public string Token { get; set; }
    }
}
