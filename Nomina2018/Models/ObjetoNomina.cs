using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nomina2018.Models
{
    public abstract class ObjetoNomina
    {
        // ingresos
        public double SueldoNeto { get; set; }
        public double Apoyo { get; set; }
       
        //descuento
        public double ISR { get; set; }
        public double Seguro { get; set; }

      
    }
}