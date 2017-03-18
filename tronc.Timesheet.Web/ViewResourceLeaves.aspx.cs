using Log4NetLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tronc.Timesheet.BL.Repository;
using tronc.Timesheet.Common.Entities;
using tronc.Timesheet.Web.Utils;

namespace tronc.Timesheet.Web
{
    public partial class ViewResourceLeaves : System.Web.UI.Page
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SessionManager.UserDetails != null)
                {
                    LoadDropDown();
                    int yId = Convert.ToInt32(ddlYear.SelectedValue);
                    int monthId = Convert.ToInt32(ddlMonth.SelectedValue);
                    GetYMResourceLeave(yId, monthId);
                }
                else
                {
                    Response.Redirect("TroncLogin.aspx?returnURL=ViewResourceLeaves.aspx");
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int yearId = Convert.ToInt32(ddlYear.SelectedValue);
            int monthId = Convert.ToInt32(ddlMonth.SelectedValue);
            GetYMResourceLeave(yearId, monthId);

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton hlEdit = (LinkButton)e.Row.FindControl("hlEdit");
                hlEdit.Text = "Edit";

                string leaveDate = ((Leave)e.Row.DataItem).LeaveDate.ToString("MM/dd/yyyy"); ;
                Label lblLeaveDate = (Label)e.Row.FindControl("lblLeaveDate");
                lblLeaveDate.Text = leaveDate;

            }
        }
        protected void grdLeave_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Leave"))
            {
                string queryParameter = e.CommandArgument.ToString();
                string[] arrParameters = queryParameter.Split('|');
                string rId = arrParameters[0].ToString();
                string lId = arrParameters[1].ToString();
                Response.Redirect("troncApplyLeave.aspx?RId=" + rId + "&LId=" + lId);
            }
        }
        protected void btnExport_Click(object sender, ImageClickEventArgs e)
        {
            if (grdLeave.Rows.Count > 0)
            {
                ExportToExcel();
            }
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Year> GetYear()
        {
            List<Year> lstYear = new List<Year>();
            TimesheetRepository timeSheetRepository = new TimesheetRepository();
            try
            {
                lstYear = timeSheetRepository.GetYear();
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(FloorPoolTimesheet));
                StringBuilder strbError = new StringBuilder();
                strbError.AppendLine(ex.StackTrace.ToString());
                strbError.AppendLine(ex.Message.ToString());
                if (ex.InnerException != null)
                {
                    strbError.AppendLine(ex.InnerException.ToString());
                }
                logService.Error(strbError.ToString());
                throw new Exception(ex.Message);
            }
            return lstYear;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Month> GetMonth()
        {
            List<Month> lstMonth = new List<Month>();
            TimesheetRepository timeSheetRepository = new TimesheetRepository();
            try
            {
                lstMonth = timeSheetRepository.GetMonth();
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(FloorPoolTimesheet));
                StringBuilder strbError = new StringBuilder();
                strbError.AppendLine(ex.StackTrace.ToString());
                strbError.AppendLine(ex.Message.ToString());
                if (ex.InnerException != null)
                {
                    strbError.AppendLine(ex.InnerException.ToString());
                }
                logService.Error(strbError.ToString());
                throw new Exception(ex.Message);
            }
            return lstMonth;
        }

        private void LoadDropDown()
        {

            try
            {

                List<Year> lstYear = GetYear();
                if (lstYear != null && lstYear.Count > 0)
                {
                    ddlYear.DataSource = lstYear;
                    ddlYear.DataTextField = "YearNumber";
                    ddlYear.DataValueField = "YearId";
                    ddlYear.DataBind();
                    int curYear = System.DateTime.Now.Year;
                    int yId = (from item in lstYear
                               where !string.IsNullOrEmpty(item.YearId.ToString())
                               && item.YearNumber.ToString().Equals(curYear.ToString())
                               select item.YearId).FirstOrDefault();
                    ddlYear.SelectedValue = yId.ToString();
                }

                List<Month> lstMonth = GetMonth();
                if (lstMonth != null && lstMonth.Count > 0)
                {
                    ddlMonth.DataSource = lstMonth;
                    ddlMonth.DataTextField = "MonthName";
                    ddlMonth.DataValueField = "MonthId";
                    ddlMonth.DataBind();
                    string curMonth = System.DateTime.Now.ToString("MMMM");
                    int mnth = (from item in lstMonth
                                where !string.IsNullOrEmpty(item.MonthId.ToString())
                                && item.MonthName.ToUpper().Equals(curMonth.ToUpper())
                                select item.MonthId).FirstOrDefault();
                    ddlMonth.SelectedValue = mnth.ToString();
                }

            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(FloorPoolTimesheet));
                StringBuilder strbError = new StringBuilder();
                strbError.AppendLine(ex.StackTrace.ToString());
                strbError.AppendLine(ex.Message.ToString());
                if (ex.InnerException != null)
                {
                    strbError.AppendLine(ex.InnerException.ToString());
                }
                logService.Error(strbError.ToString());
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// To get the leaves applied by the resources based on the on the selected Month and Year
        /// </summary>
        /// <param name="yId"></param>
        /// <param name="monthId"></param>
        private void GetYMResourceLeave(int yId, int monthId)
        {
            TimesheetRepository timesheetRepository = new TimesheetRepository();
            List<Leave> lstResourceLeave = new List<Leave>();
            try
            {
                lstResourceLeave = timesheetRepository.GetYMResourceLeaves(yId, monthId);
                if (lstResourceLeave != null && lstResourceLeave.Count > 0)
                {
                    grdLeave.DataSource = lstResourceLeave;
                    grdLeave.DataBind();
                }
                else
                {
                    grdLeave.DataSource = null;
                    grdLeave.DataBind();
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(FloorPoolTimesheet));
                StringBuilder strbError = new StringBuilder();
                strbError.AppendLine(ex.StackTrace.ToString());
                strbError.AppendLine(ex.Message.ToString());
                if (ex.InnerException != null)
                {
                    strbError.AppendLine(ex.InnerException.ToString());
                }
                logService.Error(strbError.ToString());
                throw new Exception(ex.Message);
            }
        }
        protected void ExportToExcel()
        {
            string yearName = ddlYear.SelectedItem.Text;
            string monthName = ddlMonth.SelectedItem.Text;
            string fileName = yearName + "_" + monthName + "_" + "Leave_Plan" + ".xls";
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Charset = "";
                string FileName = fileName;
                StringWriter strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                grdLeave.GridLines = GridLines.Both;
                grdLeave.HeaderStyle.Font.Bold = true;
                grdLeave.Columns[grdLeave.Columns.Count - 1].Visible = false;
                grdLeave.RenderControl(htmltextwrtter);
                Response.Write(strwritter.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(FloorPoolTimesheet));
                StringBuilder strbError = new StringBuilder();
                strbError.AppendLine(ex.StackTrace.ToString());
                strbError.AppendLine(ex.Message.ToString());
                if (ex.InnerException != null)
                {
                    strbError.AppendLine(ex.InnerException.ToString());
                }
                logService.Error(strbError.ToString());
                throw new Exception(ex.Message);
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        #endregion
    }
}