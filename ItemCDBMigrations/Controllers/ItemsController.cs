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
    public class ItemsController : Controller
    {
        private ICContext db = new ICContext();

        // GET: Items
        public ActionResult Index(string searchString)
        {
            var tblBudItemNums = db.tblBudItemNums.Include(t => t.tblBargainUnit);
            // applly search string
            if(!string.IsNullOrEmpty(searchString))
            {
                tblBudItemNums = tblBudItemNums.Where(t => t.BudItemDesc.Contains(searchString));
            }
            return View(tblBudItemNums.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBudItemNum tblBudItemNum = db.tblBudItemNums.Find(id);
            if (tblBudItemNum == null)
            {
                return HttpNotFound();
            }
            return View(tblBudItemNum);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.BudBargainUnit = new SelectList(db.tblBargainUnits, "BargainUnitCode", "BargainUnitDesc");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BudItemNum,BudItemDesc,BudSchedule,BudNote,BudBargainUnit")] tblBudItemNum tblBudItemNum)
        {
            if (ModelState.IsValid)
            {
                db.tblBudItemNums.Add(tblBudItemNum);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BudBargainUnit = new SelectList(db.tblBargainUnits, "BargainUnitCode", "BargainUnitDesc", tblBudItemNum.BudBargainUnit);
            return View(tblBudItemNum);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBudItemNum tblBudItemNum = db.tblBudItemNums.Find(id);
            if (tblBudItemNum == null)
            {
                return HttpNotFound();
            }
            ViewBag.BudBargainUnit = new SelectList(db.tblBargainUnits, "BargainUnitCode", "BargainUnitDesc", tblBudItemNum.BudBargainUnit);
            return View(tblBudItemNum);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BudItemNum,BudItemDesc,BudSchedule,BudNote,BudBargainUnit")] tblBudItemNum tblBudItemNum)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblBudItemNum).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BudBargainUnit = new SelectList(db.tblBargainUnits, "BargainUnitCode", "BargainUnitDesc", tblBudItemNum.BudBargainUnit);
            return View(tblBudItemNum);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBudItemNum tblBudItemNum = db.tblBudItemNums.Find(id);
            if (tblBudItemNum == null)
            {
                return HttpNotFound();
            }
            return View(tblBudItemNum);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblBudItemNum tblBudItemNum = db.tblBudItemNums.Find(id);
            db.tblBudItemNums.Remove(tblBudItemNum);
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
