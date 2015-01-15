using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Swagger.WebApiProxy.Demo.WebApi.Models;

namespace Swagger.WebApiProxy.Demo.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("api/values/search")]
        public IEnumerable<string> Get([FromUri] int[] query)
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        [Route("api/products/lookup")]
        [ResponseType(typeof(LookupObjectList<ValueLookup>))]
        public IHttpActionResult LookupList()
        {
            var list = new List<ValueLookup>
            {
                new ValueLookup(){Id = 1, Value = "One"},
                new ValueLookup(){Id = 2, Value = "Two"},
            };

            var lookupList = new LookupObjectList<ValueLookup>(list);
            return Ok(lookupList);
        }
    }
}