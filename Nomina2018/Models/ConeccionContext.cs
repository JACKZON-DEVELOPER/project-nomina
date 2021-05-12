using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Nomina2018.Models
{
    public class ConeccionContext: DbContext
    {
        public ConeccionContext(): base("name=ConeDB")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Empleado>()
              .HasRequired(t => t.TabuladorSueldo)
              .WithRequiredPrincipal(e => e.Empleado);
            // throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<TabuladorSueldo> TabuladorSueldos { get; set; }
        public virtual DbSet<RegistroPago> RegistroPagos { get; set; }
    }
}