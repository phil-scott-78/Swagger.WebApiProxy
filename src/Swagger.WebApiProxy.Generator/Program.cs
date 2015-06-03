using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Web.Http.Dispatcher;

using Microsoft.Owin;
using Microsoft.Owin.Testing;

using Owin;

namespace Swagger.WebApiProxy.Generator
{
    class Program
    {
        static int Main(string[] args)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            string assemblyFile = string.Empty;
            if (!args.Any())
            {
                Console.WriteLine("Please provide the path to the Web Api Assembly.");
                assemblyFile = Console.ReadLine();
            }

            if (string.IsNullOrWhiteSpace(assemblyFile))
            {
                Console.WriteLine("No path to the Web Api Assembly provided.  Press any key to quit.");
                Console.ReadKey();
                return 1;
            }

            Console.WriteLine("Loading Owin Web API Assembly... \n{0}", assemblyFile);
            currentDomain.AssemblyResolve += new ResolveEventHandler((source, e) => CustomResolver(source, e, assemblyFile));
            var assembly = Assembly.LoadFrom(assemblyFile);

            Type owinStartupClassType = null;
            Console.WriteLine("Locating Startup Class... \n{0}", assemblyFile);
            var startupAttribute = assembly.CustomAttributes.FirstOrDefault(x => x.AttributeType == typeof(OwinStartupAttribute));
            if (startupAttribute == null)
            {
                Console.WriteLine("Could not located OwinStartupAttribute.  Press any key to quit.");
                Console.ReadKey();
                return 1;
            }

            owinStartupClassType = (Type)startupAttribute.ConstructorArguments.First().Value;


            Console.WriteLine("Starting in memory server...");

            MethodInfo method = owinStartupClassType.GetMethod("Configuration", new Type[] { typeof(IAppBuilder) });

            //TestServer testServer = (TestServer)method.Invoke(null, new object[] { });
            dynamic owinStartupClass = Activator.CreateInstance(owinStartupClassType);
            TestServer testServer = TestServer.Create(
                builder =>
                {
                    owinStartupClass.InMemory = true;
                    owinStartupClass.Configuration(builder);
                });
            var getListResponse = testServer.HttpClient.GetAsync("/v2/core/accounts").Result;
            var responseContent = getListResponse.Content.ReadAsStringAsync();

            return 0;
        }

        static Assembly CustomResolver(object source, ResolveEventArgs e, string assemblyFile)
        {
            var name = string.Format("{0}.dll", e.Name.Split(',')[0]);
            var searchPath = string.Format("{1}\\{0}", name, Path.GetDirectoryName(assemblyFile));
            Console.WriteLine("Resolving {0}", e.Name);
            Assembly assembly = Assembly.LoadFrom(searchPath);
            return assembly;
        }
    }
}
