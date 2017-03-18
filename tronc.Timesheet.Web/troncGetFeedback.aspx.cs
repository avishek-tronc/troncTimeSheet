using Log4NetLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tronc.Timesheet.BL.Repository;
using tronc.Timesheet.Common.Entities;
using tronc.Timesheet.Web.Utils;
using System.Xml;
using System.IO;

namespace tronc.Timesheet.Web
{
    public partial class troncGetFeedback : System.Web.UI.Page
    {
        /// <summary>
        /// Page Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDates();
                LoadDropDown();
                LoadFeedback();
            }
        }

        /// <summary>
        /// Load From and To Dates
        /// </summary>
        private void LoadDates()
        {
            DateTime firstDateOfCurrentMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime lastDateOfCurrentMonth = firstDateOfCurrentMonth.AddMonths(1).AddDays(-1);
            txtFromDate.Text = firstDateOfCurrentMonth.ToString("MM/dd/yyyy");
            txtToDate.Text = lastDateOfCurrentMonth.ToString("MM/dd/yyyy");
        }

        /// <summary>
        /// Load Deropdown Values
        /// </summary>
        private void LoadDropDown()
        {
            try
            {
                List<FeedbackCatagory> lstFeedbackCatagory = new List<FeedbackCatagory>();
                lstFeedbackCatagory = GetFeedbackCatagory();
                if (lstFeedbackCatagory != null && lstFeedbackCatagory.Count > 0)
                {
                    //Binding Feedback Catagory on DropdownList
                    ddlFeedbackCategory.DataSource = lstFeedbackCatagory;
                    ddlFeedbackCategory.DataTextField = "FeedbackCatagoryName";
                    ddlFeedbackCategory.DataValueField = "FeedbackCatagoryId";
                    ddlFeedbackCategory.DataBind();
                    ddlFeedbackCategory.Items.Insert(0, new ListItem("All","0"));
                }

            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(troncGetFeedback));
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
        /// Get the Feedback Category
        /// </summary>
        /// <returns></returns>
        public List<FeedbackCatagory> GetFeedbackCatagory()
        {
            TimesheetRepository timesheetRepository = new TimesheetRepository();
            List<FeedbackCatagory> lstFeedbackCatagory = new List<FeedbackCatagory>();
            try
            {
                lstFeedbackCatagory = timesheetRepository.GetFeedbackCatagory();
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(troncGetFeedback));
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
            return lstFeedbackCatagory;
        }

        /// <summary>
        /// Load Feedback Details
        /// </summary>
        private void LoadFeedback()
        {
            try
            {
                TimesheetRepository timesheetRepository = new TimesheetRepository();
                FeedbackLookup feedbackLookUp = new FeedbackLookup();
                feedbackLookUp.FeedbackFromDate = Convert.ToDateTime(txtFromDate.Text);
                feedbackLookUp.FeedbackToDate = Convert.ToDateTime(txtToDate.Text);
                feedbackLookUp.IncidentNumber = string.IsNullOrEmpty(txtIncidentNumber.Text.Trim())? null : txtIncidentNumber.Text;
                feedbackLookUp.FeedbackCategoryId = ddlFeedbackCategory.SelectedValue.Equals("0") ? 0 : Convert.ToInt32(ddlFeedbackCategory.SelectedValue);
                feedbackLookUp.Name = string.IsNullOrEmpty(txtName.Text.Trim()) ? null : txtName.Text;
                feedbackLookUp.FeedbackFollowUp = ddlFollowUp.SelectedValue.Equals("0") ? null : ddlFollowUp.SelectedValue;
                grdFeedback.DataSource = timesheetRepository.GetCompanyFeedback(feedbackLookUp);
                grdFeedback.DataBind();
                string totalCountMessage="Total " +grdFeedback.Rows.Count.ToString()+" feedback(s) found";
                lblTotalCount.Text = grdFeedback.Rows.Count > 0 ? totalCountMessage : string.Empty;
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(troncGetFeedback));
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
        /// Serach Feedback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadFeedback();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
             server control at run time. */
        }

        /// <summary>
        /// Export to Excel Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, ImageClickEventArgs e)
        {
            if (grdFeedback.Rows.Count > 0)
                ExportToExcel();
        }

        /// <summary>
        /// Export To Excel
        /// </summary>
        private void ExportToExcel()
        {
            try
            {
                string fileName = "FeedbackDetails_" + DateTime.Now + ".xls";
                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Charset = string.Empty;
                StringWriter strWriter = new StringWriter();
                HtmlTextWriter htmlTxtWriter = new HtmlTextWriter(strWriter);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                grdFeedback.GridLines = GridLines.Both;
                grdFeedback.HeaderStyle.Font.Bold = true;
                grdFeedback.Columns[grdFeedback.Columns.Count - 1].Visible = false;
                grdFeedback.RenderControl(htmlTxtWriter);
                Response.Write(strWriter.ToString());
                Response.End();
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(troncGetFeedback));
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
        /// Row Databound event for the grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grdFeedback_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblFeedback = (Label)e.Row.FindControl("lblFeedback");
                string feedback = ((FeedbackEnt)e.Row.DataItem).FeedbackNote;
                string feedbackPartial = feedback.Length>20? feedback.Substring(0, 20)+"...":feedback;
                lblFeedback.Text =feedback.Length>20? "<div class='tooltiptime'><span>" + feedbackPartial + "</span><span class='tooltiptimetext'>" + feedback + "</span></div>":feedback;

            }
        }

        /// <summary>
        /// Reset all filter criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            LoadDates();
            txtIncidentNumber.Text = string.Empty;
            ddlFeedbackCategory.SelectedIndex = 0;
            txtName.Text = string.Empty;
            ddlFollowUp.SelectedIndex = 0;
            txtIncidentNumber.Text = string.Empty;
            LoadFeedback();
        }
    }
}