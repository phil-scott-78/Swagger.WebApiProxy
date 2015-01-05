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
            PetWebProxy petstoreWebProxy = new PetWebProxy(new Uri("http://petstore.swagger.wordnik.com/v2/"));
            var petById = petstoreWebProxy.GetPetById(1).Result;
            Console.WriteLine(petById.name);

            petstoreWebProxy.UpdatePetWithForm("1", "fido", "hmmm").Wait();

            var result = petstoreWebProxy.FindPetsByStatus(new List<string> {"string"}).Result;

            try
            {
                var petByIdWithError = petstoreWebProxy.GetPetById(11).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();
        }
    }
}
