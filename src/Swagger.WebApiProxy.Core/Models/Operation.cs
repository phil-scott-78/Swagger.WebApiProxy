using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swagger.WebApiProxy.Core.Models
{
    public class Operation
    {
        public Operation(string returnType, string method, string path, List<Parameter> parameters)
        {
            Path = path;
            Method = method;
            Parameters = parameters;
            ReturnType = returnType;
        }

        public string Path { get; set; }
        public string Method { get; set; }
        public List<Parameter> Parameters { get; set; }
        public string ReturnType { get; set; }
    }
}
