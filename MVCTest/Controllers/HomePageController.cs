using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Controllers
{
    public class HomePageController : Controller
    {
        Models.businessdbEntities db = new Models.businessdbEntities();

        public ActionResult Index(int chk = 0, string err = "")
            {
            Models.HomePageViewModel mod = new Models.HomePageViewModel();
            mod.departamente = db.departamente.ToList();
            mod.proiecte = db.proiecte.ToList();

            ViewBag.Error = err;
            ViewBag.Title = "Home";
            if (chk == 1)
                ViewBag.chk = true;
            else ViewBag.chk = false;

            return View(mod);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (Models.departamente dep)
            {
            Models.departamente d = db.departamente.Find(dep.id);

            if (d.angajati.Count() == 0)
                {
                db.departamente.Remove(d);
                db.SaveChanges();
                }
            return RedirectToAction("Index");
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create ( Models.HomePageViewModel model)
            {
            string err = "";
            if (ModelState.IsValid)
                {
                Models.departamente dep = new Models.departamente();
                dep.nume = model.newdepname;
                db.departamente.Add(dep);
                db.SaveChanges();
                }

            else
                {
                err = ModelState.Values.First().Errors[0].ErrorMessage;
                }

            return RedirectToAction("Index", new { chk = 0, err });
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProiect(Models.proiecte pro)
            {
            db.delete_proiect(pro.id);
            return RedirectToAction("Index", new { chk = 1 });
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProiect ( Models.HomePageViewModel model)
            {
            string err = "";
            if (ModelState.IsValid)
                {
                Models.proiecte pro = new Models.proiecte();
                pro.nume = model.newproname;
                db.proiecte.Add(pro);
                db.SaveChanges();
                }

            else
                {
                err = ModelState.Values.First().Errors[0].ErrorMessage;
                }

            return RedirectToAction("Index", new { chk = 1, err });
            }

        }
}