using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nomina2018.Models
{
    public class RegistroPago: ObjetoNomina
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="Fecha Inicial")]
        public DateTime FechaInicioRango { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Final")]
        public DateTime FechaFinalRango { get; set; }

        public int EmpleadoId { get; set; }

        public virtual Empleado Empleado { get; set; }

        [Display(Name = "Ingresos Totales")]
        public double IngresoTotal
        {
            get
            {
                return SueldoNeto + Apoyo;
            }
        }


        public double DescuentoTotal
        {
            get
            {
                return ISR + Seguro;
            }
            
        }

        public double TotalPago
        {
            get
            {
                return IngresoTotal - DescuentoTotal;
            }
            
        }


    }
}