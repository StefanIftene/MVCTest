using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTest.Models
    {
    public class ProiectePVM
        {
        public List<proiecte> proiecte { get; set; }

        [Required(ErrorMessage = "Introduceti un nume de proiect!")]
        [RegularExpression("(?!^Proiect nou$)\\w[\\w ]*", ErrorMessage = "Nume incorect")]
        public string newproname { get; set; }

        public ProiectePVM()
            {
            proiecte = new List<proiecte>();
            newproname = "Proiect";
            }
        }
    }