namespace Swagger.WebApiProxy.Core.Models
{
    public class Parameter
    {
        public string TypeName { get; set; }
        public string Name { get; set; }
        public ParameterIn ParameterIn { get; set; }
        public bool IsRequired { get; set; }

        public Parameter(string typeName, string name, ParameterIn parameterIn, bool isRequired)
        {
            TypeName = typeName;
            Name = name;
            ParameterIn = parameterIn;
            IsRequired = isRequired;
        }
    }
}