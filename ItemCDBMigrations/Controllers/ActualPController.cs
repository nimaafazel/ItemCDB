﻿using System;
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
    public class ActualPController : Controller
    {
        private ICContext db = new ICContext();

        // GET: ActualP
        public ActionResult Index(string searchString, string sortOrder, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.EmplType = string.IsNullOrEmpty(sortOrder) ? "empltype_desc" : "";
            ViewBag.EffectiveDate = sortOrder == "efdate" ? "efdate_desc" : "efdate";

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            var tblPOSITIONACTUALs = db.tblPOSITIONACTUALs.Include(t => t.tblEMPLOYEELIST).Include(t => t.tblEmploymentType).
                Include(t => t.tblPayPeriod).Include(t => t.tblPOSITIONBUDGETED).Include(t => t.tblStep);

            if(!string.IsNullOrEmpty(searchString))
            {
                // search by employee
                //tblPOSITIONACTUALs = tblPOSITIONACTUALs.Where(t => t.tblEMPLOYEELIST.LastName.Contains(searchString) || t.tblEMPLOYEELIST.FirstName.Contains(searchString));

                // search by item name or employee name
                tblPOSITIONACTUALs = tblPOSITIONACTUALs.Where(t => t.tblPOSITIONBUDGETED.tblBudItemNum.BudItemDesc.Contains(searchString)
                                                                || t.tblPOSITIONBUDGETED.BudItemNum.Contains(searchString)
                                                                || t.tblEMPLOYEELIST.LastName.Contains(searchString)
                                                                || t.tblEMPLOYEELIST.FirstName.Contains(searchString));
            }

            switch(sortOrder)
            {
                case "empltype_desc":
                    tblPOSITIONACTUALs = tblPOSITIONACTUALs.OrderByDescending(t => t.EmplType);
                    break;

                case "efdate":
                    tblPOSITIONACTUALs = tblPOSITIONACTUALs.OrderBy(t => t.EffectiveDate);
                    break;

                case "efdate_desc":
                    tblPOSITIONACTUALs = tblPOSITIONACTUALs.OrderByDescending(t => t.EffectiveDate);
                    break;

                default:
                    tblPOSITIONACTUALs = tblPOSITIONACTUALs.OrderBy(t => t.EmplType);
                    break;
            }

            int pageNumber = page ?? 1;
            int pageSize = 10;

            return View(tblPOSITIONACTUALs.ToPagedList(pageNumber, pageSize));
        }

        // GET: ActualP/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPOSITIONACTUAL tblPOSITIONACTUAL = db.tblPOSITIONACTUALs.Find(id);
            if (tblPOSITIONACTUAL == null)
            {
                return HttpNotFound();
            }
            return View(tblPOSITIONACTUAL);
        }

        private ActionResult FillFields()
        {
            var employees = from x in db.tblEMPLOYEELISTs
                            let myEmplID = x.EmplID + " - " + x.LastName + ", " + x.FirstName
                            where x.EmplStatus == "A"
                            select new { x.EmplID, myEmplID };

            ViewBag.EmplID = new SelectList(employees, "EmplID", "myEmplID");
            ViewBag.ActEmplStatus = new SelectList(db.tblEmplStatus, "EmplStatusCode", "EmplStatusDesc");
            ViewBag.EmplType = new SelectList(db.tblEmploymentTypes, "EmplType", "EmplTypeDesc");
            ViewBag.PayPeriod = new SelectList(db.tblPayPeriods, "PayTypeID", "PayTypeDesc");

            var budpos = from x in db.tblPOSITIONBUDGETEDs
                         where x.BudFilled == 0
                         select new { x.BudPosNum };
            ViewBag.ActPosNum = new SelectList(budpos, "BudPosNum", "BudPosNum");
            ViewBag.Step = new SelectList(db.tblSteps, "Step", "Step");

            var items = from x in db.tblBudItemNums
                        let itemInfo = x.BudItemNum + " - " + x.BudItemDesc
                        orderby x.BudItemNum
                        select new { x.BudItemNum, itemInfo };
            ViewBag.ActItemNum = new SelectList(items, "BudItemNum", "itemInfo");
            ViewBag.PreItemNum = new SelectList(items, "BudItemNum", "itemInfo");

            var subitems = from x in db.tblSubItems
                           let subinfo = x.SubItemCode + " - " + x.SubItemDesc
                           orderby x.SubItemCode
                           select new { x.SubItemCode, subinfo };
            ViewBag.ActSubItem = new SelectList(subitems, "SubItemCode", "subinfo");
            ViewBag.PreSubItem = new SelectList(subitems, "SubItemCode", "subinfo");
            return View();
        }

        // GET: ActualP/Create
        public ActionResult Create()
        {
            return FillFields();
        }

        // POST: ActualP/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActPosAutoID,ActPosNum,EmplID,EffectiveDate,DeptHireDate,ActEmplStatus,ActItemNum,ActSubItem,Step,PayRate,PayPeriod,EmplType,PreItemNum,PreSubItem,ReasonOfChange,Comments")] tblPOSITIONACTUAL tblPOSITIONACTUAL)
        {
            if (ModelState.IsValid)
            {
                db.tblPOSITIONACTUALs.Add(tblPOSITIONACTUAL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return FillFields();
        }

        // GET: ActualP/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPOSITIONACTUAL tblPOSITIONACTUAL = db.tblPOSITIONACTUALs.Find(id);
            if (tblPOSITIONACTUAL == null)
            {
                return HttpNotFound();
            }
            //ViewBag.EmplID = new SelectList(db.tblEMPLOYEELISTs, "EmplID", "LastName", tblPOSITIONACTUAL.EmplID);
            ViewBag.EmplID = new SelectList(db.tblEMPLOYEELISTs, "EmplID", "EmplID", tblPOSITIONACTUAL.EmplID);
            ViewBag.EmplType = new SelectList(db.tblEmploymentTypes, "EmplType", "EmplTypeDesc", tblPOSITIONACTUAL.EmplType);
            ViewBag.PayPeriod = new SelectList(db.tblPayPeriods, "PayTypeID", "PayTypeDesc", tblPOSITIONACTUAL.PayPeriod);
            //ViewBag.ActPosNum = new SelectList(db.tblPOSITIONBUDGETEDs, "BudPosNum", "BudItemNum", tblPOSITIONACTUAL.ActPosNum);
            ViewBag.ActPosNum = new SelectList(db.tblPOSITIONBUDGETEDs, "BudPosNum", "BudPosNum", tblPOSITIONACTUAL.ActPosNum);
            ViewBag.Step = new SelectList(db.tblSteps, "Step", "Step", tblPOSITIONACTUAL.Step);
            return View(tblPOSITIONACTUAL);
        }

        // POST: ActualP/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActPosAutoID,ActPosNum,EmplID,EffectiveDate,DeptHireDate,ActEmplStatus,ActItemNum,ActSubItem,Step,PayRate,PayPeriod,EmplType,PreItemNum,PreSubItem,ReasonOfChange,Comments")] tblPOSITIONACTUAL tblPOSITIONACTUAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPOSITIONACTUAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmplID = new SelectList(db.tblEMPLOYEELISTs, "EmplID", "EmplID", tblPOSITIONACTUAL.EmplID);
            ViewBag.EmplType = new SelectList(db.tblEmploymentTypes, "EmplType", "EmplTypeDesc", tblPOSITIONACTUAL.EmplType);
            ViewBag.PayPeriod = new SelectList(db.tblPayPeriods, "PayTypeID", "PayTypeDesc", tblPOSITIONACTUAL.PayPeriod);
            ViewBag.ActPosNum = new SelectList(db.tblPOSITIONBUDGETEDs, "BudPosNum", "BudPosNum", tblPOSITIONACTUAL.ActPosNum);
            ViewBag.Step = new SelectList(db.tblSteps, "Step", "Step", tblPOSITIONACTUAL.Step);
            return View(tblPOSITIONACTUAL);
        }

        // GET: ActualP/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPOSITIONACTUAL tblPOSITIONACTUAL = db.tblPOSITIONACTUALs.Find(id);
            if (tblPOSITIONACTUAL == null)
            {
                return HttpNotFound();
            }
            return View(tblPOSITIONACTUAL);
        }

        // POST: ActualP/Delete/5
        [Authorize(Roles = "RSG.DBH_ItemCtlDBA")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPOSITIONACTUAL tblPOSITIONACTUAL = db.tblPOSITIONACTUALs.Find(id);
            db.tblPOSITIONACTUALs.Remove(tblPOSITIONACTUAL);
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
