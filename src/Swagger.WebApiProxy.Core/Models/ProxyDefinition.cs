using System.Collections.Generic;

namespace Swagger.WebApiProxy.Core.Models
{
    public class ProxyDefinition
    {
        public ProxyDefinition()
        {
            ClassDefinitions = new List<ClassDefinition>();
            Operations = new List<Operation>();
        }

        public List<ClassDefinition> ClassDefinitions { get; set; }
        public List<Operation> Operations { get; set; }
    }
}