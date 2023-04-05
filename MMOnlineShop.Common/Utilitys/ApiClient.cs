using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Common.Utilitys
{
    public class ApiClient
    {
        public async Task<string> PostAsync<T>(IHttpClientService _serHttpClient, Uri requestUrl, T content)
        {
            var client = await _serHttpClient.GetClient();
            var response = await client.PostAsync(requestUrl.ToString(), CreateHttpContent(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return data;
        }

        public async Task<string> GetAsync(IHttpClientService _serHttpClient, Uri requestUrl)
        {
            var client = await _serHttpClient.GetClient();
            var response = await client.GetAsync(requestUrl);

            return await response.Content.ReadAsStringAsync();
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
        private JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }
    }
}
