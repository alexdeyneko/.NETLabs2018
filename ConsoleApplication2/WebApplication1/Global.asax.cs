using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.IO;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            string assemblyName = "DateLoggerAssembly";
            string path =
                Directory.GetParent((Server.MapPath("~"))).Parent.FullName + @"\" + assemblyName + @"\bin\Debug\" + assemblyName + ".dll";

            AssemblyCatalogLoader.LoadAssemblyCatalog(path);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
    }

    public static class AssemblyCatalogLoader
    {
        public static AssemblyCatalog Catalog { get; set; }
        public static void LoadAssemblyCatalog(string path)
        {
           
            Catalog = new AssemblyCatalog(Assembly.LoadFile(path));
        }
    }
    
}
