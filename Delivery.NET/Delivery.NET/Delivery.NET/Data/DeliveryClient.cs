using Delivery.NET.Contracts;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Delivery.NET.Data
{
    internal class DeliveryClient <TRequest, TResponse>
        where TRequest : IDeliveryRequestData
        where TResponse : IDeliveryResponseData
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _client;

        internal DeliveryClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _client = _clientFactory.CreateClient();
        }

        internal async Task<TResponse> GetDeliveryData(string url)
        {
            var response = await _client.GetAsync(url);

            var data = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResponse>(data);
        }

        internal async Task<TResponse> SendDeliveryData(TRequest requestData, string url)
        {
            string json = JsonConvert.SerializeObject(requestData);
            var httpContent = new StringContent(json);

            var response = await _client.PostAsync(url, httpContent);
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResponse>(content);
        }
    }
}
