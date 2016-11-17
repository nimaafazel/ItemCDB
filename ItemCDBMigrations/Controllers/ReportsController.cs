using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItemCDBMigrations.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Call to our aspx page to show the report.
        /// </summary>
        /// <returns></returns>
        public ActionResult LocalReport()
        {
            return Redirect("../ReprtVwr/ReprtVwr.aspx?repLoc=local");
        }
    }
}