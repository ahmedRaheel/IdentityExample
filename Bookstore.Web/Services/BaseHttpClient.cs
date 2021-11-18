using Bookstore.EnterpriseLibrary.Constants;
using Bookstore.EnterpriseLibrary.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bookstore.Web.Services
{
    public class BaseHttpClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseHttpClient(IHttpClientFactory httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        protected async Task<T> Execute<T>(HttpMethod method, string uri, T data)
        {
            var httpClient = _httpClientFactory.CreateClient(StringConstant.Http_Client_Books_Api);

            var request = new HttpRequestMessage(method, uri);

            if (method == HttpMethod.Post || method == HttpMethod.Put)
            {
                request.SerializeData<T>(data);
            }

            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.ReadContentAs<T>();
            }
            else
            {
                return default;
            }
        }
    }
}
