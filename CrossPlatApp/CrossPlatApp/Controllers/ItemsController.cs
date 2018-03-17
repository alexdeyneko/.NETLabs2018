using System.Collections.Generic;
using System.Linq;
using CrossPlatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CrossPlatApp.Controllers
{
    public class ItemsController : Controller
    {        
        [ResponseCache(Duration = 60)]
        [HttpGet]        
        public ActionResult Index(int id)
        {            
            return View(Data.GetItemById(id));
        }
    }
}