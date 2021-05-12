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
    public class RegistroPagoController : Controller
    {
        private ConeccionContext db = new ConeccionContext();

        // GET: RegistroPago
        public ActionResult Index()
        {
            var registroPagos = db.RegistroPagos.Include(r => r.Empleado);
            return View(registroPagos.ToList());
        }

        // GET: RegistroPago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroPago registroPago = db.RegistroPagos.Find(id);
            if (registroPago == null)
            {
                return HttpNotFound();
            }
            return View(registroPago);
        }

        // GET: RegistroPago/Create
        public ActionResult Create()
        {
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "Nombre");
            return View();
        }

        // POST: RegistroPago/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FechaInicioRango,FechaFinalRango,EmpleadoId,SueldoNeto,Apoyo,ISR,Seguro")] RegistroPago registroPago)
        {
            if (ModelState.IsValid)
            {
                db.RegistroPagos.Add(registroPago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "NumeroEmpleado", registroPago.EmpleadoId);
            return View(registroPago);
        }

        // GET: RegistroPago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroPago registroPago = db.RegistroPagos.Find(id);
            if (registroPago == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "NumeroEmpleado", registroPago.EmpleadoId);
            return View(registroPago);
        }

        // POST: RegistroPago/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FechaInicioRango,FechaFinalRango,EmpleadoId,SueldoNeto,Apoyo,ISR,Seguro")] RegistroPago registroPago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroPago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpleadoId = new SelectList(db.Empleados, "Id", "NumeroEmpleado", registroPago.EmpleadoId);
            return View(registroPago);
        }

        // GET: RegistroPago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroPago registroPago = db.RegistroPagos.Find(id);
            if (registroPago == null)
            {
                return HttpNotFound();
            }
            return View(registroPago);
        }

        // POST: RegistroPago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroPago registroPago = db.RegistroPagos.Find(id);
            db.RegistroPagos.Remove(registroPago);
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
