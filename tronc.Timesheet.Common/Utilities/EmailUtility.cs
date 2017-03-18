using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tronc.Timesheet.Common.Entities;
using Log4NetLibrary;
using Amazon.SimpleEmail.Model;
using Amazon.SimpleEmail;
using System.Collections;
using System.Net.Mail;
using System.Net;

namespace tronc.Timesheet.Common.Utilities
{
    public class EmailUtility
    {    
        /// <summary>
        /// Send Mail
        /// </summary>
        /// <param name="objEmailEnt"></param>
        public void SendMail(EmailEnt objEmailEnt)
        {
            try
            {
                using (MailMessage message = new MailMessage())
                {
                    message.From = new MailAddress(objEmailEnt.From);
                    objEmailEnt.To.Split(',').ToList().ForEach(x =>
                        {
                            if (!string.IsNullOrEmpty(x.Trim()))
                                message.To.Add(x.Trim());
                        });
                    message.Subject = objEmailEnt.Subject;
                    message.Body = objEmailEnt.Body;
                    message.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient(objEmailEnt.Host, objEmailEnt.Port);
                    smtp.EnableSsl = true;
                    NetworkCredential objNetworkCredential = new NetworkCredential(objEmailEnt.UserName, objEmailEnt.Password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = objNetworkCredential;
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(EmailUtility));
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
    }
}
