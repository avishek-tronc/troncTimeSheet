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

namespace tronc.Timesheet.Web
{
    public partial class troncApplyLeave : System.Web.UI.Page
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SessionManager.UserDetails != null)
                {
                    LoadDropDown();
                    ShowResourceLeaveDetails();
                }
                else { Response.Redirect("TroncLogin.aspx?returnURL=troncApplyLeave.aspx"); }

            }
            //if (!string.IsNullOrEmpty(hdnDate.Value))
            //{
            //    Page.Request.Form["datepicker"] = hdnDate.Value;
            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveResourceLeaveePlan();
            //ViewResourceLeaves.aspx
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewResourceLeaves.aspx");
        }
        #endregion

        #region Private Methods
        private void LoadDropDown()
        {
            try
            {
                List<Resource> lstResource = GetResources();

                if (lstResource != null && lstResource.Count > 0)
                {
                    ddlResource.Items.Add(new ListItem("Select One", "0"));
                    ddlResource.DataSource = lstResource;
                    ddlResource.DataTextField = "ResourceName";
                    ddlResource.DataValueField = "ResourceId";
                    ddlResource.DataBind();
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
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Resource> GetResources()
        {
            List<Resource> lstResource = new List<Resource>();
            TimesheetRepository timeSheetRepository = new TimesheetRepository();
            try
            {
                lstResource = timeSheetRepository.GetResources();
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
            return lstResource;
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
        /// To save or Edit the resource leave plan
        /// </summary>
        private void SaveResourceLeaveePlan()
        {
            int resourceId = Convert.ToInt32(ddlResource.SelectedValue);
            TimesheetRepository timeSheetRepository = new TimesheetRepository();
            string sucFlag = string.Empty;
            string leaveDate = Page.Request.Form["datepicker"];
            hdnDate.Value = leaveDate;
            string leaveReason = txtLeaveReason.Text;
            string backUpPlan = txtBackUpPlan.Text;
            string ultimatixLeaveId = txtUltimatixID.Text;
            Leave leave = new Leave();
            try
            {

                if (string.IsNullOrEmpty(leaveDate.Trim()) || string.IsNullOrEmpty(leaveReason.Trim()) || string.IsNullOrEmpty(backUpPlan.Trim()) || string.IsNullOrEmpty(ultimatixLeaveId.Trim()))
                {
                    lblSaveStatus.Text = "Please enter the values of all the mandatory fields";
                }
                else
                {
                    leave.ResourceId = Convert.ToInt32(ddlResource.SelectedValue);
                    leave.LeaveReason = txtLeaveReason.Text.Trim();
                    leave.UltimatixId = txtUltimatixID.Text.Trim();
                    leave.BackupPlan = txtBackUpPlan.Text.Trim();
                    string leaveDay = Page.Request.Form["datepicker"];
                    string[] lDay = leaveDay.Split('/');
                    int month = Convert.ToInt32(lDay[0].ToString());
                    int day = Convert.ToInt32(lDay[1].ToString());
                    int year = Convert.ToInt32(lDay[2].ToString());
                    leave.LeaveDate = Convert.ToDateTime(leaveDay);
                    leave.MonthId = (from item in GetMonth()
                                     where !string.IsNullOrEmpty(item.MonthId.ToString())
                                     && item.MonthId == month
                                     select item.MonthId).FirstOrDefault();
                    leave.YId = (from item in GetYear()
                                 where !string.IsNullOrEmpty(item.YearId.ToString())
                                 && Convert.ToInt32(item.YearNumber) == year
                                 select item.YearId).FirstOrDefault();
                    leave.LDay = day;
                    leave.CreatedBy = SessionManager.UserDetails.ResourceId.ToString();
                    leave.CreatedDate = System.DateTime.Now;
                    if (string.IsNullOrEmpty(Request.QueryString.Get("LId")) && string.IsNullOrEmpty(Request.QueryString.Get("RId")))
                    {
                        //Insert Resource Leave
                        sucFlag = timeSheetRepository.SaveResourceLeavePlan(leave);
                    }
                    else
                    {
                        //Update Resource Leave
                        leave.LeaveId = Convert.ToInt32(Request.QueryString.Get("LId"));
                        sucFlag = timeSheetRepository.EditResourceLeavePlan(leave);
                    }
                    if (string.IsNullOrEmpty(sucFlag.Trim()))
                    {
                        lblSaveStatus.Text = "Leave details saved successfully";
                    }
                    else
                    {
                        lblSaveStatus.Text = sucFlag;
                    }

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
        /// 
        /// </summary>
        private void ShowResourceLeaveDetails()
        {
            try
            {
                if (!String.IsNullOrEmpty(Request.QueryString.Get("RId")) && !String.IsNullOrEmpty(Request.QueryString.Get("LId")))
                {
                    TimesheetRepository timeSheetRepository = new TimesheetRepository();
                    int RId = Convert.ToInt32(Request.QueryString.Get("RId"));
                    int LId = Convert.ToInt32(Request.QueryString.Get("LId"));
                    Leave leave = timeSheetRepository.GetResourceLeave(RId, LId);
                    if (leave != null)
                    {
                        txtBackUpPlan.Text = leave.BackupPlan;
                        //txtDate.Text = leave.LeaveDate.Date.ToString();
                        hdnDate.Value = leave.LeaveDate.ToString("MM/dd/yyyy");
                        txtLeaveReason.Text = leave.LeaveReason;
                        txtUltimatixID.Text = leave.UltimatixId;
                        ddlResource.SelectedValue = RId.ToString();
                        ddlResource.Enabled = false;
                    }
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
        #endregion

        
    }
}