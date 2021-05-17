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
                TabuladorSueldo tabuladorSueldo1Def = new TabuladorSueldo();
                tabuladorSueldo1Def.Id = id.GetValueOrDefault();
                tabuladorSueldo1Def.SueldoNeto = 0;
                tabuladorSueldo1Def.Apoyo = 0;
                tabuladorSueldo1Def.ISR = 0;
                tabuladorSueldo1Def.Seguro = 0;
                return RedirectToAction("Create", tabuladorSueldo1Def);
                //return View("Create");
                // return HttpNotFound();
            }
            return View(tabuladorSueldo);
        }

        // GET: TabuladorSueldo/Create
        public ActionResult Create(int? id)
        {
            TabuladorSueldo tabuladorSueldo = new TabuladorSueldo();
            
            
            return View(tabuladorSueldo);
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
                ViewBag.Id = new SelectList(db.Empleados, "Id", "NumeroEmpleado", tabuladorSueldo.Id);
                return RedirectToAction("Details", tabuladorSueldo);
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
                return RedirectToAction("Details", tabuladorSueldo);
            }
            ViewBag.Id = new SelectList(db.Empleados, "Id", "NumeroEmpleado", tabuladorSueldo.Id);
            return View(tabuladorSueldo);
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
