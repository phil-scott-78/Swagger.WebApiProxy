using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;


// Swagger Petstore
// This is a sample server Petstore server.  You can find out more about Swagger at <a href="http://swagger.wordnik.com">http://swagger.wordnik.com</a> or on irc.freenode.net, #swagger.  For this sample, you can use the api key "special-key" to test the authorization filters
// Generated at 1/4/2015 3:42:46 PM
namespace Petstore
{
    /// <summary>
    /// Web Proxy for pet
    /// </summary>
    public class PetWebProxy : Swagger.WebApiProxy.Demo.Client.BaseProxy
    {
        private Action<HttpResponseMessage> _postResponseFunction = null;

        public PetWebProxy PostResponse(Action<HttpResponseMessage> postResponseFunction)
        {
            _postResponseFunction = postResponseFunction;
            return this;
        }

        public PetWebProxy(Uri baseUrl)
            : base(baseUrl)
        {
        }

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
        /// <param name="body">Pet object that needs to be added to the store</param>
        public async Task AddPet(Pet body = null)
        {
            var url = "pet";

            using (var client = BuildHttpClient())
            {
                var response = await client.PostAsJsonAsync(url, body).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="body">Pet object that needs to be added to the store</param>
        public async Task UpdatePet(Pet body = null)
        {
            var url = "pet";

            using (var client = BuildHttpClient())
            {
                var response = await client.PostAsJsonAsync(url, body).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
        }
        /// <summary>
        /// Multiple status values can be provided with comma seperated strings
        /// </summary>
        /// <param name="status">Status values that need to be considered for filter</param>
        public async Task<List<Pet>> FindPetsByStatus(List<string> status = null)
        {
            var url = "pet/findByStatus";
            if (status != null)
            {
                foreach (var item in status)
                {
                    url = AppendQuery(url, "status", item.ToString());
                }
            }

            using (var client = BuildHttpClient())
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<List<Pet>>().ConfigureAwait(false);
            }
        }
        /// <summary>
        /// Muliple tags can be provided with comma seperated strings. Use tag1, tag2, tag3 for testing.
        /// </summary>
        /// <param name="tags">Tags to filter by</param>
        public async Task<List<Pet>> FindPetsByTags(List<string> tags = null)
        {
            var url = "pet/findByTags";
            if (tags != null)
            {
                foreach (var item in tags)
                {
                    url = AppendQuery(url, "tags", item.ToString());
                }
            }

            using (var client = BuildHttpClient())
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<List<Pet>>().ConfigureAwait(false);
            }
        }
        /// <summary>
        /// Returns a pet when ID &lt; 10.  ID &gt; 10 or nonintegers will simulate API error conditions
        /// </summary>
        /// <param name="petId">ID of pet that needs to be fetched</param>
        public async Task<Pet> GetPetById(long petId)
        {
            var url = "pet/{petId}"
                .Replace("{petId}", petId.ToString());

            using (var client = BuildHttpClient())
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                if (_postResponseFunction != null)
                    _postResponseFunction(response);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<Pet>().ConfigureAwait(false);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="petId">ID of pet that needs to be updated</param>
        /// <param name="name">Updated name of the pet</param>
        /// <param name="status">Updated status of the pet</param>
        public async Task UpdatePetWithForm(string petId, string name, string status)
        {
            var url = "pet/{petId}"
                .Replace("{petId}", petId.ToString());

            using (var client = BuildHttpClient())
            {
                var formKeyValuePairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("name", name),
                    new KeyValuePair<string, string>("status", status)
                };
                HttpContent content = new FormUrlEncodedContent(formKeyValuePairs);
                var response = await client.PostAsync(url, content).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="api_key"></param>
        /// <param name="petId">Pet id to delete</param>
        public async Task DeletePet(string api_key, long petId)
        {
            var url = "pet/{petId}"
                .Replace("{petId}", petId.ToString());

            using (var client = BuildHttpClient())
            {
                var response = await client.DeleteAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
        }
    }
    /// <summary>
    /// Web Proxy for store
    /// </summary>
    public class StoreWebProxy : Swagger.WebApiProxy.Demo.Client.BaseProxy
    {
        public StoreWebProxy(Uri baseUrl)
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
        /// <param name="body">order placed for purchasing the pet</param>
        public async Task<Order> PlaceOrder(Order body = null)
        {
            var url = "store/order";

            using (var client = BuildHttpClient())
            {
                var response = await client.PostAsJsonAsync(url, body).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<Order>().ConfigureAwait(false);
            }
        }
        /// <summary>
        /// For valid response try integer IDs with value &lt;= 5 or &gt; 10. Other values will generated exceptions
        /// </summary>
        /// <param name="orderId">ID of pet that needs to be fetched</param>
        public async Task<Order> GetOrderById(string orderId)
        {
            var url = "store/order/{orderId}"
                .Replace("{orderId}", orderId.ToString());

            using (var client = BuildHttpClient())
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<Order>().ConfigureAwait(false);
            }
        }
        /// <summary>
        /// For valid response try integer IDs with value &lt; 1000. Anything above 1000 or nonintegers will generate API errors
        /// </summary>
        /// <param name="orderId">ID of the order that needs to be deleted</param>
        public async Task DeleteOrder(string orderId)
        {
            var url = "store/order/{orderId}"
                .Replace("{orderId}", orderId.ToString());

            using (var client = BuildHttpClient())
            {
                var response = await client.DeleteAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
        }
    }
    /// <summary>
    /// Web Proxy for user
    /// </summary>
    public class UserWebProxy : Swagger.WebApiProxy.Demo.Client.BaseProxy
    {
        public UserWebProxy(Uri baseUrl)
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
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="body">Created user object</param>
        public async Task CreateUser(User body = null)
        {
            var url = "user";

            using (var client = BuildHttpClient())
            {
                var response = await client.PostAsJsonAsync(url, body).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="body">List of user object</param>
        public async Task CreateUsersWithArrayInput(List<User> body = null)
        {
            var url = "user/createWithArray";

            using (var client = BuildHttpClient())
            {
                var response = await client.PostAsJsonAsync(url, body).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="body">List of user object</param>
        public async Task CreateUsersWithListInput(List<User> body = null)
        {
            var url = "user/createWithList";

            using (var client = BuildHttpClient())
            {
                var response = await client.PostAsJsonAsync(url, body).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username">The user name for login</param>
        /// <param name="password">The password for login in clear text</param>
        public async Task<string> LoginUser(string username = null, string password = null)
        {
            var url = "user/login";
            if (username != null)
            {
                url = AppendQuery(url, "username", username.ToString());
            }
            if (password != null)
            {
                url = AppendQuery(url, "password", password.ToString());
            }

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
        public async Task LogoutUser()
        {
            var url = "user/logout";

            using (var client = BuildHttpClient())
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username">The name that needs to be fetched. Use user1 for testing. </param>
        public async Task<User> GetUserByName(string username)
        {
            var url = "user/{username}"
                .Replace("{username}", username.ToString());

            using (var client = BuildHttpClient())
            {
                var response = await client.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<User>().ConfigureAwait(false);
            }
        }
        /// <summary>
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="username">name that need to be deleted</param>
        /// <param name="body">Updated user object</param>
        public async Task UpdateUser(string username, User body = null)
        {
            var url = "user/{username}"
                .Replace("{username}", username.ToString());

            using (var client = BuildHttpClient())
            {
                var response = await client.PostAsJsonAsync(url, body).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
        }
        /// <summary>
        /// This can only be done by the logged in user.
        /// </summary>
        /// <param name="username">The name that needs to be deleted</param>
        public async Task DeleteUser(string username)
        {
            var url = "user/{username}"
                .Replace("{username}", username.ToString());

            using (var client = BuildHttpClient())
            {
                var response = await client.DeleteAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
        }
    }
    public class User
    {
        public long id { get; set; }
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public int userStatus { get; set; }
    }
    public class Category
    {
        public long id { get; set; }
        public string name { get; set; }
    }
    public class Pet
    {
        public long id { get; set; }
        public Category category { get; set; }
        public string name { get; set; }
        public List<string> photoUrls { get; set; }
        public List<Tag> tags { get; set; }
        public string status { get; set; }
    }
    public class Tag
    {
        public long id { get; set; }
        public string name { get; set; }
    }
    public class Order
    {
        public long id { get; set; }
        public long petId { get; set; }
        public int quantity { get; set; }
        public DateTime shipDate { get; set; }
        public string status { get; set; }
        public bool complete { get; set; }
    }
}
