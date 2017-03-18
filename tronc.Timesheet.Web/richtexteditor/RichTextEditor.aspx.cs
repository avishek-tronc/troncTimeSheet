using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tronc.Timesheet.Web.richtexteditor
{
    public partial class RichTextEditor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string htmlContent = Editor1.Text.ToString();
            string encodedText = Server.HtmlEncode(htmlContent);
            if (!string.IsNullOrEmpty(encodedText.Trim()))
            {
                txtHTMLContent.Text = encodedText;
            }
        }
    }
}