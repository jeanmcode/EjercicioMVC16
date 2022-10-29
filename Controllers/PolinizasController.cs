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
    public class PolinizasController : Controller
    {
        private EjercicioMVC16ModelContainer db = new EjercicioMVC16ModelContainer();

        // GET: Polinizas
        public ActionResult Index()
        {
            var poliniza = db.Poliniza.Include(p => p.Flor).Include(p => p.Agente);
            return View(poliniza.ToList());
        }

        // GET: Polinizas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poliniza poliniza = db.Poliniza.Find(id);
            if (poliniza == null)
            {
                return HttpNotFound();
            }
            return View(poliniza);
        }

        // GET: Polinizas/Create
        public ActionResult Create()
        {
            ViewBag.FlorId = new SelectList(db.Flores, "Id", "Codigo");
            ViewBag.AgenteId = new SelectList(db.Agentes, "Id", "Nombre");
            return View();
        }

        // POST: Polinizas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Reclamo,FlorId,AgenteId")] Poliniza poliniza)
        {
            if (ModelState.IsValid)
            {
                db.Poliniza.Add(poliniza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FlorId = new SelectList(db.Flores, "Id", "Codigo", poliniza.FlorId);
            ViewBag.AgenteId = new SelectList(db.Agentes, "Id", "Nombre", poliniza.AgenteId);
            return View(poliniza);
        }

        // GET: Polinizas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poliniza poliniza = db.Poliniza.Find(id);
            if (poliniza == null)
            {
                return HttpNotFound();
            }
            ViewBag.FlorId = new SelectList(db.Flores, "Id", "Codigo", poliniza.FlorId);
            ViewBag.AgenteId = new SelectList(db.Agentes, "Id", "Nombre", poliniza.AgenteId);
            return View(poliniza);
        }

        // POST: Polinizas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Reclamo,FlorId,AgenteId")] Poliniza poliniza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poliniza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FlorId = new SelectList(db.Flores, "Id", "Codigo", poliniza.FlorId);
            ViewBag.AgenteId = new SelectList(db.Agentes, "Id", "Nombre", poliniza.AgenteId);
            return View(poliniza);
        }

        // GET: Polinizas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Poliniza poliniza = db.Poliniza.Find(id);
            if (poliniza == null)
            {
                return HttpNotFound();
            }
            return View(poliniza);
        }

        // POST: Polinizas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Poliniza poliniza = db.Poliniza.Find(id);
            db.Poliniza.Remove(poliniza);
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
