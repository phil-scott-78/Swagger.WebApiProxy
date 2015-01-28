using System;
using System.Security.Policy;
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
        public DateTime? DateDiscontinued { get; set; }

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

    public class AllTheDataTypes
    {
        public string StringType { get; set; }
        public Decimal DecimalType { get; set; }
        public float FloatType { get; set; }
        public double DoubleType { get; set; }
        public byte ByteType { get; set; }
        public int IntType { get; set; }
        public long LongType { get; set; }
        public bool BoolType { get; set; }
        public char CharType { get; set; }
    }
}