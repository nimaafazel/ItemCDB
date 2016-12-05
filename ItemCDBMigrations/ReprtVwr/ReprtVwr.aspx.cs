using Microsoft.Reporting.WebForms;
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
                string localReportPath = "LocalReports/ItemControlByBudItemDescBeaches.rdlc";

                // processing mode
                rptViewer.ProcessingMode = ProcessingMode.Local;

                // set the report path
                rptViewer.LocalReport.ReportPath = localReportPath;

                var dataSource = new ICDataSet18TableAdapters.View_ItemControlByBudItemDescForBeaches2TableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ItemControlByBudItemDescBeachesDataSet", (object)dataSource));

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

                var dataSource = new ICDataSet7TableAdapters.View_BudgetPosByDivisionDep3TableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("BudPosByDivDept2DataSet", (object)dataSource));

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

                var dataSource = new IC8DataSetTableAdapters.View_EmployeeListTempAndPerm2TableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("EmployeeListPermTempDataSet", (object)dataSource));

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

                var dataSource = new ICDataSet10TableAdapters.View_ItemControlByDiv4TableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ItemControlByDivDataSet3", (object)dataSource));

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

                var dataSource = new ICDataSet13TableAdapters.View_ItemControlByDivForDept4TableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ItemControlByDivForDept3DataSet", (object)dataSource));

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

                var dataSource = new ICDataSet14TableAdapters.View_ItemControlByDivForBeaches2TableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ItemControlByDivBeachesDataSet", (object)dataSource));

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

                var dataSource = new ICDataSet15TableAdapters.View_ItemControlByDivForMarina2TableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ItemControlByDivMarinaDataSet", (object)dataSource));

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

                var dataSource = new ICDataSet17TableAdapters.View_ItemControlByBudItemDescForDept3TableAdapter().GetData();
                rptViewer.LocalReport.DataSources.Add(new ReportDataSource("ItemControlByBudItemDescDeptDataSet2", (object)dataSource));

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