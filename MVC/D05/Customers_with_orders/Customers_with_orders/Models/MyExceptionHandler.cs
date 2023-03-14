using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Customers_with_orders.Models
{
    public class MyExceptionHandler : HandleErrorAttribute //FilterAttribute, IExceptionFilter
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //if (filterContext.ExceptionHandled || filterContext.HttpContext.IsCustomErrorEnabled == true)
            //{
            //    //if(filterContext.RouteData.Values.)
            //}

            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };

            base.OnException(filterContext);
        }
    }
}