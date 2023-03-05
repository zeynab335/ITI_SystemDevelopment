using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

  
        public ActionResult ViewDetails(string id , string name, string imgNumber)
        {
            ViewBag.id = id;
            ViewBag.name = name;
            ViewBag.imgNumber = "../../images/" + imgNumber?.ToString() + ".jpg";

            return View();
        }
    }
}