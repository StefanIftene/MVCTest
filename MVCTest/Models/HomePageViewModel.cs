using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCTest.Models
    {
    public class HomePageViewModel
        {
        public List<departamente> departamente { get; set; }
        public List<proiecte> proiecte { get; set; }

        [Required(ErrorMessage = "Introduceti un nume de departament!")]
        [RegularExpression("(?!^Departament nou$)\\w[\\w ]*", ErrorMessage = "Nume incorect")]
        public string newdepname { get; set; }

        [Required(ErrorMessage = "Introduceti un nume de proiect!")]
        [RegularExpression("(?!^Proiect nou$)\\w[\\w ]*", ErrorMessage = "Nume incorect")]
        public string newproname { get; set; }

        public HomePageViewModel()
            {
            departamente = new List<departamente>();
            proiecte = new List<proiecte>();
            newdepname = "Departament";
            newproname = "Proiect";
            }
        }
    }