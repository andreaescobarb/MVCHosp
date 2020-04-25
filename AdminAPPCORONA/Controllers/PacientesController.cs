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
    public class PacientesController : Controller
    {
        private HBEntities db = new HBEntities();

        // GET: /Pacientes/
        public ActionResult Index()
        {
            var pacientes = db.Pacientes.Include(p => p.Ciudade).Include(p => p.Nacionalidad).Include(p => p.Residencia1);
            return View(pacientes.ToList());
        }

        // GET: /Pacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: /Pacientes/Create
        public ActionResult Create()
        {
            ViewBag.Ciudad = new SelectList(db.Ciudades, "IDCiudad", "Nombre");
            ViewBag.IDNacionalidad = new SelectList(db.Nacionalidads, "IDNacionalidad", "Nombre");
            ViewBag.Residencia = new SelectList(db.Residencias, "IDResidencia", "Nombre");
            return View();
        }

        // POST: /Pacientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDPaciente,Correo,Nombre,Apellido,SegundoApellido,Identidad,Edad,Genero,IDNacionalidad,Ciudad,Residencia")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Pacientes.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ciudad = new SelectList(db.Ciudades, "IDCiudad", "Nombre", paciente.Ciudad);
            ViewBag.IDNacionalidad = new SelectList(db.Nacionalidads, "IDNacionalidad", "Nombre", paciente.IDNacionalidad);
            ViewBag.Residencia = new SelectList(db.Residencias, "IDResidencia", "Nombre", paciente.Residencia);
            return View(paciente);
        }

        // GET: /Pacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ciudad = new SelectList(db.Ciudades, "IDCiudad", "Nombre", paciente.Ciudad);
            ViewBag.IDNacionalidad = new SelectList(db.Nacionalidads, "IDNacionalidad", "Nombre", paciente.IDNacionalidad);
            ViewBag.Residencia = new SelectList(db.Residencias, "IDResidencia", "Nombre", paciente.Residencia);
            return View(paciente);
        }

        // POST: /Pacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDPaciente,Correo,Nombre,Apellido,SegundoApellido,Identidad,Edad,Genero,IDNacionalidad,Ciudad,Residencia")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDNacionalidad = new SelectList(db.Nacionalidads, "IDNacionalidad", "Nacionalidad", paciente.IDNacionalidad);
            ViewBag.Ciudad = new SelectList(db.Ciudades, "IDCiudad", "Ciudad", paciente.Ciudad);
            ViewBag.Residencia = new SelectList(db.Residencias, "IDResidencia", "Residencia", paciente.Residencia);
            return View(paciente);
        }

        // GET: /Pacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: /Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paciente paciente = db.Pacientes.Find(id);
            db.Pacientes.Remove(paciente);
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
