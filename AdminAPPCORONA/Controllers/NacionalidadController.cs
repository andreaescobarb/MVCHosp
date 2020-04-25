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
    public class NacionalidadController : Controller
    {
        private HBEntities db = new HBEntities();

        // GET: /Nacionalidad/
        public ActionResult Index()
        {
            return View(db.Nacionalidads.ToList());
        }

        // GET: /Nacionalidad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nacionalidad nacionalidad = db.Nacionalidads.Find(id);
            if (nacionalidad == null)
            {
                return HttpNotFound();
            }
            return View(nacionalidad);
        }

        // GET: /Nacionalidad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Nacionalidad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDNacionalidad,Nombre")] Nacionalidad nacionalidad)
        {
            if (ModelState.IsValid)
            {
                db.Nacionalidads.Add(nacionalidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nacionalidad);
        }

        // GET: /Nacionalidad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nacionalidad nacionalidad = db.Nacionalidads.Find(id);
            if (nacionalidad == null)
            {
                return HttpNotFound();
            }
            return View(nacionalidad);
        }

        // POST: /Nacionalidad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDNacionalidad,Nombre")] Nacionalidad nacionalidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nacionalidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nacionalidad);
        }

        // GET: /Nacionalidad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nacionalidad nacionalidad = db.Nacionalidads.Find(id);
            if (nacionalidad == null)
            {
                return HttpNotFound();
            }
            return View(nacionalidad);
        }

        // POST: /Nacionalidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nacionalidad nacionalidad = db.Nacionalidads.Find(id);
            db.Nacionalidads.Remove(nacionalidad);
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
