using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// Swagger Petstore
// A sample API that uses a petstore as an example to demonstrate features in the swagger-2.0 specification
public class SwaggerPetstoreWebProxy
{
    // URL: /pets
    // Method: get
    public async Task<List<pet>> findPets()
    {
        throw new NotImplementedException();
    }

    // URL: /pets
    // Method: post
    public async Task<pet> addPet()
    {
        throw new NotImplementedException();
    }

    // URL: /pets/{id}
    // Method: get
    public async Task<pet> findPetById()
    {
        throw new NotImplementedException();
    }

    // URL: /pets/{id}
    // Method: delete
    public async Task deletePet()
    {
        throw new NotImplementedException();
    }




    /// note
    public class pet
    {
        public long id { get; set; }
        public string name { get; set; }
        public string tag { get; set; }
    }

    /// note
    public class newPet : pet
    {
        public long id { get; set; }
    }

    /// note
    public class errorModel
    {
        public int code { get; set; }
        public string message { get; set; }
    }

}

