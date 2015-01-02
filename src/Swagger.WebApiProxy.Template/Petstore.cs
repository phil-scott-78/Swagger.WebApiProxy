using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

// ReSharper disable All

// Swagger Petstore
// A sample API that uses a petstore as an example to demonstrate features in the swagger-2.0 specification
// Generated at 1/2/2015 6:14:42 PM
namespace Petstore
{
    public class WebProxy : Swagger.WebApiProxy.Template.BaseProxy
    {
        public WebProxy(Uri baseUrl)
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
        /// Returns all pets from the system that the user has access to
        /// </summary>
        /// <param name="tags">tags to filter by</param>
        /// <param name="limit">maximum number of results to return</param>
        public async Task<List<pet>> FindPets(List<string> tags = null, int? limit = null)
        {
            var url = "/pets";
            if (tags != null)
            {
                url = AppendQuery(url, "tags", string.Join(",", tags));
            }
            if (limit.HasValue)
            {
                url = AppendQuery(url, "limit", limit.ToString());
            }

            using (var client = BuildHttpClient())
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<List<pet>>().ConfigureAwait(false);
            }
        }
        /// <summary>
        /// Creates a new pet in the store.  Duplicates are allowed
        /// </summary>
        /// <param name="pet">Pet to add to the store</param>
        public async Task<pet> AddPet(newPet pet)
        {
            var url = "/pets";

            using (var client = BuildHttpClient())
            {
                var response = await client.PostAsJsonAsync(url, pet).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<pet>().ConfigureAwait(false);
            }
        }
        /// <summary>
        /// Returns a user based on a single ID, if the user does not have access to the pet
        /// </summary>
        /// <param name="id">ID of pet to fetch</param>
        public async Task<pet> FindPetById(long id)
        {
            var url = "/pets/{id}"
                .Replace("{id}", id.ToString());

            using (var client = BuildHttpClient())
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<pet>().ConfigureAwait(false);
            }
        }
        /// <summary>
        /// deletes a single pet based on the ID supplied
        /// </summary>
        /// <param name="id">ID of pet to delete</param>
        public async Task DeletePet(long id)
        {
            var url = "/pets/{id}"
                .Replace("{id}", id.ToString());

            using (var client = BuildHttpClient())
            {
                var response = await client.DeleteAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
        }
    }
    public class pet
    {
        public long id { get; set; }
        public string name { get; set; }
        public string tag { get; set; }
    }
    public class newPet : pet
    {
        public long id { get; set; }
    }
    public class errorModel
    {
        public int code { get; set; }
        public string message { get; set; }
    }
}
