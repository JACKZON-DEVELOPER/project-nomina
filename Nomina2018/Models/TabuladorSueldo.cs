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
        [Required]
        [ForeignKey("Empleado")]
        public int Id { get; set; }
        
        public virtual Empleado Empleado { get; set; }




    }
}