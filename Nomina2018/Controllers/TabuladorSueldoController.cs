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
    public class TabuladorSueldoController : Controller
    {
        private ConeccionContext db = new ConeccionContext();

        // GET: TabuladorSueldo
        public ActionResult Index()
        {
            var tabuladorSueldos = db.TabuladorSueldos.Include(t => t.Empleado);
            return View(tabuladorSueldos.ToList());
        }

        // GET: TabuladorSueldo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabuladorSueldo tabuladorSueldo = db.TabuladorSueldos.Find(id);
            if (tabuladorSueldo == null)
            {
                return HttpNotFound();
            }
            return View(tabuladorSueldo);
        }

        // GET: TabuladorSueldo/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Empleados, "Id", "NumeroEmpleado");
            return View();
        }

        // POST: TabuladorSueldo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SueldoNeto,Apoyo,ISR,Seguro")] TabuladorSueldo tabuladorSueldo)
        {
            if (ModelState.IsValid)
            {
                db.TabuladorSueldos.Add(tabuladorSueldo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Empleados, "Id", "NumeroEmpleado", tabuladorSueldo.Id);
            return View(tabuladorSueldo);
        }

        // GET: TabuladorSueldo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabuladorSueldo tabuladorSueldo = db.TabuladorSueldos.Find(id);
            if (tabuladorSueldo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Empleados, "Id", "NumeroEmpleado", tabuladorSueldo.Id);
            return View(tabuladorSueldo);
        }

        // POST: TabuladorSueldo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SueldoNeto,Apoyo,ISR,Seguro")] TabuladorSueldo tabuladorSueldo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabuladorSueldo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Empleados, "Id", "NumeroEmpleado", tabuladorSueldo.Id);
            return View(tabuladorSueldo);
        }

        // GET: TabuladorSueldo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabuladorSueldo tabuladorSueldo = db.TabuladorSueldos.Find(id);
            if (tabuladorSueldo == null)
            {
                return HttpNotFound();
            }
            return View(tabuladorSueldo);
        }

        // POST: TabuladorSueldo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TabuladorSueldo tabuladorSueldo = db.TabuladorSueldos.Find(id);
            db.TabuladorSueldos.Remove(tabuladorSueldo);
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
