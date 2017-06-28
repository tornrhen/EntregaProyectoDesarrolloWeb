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
    public class ResultadosController : Controller
    {
        private DAVEntities db = new DAVEntities();

        // GET: Resultadoes
        public ActionResult Index()
        {
            var resultados = db.Resultados.Include(r => r.Prueba).Include(r => r.Respuesta);
            return View(resultados.ToList());
        }

        // GET: Resultadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultado resultado = db.Resultados.Find(id);
            if (resultado == null)
            {
                return HttpNotFound();
            }
            return View(resultado);
        }

        // GET: Resultadoes/Create
        public ActionResult Create()
        {
            ViewBag.IdF_Prueba = new SelectList(db.Pruebas, "IdT_Prueba", "Titulo");
            ViewBag.IdF_Respuesta = new SelectList(db.Respuestas, "IdT_Respuesta", "IdF_Usuario");
            return View();
        }

        // POST: Resultadoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdT_Resultado,IdF_Respuesta,IdF_Prueba,Intento")] Resultado resultado)
        {
            if (ModelState.IsValid)
            {
                db.Resultados.Add(resultado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdF_Prueba = new SelectList(db.Pruebas, "IdT_Prueba", "Titulo", resultado.IdF_Prueba);
            ViewBag.IdF_Respuesta = new SelectList(db.Respuestas, "IdT_Respuesta", "IdF_Usuario", resultado.IdF_Respuesta);
            return View(resultado);
        }

        // GET: Resultadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultado resultado = db.Resultados.Find(id);
            if (resultado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdF_Prueba = new SelectList(db.Pruebas, "IdT_Prueba", "Titulo", resultado.IdF_Prueba);
            ViewBag.IdF_Respuesta = new SelectList(db.Respuestas, "IdT_Respuesta", "IdF_Usuario", resultado.IdF_Respuesta);
            return View(resultado);
        }

        // POST: Resultadoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdT_Resultado,IdF_Respuesta,IdF_Prueba,Intento")] Resultado resultado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resultado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdF_Prueba = new SelectList(db.Pruebas, "IdT_Prueba", "Titulo", resultado.IdF_Prueba);
            ViewBag.IdF_Respuesta = new SelectList(db.Respuestas, "IdT_Respuesta", "IdF_Usuario", resultado.IdF_Respuesta);
            return View(resultado);
        }

        // GET: Resultadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resultado resultado = db.Resultados.Find(id);
            if (resultado == null)
            {
                return HttpNotFound();
            }
            return View(resultado);
        }

        // POST: Resultadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resultado resultado = db.Resultados.Find(id);
            db.Resultados.Remove(resultado);
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
