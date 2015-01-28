using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Swagger.WebApiProxy.Demo.WebApi.Models;

namespace Swagger.WebApiProxy.Demo.WebApi.Controllers
{
    /// <summary>
    /// Documentation for controller
    /// that is on multiple lines
    /// </summary>
    public class ProductsController : ApiController
    {
        readonly Product[] _products = new Product[] 
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 , Status = ProductStatus.OutOfStock, OtherStoreStatus = ProductStatus.OutOfStock, Oops = OopsNoString.FirstValue, DateDiscontinued = new DateTime(2014,12,29)},
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M, Status = ProductStatus.InStock, OtherStoreStatus = ProductStatus.InStock, Oops = OopsNoString.SecondValue},
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M, Status = ProductStatus.InStock, OtherStoreStatus = ProductStatus.InStock, Oops = OopsNoString.FirstValue}
        };

        /// <summary>
        /// Documentation for method
        /// this is on multiple
        /// line
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        [ResponseType(typeof(IEnumerable<Product>))]
        [Route("api/products/")]
        public IHttpActionResult GetProductByStatus(ProductStatus status)
        {
            return Ok(_products.Where(i => i.Status == status));
        }

        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            var product = _products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }


    }
}
