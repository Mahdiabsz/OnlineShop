using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMOnlineShop.Common.Utilitys
{
    public interface IHttpClientService
    {
        Task<HttpClient> GetClient();
    }
    public class HttpClientService : IHttpClientService
    {
        public async Task<HttpClient> GetClient()
        {
            var client = new HttpClient();
            SetupClientDefaults(client);
            return client;
        }

        protected virtual void SetupClientDefaults(HttpClient client)
        {
            client.Timeout = TimeSpan.FromSeconds(30);
        }
    }
}
