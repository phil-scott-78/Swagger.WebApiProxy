


using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

// ReSharper disable All

namespace Petstore{
/// <summary>
/// Web Proxy for pet
/// </summary>
public class petWebProxy : Swagger.WebApiProxy.Template.BaseProxy
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
await EnsureSuccessStatusCodeAsync(response);
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
var response = await client.PutAsJsonAsync(url, body).ConfigureAwait(false);
await EnsureSuccessStatusCodeAsync(response);
}
}
/// <summary>
/// Multiple status values can be provided with comma seperated strings
/// </summary>
/// <param name="status">Status values that need to be considered for filter</param>
public async Task<List<Pet>> findPetsByStatus (List<findPetsByStatusstatus> status = null)
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
await EnsureSuccessStatusCodeAsync(response);
return await response.Content.ReadAsAsync<List<Pet>>().ConfigureAwait(false);
}
}
/// <summary>
/// Muliple tags can be provided with comma seperated strings. Use tag1, tag2, tag3 for testing.
/// </summary>
/// <param name="tags">Tags to filter by</param>
public async Task<List<Pet>> findPetsByTags (List<List<string>> tags = null)
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
await EnsureSuccessStatusCodeAsync(response);
return await response.Content.ReadAsAsync<List<Pet>>().ConfigureAwait(false);
}
}
/// <summary>
/// Returns a single pet
/// </summary>
/// <param name="petId">ID of pet to return</param>
public async Task<Pet> getPetById (long petId)
{
var url = "pet/{petId}"
	.Replace("{petId}", petId.ToString());

using (var client = BuildHttpClient())
{
var response = await client.GetAsync(url).ConfigureAwait(false);
await EnsureSuccessStatusCodeAsync(response);
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
await EnsureSuccessStatusCodeAsync(response);
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
await EnsureSuccessStatusCodeAsync(response);
}
}
/// <summary>
/// 
/// </summary>
/// <param name="petId">ID of pet to update</param>
/// <param name="additionalMetadata">Additional data to pass to server</param>
/// <param name="file">file to upload</param>
public async Task<ApiResponse> uploadFile (long petId, string additionalMetadata = null, Tuple<string, byte[]> file = null)
{
var url = "pet/{petId}/uploadImage"
	.Replace("{petId}", petId.ToString());

using (var client = BuildHttpClient())
{
var formKeyValuePairs = new List<KeyValuePair<string, string>>();
if (additionalMetadata != null){
formKeyValuePairs.Add(new KeyValuePair<string, string>("additionalMetadata", additionalMetadata));
}
var fileContent = new ByteArrayContent(file.Item2);
fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment") { FileName = file.Item1 };
HttpContent content = new FormUrlEncodedContent(formKeyValuePairs);
var response = await client.PostAsync(url, content).ConfigureAwait(false);
await EnsureSuccessStatusCodeAsync(response);
return await response.Content.ReadAsAsync<ApiResponse>().ConfigureAwait(false);
}
}
public enum findPetsByStatusstatus
{
available,
pending,
sold,
}
}
/// <summary>
/// Web Proxy for store
/// </summary>
public class storeWebProxy : Swagger.WebApiProxy.Template.BaseProxy
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
await EnsureSuccessStatusCodeAsync(response);
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
await EnsureSuccessStatusCodeAsync(response);
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
await EnsureSuccessStatusCodeAsync(response);
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
await EnsureSuccessStatusCodeAsync(response);
}
}
}
/// <summary>
/// Web Proxy for user
/// </summary>
public class userWebProxy : Swagger.WebApiProxy.Template.BaseProxy
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
await EnsureSuccessStatusCodeAsync(response);
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
await EnsureSuccessStatusCodeAsync(response);
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
await EnsureSuccessStatusCodeAsync(response);
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
await EnsureSuccessStatusCodeAsync(response);
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
await EnsureSuccessStatusCodeAsync(response);
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
await EnsureSuccessStatusCodeAsync(response);
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
var response = await client.PutAsJsonAsync(url, body).ConfigureAwait(false);
await EnsureSuccessStatusCodeAsync(response);
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
await EnsureSuccessStatusCodeAsync(response);
}
}
}
public class Order 
{
public long id { get; set; }
public long petId { get; set; }
public int quantity { get; set; }
public DateTime shipDate { get; set; }
public statusValues status { get; set; }
public bool complete { get; set; }
public enum statusValues
{
placed,
approved,
delivered,
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
public class Tag 
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
public statusValues status { get; set; }
public enum statusValues
{
available,
pending,
sold,
}
}
public class ApiResponse 
{
public int code { get; set; }
public string type { get; set; }
public string message { get; set; }
}
}
        

    