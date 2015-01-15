using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

// ReSharper disable All

// Swagger.WebApiProxy.Demo.WebApi
// 
// Generated at 1/15/2015 2:57:20 PM
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
        /// <param name="status"></param>
        public async Task<List<Product>> GetProductByStatusAsync(GetProductByStatusstatus status)
        {
            var url = "api/products";
            url = AppendQuery(url, "status", status.ToString());

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
        public async Task<List<Product>> GetAllProductsAsync()
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
        public async Task<Product> GetProductAsync(int id)
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
        public enum GetProductByStatusstatus
        {
            InStock,
            OutOfStock,
            BackOrdered,
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
        public async Task<List<string>> GetAsync(List<int> query)
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
        public async Task<LookupObjectList<ValueLookup>> LookupListAsync()
        {
            var url = "api/products/lookup";

            using (var client = BuildHttpClient())
            {
                var response = await client.PostAsync(url, new StringContent(string.Empty)).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<LookupObjectList<ValueLookup>>().ConfigureAwait(false);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public async Task<List<string>> GetAsync()
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
        public async Task PostAsync(string value)
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
        public async Task<string> GetAsync(int id)
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
        public async Task PutAsync(int id, string value)
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
        public async Task DeleteAsync(int id)
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
        public StatusValues Status { get; set; }
        public OtherStoreStatusValues OtherStoreStatus { get; set; }
        public OopsValues Oops { get; set; }
        public enum StatusValues
        {
            InStock,
            OutOfStock,
            BackOrdered,
        }
        public enum OtherStoreStatusValues
        {
            InStock,
            OutOfStock,
            BackOrdered,
        }
        public enum OopsValues
        {
            _0,
            _1,
        }
    }
    public class LookupObjectList<ValueLookup>
    {
        public Dictionary<Int32, ValueLookup> Lookups { get; set; }
    }
    public class ValueLookup
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
