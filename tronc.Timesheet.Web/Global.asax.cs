using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml;
using tronc.Timesheet.Common.Entities;

namespace tronc.Timesheet.Web
{
    public class Global : System.Web.HttpApplication
    {
        /// <summary>
        /// Application Start Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Start(object sender, EventArgs e)
        {
            LoadMessages();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        private void LoadMessages()
        {
            string xmlPath = @"~/XML/Messages.xml";
            XmlTextReader xmlReader = new XmlTextReader(Server.MapPath(xmlPath));
            string elementName = string.Empty;
            Messages objMessage = new Messages();
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        elementName = xmlReader.Name;
                        break;

                    case XmlNodeType.Text:
                        switch (elementName)
                        {
                            case "feedbackSaveSuccess":
                                objMessage.FeedbackSaveSuccess = xmlReader.Value;
                                break;

                            case "feedbackSaveFailure":
                                objMessage.FeedbackSaveFailure = xmlReader.Value;
                                break;

                            case "duplicateFeedbackCategory":
                                objMessage.DuplicateFeedbackCategory = xmlReader.Value;
                                break;
                        }
                        break;

                    case XmlNodeType.EndElement:
                        break;
                }
            }

            Application["Messages"] = objMessage;

        }
    }
}