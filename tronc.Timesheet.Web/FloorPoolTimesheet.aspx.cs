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
using System.IO;
using tronc.Timesheet.Web.Utils;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace tronc.Timesheet.Web
{
    public partial class FloorPoolTimesheet : System.Web.UI.Page
    {
        private static int floorEffort;
        private static int poolEffort;
        private static int totalEffort;
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (SessionManager.UserDetails != null)
                {
                    floorEffort = 0;
                    poolEffort = 0;
                    totalEffort = 0;
                    LoadDropDown();
                    ShowEffort("L");
                    int yearId = Convert.ToInt32(ddlYear.SelectedValue);
                    int monthId = Convert.ToInt32(ddlMonth.SelectedValue);
                    GetEffortCount(yearId, monthId, 0);
                    lblMonth.Text = ddlMonth.SelectedItem.Text;
                    lblYear.Text = ddlYear.SelectedItem.Text;
                    lblFloor.Text = floorEffort.ToString();
                    lblPool.Text = poolEffort.ToString();
                    lblTotal.Text = (floorEffort + poolEffort).ToString();
                }
                else
                {
                    Response.Redirect("TroncLogin.aspx?returnURL=FloorPoolTimesheet.aspx");
                }
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton hlEdit = (LinkButton)e.Row.FindControl("hlEdit");
                Label lblDollar = (Label)e.Row.FindControl("lblAmount");
                int resourceId = Convert.ToInt32(((ResourceEffort)e.Row.DataItem).ResourceId.ToString());
                int yId = Convert.ToInt32(((ResourceEffort)e.Row.DataItem).YeadId.ToString());
                int monthId = Convert.ToInt32(((ResourceEffort)e.Row.DataItem).MonthId.ToString());

                List<ResourceEffortComment> lstResourceEffortComment = GetResourceEffortComment(resourceId, yId, monthId);
                string totalEffort = ((ResourceEffort)e.Row.DataItem).TotalEffort.ToString();
                string segment = ((ResourceEffort)e.Row.DataItem).SegmentName.ToString();
                string amount = ((ResourceEffort)e.Row.DataItem).TotalMonthRate.ToString();
                decimal value = 0.00M;
                value = Convert.ToDecimal(amount);
                string htmlDollar = String.Format(value.ToString("C"));
                lblDollar.Text = htmlDollar;
                hlEdit.Text = "Edit";

                string effortOne = ((ResourceEffort)e.Row.DataItem).EOne.ToString();
                Label lblOne = (Label)e.Row.FindControl("lblOne");
                lblOne.Text = Convert.ToInt32(effortOne) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortOne + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentOne.Trim()) + "</span></div>" : effortOne;

                string effortTwo = ((ResourceEffort)e.Row.DataItem).ETwo.ToString();
                Label lblTwo = (Label)e.Row.FindControl("lblTwo");
                lblTwo.Text = Convert.ToInt32(effortTwo) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortTwo + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentTwo.Trim()) + "</span></div>" : effortTwo;

                string effortThree = ((ResourceEffort)e.Row.DataItem).EThree.ToString();
                Label lblThree = (Label)e.Row.FindControl("lblThree");
                lblThree.Text = Convert.ToInt32(effortThree) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortThree + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentThree.Trim()) + "</span></div>" : effortThree;

                string effortFour = ((ResourceEffort)e.Row.DataItem).EFour.ToString();
                Label lblFour = (Label)e.Row.FindControl("lblFour");
                lblFour.Text = Convert.ToInt32(effortFour) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortFour + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentFour.Trim()) + "</span></div>" : effortFour;

                string effortFive = ((ResourceEffort)e.Row.DataItem).EFive.ToString();
                Label lblFive = (Label)e.Row.FindControl("lblFive");
                lblFive.Text = Convert.ToInt32(effortFive) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortFive + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentFive.Trim()) + "</span></div>" : effortFive;

                string effortSix = ((ResourceEffort)e.Row.DataItem).ESix.ToString();
                Label lblSix = (Label)e.Row.FindControl("lblSix");
                lblSix.Text = Convert.ToInt32(effortSix) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortSix + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentSix.Trim()) + "</span></div>" : effortSix;

                string effortSeven = ((ResourceEffort)e.Row.DataItem).ESeven.ToString();
                Label lblSeven = (Label)e.Row.FindControl("lblSeven");
                lblSeven.Text = Convert.ToInt32(effortSeven) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortSeven + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentSeven.Trim()) + "</span></div>" : effortSeven;

                string effortEight = ((ResourceEffort)e.Row.DataItem).EEight.ToString();
                Label lblEight = (Label)e.Row.FindControl("lblEight");
                lblEight.Text = Convert.ToInt32(effortEight) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortEight + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentEight.Trim()) + "</span></div>" : effortEight;

                string effortNine = ((ResourceEffort)e.Row.DataItem).ENine.ToString();
                Label lblNine = (Label)e.Row.FindControl("lblNine");
                lblNine.Text = Convert.ToInt32(effortNine) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortNine + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentNine.Trim()) + "</span></div>" : effortNine;

                string effortTen = ((ResourceEffort)e.Row.DataItem).ETen.ToString();
                Label lblTen = (Label)e.Row.FindControl("lblTen");
                lblTen.Text = Convert.ToInt32(effortTen) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortTen + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentTen.Trim()) + "</span></div>" : effortTen;

                string effortEleven = ((ResourceEffort)e.Row.DataItem).EEleven.ToString();
                Label lblEleven = (Label)e.Row.FindControl("lblEleven");
                lblEleven.Text = Convert.ToInt32(effortEleven) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortEleven + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentEleven.Trim()) + "</span></div>" : effortEleven;

                string effortTwelve = ((ResourceEffort)e.Row.DataItem).ETwelve.ToString();
                Label lblTwelve = (Label)e.Row.FindControl("lblTwelve");
                lblTwelve.Text = Convert.ToInt32(effortTwelve) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortTwelve + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentTwelve.Trim()) + "</span></div>" : effortTwelve;

                string effortThirteen = ((ResourceEffort)e.Row.DataItem).EThirteen.ToString();
                Label lblThirteen = (Label)e.Row.FindControl("lblThirteen");
                lblThirteen.Text = Convert.ToInt32(effortThirteen) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortThirteen + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentThirteen.Trim()) + "</span></div>" : effortThirteen;

                string effortFourteen = ((ResourceEffort)e.Row.DataItem).EFourteen.ToString();
                Label lblFourteen = (Label)e.Row.FindControl("lblFourteen");
                lblFourteen.Text = Convert.ToInt32(effortFourteen) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortFourteen + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentFourteen.Trim()) + "</span></div>" : effortFourteen;

                string effortFifteen = ((ResourceEffort)e.Row.DataItem).EFifteen.ToString();
                Label lblFiveteen = (Label)e.Row.FindControl("lblFiveteen");
                lblFiveteen.Text = Convert.ToInt32(effortFifteen) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortFifteen + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentFifteen.Trim()) + "</span></div>" : effortFifteen;

                string effortSixteen = ((ResourceEffort)e.Row.DataItem).ESixteen.ToString();
                Label lblSixteen = (Label)e.Row.FindControl("lblSixteen");
                lblSixteen.Text = Convert.ToInt32(effortSixteen) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortSixteen + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentSixteen.Trim()) + "</span></div>" : effortSixteen;

                string effortSeventeen = ((ResourceEffort)e.Row.DataItem).ESeventeen.ToString();
                Label lblSeventeen = (Label)e.Row.FindControl("lblSeventeen");
                lblSeventeen.Text = Convert.ToInt32(effortSeventeen) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortSeventeen + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentSeventeen.Trim()) + "</span></div>" : effortSeventeen;

                string effortEighteen = ((ResourceEffort)e.Row.DataItem).EEighteen.ToString();
                Label lblEighteen = (Label)e.Row.FindControl("lblEighteen");
                lblEighteen.Text = Convert.ToInt32(effortEighteen) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortEighteen + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentEighteen.Trim()) + "</span></div>" : effortEighteen;

                string effortNineteen = ((ResourceEffort)e.Row.DataItem).ENineteen.ToString();
                Label lblNineteen = (Label)e.Row.FindControl("lblNineteen");
                lblNineteen.Text = Convert.ToInt32(effortNineteen) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortNineteen + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentNineteen.Trim()) + "</span></div>" : effortNineteen;

                string effortTwenty = ((ResourceEffort)e.Row.DataItem).ETwenty.ToString();
                Label lblTwenty = (Label)e.Row.FindControl("lblTwenty");
                lblTwenty.Text = Convert.ToInt32(effortTwenty) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortTwenty + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentTwenty.Trim()) + "</span></div>" : effortTwenty;

                string effortTwentyOne = ((ResourceEffort)e.Row.DataItem).ETwentyOne.ToString();
                Label lblTwentyOne = (Label)e.Row.FindControl("lblTwentyOne");
                lblTwentyOne.Text = Convert.ToInt32(effortTwentyOne) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortTwentyOne + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentTwentyOne.Trim()) + "</span></div>" : effortTwentyOne;

                string effortTwentyTwo = ((ResourceEffort)e.Row.DataItem).ETwentyTwo.ToString();
                Label lblTwentyTwo = (Label)e.Row.FindControl("lblTwentyTwo");
                lblTwentyTwo.Text = Convert.ToInt32(effortTwentyTwo) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortTwentyTwo + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentOne.Trim()) + "</span></div>" : effortTwentyTwo;

                string effortTwentyThree = ((ResourceEffort)e.Row.DataItem).ETwentyThree.ToString();
                Label lblTwentyThree = (Label)e.Row.FindControl("lblTwentyThree");
                lblTwentyThree.Text = Convert.ToInt32(effortTwentyThree) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortTwentyThree + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentTwentyThree.Trim()) + "</span></div>" : effortTwentyThree;

                string effortTwentyFour = ((ResourceEffort)e.Row.DataItem).ETwentyFour.ToString();
                Label lblTwentyFour = (Label)e.Row.FindControl("lblTwentyFour");
                lblTwentyFour.Text = Convert.ToInt32(effortTwentyFour) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortTwentyFour + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentTwentyFour.Trim()) + "</span></div>" : effortTwentyFour;

                string effortTwentyFive = ((ResourceEffort)e.Row.DataItem).ETwentyFive.ToString();
                Label lblTwentyFive = (Label)e.Row.FindControl("lblTwentyFive");
                lblTwentyFive.Text = Convert.ToInt32(effortTwentyFive) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortTwentyFive + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentTwentyFive.Trim()) + "</span></div>" : effortTwentyFive;

                string effortTwentySix = ((ResourceEffort)e.Row.DataItem).ETwentySix.ToString();
                Label lblTwentySix = (Label)e.Row.FindControl("lblTwentySix");
                lblTwentySix.Text = Convert.ToInt32(effortTwentySix) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortTwentySix + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentTwentySix.Trim()) + "</span></div>" : effortTwentySix;

                string effortTwentySeven = ((ResourceEffort)e.Row.DataItem).ETwentySeven.ToString();
                Label lblTwentySeven = (Label)e.Row.FindControl("lblTwentySeven");
                lblTwentySeven.Text = Convert.ToInt32(effortTwentySeven) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortTwentySeven + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentTwentySeven.Trim()) + "</span></div>" : effortTwentySeven;

                string effortTwentyEight = ((ResourceEffort)e.Row.DataItem).ETwentyEight.ToString();
                Label lblTwentyEight = (Label)e.Row.FindControl("lblTwentyEight");
                lblTwentyEight.Text = Convert.ToInt32(effortTwentyEight) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortTwentyEight + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentTwentyEight.Trim()) + "</span></div>" : effortTwentyEight;

                string effortTwentyNine = ((ResourceEffort)e.Row.DataItem).ETwentyNine.ToString();
                Label lblTwentyNine = (Label)e.Row.FindControl("lblTwentyNine");
                lblTwentyNine.Text = Convert.ToInt32(effortTwentyNine) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortTwentyNine + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentTwentyNine.Trim()) + "</span></div>" : effortTwentyNine;

                string effortThirty = ((ResourceEffort)e.Row.DataItem).EThirty.ToString();
                Label lblThirty = (Label)e.Row.FindControl("lblThirty");
                lblThirty.Text = Convert.ToInt32(effortThirty) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortThirty + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentThirty.Trim()) + "</span></div>" : effortThirty;

                string effortThirtyOne = ((ResourceEffort)e.Row.DataItem).EThirtyOne.ToString();
                Label lblThirtyOne = (Label)e.Row.FindControl("lblThirtyOne");
                lblThirtyOne.Text = Convert.ToInt32(effortThirtyOne) > 9 ? "<div class='tooltiptime'><span style='color:red'>" + effortThirtyOne + "</span><span class='tooltiptimetext'>" + Server.HtmlEncode(lstResourceEffortComment[0].EcommentThirtyOne.Trim()) + "</span></div>" : effortThirtyOne;


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
                Response.Redirect("IndividualResourceTimeSheet.aspx?YId=" + yId + "&MId=" + mId + "&RId=" + rId);
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            floorEffort = 0;
            poolEffort = 0;
            totalEffort = 0;
            ShowEffort("S");
            int yearId = Convert.ToInt32(ddlYear.SelectedValue);
            int monthId = Convert.ToInt32(ddlMonth.SelectedValue);
            GetEffortCount(yearId, monthId, 0);
            lblMonth.Text = ddlMonth.SelectedItem.Text;
            lblYear.Text = ddlYear.SelectedItem.Text;
            lblFloor.Text = floorEffort.ToString();
            lblPool.Text = poolEffort.ToString();
            lblTotal.Text = (floorEffort + poolEffort).ToString();
        }

        protected void btnExport_Click(object sender, ImageClickEventArgs e)
        {
            if (grdOrder.Rows.Count > 0)
            {
                ExportToExcel();
            }
        }

        protected void btnExportPDF_Click(object sender, ImageClickEventArgs e)
        {
            if (grdOrder.Rows.Count > 0)
            {
                ExportToPDF();
            }
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
            return lstallresourceeffort;
        }


        /// <summary>
        /// 
        /// </summary>
        private void LoadDropDown()
        {

            try
            {
                List<Resource> lstResource = GetResources();

                if (lstResource != null && lstResource.Count > 0)
                {
                    ddlResource.Items.Add(new System.Web.UI.WebControls.ListItem("ALL", "0"));
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
                    ddlSegment.Items.Add(new System.Web.UI.WebControls.ListItem("ALL", "0"));
                    ddlSegment.DataSource = lstSegment;
                    ddlSegment.DataTextField = "SegmentName";
                    ddlSegment.DataValueField = "SegmentId";
                    ddlSegment.DataBind();
                    ddlSegment.SelectedIndex = 0;
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
                        for (int i = 3; i < grdOrder.Columns.Count - 3; i++)
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
                        for (int i = 3; i < grdOrder.Columns.Count - 3; i++)
                        {
                            grdOrder.Columns[i].Visible = true;
                            grdOrder.Columns[i].HeaderText = (i - 2).ToString();
                        }
                        int daysInMonth = DateTime.DaysInMonth(yearId, monthId);
                        for (int i = 3; i < grdOrder.Columns.Count - 3; i++)
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
                        for (int i = 3; i < grdOrder.Columns.Count - 3; i++)
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
                        for (int i = 3; i < grdOrder.Columns.Count - 3; i++)
                        {
                            grdOrder.Columns[i].Visible = true;
                            grdOrder.Columns[i].HeaderText = (i - 2).ToString();
                        }
                        int daysInMonth = DateTime.DaysInMonth(yearId, monthId);
                        for (int i = 3; i < grdOrder.Columns.Count - 3; i++)
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
            return lstResourceEffort;
        }

        /// <summary>
        /// To get the Floor, Pool and total Effort based on the selected Year and the Month
        /// </summary>
        /// <param name="yearId"></param>
        /// <param name="monthId"></param>
        /// <param name="segmentId"></param>
        private void GetEffortCount(int yearId, int monthId, int segmentId)
        {
            try
            {
                List<ResourceEffort> lstResourceEffort = GetAllResourceEffort(yearId, monthId, segmentId);
                if (lstResourceEffort != null && lstResourceEffort.Count > 0)
                {
                    foreach (ResourceEffort resourceEffort in lstResourceEffort)
                    {
                        if (resourceEffort.SegmentName.ToUpper().Equals("FLOOR"))
                        {
                            floorEffort += resourceEffort.TotalEffort;
                        }
                        if (resourceEffort.SegmentName.ToUpper().Equals("POOL"))
                        {
                            poolEffort += resourceEffort.TotalEffort;
                        }
                    }
                    totalEffort = floorEffort + poolEffort;
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
        /// To export the content of the Gridview to Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ExportToExcel()
        {
            string yearName = ddlYear.SelectedItem.Text;
            string monthName = ddlMonth.SelectedItem.Text;
            string fileName = yearName + "_" + monthName + "_" + "Effort" + ".xls";
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ClearContent();
                Response.ClearHeaders();
                Response.Charset = "";
                string FileName = fileName;
                StringWriter strwritter = new StringWriter();
                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
                grdOrder.GridLines = GridLines.Both;
                grdOrder.HeaderStyle.Font.Bold = true;
                grdOrder.Columns[grdOrder.Columns.Count - 1].Visible = false;
                grdOrder.RenderControl(htmltextwrtter);
                Response.Write(strwritter.ToString());
                Response.End();
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
        /// To export the Grid content to PDF 
        /// </summary>
        private void ExportToPDF()
        {
            string yearName = ddlYear.SelectedItem.Text;
            string monthName = ddlMonth.SelectedItem.Text;
            string fileName = yearName + "_" + monthName + "_" + "Effort" + ".pdf";
            try
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdOrder.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A1, 1f, 1f, 1f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                Response.End();
                grdOrder.AllowPaging = false;
                grdOrder.DataBind();
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
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="yearId"></param>
        /// <param name="monthId"></param>
        /// <returns></returns>
        private List<ResourceEffortComment> GetResourceEffortComment(int resourceId, int yearId, int monthId)
        {
            List<ResourceEffortComment> lstResourceEffortComment = new List<ResourceEffortComment>();
            TimesheetRepository timeSheetRepository = new TimesheetRepository();
            try
            {
                lstResourceEffortComment = timeSheetRepository.GetResourceEffortComment(resourceId, yearId, monthId);
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(IndividualResourceTimeSheet));
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
            return lstResourceEffortComment;
        }
        #endregion






    }
}