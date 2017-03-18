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

namespace tronc.Timesheet.Web
{
    public partial class ApplyLeave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDropDown();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int resourceId = Convert.ToInt32(ddlResource.SelectedValue);
            string leaveDate = txtDate.Text;
            string leaveReason = txtLeaveReason.Text;
            string backUpPlan = txtBackUpPlan.Text;
        }

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


    }
}