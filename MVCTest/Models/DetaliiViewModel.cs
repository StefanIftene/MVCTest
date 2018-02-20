using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTest.Models
    {
    public class DetaliiViewModel: departamente
        {
        [Required(ErrorMessage = "Introduceti un nume!")]
        [RegularExpression("(?!^Nume$)[A-Z][a-z]*", ErrorMessage="Nume incorect")]
        public string nume_angajat { get; set; }

        [Required(ErrorMessage = "Introduceti un prenume!")]
        [RegularExpression("(?!^Prenume$)[A-Z][a-z]*", ErrorMessage="Prenume incorect")]
        public string prenume_angajat { get; set; }

        public DetaliiViewModel (departamente dep)
            {
            id = dep.id;
            nume = dep.nume;
            angajati = dep.angajati;
            }

        public DetaliiViewModel() { }
        }
    }