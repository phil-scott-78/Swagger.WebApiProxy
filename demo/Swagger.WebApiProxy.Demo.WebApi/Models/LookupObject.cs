namespace Swagger.WebApiProxy.Demo.WebApi.Models
{
    public class LookupObject
    {
        public int Id { get; internal set; }
        public string Value { get; internal set; }
    }

    public class ValueLookup : LookupObject
    {
    }
}