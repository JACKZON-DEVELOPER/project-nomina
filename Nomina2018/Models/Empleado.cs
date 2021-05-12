using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nomina2018.Models
{
    public class Empleado
    {
       
        public int Id { get; set; }
        //[Display(Name = "Numero Empleado")]
        [Required]
        public string NumeroEmpleado { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Exedido el numero de caracteres para este campo")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Exedido el numero de caracteres para este campo")]
        public string ApellidoPaterno { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Exedido el numero de caracteres para este campo")]
        public string ApellidoMaterno { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        [Required]  
        [StringLength(50, ErrorMessage = "Exedido el numero de caracteres para este campo")]
        public string Direccion { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "El Numero no deve exeder los 10 caracters")]
        public string Telefono { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Exedido el numero de caracteres para este campo")]
        public string Correo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        
        // claves foranesa
        public int DepartamentoID { get; set; }


        // Navegacion 
        public virtual Departamento Departamento { get; set; }
        public virtual ICollection<RegistroPago> PagoSueldos { get; set; }
        public virtual TabuladorSueldo TabuladorSueldo { get; set; }

       
    }
}