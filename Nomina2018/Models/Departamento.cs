using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nomina2018.Models
{
    public class Departamento
    {
        public int Id { get; set; }

        [Display(Name = "Departamento")]
        public string Nombre { get; set; }

        public virtual List<Empleado> Empleados { get; set; }
    }
}