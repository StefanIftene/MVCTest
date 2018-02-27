using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Controllers
{
    public class DetaliiProiectController : Controller
    {
        Models.businessdbEntities db = new Models.businessdbEntities();
        public ActionResult Index(int id)
            {
            var query_name = from p in db.proiecte
                             where p.id == id
                             select p.nume;
            ViewBag.Title = query_name.ToList().FirstOrDefault();

            var query_proiecte = from p in db.proiecte
                        select p.nume;

            ViewBag.proiecte = query_proiecte.ToList();
            ViewBag.Id = id;

            return View();
            }

        public ActionResult Content (int id)
            {
            Models.proiecte proiect = db.proiecte.Find(id);
            Models.DetaliiProiectViewModel model = new Models.DetaliiProiectViewModel(proiect);

            return PartialView("_Content", model);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Modifica (Models.DetaliiProiectViewModel model)
            {
            int id = model.id;
            Models.proiecte pro = db.proiecte.Find(id);

            if (ModelState.IsValid)
                {
                pro.nume = model.nume;
                db.SaveChanges();
                }

            else model.nume = pro.nume;

            return model.nume;
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Schimbari(Models.DetaliiProiectViewModel model)
            {
            int proid = model.id;

            for (int i = 0; i < model.totiangajatii.Count(); i++)
                {
                int id = model.totiangajatii[i].id;
                if (model.totiangajatii[i].check && !Models.DetaliiProiectViewModel.chk(id, proid))
                    {
                    db.plusproiect(id, proid);
                    }
                else if (!model.totiangajatii[i].check && Models.DetaliiProiectViewModel.chk(id, proid))
                    {
                    db.minusproiect(id, proid);
                    }
                }

            return RedirectToAction("Content", new { id = proid });
            }

        public ActionResult FindId(string nume)
            {
            var idquery = from p in db.proiecte
                          where p.nume == nume
                          select p.id;

            int proid = idquery.First();

            return RedirectToAction("Index", new { id = proid });
            }
        }
}