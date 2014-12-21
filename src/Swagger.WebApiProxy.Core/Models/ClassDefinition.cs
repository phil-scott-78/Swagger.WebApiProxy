using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swagger.WebApiProxy.Core.Models
{
    public class ClassDefinition
    {
        public ClassDefinition(string name)
        {
            Name = name;
            Properties = new List<Property>();
        }

        public string Name { get; set; }
        public List<Property>  Properties { get; set; }
    }
}
