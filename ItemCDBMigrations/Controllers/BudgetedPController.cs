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
    public class BudgetedPController : Controller
    {
        private ICContext db = new ICContext();

        // GET: BudgetedP
        public ActionResult Index(string searchString, string sortOrder, string currentFilter, int? page)
        {
            ViewBag.ItemD = (string.IsNullOrEmpty(sortOrder)) ? "item_desc" : "";
            ViewBag.Unit = sortOrder == "unit" ? "unit_desc" : "unit";

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentSortOrder = sortOrder;

            // get the positions
            var tblPOSITIONBUDGETEDs = db.tblPOSITIONBUDGETEDs.Include(t => t.tblBud).
                Include(t => t.tblBudItemNum).Include(t => t.tblDivision).Include(t => t.tblFilled).
                Include(t => t.tblFunction).Include(t => t.tblOrd).Include(t => t.tblOrgCode).
                Include(t => t.tblSection).Include(t => t.tblSubItem).Include(t => t.tblUnit);

            if(!string.IsNullOrEmpty(searchString))
            {
                tblPOSITIONBUDGETEDs = tblPOSITIONBUDGETEDs.Where(t => t.tblBudItemNum.BudItemDesc.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "item_desc":
                    tblPOSITIONBUDGETEDs = tblPOSITIONBUDGETEDs.OrderByDescending(t => t.tblBudItemNum.BudItemDesc);
                    break;

                case "unit":
                    tblPOSITIONBUDGETEDs = tblPOSITIONBUDGETEDs.OrderBy(t => t.tblUnit.UnitDesc);
                    break;

                case "unit_desc":
                    tblPOSITIONBUDGETEDs = tblPOSITIONBUDGETEDs.OrderByDescending(t => t.tblUnit.UnitDesc);
                    break;

                default:
                    tblPOSITIONBUDGETEDs = tblPOSITIONBUDGETEDs.OrderBy(t => t.tblBudItemNum.BudItemDesc);
                    break;
            }

            int pageNumber = page ?? 1;
            int pageSize = 10;

            return View(tblPOSITIONBUDGETEDs.ToPagedList(pageNumber, pageSize));
        }

        // GET: BudgetedP/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPOSITIONBUDGETED tblPOSITIONBUDGETED = db.tblPOSITIONBUDGETEDs.Find(id);
            if (tblPOSITIONBUDGETED == null)
            {
                return HttpNotFound();
            }
            return View(tblPOSITIONBUDGETED);
        }

        // GET: BudgetedP/Create
        public ActionResult Create()
        {
            ViewBag.BudBud = new SelectList(db.tblBuds, "BudCode", "BudDesc");
            ViewBag.BudItemNum = new SelectList(db.tblBudItemNums, "BudItemNum", "BudItemDesc");
            ViewBag.BudDivCode = new SelectList(db.tblDivisions, "DivCode", "DivDesc");
            ViewBag.BudFilled = new SelectList(db.tblFilleds, "FilledCode", "FilledDesc");
            ViewBag.BudFunction = new SelectList(db.tblFunctions, "FuncCode", "FuncDesc");
            ViewBag.BudOrd = new SelectList(db.tblOrds, "OrdCode", "OrdDesc");
            ViewBag.BudOrgCode = new SelectList(db.tblOrgCodes, "BudOrgCode", "BudOrgCodeDesc");
            ViewBag.BudSecCode = new SelectList(db.tblSections, "SecCode", "SecDesc");
            ViewBag.BudSubItem = new SelectList(db.tblSubItems, "SubItemCode", "SubItemDesc");
            ViewBag.BudUnitCode = new SelectList(db.tblUnits, "UnitCode", "UnitDesc");
            return View();
        }

        // POST: BudgetedP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BudPosNum,BudItemNum,BudSubItem,BudOrd,BudBud,BudFilled,BudFunction,BudOrgCode,BudDivCode,BudSecCode,BudUnitCode,Comments")] tblPOSITIONBUDGETED tblPOSITIONBUDGETED)
        {
            if (ModelState.IsValid)
            {
                db.tblPOSITIONBUDGETEDs.Add(tblPOSITIONBUDGETED);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BudBud = new SelectList(db.tblBuds, "BudCode", "BudDesc", tblPOSITIONBUDGETED.BudBud);
            ViewBag.BudItemNum = new SelectList(db.tblBudItemNums, "BudItemNum", "BudItemDesc", tblPOSITIONBUDGETED.BudItemNum);
            ViewBag.BudDivCode = new SelectList(db.tblDivisions, "DivCode", "DivDesc", tblPOSITIONBUDGETED.BudDivCode);
            ViewBag.BudFilled = new SelectList(db.tblFilleds, "FilledCode", "FilledDesc", tblPOSITIONBUDGETED.BudFilled);
            ViewBag.BudFunction = new SelectList(db.tblFunctions, "FuncCode", "FuncDesc", tblPOSITIONBUDGETED.BudFunction);
            ViewBag.BudOrd = new SelectList(db.tblOrds, "OrdCode", "OrdDesc", tblPOSITIONBUDGETED.BudOrd);
            ViewBag.BudOrgCode = new SelectList(db.tblOrgCodes, "BudOrgCode", "BudOrgCodeDesc", tblPOSITIONBUDGETED.BudOrgCode);
            ViewBag.BudSecCode = new SelectList(db.tblSections, "SecCode", "SecDesc", tblPOSITIONBUDGETED.BudSecCode);
            ViewBag.BudSubItem = new SelectList(db.tblSubItems, "SubItemCode", "SubItemDesc", tblPOSITIONBUDGETED.BudSubItem);
            ViewBag.BudUnitCode = new SelectList(db.tblUnits, "UnitCode", "UnitDesc", tblPOSITIONBUDGETED.BudUnitCode);
            return View(tblPOSITIONBUDGETED);
        }

        // GET: BudgetedP/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPOSITIONBUDGETED tblPOSITIONBUDGETED = db.tblPOSITIONBUDGETEDs.Find(id);
            if (tblPOSITIONBUDGETED == null)
            {
                return HttpNotFound();
            }
            ViewBag.BudBud = new SelectList(db.tblBuds, "BudCode", "BudDesc", tblPOSITIONBUDGETED.BudBud);
            ViewBag.BudItemNum = new SelectList(db.tblBudItemNums, "BudItemNum", "BudItemDesc", tblPOSITIONBUDGETED.BudItemNum);
            ViewBag.BudDivCode = new SelectList(db.tblDivisions, "DivCode", "DivDesc", tblPOSITIONBUDGETED.BudDivCode);
            ViewBag.BudFilled = new SelectList(db.tblFilleds, "FilledCode", "FilledDesc", tblPOSITIONBUDGETED.BudFilled);
            ViewBag.BudFunction = new SelectList(db.tblFunctions, "FuncCode", "FuncDesc", tblPOSITIONBUDGETED.BudFunction);
            ViewBag.BudOrd = new SelectList(db.tblOrds, "OrdCode", "OrdDesc", tblPOSITIONBUDGETED.BudOrd);
            ViewBag.BudOrgCode = new SelectList(db.tblOrgCodes, "BudOrgCode", "BudOrgCodeDesc", tblPOSITIONBUDGETED.BudOrgCode);
            ViewBag.BudSecCode = new SelectList(db.tblSections, "SecCode", "SecDesc", tblPOSITIONBUDGETED.BudSecCode);
            ViewBag.BudSubItem = new SelectList(db.tblSubItems, "SubItemCode", "SubItemDesc", tblPOSITIONBUDGETED.BudSubItem);
            ViewBag.BudUnitCode = new SelectList(db.tblUnits, "UnitCode", "UnitDesc", tblPOSITIONBUDGETED.BudUnitCode);
            return View(tblPOSITIONBUDGETED);
        }

        // POST: BudgetedP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BudPosNum,BudItemNum,BudSubItem,BudOrd,BudBud,BudFilled,BudFunction,BudOrgCode,BudDivCode,BudSecCode,BudUnitCode,Comments")] tblPOSITIONBUDGETED tblPOSITIONBUDGETED)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPOSITIONBUDGETED).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BudBud = new SelectList(db.tblBuds, "BudCode", "BudDesc", tblPOSITIONBUDGETED.BudBud);
            ViewBag.BudItemNum = new SelectList(db.tblBudItemNums, "BudItemNum", "BudItemDesc", tblPOSITIONBUDGETED.BudItemNum);
            ViewBag.BudDivCode = new SelectList(db.tblDivisions, "DivCode", "DivDesc", tblPOSITIONBUDGETED.BudDivCode);
            ViewBag.BudFilled = new SelectList(db.tblFilleds, "FilledCode", "FilledDesc", tblPOSITIONBUDGETED.BudFilled);
            ViewBag.BudFunction = new SelectList(db.tblFunctions, "FuncCode", "FuncDesc", tblPOSITIONBUDGETED.BudFunction);
            ViewBag.BudOrd = new SelectList(db.tblOrds, "OrdCode", "OrdDesc", tblPOSITIONBUDGETED.BudOrd);
            ViewBag.BudOrgCode = new SelectList(db.tblOrgCodes, "BudOrgCode", "BudOrgCodeDesc", tblPOSITIONBUDGETED.BudOrgCode);
            ViewBag.BudSecCode = new SelectList(db.tblSections, "SecCode", "SecDesc", tblPOSITIONBUDGETED.BudSecCode);
            ViewBag.BudSubItem = new SelectList(db.tblSubItems, "SubItemCode", "SubItemDesc", tblPOSITIONBUDGETED.BudSubItem);
            ViewBag.BudUnitCode = new SelectList(db.tblUnits, "UnitCode", "UnitDesc", tblPOSITIONBUDGETED.BudUnitCode);
            return View(tblPOSITIONBUDGETED);
        }

        // GET: BudgetedP/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPOSITIONBUDGETED tblPOSITIONBUDGETED = db.tblPOSITIONBUDGETEDs.Find(id);
            if (tblPOSITIONBUDGETED == null)
            {
                return HttpNotFound();
            }
            return View(tblPOSITIONBUDGETED);
        }

        // POST: BudgetedP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPOSITIONBUDGETED tblPOSITIONBUDGETED = db.tblPOSITIONBUDGETEDs.Find(id);
            db.tblPOSITIONBUDGETEDs.Remove(tblPOSITIONBUDGETED);
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
