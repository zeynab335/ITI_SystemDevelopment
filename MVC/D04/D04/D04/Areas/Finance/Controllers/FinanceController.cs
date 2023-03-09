using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace D04.Areas.Finance.Controllers

{
    [HandleError(View = "ErrorViewPage")]
    public class FinanceController : Controller
    {
        // GET: Finance/Finance
        public ActionResult Index()
        {
            string c = "yyyy";
            int x = Convert.ToInt32(c);

            return View();
        }
    }
}