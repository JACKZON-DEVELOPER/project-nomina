using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nomina2018.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual List<Empleado> Empleados { get; set; }
    }
}