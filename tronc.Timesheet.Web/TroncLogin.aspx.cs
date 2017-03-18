using System;
using System.Web.UI;
using tronc.Timesheet.BL.Repository;
using tronc.Timesheet.Common.Entities;
using Log4NetLibrary;
using System.Text;
using tronc.Timesheet.Web.Utils;
using System.Security.Cryptography;
using tronc.Timesheet.Common.Utilities;

namespace tronc.Timesheet.Web
{
    public partial class TroncLogin : System.Web.UI.Page
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SessionManager.UserDetails = null;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string emailAddress = txtUserId.Text.ToString().Trim();
            string password = txtPassword.Text.ToString().Trim();
            ValidateUserLogin(emailAddress, password);

        }
        #endregion

        #region Private Methods


        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        private void ValidateUserLogin(string emailAddress, string password)
        {
            TimesheetRepository timesheetRepository = new TimesheetRepository();
            Resource resource = timesheetRepository.GetResourceDetails(emailAddress);
            bool isPasswordCorrect = false;
            try
            {
                string source = password;
                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = System.Configuration.ConfigurationManager.AppSettings["troncPassword"];
                    if (Encryption.VerifyMd5Hash(md5Hash, source, hash))
                    {
                        isPasswordCorrect = true;
                    }
                    else
                    {
                        isPasswordCorrect = false;
                    }
                }

                if (resource != null && isPasswordCorrect)
                {
                    if (SessionManager.UserDetails == null)
                    {
                        SessionManager.UserDetails = resource;
                        if (!String.IsNullOrEmpty(Request.QueryString.Get("returnURL")))
                        {
                            Response.Redirect(Request.QueryString.Get("returnURL"));
                        }
                        else
                        {
                            Response.Redirect("FloorPoolTimesheet.aspx");
                        }
                    }
                }
                else
                {
                    lblError.Text = "Incorrect Login credentials.";
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