using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nomina2018.Models
{
    public abstract class ObjetoNomina
    {
        // ingresos
        public float SueldoNeto { get; set; }
        public float Apoyo { get; set; }

        //descuento
        public float ISR { get; set; }
        public float Seguro { get; set; }

      
    }
}