using Log4NetLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using tronc.Timesheet.Common.Entities;


namespace Feedback
{
    public class FeedBackValidator
    {
        /// <summary>
        /// To validate the service request
        /// </summary>
        /// <param name="headerEnt"></param>
        /// <returns></returns>
        public bool ValidateServiceRequest(HeaderEntity headerEnt)
        {
            bool isValid = false;
            try
            {
                Guid newGuid;
                string userName = System.Configuration.ConfigurationManager.AppSettings["feedbackUserId"];
                string passWord = System.Configuration.ConfigurationManager.AppSettings["feedbackPassword"];
                if(userName.Trim().ToLower().Equals(headerEnt.UserName.Trim().ToLower()) && passWord.Trim().ToLower().Equals(headerEnt.Password.Trim().ToLower()) && !string.IsNullOrEmpty(headerEnt.Guid))
                {
                    if (Guid.TryParse(headerEnt.Guid, out newGuid))
                    isValid = true;
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(FeedBackValidator));
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
            return isValid;
        }
    }
}