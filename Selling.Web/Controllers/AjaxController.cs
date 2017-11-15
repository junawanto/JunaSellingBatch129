using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Selling.Repo;
namespace Selling.Web.Controllers
{
    public class AjaxController : Controller
    {
        tblOfficerRepo serviceOfficer = new tblOfficerRepo();
        tblItemRepo serviceItem = new tblItemRepo();
        tblSellingRepo serviceselling = new tblSellingRepo();
        //
        // GET: /Ajax/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetListOfficer()
        {

            return PartialView("_GetListOfficer",serviceOfficer.GetAll());
        }

        public ActionResult GetListItem()
        {

            return PartialView("_GetListItem", serviceItem.GetAll());
        }

        public ActionResult GetListSelling()
        {
            return PartialView("_GetListSelling", serviceselling.GetAll());
        }

        public ActionResult AddDataOfficer()
        {
            return PartialView("_AddDataOfficer");
        }

        public ActionResult EditDataOfficer(string code)
        {
            return PartialView("_EditDataOfficer", serviceOfficer.GetById(code));
        }
	}
}