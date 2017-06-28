using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoConsula.Models;

namespace ProyectoConsula.Controllers
{
    public class OpcionesController : Controller
    {
        private DAVEntities db = new DAVEntities();

        // GET: Opciones
        public ActionResult Index()
        {
            return View(db.Opciones.ToList());
        }

        // GET: Opciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opcione opcione = db.Opciones.Find(id);
            if (opcione == null)
            {
                return HttpNotFound();
            }
            return View(opcione);
        }

        // GET: Opciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Opciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdT_Opcion,Titulo,Descripcion")] Opcione opcione)
        {
            if (ModelState.IsValid)
            {
                db.Opciones.Add(opcione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(opcione);
        }

        // GET: Opciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opcione opcione = db.Opciones.Find(id);
            if (opcione == null)
            {
                return HttpNotFound();
            }
            return View(opcione);
        }

        // POST: Opciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdT_Opcion,Titulo,Descripcion")] Opcione opcione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opcione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(opcione);
        }

        // GET: Opciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Opcione opcione = db.Opciones.Find(id);
            if (opcione == null)
            {
                return HttpNotFound();
            }
            return View(opcione);
        }

        // POST: Opciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Opcione opcione = db.Opciones.Find(id);
            db.Opciones.Remove(opcione);
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
