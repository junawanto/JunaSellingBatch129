using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Selling.Web.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["Username"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new {controller = "Login", action ="Index" }));
            }
            base.OnActionExecuting(filterContext);
        }
	}
}