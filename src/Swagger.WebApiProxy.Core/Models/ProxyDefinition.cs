using System.Collections.Generic;

namespace Swagger.WebApiProxy.Core.Models
{
    public class ProxyDefinition
    {
        public ProxyDefinition()
        {
            ClassDefinitions = new List<ClassDefinition>();
        }

        public List<ClassDefinition> ClassDefinitions { get; set; }
    }
}