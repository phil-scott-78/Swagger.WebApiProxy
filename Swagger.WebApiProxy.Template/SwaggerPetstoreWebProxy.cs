
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// Swagger Petstore
// A sample API that uses a petstore as an example to demonstrate features in the swagger-2.0 specification
public class SwaggerPetstoreWebProxy
{
    // URL: /pets
    // Method: GET
    public async Task<List<pet>> findPets(List<string> tags, int limit)
    {
        throw new NotImplementedException();
    }

    // URL: /pets
    // Method: POST
    public async Task<pet> addPet(newPet pet)
    {
        throw new NotImplementedException();
    }

    // URL: /pets/{id}
    // Method: GET
    public async Task<pet> findPetById(long id)
    {
        throw new NotImplementedException();
    }

    // URL: /pets/{id}
    // Method: DELETE
    public async Task deletePet(long id)
    {
        throw new NotImplementedException();
    }

    public class pet
    {
        public long id { get; set; }
        public string name { get; set; }
        public string tag { get; set; }
    }

    public class newPet : pet
    {
        public long id { get; set; }
    }

    public class errorModel
    {
        public int code { get; set; }
        public string message { get; set; }
    }

}


