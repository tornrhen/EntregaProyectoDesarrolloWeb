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
    public class RespuestasController : Controller
    {
        private DAVEntities db = new DAVEntities();

        // GET: Respuestas
        public ActionResult Index()
        {
            var respuestas = db.Respuestas.Include(r => r.AspNetUser).Include(r => r.Pregunta).Include(r => r.Prueba);
            return View(respuestas.ToList());
        }

        // GET: Respuestas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta respuesta = db.Respuestas.Find(id);
            if (respuesta == null)
            {
                return HttpNotFound();
            }
            return View(respuesta);
        }

        // GET: Respuestas/Create
        public ActionResult Create()
        {
            ViewBag.IdF_Usuario = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.IdF_Pregunta = new SelectList(db.Preguntas, "IdT_Pregunta", "Titulo");
            ViewBag.IdF_Prueba = new SelectList(db.Pruebas, "IdT_Prueba", "Titulo");
            return View();
        }

        // POST: Respuestas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdT_Respuesta,IdF_Pregunta,IdF_Prueba,IdF_Usuario,TituloRespuesta,TextoRespuesta,Correcto,Ponderacion")] Respuesta respuesta)
        {
            if (ModelState.IsValid)
            {
                db.Respuestas.Add(respuesta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdF_Usuario = new SelectList(db.AspNetUsers, "Id", "Email", respuesta.IdF_Usuario);
            ViewBag.IdF_Pregunta = new SelectList(db.Preguntas, "IdT_Pregunta", "Titulo", respuesta.IdF_Pregunta);
            ViewBag.IdF_Prueba = new SelectList(db.Pruebas, "IdT_Prueba", "Titulo", respuesta.IdF_Prueba);
            return View(respuesta);
        }

        // GET: Respuestas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta respuesta = db.Respuestas.Find(id);
            if (respuesta == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdF_Usuario = new SelectList(db.AspNetUsers, "Id", "Email", respuesta.IdF_Usuario);
            ViewBag.IdF_Pregunta = new SelectList(db.Preguntas, "IdT_Pregunta", "Titulo", respuesta.IdF_Pregunta);
            ViewBag.IdF_Prueba = new SelectList(db.Pruebas, "IdT_Prueba", "Titulo", respuesta.IdF_Prueba);
            return View(respuesta);
        }

        // POST: Respuestas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdT_Respuesta,IdF_Pregunta,IdF_Prueba,IdF_Usuario,TituloRespuesta,TextoRespuesta,Correcto,Ponderacion")] Respuesta respuesta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(respuesta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdF_Usuario = new SelectList(db.AspNetUsers, "Id", "Email", respuesta.IdF_Usuario);
            ViewBag.IdF_Pregunta = new SelectList(db.Preguntas, "IdT_Pregunta", "Titulo", respuesta.IdF_Pregunta);
            ViewBag.IdF_Prueba = new SelectList(db.Pruebas, "IdT_Prueba", "Titulo", respuesta.IdF_Prueba);
            return View(respuesta);
        }

        // GET: Respuestas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Respuesta respuesta = db.Respuestas.Find(id);
            if (respuesta == null)
            {
                return HttpNotFound();
            }
            return View(respuesta);
        }

        // POST: Respuestas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Respuesta respuesta = db.Respuestas.Find(id);
            db.Respuestas.Remove(respuesta);
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
