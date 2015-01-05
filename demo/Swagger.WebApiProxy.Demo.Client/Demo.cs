using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

// ReSharper disable All

// Swagger.WebApiProxy.Demo.WebApi
// 
// Generated at 1/4/2015 3:41:58 PM
namespace Demo
{
    /// <summary>
    /// Web Proxy for Products
    /// </summary>
    public class ProductsWebProxy : Swagger.WebApiProxy.Demo.Client.BaseProxy
    {
        public ProductsWebProxy(Uri baseUrl)
            : base(baseUrl)
        { }
        // helper function for building uris. 
        private string AppendQuery(string currentUrl, string paramName, string value)
        {
            if (currentUrl.Contains("?"))
                currentUrl += string.Format("&{0}={1}", paramName, Uri.EscapeUriString(value));
            else
                currentUrl += string.Format("?{0}={1}", paramName, Uri.EscapeUriString(value));
            return currentUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        public async Task<List<Product>> GetAllProducts()
        {
            var url = "api/Products";

            using (var client = BuildHttpClient())
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<List<Product>>().ConfigureAwait(false);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public async Task<Product> GetProduct(int id)
        {
            var url = "api/Products/{id}"
                .Replace("{id}", id.ToString());

            using (var client = BuildHttpClient())
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<Product>().ConfigureAwait(false);
            }
        }
    }
    /// <summary>
    /// Web Proxy for Values
    /// </summary>
    public class ValuesWebProxy : Swagger.WebApiProxy.Demo.Client.BaseProxy
    {
        public ValuesWebProxy(Uri baseUrl)
            : base(baseUrl)
        { }
        // helper function for building uris. 
        private string AppendQuery(string currentUrl, string paramName, string value)
        {
            if (currentUrl.Contains("?"))
                currentUrl += string.Format("&{0}={1}", paramName, Uri.EscapeUriString(value));
            else
                currentUrl += string.Format("?{0}={1}", paramName, Uri.EscapeUriString(value));
            return currentUrl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        public async Task<List<string>> Get(List<int> query)
        {
            var url = "api/values/search";
            foreach (var item in query)
            {
                url = AppendQuery(url, "query", item.ToString());
            }

            using (var client = BuildHttpClient())
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<List<string>>().ConfigureAwait(false);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public async Task<List<string>> Get()
        {
            var url = "api/Values";

            using (var client = BuildHttpClient())
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<List<string>>().ConfigureAwait(false);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public async Task Post(string value)
        {
            var url = "api/Values";

            using (var client = BuildHttpClient())
            {
                var response = await client.PostAsJsonAsync(url, value).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public async Task<string> Get(int id)
        {
            var url = "api/Values/{id}"
                .Replace("{id}", id.ToString());

            using (var client = BuildHttpClient())
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<string>().ConfigureAwait(false);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public async Task Put(int id, string value)
        {
            var url = "api/Values/{id}"
                .Replace("{id}", id.ToString());

            using (var client = BuildHttpClient())
            {
                var response = await client.PostAsJsonAsync(url, value).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public async Task Delete(int id)
        {
            var url = "api/Values/{id}"
                .Replace("{id}", id.ToString());

            using (var client = BuildHttpClient())
            {
                var response = await client.DeleteAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
        }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public long Price { get; set; }
    }
}
