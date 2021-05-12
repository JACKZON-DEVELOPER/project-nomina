using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nomina2018.Models
{
    public class TabuladorSueldo: ObjetoNomina
    {
        public int Id { get; set; }

        [ForeignKey("Empleado")]
        public int EmpleadoId { get; set; }

        public Empleado Empleado { get; set; }



      
    }
}