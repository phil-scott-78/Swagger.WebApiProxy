using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Swagger.WebApiProxy.Core;
using Swagger.WebApiProxy.Core.Models;

namespace Swagger.WebApiProxy.Tests
{
    [TestFixture]
    public class ParsingTests
    {
        [Test]
        public void TryingStuffOut()
        {
            var petsJson = System.IO.File.ReadAllText("referenceDocs\\docs.json");
            SwaggerParser parser = new SwaggerParser();
            var proxyDefinition = parser.ParseSwaggerDoc(petsJson);
        }

        [Test]
        public void TryPetStore()
        {
            HttpClient httpClient = new HttpClient();
            var result = httpClient.GetStringAsync(
                "https://raw.githubusercontent.com/swagger-api/swagger-spec/master/examples/v2.0/json/petstore-expanded.json")
                .Result;
            SwaggerParser parser = new SwaggerParser();
            var proxyDefinition = parser.ParseSwaggerDoc(result);
        }
    }
}
