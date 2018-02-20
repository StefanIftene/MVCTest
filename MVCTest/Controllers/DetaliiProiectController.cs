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
            Models.proiecte proiect = db.proiecte.Find(id);
            Models.DetaliiProiectViewModel mod = new Models.DetaliiProiectViewModel(proiect);

            var query = from p in db.proiecte
                        select p.nume;

            ViewBag.proiecte = query.ToList();

            return View(mod);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modifica (Models.DetaliiProiectViewModel model)
            {
            if (ModelState.IsValid)
                {
                int id = model.id;
                Models.proiecte pro = db.proiecte.Find(id);
                pro.nume = model.nume;
                db.SaveChanges();
                }
            return RedirectToAction("Index", new { model.id });
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

            return RedirectToAction("Index", new { id = proid });
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