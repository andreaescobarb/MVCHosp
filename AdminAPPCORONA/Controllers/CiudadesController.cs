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
    public class CiudadesController : Controller
    {
        private HBEntities db = new HBEntities();

        // GET: /Ciudades/
        public ActionResult Index()
        {
            return View(db.Ciudades.ToList());
        }

        // GET: /Ciudades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudade ciudade = db.Ciudades.Find(id);
            if (ciudade == null)
            {
                return HttpNotFound();
            }
            return View(ciudade);
        }

        // GET: /Ciudades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Ciudades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDCiudad,Nombre")] Ciudade ciudade)
        {
            if (ModelState.IsValid)
            {
                db.Ciudades.Add(ciudade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ciudade);
        }

        // GET: /Ciudades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudade ciudade = db.Ciudades.Find(id);
            if (ciudade == null)
            {
                return HttpNotFound();
            }
            return View(ciudade);
        }

        // POST: /Ciudades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDCiudad,Nombre")] Ciudade ciudade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ciudade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ciudade);
        }

        // GET: /Ciudades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudade ciudade = db.Ciudades.Find(id);
            if (ciudade == null)
            {
                return HttpNotFound();
            }
            return View(ciudade);
        }

        // POST: /Ciudades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ciudade ciudade = db.Ciudades.Find(id);
            db.Ciudades.Remove(ciudade);
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
