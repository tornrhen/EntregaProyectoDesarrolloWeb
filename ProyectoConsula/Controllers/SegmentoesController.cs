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
    public class SegmentoesController : Controller
    {
        private DAVEntities db = new DAVEntities();

        // GET: Segmentoes
        public ActionResult Index()
        {
            var segmentos = db.Segmentos.Include(s => s.Curso);
            return View(segmentos.ToList());
        }

        // GET: Segmentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Segmento segmento = db.Segmentos.Find(id);
            if (segmento == null)
            {
                return HttpNotFound();
            }
            return View(segmento);
        }

        // GET: Segmentoes/Create
        public ActionResult Create()
        {
            ViewBag.IdF_Curso = new SelectList(db.Cursos, "IdT_Curso", "Nombre");
            return View();
        }

        // POST: Segmentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdT_Segmento,IdF_Curso,Id_SegmentoPadre,Titulo,Descripcion,Visible,IdF_Pais")] Segmento segmento)
        {
            if (ModelState.IsValid)
            {
                db.Segmentos.Add(segmento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdF_Curso = new SelectList(db.Cursos, "IdT_Curso", "Nombre", segmento.IdF_Curso);
            return View(segmento);
        }

        // GET: Segmentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Segmento segmento = db.Segmentos.Find(id);
            if (segmento == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdF_Curso = new SelectList(db.Cursos, "IdT_Curso", "Nombre", segmento.IdF_Curso);
            return View(segmento);
        }

        // POST: Segmentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdT_Segmento,IdF_Curso,Id_SegmentoPadre,Titulo,Descripcion,Visible,IdF_Pais")] Segmento segmento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(segmento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdF_Curso = new SelectList(db.Cursos, "IdT_Curso", "Nombre", segmento.IdF_Curso);
            return View(segmento);
        }

        // GET: Segmentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Segmento segmento = db.Segmentos.Find(id);
            if (segmento == null)
            {
                return HttpNotFound();
            }
            return View(segmento);
        }

        // POST: Segmentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Segmento segmento = db.Segmentos.Find(id);
            db.Segmentos.Remove(segmento);
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
