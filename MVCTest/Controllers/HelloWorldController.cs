using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public ActionResult Index()
            {
            return View();
            }

        // 
        // GET: /HelloWorld/Welcome/ 

        public ActionResult Welcome(string s)
            {
            ViewBag.Message = "This is the Welcome action method..." + s;
            return View();
            }
        }
}