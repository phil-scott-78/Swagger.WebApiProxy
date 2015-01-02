using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo;
using Petstore;

namespace Swagger.WebApiProxy.Demo.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var valuesWebProxy = new ValuesWebProxy(new Uri("http://localhost:54076/"));
            var result = valuesWebProxy.Get().Result;
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            var s = valuesWebProxy.Get(1).Result;
            var list = valuesWebProxy.Get(new List<int> {1, 2}).Result;
            valuesWebProxy.Post("value3").Wait();
            valuesWebProxy.Put(1, "new value 1").Wait();
            valuesWebProxy.Delete(1).Wait();
        }
    }
}
