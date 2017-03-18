using Log4NetLibrary;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tronc.Timesheet.BL.Repository;
using tronc.Timesheet.Common.Entities;

namespace tronc.Timesheet.Web
{
    public partial class troncTimeSheet : System.Web.UI.Page
    {
        private static int floorEffort;
        private static int poolEffort;
        private static int totalEffort;
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                LoadDropDown();
                ShowEffort("L");
                lblFloor.Text = floorEffort.ToString();
                lblPool.Text = poolEffort.ToString();
                lblTotal.Text = (floorEffort + poolEffort).ToString();
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton hlEdit = (LinkButton)e.Row.FindControl("hlEdit");
                string totalEffort = ((ResourceEffort)e.Row.DataItem).TotalEffort.ToString();
                string segment = ((ResourceEffort)e.Row.DataItem).SegmentName.ToString();
                hlEdit.Text = "Edit";
                if (segment.ToUpper().Equals("FLOOR"))
                {
                    floorEffort += Convert.ToInt32(totalEffort);
                }
                if (segment.ToUpper().Equals("POOL"))
                {
                    poolEffort += Convert.ToInt32(totalEffort);
                }
                //hlEdit.PostBackUrl = "OrderDetail.aspx?OrderNum=" + orderNumber;
            }
        }

        protected void grdOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Resource"))
            {
                string queryParameter = e.CommandArgument.ToString();
                string[] arrParameters = queryParameter.Split('|');
                string yId = arrParameters[0].ToString();
                string mId = arrParameters[1].ToString();
                string rId = arrParameters[2].ToString();
                Response.Redirect("ResourceTimeSheet.aspx?YId=" + yId + "&MId=" + mId + "&RId" + rId);
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            floorEffort = 0;
            poolEffort = 0;
            totalEffort = 0;
            ShowEffort("S");
            lblFloor.Text = floorEffort.ToString();
            lblPool.Text = poolEffort.ToString();
            lblTotal.Text = (floorEffort + poolEffort).ToString();
        }
        #endregion

        #region Private Methods


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
                ILogService logService = new FileLogService(typeof(troncTimeSheet));
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
                ILogService logService = new FileLogService(typeof(troncTimeSheet));
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
                ILogService logService = new FileLogService(typeof(troncTimeSheet));
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
        private List<Segment> GetSegment()
        {
            List<Segment> lstSegment = new List<Segment>();
            TimesheetRepository timeSheetRepository = new TimesheetRepository();
            try
            {
                lstSegment = timeSheetRepository.GetSegment();
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(troncTimeSheet));
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
            return lstSegment;
        }
        /// <summary>
        /// To get the effort of all the users for the selected segment
        /// </summary>
        /// <param name="yearId"></param>
        /// <param name="monthId"></param>
        /// <param name="segmentId"></param>
        /// <returns></returns>
        private List<ResourceEffort> GetAllResourceEffort(int yearId, int monthId, int segmentId)
        {
            List<ResourceEffort> lstallresourceeffort = new List<ResourceEffort>();
            TimesheetRepository timeSheetRepository = new TimesheetRepository();
            try
            {
                lstallresourceeffort = timeSheetRepository.GetAllResourceEffort(yearId, monthId, segmentId);
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(troncTimeSheet));
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
            return lstallresourceeffort;
        }

        private void LoadDropDown()
        {
            try
            {
                List<Resource> lstResource = GetResources();

                if (lstResource != null && lstResource.Count > 0)
                {
                    ddlResource.Items.Add(new ListItem("ALL", "0"));
                    ddlResource.DataSource = lstResource;
                    ddlResource.DataTextField = "ResourceName";
                    ddlResource.DataValueField = "ResourceId";
                    ddlResource.DataBind();
                }
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
                List<Segment> lstSegment = GetSegment();
                if (lstSegment != null && lstSegment.Count > 0)
                {
                    ddlSegment.Items.Add(new ListItem("ALL", "0"));
                    ddlSegment.DataSource = lstSegment;
                    ddlSegment.DataTextField = "SegmentName";
                    ddlSegment.DataValueField = "SegmentId";
                    ddlSegment.DataBind();
                    ddlSegment.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(troncTimeSheet));
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
        /// <param name="status"></param>
        private void ShowEffort(string status)
        {
            try
            {
                int yearId = Convert.ToInt32(ddlYear.SelectedValue);
                int yearName = Convert.ToInt32(ddlYear.SelectedItem.Text);
                int monthId = Convert.ToInt32(ddlMonth.SelectedValue);
                int segmentId = Convert.ToInt32(ddlSegment.SelectedValue);
                int resourceId = Convert.ToInt32(ddlResource.SelectedValue);

                if (resourceId == 0)
                {
                    if (status.ToUpper().Equals("L"))
                    {
                        int daysInMonth = DateTime.DaysInMonth(yearId, monthId);
                        for (int i = 3; i < grdOrder.Columns.Count - 2; i++)
                        {
                            string hText = grdOrder.Columns[i].HeaderText;
                            if (Convert.ToInt32(hText.Trim()) <= daysInMonth)
                            {
                                int day = Convert.ToInt32(hText.Trim());
                                string dayName = GetWeekDayName(yearName, monthId, day);
                                if (!string.IsNullOrEmpty(dayName))
                                {
                                    grdOrder.Columns[i].HeaderText = hText.Trim() + "<br/>" + dayName.Substring(0, 1);
                                }
                            }
                            else
                            {
                                grdOrder.Columns[i].Visible = false;
                            }

                        }
                    }
                    else
                    {
                        for (int i = 3; i < grdOrder.Columns.Count - 2; i++)
                        {
                            grdOrder.Columns[i].Visible = true;
                            grdOrder.Columns[i].HeaderText = (i - 2).ToString();
                        }
                        int daysInMonth = DateTime.DaysInMonth(yearId, monthId);
                        for (int i = 3; i < grdOrder.Columns.Count - 2; i++)
                        {
                            string hText = grdOrder.Columns[i].HeaderText;
                            if (Convert.ToInt32(hText.Trim()) <= daysInMonth)
                            {
                                int day = Convert.ToInt32(hText.Trim());
                                string dayName = GetWeekDayName(yearName, monthId, day);
                                if (!string.IsNullOrEmpty(dayName))
                                {
                                    grdOrder.Columns[i].HeaderText = hText.Trim() + "<br/>" + dayName.Substring(0, 1);
                                }
                            }
                            else
                            {
                                grdOrder.Columns[i].Visible = false;
                            }

                        }
                    }
                    List<ResourceEffort> lstResourceEffort = GetAllResourceEffort(yearId, monthId, segmentId);
                    if (lstResourceEffort != null && lstResourceEffort.Count > 0)
                    {
                        grdOrder.DataSource = lstResourceEffort;
                        grdOrder.DataBind();
                    }
                }
                else
                {
                    ddlSegment.SelectedIndex = 0;
                    if (status.ToUpper().Equals("L"))
                    {
                        int daysInMonth = DateTime.DaysInMonth(yearId, monthId);
                        for (int i = 3; i < grdOrder.Columns.Count - 2; i++)
                        {
                            string hText = grdOrder.Columns[i].HeaderText;
                            if (Convert.ToInt32(hText.Trim()) <= daysInMonth)
                            {
                                int day = Convert.ToInt32(hText.Trim());
                                string dayName = GetWeekDayName(yearId, monthId, day);
                                if (!string.IsNullOrEmpty(dayName))
                                {
                                    grdOrder.Columns[i].HeaderText = hText.Trim() + "<br/>" + dayName.Substring(0, 1);
                                }
                            }
                            else
                            {
                                grdOrder.Columns[i].Visible = false;
                            }

                        }
                    }
                    else
                    {
                        for (int i = 3; i < grdOrder.Columns.Count - 2; i++)
                        {
                            grdOrder.Columns[i].Visible = true;
                            grdOrder.Columns[i].HeaderText = (i - 2).ToString();
                        }
                        int daysInMonth = DateTime.DaysInMonth(yearId, monthId);
                        for (int i = 3; i < grdOrder.Columns.Count - 2; i++)
                        {
                            string hText = grdOrder.Columns[i].HeaderText;
                            if (Convert.ToInt32(hText.Trim()) <= daysInMonth)
                            {
                                int day = Convert.ToInt32(hText.Trim());
                                string dayName = GetWeekDayName(yearName, monthId, day);
                                if (!string.IsNullOrEmpty(dayName))
                                {
                                    grdOrder.Columns[i].HeaderText = hText.Trim() + "<br/>" + dayName.Substring(0, 1);
                                }
                            }
                            else
                            {
                                grdOrder.Columns[i].Visible = false;
                            }

                        }
                    }
                    List<ResourceEffort> lstResourceEffort = GetResourceEffort(resourceId, yearId, monthId);
                    if (lstResourceEffort != null && lstResourceEffort.Count > 0)
                    {
                        grdOrder.DataSource = lstResourceEffort;
                        grdOrder.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(troncTimeSheet));
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
        /// <param name="year"></param>
        /// <param name="Month"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        private string GetWeekDayName(int year, int Month, int date)
        {
            string weekDay = string.Empty;
            try
            {
                var Date = new DateTime(year, Month, date);
                var thisYear = new DateTime(Date.Year, Date.Month, Date.Day);
                var dayOfWeek = thisYear.DayOfWeek;
                weekDay = dayOfWeek.ToString();
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(troncTimeSheet));
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
            return weekDay;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="yearId"></param>
        /// <param name="monthId"></param>
        /// <returns></returns>
        private List<ResourceEffort> GetResourceEffort(int resourceId, int yearId, int monthId)
        {
            List<ResourceEffort> lstResourceEffort = new List<ResourceEffort>();
            TimesheetRepository timeSheetRepository = new TimesheetRepository();
            try
            {
                lstResourceEffort = timeSheetRepository.GetResourceEffort(resourceId, yearId, monthId);

            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(troncTimeSheet));
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
            return lstResourceEffort;
        }
        #endregion

    }
}