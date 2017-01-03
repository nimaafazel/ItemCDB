using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ItemCDBMigrations.Models;

namespace ItemCDBMigrations.Controllers
{
    [Authorize(Roles = "RSG.DBH_ItemCtlAdmin, RSG.DBH_ItemCtlDBA")]
    public class UnitsController : Controller
    {
        private ICContext db = new ICContext();

        // GET: Units
        public ActionResult Index()
        {
            var sortedUnits = db.tblUnits.OrderBy(t => t.UnitDesc);
            return View(sortedUnits.ToList());
        }

        // GET: Units/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUnit tblUnit = db.tblUnits.Find(id);
            if (tblUnit == null)
            {
                return HttpNotFound();
            }
            return View(tblUnit);
        }

        // GET: Units/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Units/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UnitCode,UnitDesc,UnitSupervisor")] tblUnit tblUnit)
        {
            if (ModelState.IsValid)
            {
                db.tblUnits.Add(tblUnit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblUnit);
        }

        // GET: Units/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUnit tblUnit = db.tblUnits.Find(id);
            if (tblUnit == null)
            {
                return HttpNotFound();
            }
            return View(tblUnit);
        }

        // POST: Units/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UnitCode,UnitDesc,UnitSupervisor")] tblUnit tblUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUnit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblUnit);
        }

        // GET: Units/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUnit tblUnit = db.tblUnits.Find(id);
            if (tblUnit == null)
            {
                return HttpNotFound();
            }
            return View(tblUnit);
        }

        // POST: Units/Delete/5
        [Authorize(Roles = "RSG.DBH_ItemCtlDBA")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUnit tblUnit = db.tblUnits.Find(id);
            db.tblUnits.Remove(tblUnit);
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
