using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTest.Models
    {
    public class DetaliiViewModel: departamente
        {
        [RegularExpression("(?!^Nume$)[A-Z][a-z]*")]
        public string nume_angajat { get; set; }

        [RegularExpression("(?!^Prenume$)[A-Z][a-z]*")]
        public string prenume_angajat { get; set; }

        public DetaliiViewModel (departamente dep)
            {
            nume_angajat = "Nume";
            prenume_angajat = "Prenume";
            id = dep.id;
            nume = dep.nume;
            angajati = dep.angajati;
            }

        public DetaliiViewModel() { }
        }
    }