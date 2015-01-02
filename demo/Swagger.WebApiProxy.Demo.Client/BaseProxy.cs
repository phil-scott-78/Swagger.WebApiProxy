using System;
using System.Net.Http;

namespace Swagger.WebApiProxy.Demo.Client
{
    public abstract class BaseProxy
    {
        private readonly Uri _baseUrl;

        protected BaseProxy(Uri baseUrl)
        {
            _baseUrl = baseUrl;
        }

        protected HttpClient BuildHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = _baseUrl;
            return httpClient;
        }
    }
}
