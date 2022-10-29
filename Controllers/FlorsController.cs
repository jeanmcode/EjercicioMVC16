using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EjercicioMVC16.Models;

namespace EjercicioMVC16.Controllers
{
    public class FlorsController : Controller
    {
        private EjercicioMVC16ModelContainer db = new EjercicioMVC16ModelContainer();

        // GET: Flors
        public ActionResult Index()
        {
            var flores = db.Flores.Include(f => f.Especie);
            return View(flores.ToList());
        }

        // GET: Flors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flor flor = db.Flores.Find(id);
            if (flor == null)
            {
                return HttpNotFound();
            }
            return View(flor);
        }

        // GET: Flors/Create
        public ActionResult Create()
        {
            ViewBag.EspecieId = new SelectList(db.Especies, "Id", "Nombre");
            return View();
        }

        // POST: Flors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Nombre,Descripcion,Fotografia,EspecieId")] Flor flor)
        {
            if (ModelState.IsValid)
            {
                db.Flores.Add(flor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EspecieId = new SelectList(db.Especies, "Id", "Nombre", flor.EspecieId);
            return View(flor);
        }

        // GET: Flors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flor flor = db.Flores.Find(id);
            if (flor == null)
            {
                return HttpNotFound();
            }
            ViewBag.EspecieId = new SelectList(db.Especies, "Id", "Nombre", flor.EspecieId);
            return View(flor);
        }

        // POST: Flors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Nombre,Descripcion,Fotografia,EspecieId")] Flor flor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EspecieId = new SelectList(db.Especies, "Id", "Nombre", flor.EspecieId);
            return View(flor);
        }

        // GET: Flors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flor flor = db.Flores.Find(id);
            if (flor == null)
            {
                return HttpNotFound();
            }
            return View(flor);
        }

        // POST: Flors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flor flor = db.Flores.Find(id);
            db.Flores.Remove(flor);
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
