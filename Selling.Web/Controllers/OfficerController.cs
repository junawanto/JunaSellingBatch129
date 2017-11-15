using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Selling;
using System.Data;

namespace Selling.Web.Controllers
{
    public class OfficerController : Controller
    {
        //
        // GET: /Officer/
        Repo.tblOfficerRepo serviceOfficer = new Repo.tblOfficerRepo();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(ViewModel.tblOfficer mode)
        {
            if (ModelState.IsValid) // client ke server = valid
            {
                string sp = " spomaxidofficer ";
                DataSet data = Commonly.Common.ExecuteDataSet(sp);
                int id = data.Tables[0].Rows[0].Field<int>("MaxID");
                mode.tblOfficerID = id+1;
                if (serviceOfficer.Create(mode))
                {
                    return Json(new {pesan = "Sukses" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { pesan = "Gagal!" }, JsonRequestBehavior.AllowGet);
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult Update(ViewModel.tblOfficer mode)
        {
            if (ModelState.IsValid)
            {
                if (serviceOfficer.Update(mode))
                {
                    return Json(new { pesan = "Sukses" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { pesan = "Gagal!" }, JsonRequestBehavior.AllowGet);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(string kodeOfficer)
        {
            if (ModelState.IsValid)
            {
                if (serviceOfficer.Delete(kodeOfficer))
                {
                    return Json(new { pesan = "Sukses" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { pesan = "Gagal!" }, JsonRequestBehavior.AllowGet);
                }
            }
            return View();
        }
	}
}