using System;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Swagger.WebApiProxy.Demo.WebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }

        public ProductStatus Status { get; set; }
        public ProductStatus OtherStoreStatus { get; set; }
        public OopsNoString  Oops { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProductStatus
    {
        InStock,
        OutOfStock,
        BackOrdered
    }

    public enum OopsNoString
    {
        FirstValue,
        SecondValue
    }
}