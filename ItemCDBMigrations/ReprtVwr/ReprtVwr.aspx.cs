using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ItemCDBMigrations.ReprtVwr
{
    public partial class ReprtVwr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // check the parameters to see which report are we going to show
                string param = Request["repLoc"];

                // load the report after the page loads
                if (!string.IsNullOrEmpty(param))
                {
                    
                    if (param == "local")
                        showLocalReport();
                    /*
                    if (param == "remote")
                        showRemoteReport();
                        */
                }
            }
        }

        private void showLocalReport()
        {
            try
            {
                // report url         
                string localReportPath = "LocalReports/VacByDivision.rdlc";

                
                // processing mode
                rptViewer.ProcessingMode = ProcessingMode.Local;

                // set the report path
                rptViewer.LocalReport.ReportPath = localReportPath;

                var dataSource = new ICViewsDataSetTableAdapters.View_VacByDivisionTableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ICViewsDataSet", (object)dataSource));                

                // refresh the report
                rptViewer.LocalReport.Refresh();                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}