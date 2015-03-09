using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Demo;
using Petstore;

namespace Swagger.WebApiProxy.Demo.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            petWebProxy petstoreWebProxy = new petWebProxy(new Uri("http://petstore.swagger.io/v2/swagger.json"));

            try
            {
                var petById = petstoreWebProxy.getPetById(1).Result;
                Console.WriteLine(petById.name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            petstoreWebProxy.updatePetWithForm("1", "fido", "hmmm").Wait();

            var result = petstoreWebProxy.findPetsByStatus(new List<petWebProxy.findPetsByStatusstatus>{petWebProxy.findPetsByStatusstatus.available}).Result;

            try
            {
                var petByIdWithError = petstoreWebProxy.getPetById(11).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }



            var valuesWebProxy = new ValuesWebProxy(new Uri("http://localhost:54076/"));
            var allTheDataTypes = valuesWebProxy.GetDataTypesAsync().Result;

            var productsWebProxy = new ProductsWebProxy(new Uri("http://localhost:54076/"));
            try
            {
                var kablamResult = productsWebProxy.KablamAsync().Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadLine();
        }
    }
}
