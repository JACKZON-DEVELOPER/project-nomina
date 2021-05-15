using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nomina2018.Models;

namespace Nomina2018.Controllers
{
    public class EmpleadoController : Controller
    {
        private ConeccionContext db = new ConeccionContext();

        // GET: Empleado
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.NumeroSortParm = String.IsNullOrEmpty(sortOrder) ? "numero_desc" : "";
            ViewBag.DepartamentoSortParm = String.IsNullOrEmpty(sortOrder) ? "departamento_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
                  

            var empleados = db.Empleados.Include(e => e.Departamento).Include(e => e.TabuladorSueldo);


            if (!String.IsNullOrEmpty(searchString))
            {
                empleados = empleados.Where(s => s.NumeroEmpleado.Contains(searchString)
                                       || s.Nombre.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    empleados = empleados.OrderByDescending(e => e.Nombre);
                    break;
                case "numero_desc":
                    empleados = empleados.OrderByDescending(e => e.NumeroEmpleado);
                    break;
                case "departamento_desc":
                    empleados = empleados.OrderByDescending(e => e.Departamento.Nombre);
                    break;
                //case "Date":
                //    students = students.OrderBy(s => s.EnrollmentDate);
                //    break;
                //case "date_desc":
                //    students = students.OrderByDescending(s => s.EnrollmentDate);
                //    break;
                default:
                    empleados = empleados.OrderBy(e => e.ApellidoPaterno);
                    break;
            }


           
            return View(empleados.ToList());
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.DepartamentoID = new SelectList(db.Departamentos, "Id", "Nombre");
            ViewBag.Id = new SelectList(db.TabuladorSueldos, "Id", "Id");
            return View();
        }

        // POST: Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumeroEmpleado,Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Direccion,Telefono,Correo,FechaIngreso,DepartamentoID")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartamentoID = new SelectList(db.Departamentos, "Id", "Nombre", empleado.DepartamentoID);
            ViewBag.Id = new SelectList(db.TabuladorSueldos, "Id", "Id", empleado.Id);
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartamentoID = new SelectList(db.Departamentos, "Id", "Nombre", empleado.DepartamentoID);
            ViewBag.Id = new SelectList(db.TabuladorSueldos, "Id", "Id", empleado.Id);
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumeroEmpleado,Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,Direccion,Telefono,Correo,FechaIngreso,DepartamentoID")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartamentoID = new SelectList(db.Departamentos, "Id", "Nombre", empleado.DepartamentoID);
            ViewBag.Id = new SelectList(db.TabuladorSueldos, "Id", "Id", empleado.Id);
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleados.Find(id);
            db.Empleados.Remove(empleado);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
