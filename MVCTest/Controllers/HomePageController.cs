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
            ViewBag.Title = "Home";
            if (chk == 1)
                ViewBag.chk = true;
            else ViewBag.chk = false;

            return View();
            }

        public ActionResult Departamente ()
            {
            Models.DepartamentePVM model = new Models.DepartamentePVM();
            model.departamente = db.departamente.ToList();

            return PartialView("_Departamente", model);
            }

        public ActionResult Proiecte()
            {
            Models.ProiectePVM model = new Models.ProiectePVM();
            model.proiecte = db.proiecte.ToList();

            return PartialView("_Proiecte", model);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDepartament (Models.departamente dep)
            {
            Models.departamente d = db.departamente.Find(dep.id);

            if (d.angajati.Count() == 0)
                {
                db.departamente.Remove(d);
                db.SaveChanges();
                }
            return RedirectToAction("Departamente");
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDepartament ( Models.DepartamentePVM model)
            {
            if (ModelState.IsValid)
                {
                Models.departamente dep = new Models.departamente();
                dep.nume = model.newdepname;
                db.departamente.Add(dep);
                db.SaveChanges();
                }

            return RedirectToAction("Departamente");
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProiect (Models.proiecte pro)
            {
            db.delete_proiect(pro.id);
            return RedirectToAction("Proiecte");
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProiect ( Models.ProiectePVM model)
            {
            if (ModelState.IsValid)
                {
                Models.proiecte pro = new Models.proiecte();
                pro.nume = model.newproname;
                db.proiecte.Add(pro);
                db.SaveChanges();
                }

            return RedirectToAction("Proiecte");
            }
            
        }
}