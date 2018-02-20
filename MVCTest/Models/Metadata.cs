using System;
using System.ComponentModel.DataAnnotations;

namespace MVCTest.Models
    {
    [MetadataType(typeof(departamenteMetadata))]
    public partial class departamente { }

    [MetadataType(typeof(proiecteMetadata))]
    public partial class proiecte { }

    [MetadataType(typeof(angajatiMetadata))]
    public partial class angajati { }

    public class departamenteMetadata
        {
        [Display(Name = "Nume Departament")]
        [Required(ErrorMessage = "Introduceti un nume de departament!")]
        [RegularExpression("(?!^Departament nou$)\\w[\\w ]*", ErrorMessage = "Nume incorect")]
        public string nume { get; set; }
        }

    public class proiecteMetadata
        {
        [Display (Name = "Nume Proiect")]
        [Required (ErrorMessage = "Introduceti un nume de proiect!")]
        [RegularExpression ("(?!^Proiect nou$)\\w[\\w ]*", ErrorMessage = "Nume incorect!")]
        public string nume { get; set; }
        }

    public class angajatiMetadata
        {
        
        [Display (Name = "Nume")]
        public string nume { get; set; }

        [Display (Name = "Prenume")]
        public string prenume { get; set; }

        [Display (Name = "Data Angajarii")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime data { get; set; }
        }

    }