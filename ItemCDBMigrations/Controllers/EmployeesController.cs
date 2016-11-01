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
    public class EmployeesController : Controller
    {
        private ICContext db = new ICContext();

        // GET: Employees
        //public ActionResult Index()
        //{
        //    var tblEMPLOYEELISTs = db.tblEMPLOYEELISTs.Include(t => t.tblEmplStatu).Include(t => t.tblEthnicity).Include(t => t.tblGender).Include(t => t.tblPayLocation);
        //    return View(tblEMPLOYEELISTs.ToList());
        //}

        /// Search Employee by Last Name
        public ActionResult Index(string searchString)
        {
            // fill the list of properties to search by
            //List<string> listProperties = new List<string>();
            //listProperties = (from t in typeof(tblEMPLOYEELIST).GetProperties()
            //            select t.Name).ToList();
            //ViewBag.searchProperties = new SelectList(listProperties);
            

            if(!string.IsNullOrEmpty(searchString))
            {
                // get all employees
                var tblEMPLOYEELISTs = db.tblEMPLOYEELISTs.Include(t => t.tblEmplStatu).Include(t => t.tblEthnicity).Include(t => t.tblGender).Include(t => t.tblPayLocation);

                // filter down by the search value
                tblEMPLOYEELISTs = tblEMPLOYEELISTs.Where(e => e.LastName.Contains(searchString));

                // return them as a List
                List<tblEMPLOYEELIST> listOfEmployees = tblEMPLOYEELISTs.ToList();
                return View(listOfEmployees);
            }

            // empty view
            return View();
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEMPLOYEELIST tblEMPLOYEELIST = db.tblEMPLOYEELISTs.Find(id);
            if (tblEMPLOYEELIST == null)
            {
                return HttpNotFound();
            }
            return View(tblEMPLOYEELIST);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.EmplStatus = new SelectList(db.tblEmplStatus, "EmplStatusCode", "EmplStatusDesc");
            ViewBag.Ethnicity = new SelectList(db.tblEthnicities, "EthnicCode", "EthnicDesc");
            ViewBag.Gender = new SelectList(db.tblGenders, "GenderCode", "GenderDesc");
            ViewBag.PayLoc = new SelectList(db.tblPayLocations, "PayLocCode", "PayLocDesc");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmplID,LastName,FirstName,MiddleName,NameSuffix,EmplStatus,SeniorityDate,PayLoc,BirthDate,Gender,Ethnicity,Comments,ehrPositionID,ehrUnitNumber,SSMA_TimeStamp")] tblEMPLOYEELIST tblEMPLOYEELIST)
        {
            if (ModelState.IsValid)
            {
                db.tblEMPLOYEELISTs.Add(tblEMPLOYEELIST);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmplStatus = new SelectList(db.tblEmplStatus, "EmplStatusCode", "EmplStatusDesc", tblEMPLOYEELIST.EmplStatus);
            ViewBag.Ethnicity = new SelectList(db.tblEthnicities, "EthnicCode", "EthnicDesc", tblEMPLOYEELIST.Ethnicity);
            ViewBag.Gender = new SelectList(db.tblGenders, "GenderCode", "GenderDesc", tblEMPLOYEELIST.Gender);
            ViewBag.PayLoc = new SelectList(db.tblPayLocations, "PayLocCode", "PayLocDesc", tblEMPLOYEELIST.PayLoc);
            return View(tblEMPLOYEELIST);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEMPLOYEELIST tblEMPLOYEELIST = db.tblEMPLOYEELISTs.Find(id);
            if (tblEMPLOYEELIST == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmplStatus = new SelectList(db.tblEmplStatus, "EmplStatusCode", "EmplStatusDesc", tblEMPLOYEELIST.EmplStatus);
            ViewBag.Ethnicity = new SelectList(db.tblEthnicities, "EthnicCode", "EthnicDesc", tblEMPLOYEELIST.Ethnicity);
            ViewBag.Gender = new SelectList(db.tblGenders, "GenderCode", "GenderDesc", tblEMPLOYEELIST.Gender);
            ViewBag.PayLoc = new SelectList(db.tblPayLocations, "PayLocCode", "PayLocDesc", tblEMPLOYEELIST.PayLoc);
            return View(tblEMPLOYEELIST);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmplID,LastName,FirstName,MiddleName,NameSuffix,EmplStatus,SeniorityDate,PayLoc,BirthDate,Gender,Ethnicity,Comments,ehrPositionID,ehrUnitNumber,SSMA_TimeStamp")] tblEMPLOYEELIST tblEMPLOYEELIST)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEMPLOYEELIST).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmplStatus = new SelectList(db.tblEmplStatus, "EmplStatusCode", "EmplStatusDesc", tblEMPLOYEELIST.EmplStatus);
            ViewBag.Ethnicity = new SelectList(db.tblEthnicities, "EthnicCode", "EthnicDesc", tblEMPLOYEELIST.Ethnicity);
            ViewBag.Gender = new SelectList(db.tblGenders, "GenderCode", "GenderDesc", tblEMPLOYEELIST.Gender);
            ViewBag.PayLoc = new SelectList(db.tblPayLocations, "PayLocCode", "PayLocDesc", tblEMPLOYEELIST.PayLoc);
            return View(tblEMPLOYEELIST);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblEMPLOYEELIST tblEMPLOYEELIST = db.tblEMPLOYEELISTs.Find(id);
            if (tblEMPLOYEELIST == null)
            {
                return HttpNotFound();
            }
            return View(tblEMPLOYEELIST);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblEMPLOYEELIST tblEMPLOYEELIST = db.tblEMPLOYEELISTs.Find(id);
            db.tblEMPLOYEELISTs.Remove(tblEMPLOYEELIST);
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
