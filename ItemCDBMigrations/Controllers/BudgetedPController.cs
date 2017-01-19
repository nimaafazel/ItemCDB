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
                tblPOSITIONBUDGETEDs = tblPOSITIONBUDGETEDs.Where(t => t.tblBudItemNum.BudItemDesc.Contains(searchString) || t.BudItemNum.Contains(searchString));
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

        /// <summary>
        /// Fills the ViewBag with the information neccesary for the foorm fields.
        /// </summary>
        /// <returns></returns>
        private ActionResult PrepareFields()
        {
            ViewBag.BudBud = new SelectList(db.tblBuds, "BudCode", "BudDesc");

            var itemconcat = from x in db.tblBudItemNums
                             let BudItemDesc = x.BudItemNum + " - " + x.BudItemDesc
                             orderby x.BudItemDesc
                             select new { x.BudItemNum, BudItemDesc };
            ViewBag.BudItemNum = new SelectList(itemconcat, "BudItemNum", "BudItemDesc");
            //ViewBag.BudItemNum = new SelectList(db.tblBudItemNums, "BudItemNum", "BudItemDesc");

            var divisions = from x in db.tblDivisions
                            let DivDesc = x.DivDesc1 + " - " + x.DivCode
                            orderby x.DivDesc1
                            select new { x.DivCode, DivDesc };
            ViewBag.BudDivCode = new SelectList(divisions, "DivCode", "DivDesc");
            //ViewBag.BudDivCode = new SelectList(db.tblDivisions, "DivCode", "DivDesc");

            ViewBag.BudFilled = new SelectList(db.tblFilleds, "FilledCode", "FilledDesc");
            ViewBag.BudFunction = new SelectList(db.tblFunctions, "FuncCode", "FuncDesc");
            ViewBag.BudOrd = new SelectList(db.tblOrds, "OrdCode", "OrdDesc");
            ViewBag.BudOrgCode = new SelectList(db.tblOrgCodes, "BudOrgCode", "BudOrgCodeDesc");

            var sections = from x in db.tblSections
                           let SecDesc = x.SecDesc1 + " - " + x.SecCode
                           orderby x.SecDesc1
                           select new { x.SecCode, SecDesc };
            ViewBag.BudSecCode = new SelectList(sections, "SecCode", "SecDesc");
            //ViewBag.BudSecCode = new SelectList(db.tblSections, "SecCode", "SecDesc");

            var subconcat = from x in db.tblSubItems
                            let SubItemDesc = x.SubItemCode + " - " + x.SubItemDesc
                            select new { x.SubItemCode, SubItemDesc };
            ViewBag.BudSubItem = new SelectList(subconcat, "SubItemCode", "SubItemDesc");
            //ViewBag.BudSubItem = new SelectList(db.tblSubItems, "SubItemCode", "SubItemDesc");

            var units = from x in db.tblUnits
                        let UnitDesc = x.UnitDesc + " - " + x.UnitCode
                        orderby x.UnitDesc
                        select new { x.UnitCode, UnitDesc };
            ViewBag.BudUnitCode = new SelectList(units, "UnitCode", "UnitDesc");
            //ViewBag.BudUnitCode = new SelectList(db.tblUnits, "UnitCode", "UnitDesc");
            return View();
        }

        // GET: BudgetedP/Create
        public ActionResult Create()
        {
            return PrepareFields();
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
            // else, stay on page
            return PrepareFields();
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

            var itemconcat = from x in db.tblBudItemNums
                             let BudItemDesc = x.BudItemNum + " - " + x.BudItemDesc
                             orderby x.BudItemDesc
                             select new { x.BudItemNum, BudItemDesc };
            ViewBag.BudItemNum = new SelectList(itemconcat, "BudItemNum", "BudItemDesc", tblPOSITIONBUDGETED.BudItemNum);

            //ViewBag.BudItemNum = new SelectList(db.tblBudItemNums, "BudItemNum", "BudItemDesc", tblPOSITIONBUDGETED.BudItemNum);
            ViewBag.BudDivCode = new SelectList(db.tblDivisions, "DivCode", "DivDesc", tblPOSITIONBUDGETED.BudDivCode);
            ViewBag.BudFilled = new SelectList(db.tblFilleds, "FilledCode", "FilledDesc", tblPOSITIONBUDGETED.BudFilled);
            ViewBag.BudFunction = new SelectList(db.tblFunctions, "FuncCode", "FuncDesc", tblPOSITIONBUDGETED.BudFunction);
            ViewBag.BudOrd = new SelectList(db.tblOrds, "OrdCode", "OrdDesc", tblPOSITIONBUDGETED.BudOrd);
            ViewBag.BudOrgCode = new SelectList(db.tblOrgCodes, "BudOrgCode", "BudOrgCodeDesc", tblPOSITIONBUDGETED.BudOrgCode);
            ViewBag.BudSecCode = new SelectList(db.tblSections, "SecCode", "SecDesc", tblPOSITIONBUDGETED.BudSecCode);

            // create a custom select to concat code and desc in the dropdown list
            var alias = (from x in db.tblSubItems
                         let SubItemDesc = x.SubItemCode + " - " + x.SubItemDesc
                         select new { x.SubItemCode, SubItemDesc });
            ViewBag.BudSubItem = new SelectList(alias, "SubItemCode", "SubItemDesc", tblPOSITIONBUDGETED.BudSubItem);

            //ViewBag.BudSubItem = new SelectList(db.tblSubItems, "SubItemCode", "SubItemDesc", tblPOSITIONBUDGETED.BudSubItem);
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
        [Authorize(Roles = "RSG.DBH_ItemCtlDBA")]
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
