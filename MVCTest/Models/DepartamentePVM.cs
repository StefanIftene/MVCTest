using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCTest.Models
    {
    public class DepartamentePVM
        {
        public List<departamente> departamente { get; set; }

        [Required(ErrorMessage = "Introduceti un nume de departament!")]
        [RegularExpression("(?!^Departament nou$)\\w[\\w ]*", ErrorMessage = "Nume incorect")]
        public string newdepname { get; set; }

        public DepartamentePVM()
            {
            departamente = new List<departamente>();
            newdepname = "Departament";
            }
        }
    }