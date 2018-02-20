using MVCTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTest.Controllers
{
    public class DetaliiController : Controller
    {
        businessdbEntities db = new businessdbEntities();
        public ActionResult Index(int id)
            {
            var query_angajati = from a in db.angajati
                        select a.nume + " " + a.prenume;

            ViewBag.angajati = new SelectList(query_angajati.ToList());

            var query_departamente = from d in db.departamente
                           select d.nume;

            ViewBag.departamente = query_departamente.ToList();

            departamente departament = db.departamente.Find(id);

            DetaliiViewModel model = new DetaliiViewModel(departament);

            return View(model);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificaDepartament([Bind (Include = "id, nume")] DetaliiViewModel model)
            {

            if (ModelState.IsValid)
                {
                departamente departament = db.departamente.Find(model.id);
                departament.nume = model.nume;
                db.SaveChanges();
                }

            return RedirectToAction("Index", new { model.id });
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Transfera(int id, FormCollection form)
            {
            string nume = form["angajati"].ToString();

            foreach (angajati angajat in db.angajati)
                {
                if (nume == angajat.nume + " " + angajat.prenume)
                    {
                    angajat.depid = id;
                    departamente dep = db.departamente.Find(id);
                    dep.angajati.Add(angajat);                   
                    break;
                    }
                }

            db.SaveChanges();
            return RedirectToAction("Index", new { id });
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Angajeaza ( DetaliiViewModel model)
            {
            if (ModelState.IsValid)
                {
                angajati angjat_nou = new angajati();

                angjat_nou.nume = model.nume_angajat;
                angjat_nou.prenume = model.prenume_angajat;
                angjat_nou.conducere = false;
                angjat_nou.depid = model.id;
                angjat_nou.data = DateTime.Now;

                db.angajati.Add(angjat_nou);
                db.SaveChanges();
                }

            return RedirectToAction("Index", new { model.id });
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Concediaza (int id, int proid)
            {
            db.delete_angajat(id);

            return RedirectToAction("Index", new { id = proid });
            }

        public ActionResult FindId (string nume)
            {
            var query_id = from d in db.departamente
                          where d.nume == nume
                          select d.id;

            return RedirectToAction("Index", new { id = query_id.First() });
            }
        }
}