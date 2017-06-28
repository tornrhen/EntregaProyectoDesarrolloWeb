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
    public class ContenidosController : Controller
    {
        private DAVEntities db = new DAVEntities();

        // GET: Contenidos
        public ActionResult Index()
        {
            return View(db.Contenidos.ToList());
        }

        // GET: Contenidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contenido contenido = db.Contenidos.Find(id);
            if (contenido == null)
            {
                return HttpNotFound();
            }
            return View(contenido);
        }

        // GET: Contenidos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contenidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdT_Contenido,Titulo,Descripcion,Archivo,Enlace")] Contenido contenido)
        {
            if (ModelState.IsValid)
            {
                db.Contenidos.Add(contenido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contenido);
        }

        // GET: Contenidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contenido contenido = db.Contenidos.Find(id);
            if (contenido == null)
            {
                return HttpNotFound();
            }
            return View(contenido);
        }

        // POST: Contenidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdT_Contenido,Titulo,Descripcion,Archivo,Enlace")] Contenido contenido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contenido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contenido);
        }

        // GET: Contenidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contenido contenido = db.Contenidos.Find(id);
            if (contenido == null)
            {
                return HttpNotFound();
            }
            return View(contenido);
        }

        // POST: Contenidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contenido contenido = db.Contenidos.Find(id);
            db.Contenidos.Remove(contenido);
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
