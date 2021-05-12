using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nomina2018.Models
{
    public class RegistroPago: ObjetoNomina
    {
        public int Id { get; set; }
        public DateTime FechaInicioRango { get; set; }
        public DateTime FechaFinalRango { get; set; }

        public int EmpleadoId { get; set; }

        public virtual Empleado Empleado { get; set; }

        public float IngresoTotal()
        {
            return SueldoNeto + Apoyo;
        }

        public float DescuentoTotal()
        {
            return ISR + Seguro;
        }

        public float TotalPago()
        {
            return IngresoTotal() - DescuentoTotal();
        }


    }
}