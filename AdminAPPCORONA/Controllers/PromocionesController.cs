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
    public class PromocionesController : Controller
    {
        private HBEntities db = new HBEntities();

        // GET: /Promociones/
        public ActionResult Index()
        {
            return View(db.Promociones.ToList());
        }

        // GET: /Promociones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocione promocione = db.Promociones.Find(id);
            if (promocione == null)
            {
                return HttpNotFound();
            }
            return View(promocione);
        }

        // GET: /Promociones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Promociones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDPromocion,Nombre,Detalle,FechaExpiracion")] Promocione promocione)
        {
            if (ModelState.IsValid)
            {
                db.Promociones.Add(promocione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(promocione);
        }

        // GET: /Promociones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocione promocione = db.Promociones.Find(id);
            if (promocione == null)
            {
                return HttpNotFound();
            }
            return View(promocione);
        }

        // POST: /Promociones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDPromocion,Nombre,Detalle,FechaExpiracion")] Promocione promocione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promocione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(promocione);
        }

        // GET: /Promociones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promocione promocione = db.Promociones.Find(id);
            if (promocione == null)
            {
                return HttpNotFound();
            }
            return View(promocione);
        }

        // POST: /Promociones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Promocione promocione = db.Promociones.Find(id);
            db.Promociones.Remove(promocione);
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
