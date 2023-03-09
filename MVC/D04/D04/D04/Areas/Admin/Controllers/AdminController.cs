using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace D04.Areas.Admin.Controllers
{

    [HandleError(View = "ErrorViewPage")]
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            
            int x = 5;
            int Z = x / 0;
            
            return View();
        }
    }
}