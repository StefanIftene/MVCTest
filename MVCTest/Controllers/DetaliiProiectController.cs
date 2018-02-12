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
            return View(mod);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modifica (Models.DetaliiProiectViewModel model)
            {
            int id = model.proiect.id;
            Models.proiecte pro = db.proiecte.Find(id);
            pro.nume = model.proiect.nume;
            db.SaveChanges();
            return RedirectToAction("Index", new { id = id });
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Schimbari(Models.DetaliiProiectViewModel model)
            {
            int proid = model.proiect.id;

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
        }
}