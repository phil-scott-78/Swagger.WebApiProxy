using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swagger.WebApiProxy.Core.Models;

namespace Swagger.WebApiProxy.Core
{
    public class SwaggerParser
    {
        public ProxyDefinition ParseSwaggerDoc(string document)
        {
            var jObject = JObject.Parse(document);

            var proxyDefinition = new ProxyDefinition();
            ParsePaths(jObject, proxyDefinition);
            ParseDefinitions(jObject, proxyDefinition);

            return proxyDefinition;
        }

        private void ParsePaths(JObject jObject, ProxyDefinition proxyDefinition)
        {
            foreach (var pathToken in jObject["paths"].Cast<JProperty>())
            {
                var path = pathToken.Name;
                foreach (var operationToken in pathToken.First.Cast<JProperty>())
                {
                    var method = operationToken.Name;

                    var schema = operationToken.First["responses"]["200"];
                    var returnType = GetTypeName(schema);

                    var parameters = new List<Parameter>();
                    var paramTokens = operationToken.First["parameters"];
                    if (paramTokens != null)
                    {
                        foreach (var prop in paramTokens)
                        {
                            var typeName = GetTypeName(prop);
                            var name = prop["name"].ToString();
                            var parameterIn = prop["in"].ToString().Equals("path") ? ParameterIn.Path : ParameterIn.Body;
                            var isRequired = prop["required"].ToObject<bool>();
                            parameters.Add(new Parameter(typeName, name, parameterIn, isRequired));
                        }
                    }

                    proxyDefinition.Operations.Add(new Operation(returnType, method, path, parameters));
                }
            }
        }

        private void ParseDefinitions(JObject jObject, ProxyDefinition proxyDefinition)
        {
            foreach (var definitionToken in jObject["definitions"].Where(i => i.Type == JTokenType.Property).Cast<JProperty>())
            {
                var classDefinition = new ClassDefinition(definitionToken.Name);
                var properties = definitionToken.Value["properties"];
                foreach (var prop in properties)
                {
                    var typeName = GetTypeName(prop.First);
                    var name = ((JProperty) prop).Name;
                    classDefinition.Properties.Add(new Property(typeName, name));
                }

                proxyDefinition.ClassDefinitions.Add(classDefinition);
            }
        }

        internal string ParseRef(string input)
        {
            return input.StartsWith("#/definitions/") ? input.Substring("#/definitions/".Length) : input;
        }

        internal string GetTypeName(JToken token)
        {
            var refType  =token["$ref"] as JValue;
            if (refType != null)
            {
                return ParseRef(refType.Value.ToString());
            }

            var schema = token["schema"];
            if (schema != null)
            {
                return GetTypeName(schema);
            }

            var type = token["type"] as JValue;
            if (type == null)
                return null;

            if (type.Value.Equals("boolean"))
            {
                return "bool";
            }
            if (type.Value.Equals("string"))
            {
                var format = token["format"] as JValue;
                if (format == null)
                    return "string";

                if (format.Value.Equals("date") || format.Value.Equals("date-time"))
                    return "DateTime";

                if (format.Value.Equals("byte"))
                    return "byte";

                return "string";
            }

            if (type.Value.Equals("integer"))
            {
                var format = token["format"] as JValue;
                if (format != null)
                {
                    if (format.Value.Equals("int32"))
                        return "int";

                    if (format.Value.Equals("int64"))
                        return "long";
                }

                return "int";
            }

            if (type.Value.Equals("number"))
            {
                var format = token["format"] as JValue;
                if (format != null)
                {
                    if (format.Value.Equals("float"))
                        return "float";

                    if (format.Value.Equals("double"))
                        return "long";
                }
            }

            if (type.Value.Equals("array"))
            {
                var jToken = token["items"];
                return string.Format("List<{0}>", GetTypeName(jToken));
            }

            return "";
        }
    }
}
