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

        // GET: HomePage
        public ActionResult Index()
            {
            Models.HomePageViewModel mod = new Models.HomePageViewModel();
            mod.departamente = db.departamente.ToList();
            mod.proiecte = db.proiecte.ToList();
            return View(mod);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete (Models.departamente dep)
            {
            if (dep.angajati.Count() == 0)
                {
                Models.departamente d = db.departamente.Find(dep.id);
                db.departamente.Remove(d);
                db.SaveChanges();
                }
            return RedirectToAction("Index");
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (Models.departamente dep)
            {
            db.departamente.Add(dep);
            db.SaveChanges();
            return RedirectToAction("Index");
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProiect(Models.proiecte pro)
            {
            db.delete_proiect(pro.id);
            return RedirectToAction("Index");
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProiect (Models.proiecte pro)
            {
            db.proiecte.Add(pro);
            db.SaveChanges();
            return RedirectToAction("Index");
            }

        }
}