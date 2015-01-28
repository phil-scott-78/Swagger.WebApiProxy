 



using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

// ReSharper disable All

namespace Petstore{
/// <summary>
/// Web Proxy for pet
/// </summary>
public class petWebProxy : Swagger.WebApiProxy.Demo.Client.BaseProxy
{
public petWebProxy(Uri baseUrl) : base(baseUrl)
{}
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
public async Task addPet (Pet body = null)
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
public async Task updatePet (Pet body = null)
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
public async Task<List<Pet>> findPetsByStatus (List<string> status = null)
{
var url = "pet/findByStatus";
if (status != null){
foreach(var item in status)
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
public async Task<List<Pet>> findPetsByTags (List<string> tags = null)
{
var url = "pet/findByTags";
if (tags != null){
foreach(var item in tags)
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
public async Task<Pet> getPetById (long petId)
{
var url = "pet/{petId}"
	.Replace("{petId}", petId.ToString());

using (var client = BuildHttpClient())
{
var response = await client.GetAsync(url).ConfigureAwait(false);
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
public async Task updatePetWithForm (string petId, string name = null, string status = null)
{
var url = "pet/{petId}"
	.Replace("{petId}", petId.ToString());

using (var client = BuildHttpClient())
{
var formKeyValuePairs = new List<KeyValuePair<string, string>>();
if (name != null){
formKeyValuePairs.Add(new KeyValuePair<string, string>("name", name));
}
if (status != null){
formKeyValuePairs.Add(new KeyValuePair<string, string>("status", status));
}
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
public async Task deletePet (long petId, string api_key = null)
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
public class storeWebProxy : Swagger.WebApiProxy.Demo.Client.BaseProxy
{
public storeWebProxy(Uri baseUrl) : base(baseUrl)
{}
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
/// Returns a map of status codes to quantities
/// </summary>
public async Task getInventory ()
{
var url = "store/inventory";

using (var client = BuildHttpClient())
{
var response = await client.GetAsync(url).ConfigureAwait(false);
response.EnsureSuccessStatusCode();
}
}
/// <summary>
/// 
/// </summary>
/// <param name="body">order placed for purchasing the pet</param>
public async Task<Order> placeOrder (Order body = null)
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
public async Task<Order> getOrderById (string orderId)
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
public async Task deleteOrder (string orderId)
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
public class userWebProxy : Swagger.WebApiProxy.Demo.Client.BaseProxy
{
public userWebProxy(Uri baseUrl) : base(baseUrl)
{}
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
public async Task createUser (User body = null)
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
public async Task createUsersWithArrayInput (List<User> body = null)
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
public async Task createUsersWithListInput (List<User> body = null)
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
public async Task<string> loginUser (string username = null, string password = null)
{
var url = "user/login";
if (username != null){
url = AppendQuery(url, "username", username.ToString());
}
if (password != null){
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
public async Task logoutUser ()
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
public async Task<User> getUserByName (string username)
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
public async Task updateUser (string username, User body = null)
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
public async Task deleteUser (string username)
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
namespace Demo{
/// <summary>
/// Web Proxy for Products
/// </summary>
public class ProductsWebProxy : Swagger.WebApiProxy.Demo.Client.BaseProxy
{
public ProductsWebProxy(Uri baseUrl) : base(baseUrl)
{}
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
public async Task<List<Product>> GetProductByStatusAsync (GetProductByStatusstatus status)
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
public async Task<List<Product>> GetAllProductsAsync ()
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
public async Task<Product> GetProductAsync (int id)
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
public ValuesWebProxy(Uri baseUrl) : base(baseUrl)
{}
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
public async Task<List<string>> GetAsync (List<int> query)
{
var url = "api/values/search";
foreach(var item in query)
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
public async Task<AllTheDataTypes> GetDataTypesAsync ()
{
var url = "api/values/dataTypes";

using (var client = BuildHttpClient())
{
var response = await client.GetAsync(url).ConfigureAwait(false);
response.EnsureSuccessStatusCode();
return await response.Content.ReadAsAsync<AllTheDataTypes>().ConfigureAwait(false);
}
}
/// <summary>
/// 
/// </summary>
public async Task<LookupObjectList<ValueLookup>> LookupListAsync ()
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
public async Task<List<string>> GetAsync ()
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
public async Task PostAsync (string value)
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
public async Task<string> GetAsync (int id)
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
public async Task PutAsync (int id, string value)
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
public async Task DeleteAsync (int id)
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
public decimal Price { get; set; }
public DateTime? DateDiscontinued { get; set; }
public StatusValues Status { get; set; }
public OtherStoreStatusValues OtherStoreStatus { get; set; }
public int Oops { get; set; }
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
}
public class AllTheDataTypes 
{
public string StringType { get; set; }
public decimal DecimalType { get; set; }
public float FloatType { get; set; }
public double DoubleType { get; set; }
public byte ByteType { get; set; }
public int IntType { get; set; }
public long LongType { get; set; }
public bool BoolType { get; set; }
public string CharType { get; set; }
}
public class LookupObjectList<ValueLookup> 
{
public Dictionary<Int32,ValueLookup> Lookups { get; set; }
}
public class ValueLookup 
{
public int Id { get; set; }
public string Value { get; set; }
}
}
        

    