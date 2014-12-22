using System.Runtime.InteropServices;

namespace Swagger.WebApiProxy.Core.Models
{
    public class Property
    {
        public Property(string typeName, string name)
        {
            TypeName = typeName;
            Name = name;
        }

        public string Name { get; set; }
        public string TypeName { get; set; }
    }
}