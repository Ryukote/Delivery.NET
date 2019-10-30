using Delivery.NET.Contracts;

namespace Delivery.NET.RoyalMail.Values.Requests
{
    /// <summary>
    /// All properties needs to be filled with valid data from portal developer.royalmail.net
    /// </summary>
    public class TokenRequest : IDeliveryRequestData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
