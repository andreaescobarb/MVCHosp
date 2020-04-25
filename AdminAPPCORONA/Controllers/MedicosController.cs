using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminAPPCORONA.Models;

namespace AdminAPPCORONA.Controllers
{
    public class MedicosController : Controller
    {
        private HBEntities db = new HBEntities();

        // GET: /Medicos/
        public ActionResult Index()
        {
            var medicos = db.Medicos.Include(m => m.Especialidade);
            return View(medicos.ToList());
        }

        // GET: /Medicos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // GET: /Medicos/Create
        public ActionResult Create()
        {
            ViewBag.IDEspecialidad = new SelectList(db.Especialidades, "IDEspecialidad", "Nombre");
            return View();
        }

        // POST: /Medicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDMedico,Nombre,Apellido,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Titulos,IDEspecialidad")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDEspecialidad = new SelectList(db.Especialidades, "IDEspecialidad", "Nombre", medico.IDEspecialidad);
            return View(medico);
        }

        // GET: /Medicos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDEspecialidad = new SelectList(db.Especialidades, "IDEspecialidad", "Nombre", medico.IDEspecialidad);
            return View(medico);
        }

        // POST: /Medicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDMedico,Nombre,Apellido,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Titulos,IDEspecialidad")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDEspecialidad = new SelectList(db.Especialidades, "IDEspecialidad", "Nombre", medico.IDEspecialidad);
            return View(medico);
        }

        // GET: /Medicos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medicos.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: /Medicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medico medico = db.Medicos.Find(id);
            db.Medicos.Remove(medico);
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
