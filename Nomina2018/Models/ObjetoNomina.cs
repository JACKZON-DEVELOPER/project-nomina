using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nomina2018.Models
{
    public abstract class ObjetoNomina
    {
        // ingresos
        [Required]
        [Display(Name = "Sueldo Neto")]
        public double SueldoNeto { get; set; }
        [Required]
        [Display(Name = "Apoyo")]
        public double Apoyo { get; set; }

        //descuento
        [Required]
        [Display(Name ="ISR")]
        public double ISR { get; set; }
        [Required]
        [Display(Name = "Seguro")]
        public double Seguro { get; set; }

      
    }
}