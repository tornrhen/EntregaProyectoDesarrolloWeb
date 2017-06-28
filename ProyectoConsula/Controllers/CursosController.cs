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
    public class CursosController : Controller
    {
        private DAVEntities db = new DAVEntities();

        // GET: Cursos
        public ActionResult Index()
        {
            var cursos = db.Cursos.Include(c => c.AspNetUser).Include(c => c.AspNetUser1);
            return View(cursos.ToList());
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            ViewBag.IdF_UsuarioCreacion = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.IdF_UsuarioModificacion = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdT_Curso,Nombre,Id_CursoRequisito,Autorizado,IdF_Pais,NotaMinima,Visible,IdF_UsuarioCreacion,FechaCreacion,IdF_UsuarioModificacion,FechaModificacion,Estado")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Cursos.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdF_UsuarioCreacion = new SelectList(db.AspNetUsers, "Id", "Email", curso.IdF_UsuarioCreacion);
            ViewBag.IdF_UsuarioModificacion = new SelectList(db.AspNetUsers, "Id", "Email", curso.IdF_UsuarioModificacion);
            return View(curso);
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdF_UsuarioCreacion = new SelectList(db.AspNetUsers, "Id", "Email", curso.IdF_UsuarioCreacion);
            ViewBag.IdF_UsuarioModificacion = new SelectList(db.AspNetUsers, "Id", "Email", curso.IdF_UsuarioModificacion);
            return View(curso);
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdT_Curso,Nombre,Id_CursoRequisito,Autorizado,IdF_Pais,NotaMinima,Visible,IdF_UsuarioCreacion,FechaCreacion,IdF_UsuarioModificacion,FechaModificacion,Estado")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdF_UsuarioCreacion = new SelectList(db.AspNetUsers, "Id", "Email", curso.IdF_UsuarioCreacion);
            ViewBag.IdF_UsuarioModificacion = new SelectList(db.AspNetUsers, "Id", "Email", curso.IdF_UsuarioModificacion);
            return View(curso);
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursos.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = db.Cursos.Find(id);
            db.Cursos.Remove(curso);
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
