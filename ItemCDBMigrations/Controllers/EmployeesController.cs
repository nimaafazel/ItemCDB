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
    public class EmployeesController : Controller
    {
        private ICContext db = new ICContext();

        // I leave the progression of Index commented for future reference.

        // GET: Employees
        //public ActionResult Index()
        //{
        //    var tblEMPLOYEELISTs = db.tblEMPLOYEELISTs.Include(t => t.tblEmplStatu).Include(t => t.tblEthnicity).Include(t => t.tblGender).Include(t => t.tblPayLocation);
        //    return View(tblEMPLOYEELISTs.ToList());
        //}

        /// Search Employee by Last Name
        //public ActionResult Index(string searchString)
        //{
        //    // fill the list of properties to search by
        //    //List<string> listProperties = new List<string>();
        //    //listProperties = (from t in typeof(tblEMPLOYEELIST).GetProperties()
        //    //            select t.Name).ToList();
        //    //ViewBag.searchProperties = new SelectList(listProperties);


        //    if(!string.IsNullOrEmpty(searchString))
        //    {
        //        // get all employees
        //        var tblEMPLOYEELISTs = db.tblEMPLOYEELISTs.Include(t => t.tblEmplStatu).Include(t => t.tblEthnicity).Include(t => t.tblGender).Include(t => t.tblPayLocation);

        //        // filter down by the search value
        //        tblEMPLOYEELISTs = tblEMPLOYEELISTs.Where(e => e.LastName.Contains(searchString));

        //        // return them as a List
        //        List<tblEMPLOYEELIST> listOfEmployees = tblEMPLOYEELISTs.ToList();
        //        return View(listOfEmployees);
        //    }

        //    // empty view
        //    return View();
        //}


        /// Search and sort
        //public ActionResult Index(string searchString, string sortOrder)
        //{
        //    // fill the list of properties to search by
        //    //List<string> listProperties = new List<string>();
        //    //listProperties = (from t in typeof(tblEMPLOYEELIST).GetProperties()
        //    //            select t.Name).ToList();
        //    //ViewBag.searchProperties = new SelectList(listProperties);

        //    ViewBag.SearchString = searchString;  // save the searchString

        //    // set the sort parameter
        //    ViewBag.SortLastNameParam = string.IsNullOrEmpty(sortOrder) ? "lname_desc" : "";
        //    ViewBag.SortFirstNameParam = sortOrder == "fname" ? "fname_desc" : "fname";
        //    ViewBag.SortDateSeniorParam = sortOrder == "Date" ? "date_desc" : "Date";

        //    // get all employees
        //    var tblEMPLOYEELISTs = db.tblEMPLOYEELISTs.Include(t => t.tblEmplStatu).Include(t => t.tblEthnicity).Include(t => t.tblGender).Include(t => t.tblPayLocation);

        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        // filter down by the search value
        //        tblEMPLOYEELISTs = tblEMPLOYEELISTs.Where(e => e.LastName.Contains(searchString) || e.FirstName.Contains(searchString));
        //    }
        //    else
        //        return View();

        //    // sort the results
        //    switch(sortOrder)
        //    {
        //        case "lname_desc":
        //            tblEMPLOYEELISTs = tblEMPLOYEELISTs.OrderByDescending(emp => emp.LastName);
        //            break;

        //        case "fname_desc":
        //            tblEMPLOYEELISTs = tblEMPLOYEELISTs.OrderByDescending(emp => emp.FirstName);
        //            break;

        //        case "fname":
        //            tblEMPLOYEELISTs = tblEMPLOYEELISTs.OrderBy(emp => emp.FirstName);
        //            break;

        //        case "Date":
        //            tblEMPLOYEELISTs = tblEMPLOYEELISTs.OrderByDescending(emp => emp.SeniorityDate);
        //            break;

        //        case "date_desc":
        //            tblEMPLOYEELISTs = tblEMPLOYEELISTs.OrderBy(emp => emp.SeniorityDate);
        //            break;

        //        default:
        //            tblEMPLOYEELISTs = tblEMPLOYEELISTs.OrderBy(emp => emp.LastName);
        //            break;
        //    }

        //    // return them as a List
        //    List<tblEMPLOYEELIST> listOfEmployees = tblEMPLOYEELISTs.ToList();
        //    return View(listOfEmployees);
        //}

        /// Search, sort and pagination
        public ActionResult Index(string searchString, string sortOrder, string currentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder; // save the current sort order for the pagination
            
            // set the sort parameter on the links by switching the current one
            ViewBag.SortLastNameParam = string.IsNullOrEmpty(sortOrder) ? "lname_desc" : "";
            ViewBag.SortFirstNameParam = sortOrder == "fname" ? "fname_desc" : "fname";
            ViewBag.SortDateSeniorParam = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null) // if we just searched, we go to the first page
            {
                page = 1;
            }
            else
                searchString = currentFilter;  // if not, we save the currentFilter in the searchString to paginate

            ViewBag.CurrentFilter = searchString;  // save the current filter            

            // get all employees
            var tblEMPLOYEELISTs = db.tblEMPLOYEELISTs.Include(t => t.tblEmplStatu).Include(t => t.tblEthnicity).Include(t => t.tblGender).Include(t => t.tblPayLocation);

            if (!string.IsNullOrEmpty(searchString))
            {
                // filter down by the search value
                tblEMPLOYEELISTs = tblEMPLOYEELISTs.Where(e => e.LastName.Contains(searchString) || e.FirstName.Contains(searchString));
            }
            
            // sort the results
            switch (sortOrder)
            {
                case "lname_desc":
                    tblEMPLOYEELISTs = tblEMPLOYEELISTs.OrderByDescending(emp => emp.LastName);
                    break;

                case "fname_desc":
                    tblEMPLOYEELISTs = tblEMPLOYEELISTs.OrderByDescending(emp => emp.FirstName);
                    break;

                case "fname":
                    tblEMPLOYEELISTs = tblEMPLOYEELISTs.OrderBy(emp => emp.FirstName);
                    break;

                case "Date":
                    tblEMPLOYEELISTs = tblEMPLOYEELISTs.OrderByDescending(emp => emp.SeniorityDate);
                    break;

                case "date_desc":
                    tblEMPLOYEELISTs = tblEMPLOYEELISTs.OrderBy(emp => emp.SeniorityDate);
                    break;

                default:
                    tblEMPLOYEELISTs = tblEMPLOYEELISTs.OrderBy(emp => emp.LastName);
                    break;
            }

            // get the number of results
            ViewBag.NumberOfResults = tblEMPLOYEELISTs.Count();

            // page according to the page number
            int pageSize = 10;  // set number of results by page
            int pageNumber = (page ?? 1);  // page == null ? 1 : page

            // return the page with the subset of elements from the query
            return View(tblEMPLOYEELISTs.ToPagedList(pageNumber, pageSize));
        }


        // GET: Employees/Details/5
        /// <summary>
        /// Displays the Employee Details.
        /// </summary>
        /// <param name="id">The Employee ID</param>
        /// <returns>A View with the tblEMPLOYEELIST model if Id found, or a HTTP error if not found.</returns>
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
        /// <summary>
        /// Prepares the model to display the Create View for a new Employee
        /// </summary>
        /// <returns>A View</returns>
        public ActionResult Create()
        {
            // Set up the list of options for each DropDownList
            ViewBag.EmplStatus = new SelectList(db.tblEmplStatus, "EmplStatusCode", "EmplStatusDesc");
            ViewBag.Ethnicity = new SelectList(db.tblEthnicities, "EthnicCode", "EthnicDesc");
            ViewBag.Gender = new SelectList(db.tblGenders, "GenderCode", "GenderDesc");
            ViewBag.PayLoc = new SelectList(db.tblPayLocations, "PayLocCode", "PayLocDesc");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Saves the new Employee created if all the validations pass, otherwise, prepares the model to repopulate the view with the recent values.
        /// </summary>
        /// <param name="tblEMPLOYEELIST">The new Employee model instance.</param>
        /// <returns>A redirect to Index if succesful, or a retry on the same view with the validation messages.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmplID,LastName,FirstName,MiddleName,NameSuffix,EmplStatus,SeniorityDate,PayLoc,BirthDate,Gender,Ethnicity,Comments,ehrPositionID,ehrUnitNumber,SSMA_TimeStamp")] tblEMPLOYEELIST tblEMPLOYEELIST)
        {
            if (ModelState.IsValid)  // check the model validations
            {
                db.tblEMPLOYEELISTs.Add(tblEMPLOYEELIST);  // add the new entry to the context
                db.SaveChanges();                          // save the changes to the database
                return RedirectToAction("Index");          // go back to index
            }

            // prepare the model with the values already picked by the user
            ViewBag.EmplStatus = new SelectList(db.tblEmplStatus, "EmplStatusCode", "EmplStatusDesc", tblEMPLOYEELIST.EmplStatus);
            ViewBag.Ethnicity = new SelectList(db.tblEthnicities, "EthnicCode", "EthnicDesc", tblEMPLOYEELIST.Ethnicity);
            ViewBag.Gender = new SelectList(db.tblGenders, "GenderCode", "GenderDesc", tblEMPLOYEELIST.Gender);
            ViewBag.PayLoc = new SelectList(db.tblPayLocations, "PayLocCode", "PayLocDesc", tblEMPLOYEELIST.PayLoc);
            return View(tblEMPLOYEELIST);
        }

        // GET: Employees/Edit/5
        /// <summary>
        /// Displays the Edit Form for an existent Employee.
        /// </summary>
        /// <param name="id">The Employee ID</param>
        /// <returns>A View with the found Employee values populated on the model, or a HTTP error if not found. </returns>
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
        /// <summary>
        /// Saves the new Employee changes if all the validations pass, otherwise, prepares the model to repopulate the view with the recent values.
        /// </summary>
        /// <param name="tblEMPLOYEELIST">The Employee model instance with the values from the View.</param>
        /// <returns>A redirect to Index if succesful, or a retry on the same view with the validation messages.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmplID,LastName,FirstName,MiddleName,NameSuffix,EmplStatus,SeniorityDate,PayLoc,BirthDate,Gender,Ethnicity,Comments,ehrPositionID,ehrUnitNumber")] tblEMPLOYEELIST tblEMPLOYEELIST)        
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
        /// <summary>
        /// Displays the information for the Employee to be deleted.
        /// </summary>
        /// <param name="id">The Employee ID</param>
        /// <returns>A View with the tblEMPLOYEELIST model if ID is found, or a HTTP error if not found.</returns>
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
        /// <summary>
        /// Deletes an Employee from the database. This method has the Authorize attribute for a specific Role. Only Users in this role can execute this method.
        /// </summary>
        /// <param name="id">The Employee ID</param>
        /// <returns>A redirect to Index.</returns>
        [Authorize(Roles = "RSG.DBH_ItemCtlDBA")]
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
