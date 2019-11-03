using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebSiteClient.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LineProduct()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }
        public IActionResult Customer()
        {
            return View();
        }
        public IActionResult Supplier()
        {
            return View();
        }

    }
}