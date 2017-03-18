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
using tronc.Timesheet.Common.Utilities;
using tronc.Timesheet.Web.Utils;
using System.Xml;
using System.Configuration;
using System.IO;

namespace tronc.Timesheet.Web
{
    public partial class troncProvideFeedback : System.Web.UI.Page
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDropDown();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveFeedbackDetails();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Response.Redirect("ViewResourceLeaves.aspx");
        }
        #endregion

        #region Private Methods
        private void LoadDropDown()
        {
            try
            {
                //List<Tower> lstTower = new List<Tower>();
                //List<Company> lstCompany = new List<Company>();
                //List<EmployeeCatagory> lstEmployeeCatagory = new List<EmployeeCatagory>();
                List<FeedbackCatagory> lstFeedbackCategory = new List<FeedbackCatagory>();
                //List<FeedbackType> lstFeedbackType = new List<FeedbackType>();
                //lstTower = GetTower();
                //lstCompany = GetCompany();
                //lstEmployeeCatagory = GetEmployeeCatagory();
                lstFeedbackCategory = GetFeedbackCatagory();
                //lstFeedbackType = GetFeedbackType();

                //if (lstCompany != null && lstCompany.Count > 0)
                //{
                //Binding Employee Organisation and Feedback on DropdownList
                //ddlEmployeeOrganisation.DataSource = lstCompany;
                //ddlEmployeeOrganisation.DataTextField = "CompanyName";
                //ddlEmployeeOrganisation.DataValueField = "CompanyId";
                //ddlEmployeeOrganisation.DataBind();

                //ddlFeedbackOn.DataSource = lstCompany;
                //ddlFeedbackOn.DataTextField = "CompanyName";
                //ddlFeedbackOn.DataValueField = "CompanyId";
                //ddlFeedbackOn.DataBind();
                //}

                //if (lstEmployeeCatagory != null && lstEmployeeCatagory.Count > 0)
                //{
                //    //Binding Employee Catagory on DropdownList
                //    ddlEmployeeCatagory.DataSource = lstEmployeeCatagory;
                //    ddlEmployeeCatagory.DataTextField = "EmployeeCatagoryName";
                //    ddlEmployeeCatagory.DataValueField = "EmployeeCatagoryId";
                //    ddlEmployeeCatagory.DataBind();
                //}

                if (lstFeedbackCategory != null && lstFeedbackCategory.Count > 0)
                {
                    //Binding Feedback Catagory on DropdownList

                    ddlFeedbackCategory.DataSource = lstFeedbackCategory;
                    ddlFeedbackCategory.DataTextField = "FeedbackCatagoryName";
                    ddlFeedbackCategory.DataValueField = "FeedbackCatagoryId";
                    ddlFeedbackCategory.DataBind();

                    //ddlSecondFeedbackCatagory.DataSource = lstFeedbackCatagory.Where(x => x.FeedbackCatagoryId != Convert.ToInt32(ddlFeedbackCategory.SelectedValue));
                    //ddlSecondFeedbackCatagory.DataTextField = "FeedbackCatagoryName";
                    //ddlSecondFeedbackCatagory.DataValueField = "FeedbackCatagoryId";
                    //ddlSecondFeedbackCatagory.DataBind();
                }

                //if (lstFeedbackType != null && lstFeedbackType.Count > 0)
                //{
                //    //Binding Feedback Type on DropdownList
                //    ddlFeedbackType.DataSource = lstFeedbackType;
                //    ddlFeedbackType.DataTextField = "FeedbackTypeName";
                //    ddlFeedbackType.DataValueField = "FeedbackTypeId";
                //    ddlFeedbackType.DataBind();
                //}

            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(troncProvideFeedback));
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
        public List<Company> GetCompany()
        {
            TimesheetRepository timesheetRepository = new TimesheetRepository();
            List<Company> lstCompany = new List<Company>();
            try
            {
                lstCompany = timesheetRepository.GetCompany();
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(troncProvideFeedback));
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
            return lstCompany;
        }



        /// <summary>
        /// To save or Edit the resource leave plan
        /// </summary>
        private void SaveFeedbackDetails()
        {
            Messages objMessages = (Messages)Application["Messages"];
            TimesheetRepository timesheetRepository = new TimesheetRepository();
            string suc = string.Empty;
            try
            {
                string userName =string.IsNullOrEmpty(txtName.Text.Trim()) ? "Anonymous" : txtName.Text.Trim();
                string htmlContent = txtFeedbackNote.Text.ToString();
                string encodedText = Server.HtmlEncode(htmlContent);
                string ipAddress = Request.UserHostAddress;
                string hostName = Request.UserHostName;
                HttpBrowserCapabilities bc = Request.Browser;
                string browserDetails = bc.Browser.ToString().Trim() + " " + bc.Version.ToString();
                List<FeedbackEnt> lstFeedback = new List<FeedbackEnt>();
                //for (int counter = 0; counter < 2; counter++)
                //{
                FeedbackEnt feedback = new FeedbackEnt();
                feedback.FeedbackName = userName;
                feedback.CompanyId = 1;//Convert.ToInt32(ddlEmployeeOrganisation.SelectedValue);
                feedback.FeedbackOnId = 2;//Convert.ToInt32(ddlFeedbackOn.SelectedValue);
                feedback.EmployeeCatagoryId = 1;//Convert.ToInt32(ddlEmployeeCatagory.SelectedValue);
                feedback.FeedbackOnEmployeeNameOrGroup = string.Empty; //txtFeedbackOnEmployeeNameGroup.Text.Trim();
                feedback.FeedbackTypeId = 1;//Convert.ToInt32(ddlFeedbackType.SelectedValue);
                feedback.Browser = browserDetails;
                feedback.IpAddress = ipAddress;
                feedback.CreatedBy = !string.IsNullOrEmpty(userName) ? userName : "dbUser";
                feedback.CreatedDate = System.DateTime.Now;
                feedback.FeedbackCategoryId = Convert.ToInt32(ddlFeedbackCategory.SelectedValue);
                feedback.FeedbackNote = encodedText;
                feedback.FeedbackPurpose = txtFeedbackPurpose.Text.Trim();
                feedback.IncidentNumber = chkIncident.Checked ? txtIncidentNumber.Text.Trim() : string.Empty;
                feedback.FeedbackFollowUp =chkFollowUp.Checked?"Yes" : "No";
                feedback.ContactNumber =chkFollowUp.Checked?txtContactNumber.Text.Trim(): string.Empty;//txtContactNumber.Attributes.
                lstFeedback.Add(feedback);
                //if (counter > 0 && hdnSecondField.Value != string.Empty)
                //{
                //    feedback.FeedbackCatagoryId = Convert.ToInt32(ddlSecondFeedbackCatagory.SelectedValue);
                //    feedback.FeedbackNote = txtSecondFeedbackNote.Text;
                //    lstFeedback.Add(feedback);
                //}
                //else if (counter == 0)
                //{
                //    feedback.FeedbackCatagoryId = Convert.ToInt32(ddlFeedbackCategory.SelectedValue);
                //    feedback.FeedbackNote = encodedText;
                //    lstFeedback.Add(feedback);
                //}

                //}

                //Send Email if Feedback Type is Escalation
                if (ddlFeedbackCategory.SelectedItem.Text.Trim().ToUpper().Equals("ESCALATION"))
                    SendEscalationEmail();

                suc = timesheetRepository.SaveEmployeeFeedback(lstFeedback);
                if (suc != null && suc.Equals(string.Empty))
                {
                    lblMessage.Text = objMessages.FeedbackSaveSuccess;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "javascript:openModal();", true);

                }

                else
                {
                    lblMessage.Text = objMessages.FeedbackSaveFailure;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "message", "javascript:openModal();", true);
                }
                hdnSecondField.Value = string.Empty;
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(troncProvideFeedback));
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
        private void ShowFeedbackDetails()
        {
            try
            {
                if (!String.IsNullOrEmpty(Request.QueryString.Get("FId")))
                {
                    TimesheetRepository timeSheetRepository = new TimesheetRepository();
                    int FId = Convert.ToInt32(Request.QueryString.Get("FId"));

                    List<FeedbackEnt> lstFeedback = timeSheetRepository.GetIndividualFeedback(FId);
                    if (lstFeedback != null && lstFeedback.Count > 0)
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(troncProvideFeedback));
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
        /// Get Employee Catagory List
        /// </summary>
        /// <returns></returns>
        public List<EmployeeCatagory> GetEmployeeCatagory()
        {
            TimesheetRepository timesheetRepository = new TimesheetRepository();
            List<EmployeeCatagory> lstEmployeeCatagory = new List<EmployeeCatagory>();
            try
            {
                lstEmployeeCatagory = timesheetRepository.GetEmployeeCatagory();
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(troncProvideFeedback));
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
            return lstEmployeeCatagory;
        }

        /// <summary>
        /// Get Feedback Catagory List
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
                ILogService logService = new FileLogService(typeof(troncProvideFeedback));
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
        /// Get Feedback Type List
        /// </summary>
        /// <returns></returns>
        public List<FeedbackType> GetFeedbackType()
        {
            TimesheetRepository timesheetRepository = new TimesheetRepository();
            List<FeedbackType> lstFeedbackType = new List<FeedbackType>();
            try
            {
                lstFeedbackType = timesheetRepository.GetFeedbackType();
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(troncProvideFeedback));
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
            return lstFeedbackType;
        }

        /// <summary>
        /// To send email for Escalation type of feedback
        /// </summary>
        private void SendEscalationEmail()
        {
            try
            {            
                EmailEnt objEmailEnt = new EmailEnt();
                string htmlTemplatePath = @"~/HtmlTemplate/EmailTemplate.html"; //Convert.ToString(ConfigurationManager.AppSettings["HtmlBodyTemplatePath"]);
                objEmailEnt.To = Convert.ToString(ConfigurationManager.AppSettings["EscalationEmailTo"]);
                objEmailEnt.From = Convert.ToString(ConfigurationManager.AppSettings["EscalationEmailFrom"]);
                objEmailEnt.UserName = Convert.ToString(ConfigurationManager.AppSettings["MailUserName"]);
                objEmailEnt.Password = Convert.ToString(ConfigurationManager.AppSettings["MailPassword"]); ;
                objEmailEnt.Host = Convert.ToString(ConfigurationManager.AppSettings["Host"]);
                objEmailEnt.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
                StringBuilder strBldrSubject = new StringBuilder();
                strBldrSubject.Append("Escalation: ");
                strBldrSubject.Append(string.IsNullOrEmpty(txtFeedbackPurpose.Text.Trim()) ? "From Tronc Feedback System" : txtFeedbackPurpose.Text.Trim());
                objEmailEnt.Subject = strBldrSubject.ToString();

                string mailBody = File.ReadAllText(Server.MapPath(htmlTemplatePath));
                mailBody = mailBody.Replace("##BODY##", txtFeedbackNote.Text.Trim());
                objEmailEnt.Body = mailBody;


                EmailUtility objEmailUtility = new EmailUtility();
                objEmailUtility.SendMail(objEmailEnt);
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(troncProvideFeedback));
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
        /// To pass the message for Duplicate Feedback Category to frontend
        /// </summary>
        /// <returns></returns>
        //public string GetDuplicateFeedbackCategoryMessage()
        //{
        //    return ((Messages)Application["Messages"]).DuplicateFeedbackCategory;
        //}


        #endregion

    }
}