using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminAPPCORONA.Models;

namespace AdminAPPCORONA.Controllers
{
    public class ColaboradorController : Controller
    {
        private HBEntities db = new HBEntities();

        // GET: /Colaborador/
        public ActionResult Index()
        {
            return View(db.Colaboradors.ToList());
        }

        // GET: /Colaborador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborador colaborador = db.Colaboradors.Find(id);
            if (colaborador == null)
            {
                return HttpNotFound();
            }
            return View(colaborador);
        }

        // GET: /Colaborador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Colaborador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDColaborador,Usuario,Contraseña,Nombre,Apellido,Cargo,TelPersonal,TelOficina,Correo")] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                try
                {
                db.Colaboradors.Add(colaborador);
                db.SaveChanges();
                return RedirectToAction("Index");
                    
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }

            return View(colaborador);
        }

        // GET: /Colaborador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborador colaborador = db.Colaboradors.Find(id);
            if (colaborador == null)
            {
                return HttpNotFound();
            }
            return View(colaborador);
        }

        // POST: /Colaborador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDColaborador,Usuario,Contraseña,Nombre,Apellido,Cargo,TelPersonal,TelOficina,Correo")] Colaborador colaborador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colaborador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colaborador);
        }

        // GET: /Colaborador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colaborador colaborador = db.Colaboradors.Find(id);
            if (colaborador == null)
            {
                return HttpNotFound();
            }
            return View(colaborador);
        }

        // POST: /Colaborador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Colaborador colaborador = db.Colaboradors.Find(id);
            db.Colaboradors.Remove(colaborador);
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
