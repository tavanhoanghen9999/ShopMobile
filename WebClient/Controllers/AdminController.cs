using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
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
        public IActionResult AddLineProduct()
        {
            return View();
        }
        
        public IActionResult EditLineProduct(int? id)
        {
            int lineid = id ?? 0;
            if (lineid == 0)
            {
                return RedirectToAction("LineProduct", "admin");
            }
            else
            {
                ViewBag.lineid = lineid;
                return View();
            }
            
        }
        //hien thi customer
        public IActionResult CustomerIndex()
        {
            return View();
        }
        //them customer
        public IActionResult CustomerInsert()
        {
            return View();
        }
        //sửa laoi
        public IActionResult editCustomer()
        {
            return View();
        }

        //Hien thi nhà cung cap
        public IActionResult SupplerIndex()
        {
            return View();
        }
        public IActionResult SupplerInsert()
        {
            return View();
        }
        //product
        public IActionResult Product()
        {
            return View();
        }
        public IActionResult ProductInsert()
        {
            return View();
        }

    }
}