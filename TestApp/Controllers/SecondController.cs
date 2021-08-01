using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApp.Controllers
{
    public class SecondController : Controller
    {
        // GET: Second
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Second()
        {
            ViewBag.Message = "This is the SecondController";
            return View();
        }
    }
}