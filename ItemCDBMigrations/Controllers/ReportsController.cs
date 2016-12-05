using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItemCDBMigrations.Controllers
{
    public class ReportsController : Controller
    {
        public const string REPORT_VACBYDIV = "VacancyByDivision";
        public const string REPORT_VACBYBUDITEMDESC = "VacancyByBudItemDescription";
        public const string REPORT_ITEMSENCUMBERED = "ItemsEncumbered";
        public const string REPORT_ORGCODES = "OrgCodes";
        public const string REPORT_BUDPOSBYEMPLLN = "BudPosByEmployeeLN";
        public const string REPORT_BUDPOSBYDIVDEPT = "BudPosByDivisionDept";
        public const string REPORT_EMPLOYEELISTPERMTEMP = "EmployeeListPermTemp";
        public const string REPORT_ITEMCTRLBYDIV = "ItemControlByDiv";
        public const string REPORT_ITEMCTRLBYDIVDEPT = "ItemControlByDivDept";
        public const string REPORT_ITEMCTRLBYDIVBEACHES = "ItemControlByDivBeaches";
        public const string REPORT_ITEMCTRLBYDIVMARINA = "ItemControlByDivMarina";
        public const string REPORT_ITEMCTRLBYBUDITEMDEPT = "ItemControlByBudItemDept";
        public const string REPORT_ITEMCTRLBYBUDITEMBEACHES = "ItemControlByBudItemBeaches";

        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Call to our aspx page to show the report.
        /// </summary>
        /// <returns></returns>
        public ActionResult LocalReport(string reportName)
        {
            return Redirect("../ReprtVwr/ReprtVwr.aspx?repLoc=" + reportName);            
        }
    }
}