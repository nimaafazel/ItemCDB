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
    /// <summary>
    /// Used an aspx Page to get the ReportViewer working on MVC.
    /// This Page takes the id of the report and displays the appropiate report.
    /// </summary>
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

                        case ReportsController.REPORT_BUDPOSBYDIVDEPT:
                            showLocalBudPosByDivisionDept();
                            break;

                        case ReportsController.REPORT_EMPLOYEELISTPERMTEMP:
                            showLocalEmployeeListPermTemp();
                            break;

                        case ReportsController.REPORT_ITEMCTRLBYDIV:
                            showLocalItemControlByDiv();
                            break;

                        case ReportsController.REPORT_ITEMCTRLBYDIVDEPT:
                            showLocalItemControlByDivDept();
                            break;

                        case ReportsController.REPORT_ITEMCTRLBYDIVBEACHES:
                            showLocalItemControlByDivBeaches();
                            break;

                        case ReportsController.REPORT_ITEMCTRLBYDIVMARINA:
                            showLocalItemControlByDivMarina();
                            break;

                        case ReportsController.REPORT_ITEMCTRLBYBUDITEMDEPT:
                            showLocalItemControlByBudItemDescDept();
                            break;

                        case ReportsController.REPORT_ITEMCTRLBYBUDITEMBEACHES:
                            showLocalItemControlByBudItemDescBeaches();
                            break;

                        case ReportsController.REPORT_ITEMCTRLBYBUDITEMMARINA:
                            showLocalItemControlByBudItemDescMarina();
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
                string localReportPath = "LocalReports/ItemControlByBudItemDescMarina.rdlc";

                // processing mode
                rptViewer.ProcessingMode = ProcessingMode.Local;

                // set the report path
                rptViewer.LocalReport.ReportPath = localReportPath;

                var dataSource = new ItemCtrlDataSetTableAdapters.View_ItemControlByBudItemDescForMarina2TableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ItemControlByBudItemDescMarinaDataSet", (object)dataSource));

                // refresh the report
                rptViewer.LocalReport.Refresh();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #region LocalReports

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

                var dataSource = new ItemCtrlDataSetTableAdapters.View_FVacByDivisionTableAdapter().GetData();          
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("VacByDivisionDataSet", (object)dataSource));                

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

                var dataSource = new ItemCtrlDataSetTableAdapters.View_FVacByBudItemDescTableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("VacByBudgetItemDescDataSet", (object)dataSource));

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

                var dataSource = new ItemCtrlDataSetTableAdapters.View_FItemsEncumberedTableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ItemsEncumberedFDataSet", (object)dataSource));

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

                var dataSource = new ItemCtrlDataSetTableAdapters.View_FOrgCoodesByEmplIDTableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("OrgCodesByEmpIDDataSet", (object)dataSource));

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

                var dataSource = new ItemCtrlDataSetTableAdapters.View_FBudgetPosByEmployeeLNTableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("BudPosByEmplLNDataSet", (object)dataSource));

                // refresh the report
                rptViewer.LocalReport.Refresh();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void showLocalBudPosByDivisionDept()
        {
            try
            {
                // report url         
                string localReportPath = "LocalReports/BudPosByDivisionDept.rdlc";

                // processing mode
                rptViewer.ProcessingMode = ProcessingMode.Local;

                // set the report path
                rptViewer.LocalReport.ReportPath = localReportPath;

                var dataSource = new ItemCtrlDataSetTableAdapters.View_FBudgetPosByDivisionDepTableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("BudPosByDivForDeptDataSet", (object)dataSource));

                // refresh the report
                rptViewer.LocalReport.Refresh();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void showLocalEmployeeListPermTemp()
        {
            try
            {
                // report url         
                string localReportPath = "LocalReports/EmployeeListPermAndTemp.rdlc";

                // processing mode
                rptViewer.ProcessingMode = ProcessingMode.Local;

                // set the report path
                rptViewer.LocalReport.ReportPath = localReportPath;

                var dataSource = new ItemCtrlDataSetTableAdapters.View_FEmployeeListTempAndPermTableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("EmplListPermTempDataSet", (object)dataSource));

                // refresh the report
                rptViewer.LocalReport.Refresh();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void showLocalItemControlByDiv()
        {
            try
            {
                // report url         
                string localReportPath = "LocalReports/ItemControlByDivision.rdlc";

                // processing mode
                rptViewer.ProcessingMode = ProcessingMode.Local;

                // set the report path
                rptViewer.LocalReport.ReportPath = localReportPath;

                var dataSource = new ItemCtrlDataSetTableAdapters.View_FItemControlByDivTableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ItemControlByDivisionDataSet", (object)dataSource));

                // refresh the report
                rptViewer.LocalReport.Refresh();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void showLocalItemControlByDivDept()
        {
            try
            {
                // report url         
                string localReportPath = "LocalReports/ItemControlByDivDept.rdlc";

                // processing mode
                rptViewer.ProcessingMode = ProcessingMode.Local;

                // set the report path
                rptViewer.LocalReport.ReportPath = localReportPath;

                var dataSource = new ItemCtrlDataSetTableAdapters.View_ItemControlByDivForDept4TableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ItemControlByDivForDeptDataSet", (object)dataSource));

                // refresh the report
                rptViewer.LocalReport.Refresh();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void showLocalItemControlByDivBeaches()
        {
            try
            {
                // report url         
                string localReportPath = "LocalReports/ItemControlByDivBeaches.rdlc";

                // processing mode
                rptViewer.ProcessingMode = ProcessingMode.Local;

                // set the report path
                rptViewer.LocalReport.ReportPath = localReportPath;

                var dataSource = new ItemCtrlDataSetTableAdapters.View_FItemControlByDivForBeachesTableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ItemCtrlByDivBeachesDataSet", (object)dataSource));

                // refresh the report
                rptViewer.LocalReport.Refresh();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void showLocalItemControlByDivMarina()
        {
            try
            {
                // report url         
                string localReportPath = "LocalReports/ItemControlByDivMarina.rdlc";

                // processing mode
                rptViewer.ProcessingMode = ProcessingMode.Local;

                // set the report path
                rptViewer.LocalReport.ReportPath = localReportPath;

                var dataSource = new ItemCtrlDataSetTableAdapters.View_FItemControlByDivForMarinaTableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ItemCtrlByDivMarinaDataSet", (object)dataSource));

                // refresh the report
                rptViewer.LocalReport.Refresh();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void showLocalItemControlByBudItemDescDept()
        {
            try
            {
                // report url         
                string localReportPath = "LocalReports/ItemControlByBudItemDescDept.rdlc";

                // processing mode
                rptViewer.ProcessingMode = ProcessingMode.Local;

                // set the report path
                rptViewer.LocalReport.ReportPath = localReportPath;

                var dataSource = new ItemCtrlDataSetTableAdapters.View_FItemControlByBudItemDescForDeptTableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ItemControlByBudItemDescDeptDataSet", (object)dataSource));

                // refresh the report
                rptViewer.LocalReport.Refresh();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void showLocalItemControlByBudItemDescBeaches()
        {
            try
            {
                // report url         
                string localReportPath = "LocalReports/ItemControlByBudItemDescBeaches.rdlc";

                // processing mode
                rptViewer.ProcessingMode = ProcessingMode.Local;

                // set the report path
                rptViewer.LocalReport.ReportPath = localReportPath;

                var dataSource = new ItemCtrlDataSetTableAdapters.View_FItemControlByBudItemDescForBeachesTableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ItemCtrlByBudItemDescBeachesDataSet", (object)dataSource));

                // refresh the report
                rptViewer.LocalReport.Refresh();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void showLocalItemControlByBudItemDescMarina()
        {
            try
            {
                // report url         
                string localReportPath = "LocalReports/ItemControlByBudItemDescMarina.rdlc";

                // processing mode
                rptViewer.ProcessingMode = ProcessingMode.Local;

                // set the report path
                rptViewer.LocalReport.ReportPath = localReportPath;

                var dataSource = new ItemCtrlDataSetTableAdapters.View_FItemControlByBudItemDescMarinaTableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ItemCtrlByBudItemDescMarinaDataSet", (object)dataSource));

                // refresh the report
                rptViewer.LocalReport.Refresh();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
         
    }
}