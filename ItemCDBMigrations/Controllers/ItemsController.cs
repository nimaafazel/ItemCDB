using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ItemCDBMigrations.Models;
using PagedList;

namespace ItemCDBMigrations.Controllers
{
    [Authorize(Roles = "RSG.DBH_ItemCtlAdmin, RSG.DBH_ItemCtlDBA")]
    public class ItemsController : Controller
    {
        private ICContext db = new ICContext();

        // GET: Items
        public ActionResult Index(string searchString, string sortOrder, string currentFilter, int? page)
        {
            // save the sortorder value
            ViewBag.CurrentSortOrder = sortOrder;

            // filter aux vars
            ViewBag.ItemDesc = string.IsNullOrEmpty(sortOrder) ? "item_desc" : "";
            ViewBag.BUnit = sortOrder == "bunit" ? "bunit_desc" : "bunit";

            if (searchString != null)  // we only set searchString from a form submission, so we always go to the first page with a new search
                page = 1;
            else
                searchString = currentFilter;

            // save the search filter
            ViewBag.CurrentFilter = searchString;
            
            var tblBudItemNums = db.tblBudItemNums.Include(t => t.tblBargainUnit);
            // apply search string
            if(!string.IsNullOrEmpty(searchString))
            {
                tblBudItemNums = tblBudItemNums.Where(t => t.BudItemDesc.Contains(searchString) || t.tblBargainUnit.BargainUnitDesc.Contains(searchString));
            }

            // apply ordering
            switch(sortOrder)
            {
                case "item_desc":
                    tblBudItemNums = tblBudItemNums.OrderByDescending(t => t.BudItemDesc);
                    break;

                case "bunit":
                    tblBudItemNums = tblBudItemNums.OrderBy(t => t.tblBargainUnit.BargainUnitDesc);
                    break;

                case "bunit_desc":
                    tblBudItemNums = tblBudItemNums.OrderByDescending(t => t.tblBargainUnit.BargainUnitDesc);
                    break;

                default:
                    tblBudItemNums = tblBudItemNums.OrderBy(t => t.BudItemDesc);
                    break;
            }

            // paging
            int pageNumber = page ?? 1;
            int pageSize = 10;

            return View(tblBudItemNums.ToPagedList(pageNumber, pageSize));
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
