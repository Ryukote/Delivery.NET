namespace Delivery.NET.RoyalMail
{
    internal class RoyalEndpoints
    {
        internal const string baseUrl = "https://api.royalmail.net";
        /// <summary>
        /// Token endpoint is for GET request.
        /// </summary>
        internal const string token = baseUrl + "/shipping/v2/token";
        internal const string domestic = baseUrl + "/shipping/v2/domestic";
        internal const string shipments = baseUrl + "/shipping/v2/shipments";
    }
}
