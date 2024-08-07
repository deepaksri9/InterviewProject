using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;

namespace WebUI.Data
{
    public class WebApiExecutor : IWebApiExecutor
    {
        private const string apiName = "EmpApi";
        private readonly IHttpClientFactory _httpClientFactory;

        public WebApiExecutor(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T?> InvokePost<T>(string relativeApi, T obj)
        {
            var httpClient = _httpClientFactory.CreateClient(apiName);
            var response = await httpClient.PostAsJsonAsync(relativeApi, obj);

            if (!response.IsSuccessStatusCode)
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                throw new Exception(errorJson);
            }

            return await response.Content.ReadFromJsonAsync<T>();

        }
    }
}
