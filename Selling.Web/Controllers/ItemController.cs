using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace Selling.Web.Controllers
{
    public class ItemController : Controller
    {
        //
        // GET: /Item/
        Repo.tblItemRepo serviceItem = new Repo.tblItemRepo();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ViewModel.tblItem mode)
        {
            if (ModelState.IsValid)
            {
                string sp = " spomaxiditem ";
                DataSet data = Commonly.Common.ExecuteDataSet(sp);
                int id = data.Tables[0].Rows[0].Field<int>("MaxID");
                mode.tblItemID = id+1;
                if (serviceItem.Create(mode))
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

        [HttpPost]
        public ActionResult Update(ViewModel.tblItem mode)
        {
            if (ModelState.IsValid)
            {
                if (serviceItem.Update(mode))
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
        public ActionResult Delete(string kodeItem)
        {
            if (ModelState.IsValid)
            {
                if (serviceItem.Delete(kodeItem))
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