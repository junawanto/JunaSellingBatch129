using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Selling.Repo;
using Selling.ViewModel;

namespace Selling.Web.Controllers
{
    public class LoginController : Controller
    {
        MstUserRepo serviceUser = new MstUserRepo();
        //
        // GET: /Login/
        public ActionResult Index()
        {
            //Session["Username"] = "Juna";
            return View();
        }

        [HttpPost]
        public ActionResult Login(MstUserViewModel dataLogin)
        {
            var modelUser = serviceUser.GetAll(dataLogin);
            if (modelUser.Count == 0)
            {
                ViewBag.error = "Username atau Password salah";
                return View("Index"); // index yang atas
            }
            else
            {
                if (modelUser[0].Active.ToString() == "True")//modelUser[0] karena di bikin ToList. Active karena bentuknya boolean
                {
                    Session["Username"]=modelUser[0].Username;
                    Session["Role"] = modelUser[0].Username;
                    Session["EmployeeName"] = modelUser[0].officerName;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
            //return RedirectToAction("Index", "Home");
        }
	}
}