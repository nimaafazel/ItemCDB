﻿using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ItemCDBMigrations.Controllers;

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
                    switch (param)
                    {
                        case ReportsController.REPORT_VACBYDIV:
                            showLocalReportVacByDivision();
                            break;

                        case ReportsController.REPORT_VACBYBUDITEMDESC:
                            showLocalReportVacByBudItemDesc();
                            break;

                        case ReportsController.REPORT_ITEMSENCUMBERED:
                            showLocalItemsEncumbered();
                            break;

                        case ReportsController.REPORT_ORGCODES:
                            showLocalOrgCodesByEmplID();
                            break;

                        case ReportsController.REPORT_BUDPOSBYEMPLLN:
                            showLocalBudPosByEmployeeLN();
                            break;

                        default:
                            showLocal();
                            break;
                    }
                    /*
                    if (param == "local")
                        showLocalReport();                    
                    if (param == "remote")
                        showRemoteReport();
                        */
                }
            }
        }

        private void showLocal()
        {
            try
            {
                // report url         
                string localReportPath = "LocalReports/BudPosByDivisionDept.rdlc";

                // processing mode
                rptViewer.ProcessingMode = ProcessingMode.Local;

                // set the report path
                rptViewer.LocalReport.ReportPath = localReportPath;

                var dataSource = new ICDataSet6TableAdapters.View_BudgetPosByDivisionDep2TableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("BudPosByDivisionDepDataSet", (object)dataSource));

                // refresh the report
                rptViewer.LocalReport.Refresh();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void showLocalReportVacByDivision()
        {
            try
            {
                // report url         
                string localReportPath = "LocalReports/VacByDivision.rdlc";
                
                // processing mode
                rptViewer.ProcessingMode = ProcessingMode.Local;

                // set the report path
                rptViewer.LocalReport.ReportPath = localReportPath;

                var dataSource = new ICDataSet1TableAdapters.View_VacByDivision6TableAdapter().GetData();              
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ICDataSet1", (object)dataSource));                

                // refresh the report
                rptViewer.LocalReport.Refresh();             
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void showLocalReportVacByBudItemDesc()
        {
            try
            {
                // report url         
                string localReportPath = "LocalReports/VacByBudItemDesc.rdlc";


                // processing mode
                rptViewer.ProcessingMode = ProcessingMode.Local;

                // set the report path
                rptViewer.LocalReport.ReportPath = localReportPath;

                var dataSource = new ICDataSet2TableAdapters.View_VacByBudItemDescription2TableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("VacByBudItemDescDataSet", (object)dataSource));

                // refresh the report
                rptViewer.LocalReport.Refresh();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void showLocalItemsEncumbered()
        {
            try
            {
                // report url         
                string localReportPath = "LocalReports/ItemsEncumbered.rdlc";

                // processing mode
                rptViewer.ProcessingMode = ProcessingMode.Local;

                // set the report path
                rptViewer.LocalReport.ReportPath = localReportPath;

                var dataSource = new ICDataSet3TableAdapters.View_ItemsEncumbered2TableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ItemsEncumberedDataSet", (object)dataSource));

                // refresh the report
                rptViewer.LocalReport.Refresh();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void showLocalOrgCodesByEmplID()
        {
            try
            {
                // report url         
                string localReportPath = "LocalReports/OrgCodesByEmplID.rdlc";

                // processing mode
                rptViewer.ProcessingMode = ProcessingMode.Local;

                // set the report path
                rptViewer.LocalReport.ReportPath = localReportPath;

                var dataSource = new ICDataSet4TableAdapters.View_OrgCodesByEmplID2TableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("OrgCodesByEmplIDDataSet", (object)dataSource));

                // refresh the report
                rptViewer.LocalReport.Refresh();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void showLocalBudPosByEmployeeLN()
        {
            try
            {
                // report url         
                string localReportPath = "LocalReports/BudPosByEmployeeLN.rdlc";

                // processing mode
                rptViewer.ProcessingMode = ProcessingMode.Local;

                // set the report path
                rptViewer.LocalReport.ReportPath = localReportPath;

                var dataSource = new ICDataSet5TableAdapters.View_BudgetPosByEmployeeLN2TableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("BudPosByEmployeeLNDataSet", (object)dataSource));

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