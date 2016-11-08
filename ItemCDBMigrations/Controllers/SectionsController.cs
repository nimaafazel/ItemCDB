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
    public class SectionsController : Controller
    {
        private ICContext db = new ICContext();

        // GET: Sections
        public ActionResult Index()
        {
            return View(db.tblSections.ToList());
        }

        // GET: Sections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSection tblSection = db.tblSections.Find(id);
            if (tblSection == null)
            {
                return HttpNotFound();
            }
            return View(tblSection);
        }

        // GET: Sections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SecCode,SecDesc,SecDesc1,SecHead")] tblSection tblSection)
        {
            if (ModelState.IsValid)
            {
                db.tblSections.Add(tblSection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblSection);
        }

        // GET: Sections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSection tblSection = db.tblSections.Find(id);
            if (tblSection == null)
            {
                return HttpNotFound();
            }
            return View(tblSection);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SecCode,SecDesc,SecDesc1,SecHead")] tblSection tblSection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblSection);
        }

        // GET: Sections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSection tblSection = db.tblSections.Find(id);
            if (tblSection == null)
            {
                return HttpNotFound();
            }
            return View(tblSection);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSection tblSection = db.tblSections.Find(id);
            db.tblSections.Remove(tblSection);
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
