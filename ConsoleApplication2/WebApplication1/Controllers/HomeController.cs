using ConsoleApplication2;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    
    public class HomeController : Controller
    {
        [Import(typeof(ILogger))]
        public ILogger logger { get; set; }

        public HomeController()
        {
            string assemblyPath = "C:\\Users\\Алексей\\Documents\\GitHub\\.NETLabs2018\\ConsoleApplication2\\DateLoggerAssembly\\bin\\Debug\\DateLoggerAssembly.dll";
            var container = new CompositionContainer(new AssemblyCatalog(Assembly.LoadFile(assemblyPath)));
            container.ComposeParts(this);

        }
        public ActionResult Index()
        {
            logger.Log("Hello");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}