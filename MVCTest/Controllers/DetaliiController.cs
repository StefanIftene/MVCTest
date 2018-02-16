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
        Models.businessdbEntities db = new Models.businessdbEntities();
        public ActionResult Index(int id)
            {
            var query = from a in db.angajati
                        select a.nume + " " + a.prenume;

            ViewBag.angajati = new SelectList(query.ToList());

            var querydep = from d in db.departamente
                           select d.nume;

            ViewBag.departamente = querydep.ToList();

            Models.departamente dep = db.departamente.Find(id);
            return View(dep);
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificaDepartament(Models.departamente dep)
            {
            if (ModelState.IsValid)
                {
                db.Entry(dep).State = EntityState.Modified;
                db.SaveChanges();
                }

            return RedirectToAction("Index", new { id = dep.id });
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Transfera(int id, FormCollection form)
            {
            string nume = form["angajati"].ToString();

            foreach (Models.angajati a in db.angajati)
                {
                if (nume == a.nume + " " + a.prenume)
                    {
                    a.depid = id;
                    Models.departamente dep = db.departamente.Find(id);
                    dep.angajati.Add(a);                   
                    break;
                    }
                }

            db.SaveChanges();
            return RedirectToAction("Index", new { id = id });
            }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Angajeaza (int id, FormCollection form)
            {
            string nume = form["TextNume"].ToString();
            string prenume = form["TextPrenume"].ToString();
            Models.angajati ang = new Models.angajati();

            ang.nume = nume;
            ang.prenume = prenume;
            ang.conducere = false;
            ang.depid = id;
            ang.data = DateTime.Now;

            db.angajati.Add(ang);
            db.SaveChanges();

            return RedirectToAction("Index", new { id = id });
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
            var idquery = from d in db.departamente
                     where d.nume == nume
                     select d.id;

            int depid = idquery.First();

            return RedirectToAction("Index", new { id = depid });
            }
        }
}