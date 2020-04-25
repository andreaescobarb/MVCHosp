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
    public class ServiciosEnPromocionController : Controller
    {
        private HBEntities db = new HBEntities();

        // GET: /ServiciosEnPromocion/
        public ActionResult Index()
        {
            var serviciosenpromocions = db.ServiciosEnPromocions.Include(s => s.Promocione).Include(s => s.Servicio);
            return View(serviciosenpromocions.ToList());
        }

        // GET: /ServiciosEnPromocion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiciosEnPromocion serviciosEnPromocion = db.ServiciosEnPromocions.Find(id);
            if (serviciosEnPromocion == null)
            {
                return HttpNotFound();
            }
            return View(serviciosEnPromocion);
        }

        // GET: /ServiciosEnPromocion/Create
        public ActionResult Create()
        {
            ViewBag.IDPromocion = new SelectList(db.Promociones, "IDPromocion", "Nombre");
            ViewBag.IDServicio = new SelectList(db.Servicios, "IDServicio", "Nombre");
            return View();
        }

        // POST: /ServiciosEnPromocion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="IDServiciosPromocion,PrecioFinal,IDPromocion,IDServicio")] ServiciosEnPromocion serviciosEnPromocion)
        {
            if (ModelState.IsValid)
            {
                db.ServiciosEnPromocions.Add(serviciosEnPromocion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPromocion = new SelectList(db.Promociones, "IDPromocion", "Nombre", serviciosEnPromocion.IDPromocion);
            ViewBag.IDServicio = new SelectList(db.Servicios, "IDServicio", "Nombre", serviciosEnPromocion.IDServicio);
            return View(serviciosEnPromocion);
        }

        // GET: /ServiciosEnPromocion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiciosEnPromocion serviciosEnPromocion = db.ServiciosEnPromocions.Find(id);
            if (serviciosEnPromocion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPromocion = new SelectList(db.Promociones, "IDPromocion", "Nombre", serviciosEnPromocion.IDPromocion);
            ViewBag.IDServicio = new SelectList(db.Servicios, "IDServicio", "Nombre", serviciosEnPromocion.IDServicio);
            return View(serviciosEnPromocion);
        }

        // POST: /ServiciosEnPromocion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="IDServiciosPromocion,PrecioFinal,IDPromocion,IDServicio")] ServiciosEnPromocion serviciosEnPromocion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviciosEnPromocion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPromocion = new SelectList(db.Promociones, "IDPromocion", "Nombre", serviciosEnPromocion.IDPromocion);
            ViewBag.IDServicio = new SelectList(db.Servicios, "IDServicio", "Nombre", serviciosEnPromocion.IDServicio);
            return View(serviciosEnPromocion);
        }

        // GET: /ServiciosEnPromocion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiciosEnPromocion serviciosEnPromocion = db.ServiciosEnPromocions.Find(id);
            if (serviciosEnPromocion == null)
            {
                return HttpNotFound();
            }
            return View(serviciosEnPromocion);
        }

        // POST: /ServiciosEnPromocion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiciosEnPromocion serviciosEnPromocion = db.ServiciosEnPromocions.Find(id);
            db.ServiciosEnPromocions.Remove(serviciosEnPromocion);
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
