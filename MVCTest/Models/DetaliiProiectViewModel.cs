using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MVCTest.Models
    {
    public class angajatcheck
        {
        public int id { get; set; }
        public bool check { get; set; }
        public string nume { get; set; }
        
        public angajatcheck()
            { }
        }
    public class DetaliiProiectViewModel: proiecte
        {
        public angajatcheck[] totiangajatii { get; set; }

        public DetaliiProiectViewModel(proiecte pro)
            {

            businessdbEntities db = new businessdbEntities();
            int count = (from a in db.angajati select a).Count();
            totiangajatii = new angajatcheck[count];

            id = pro.id;
            nume = pro.nume;
            int i = 0;

            foreach (angajati a in db.angajati)
                {
                angajatcheck ang = new angajatcheck();
                ang.id = a.id;
                ang.nume = a.nume + " " + a.prenume;

                if (chk(a.id, id))
                    {
                    ang.check = true;
                    }

                else
                    {
                    ang.check = false;
                    }
                totiangajatii[i] = ang;
                i++;
                }
            }

        public DetaliiProiectViewModel() { }

        public static bool chk (int angid, int proid)
            {
            businessdbEntities db = new businessdbEntities();
            angajati ang = db.angajati.Find(angid);
       
            proiecte proiect = ang.proiecte.Where(p => p.id == proid).FirstOrDefault();
            if (proiect != null)
                return true;
            return false;
            }
        }
    }