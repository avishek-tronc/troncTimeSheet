using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tronc.Timesheet.BL.Repository;
using tronc.Timesheet.Common.Entities;
using Log4NetLibrary;
using System.Text;
using System.Data;
using System.IO;
using tronc.Timesheet.Web.Utils;



namespace tronc.Timesheet.Web
{
    public partial class IndividualResourceTimeSheet : System.Web.UI.Page
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SessionManager.UserDetails != null)
                {
                    int yId = Convert.ToInt32(Request.QueryString.Get("YId"));
                    int monthId = Convert.ToInt32(Request.QueryString.Get("MId"));
                    int resourceId = Convert.ToInt32(Request.QueryString.Get("RId"));

                    ShowResourceDetails(yId, monthId, resourceId);
                    ShowResourceEffort(resourceId, yId, monthId);
                    ShowResourceEffortComment(resourceId, yId, monthId);
                    ShowDayLabels();
                    DataTable dtResourceEffort = GetEmployeeEffortTable();
                    if (dtResourceEffort.Rows.Count > 0)
                    {
                        grdOrder.DataSource = dtResourceEffort;
                        grdOrder.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("TroncLogin.aspx?returnURL=IndividualResourceTimeSheet.aspx");
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string a;
            Response.Redirect("FloorPoolTimesheet.aspx");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int resourceId = Convert.ToInt32(Request.QueryString.Get("Rid"));
            int yeadId = Convert.ToInt32(Request.QueryString.Get("Yid"));
            int monthId = Convert.ToInt32(Request.QueryString.Get("Mid"));
            string recStatus = UpdateResourceEffort(resourceId, yeadId, monthId);
            string recCommentStatus = UpdateResourceEffortComment(resourceId, yeadId, monthId);
            if (string.IsNullOrEmpty(recStatus) && string.IsNullOrEmpty(recCommentStatus))
            {
                lblSaveStatus.Text = "Effort Saved Successfully";

                ShowResourceEffort(resourceId, yeadId, monthId);
                ShowResourceEffortComment(resourceId, yeadId, monthId);
                DataTable dtResourceEffort = GetEmployeeEffortTable();
                if (dtResourceEffort.Rows.Count > 0)
                {
                    grdOrder.DataSource = dtResourceEffort;
                    grdOrder.DataBind();

                }
            }
            else
            {
                lblSaveStatus.Text = !string.IsNullOrEmpty(recStatus) ? recStatus.ToString() : recCommentStatus.ToString();
            }
        }
        protected void btnExport_Click(object sender, ImageClickEventArgs e)
        {

            ExportToExcel();

        }

        protected void lbCopyEffort_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Private Methods
        private void ShowDayLabels()
        {
            //To retrive the Year and Month details dynamically based on the Id
            int month = Convert.ToInt32(Request.QueryString.Get("Mid"));
            int year = Convert.ToInt32((string)ViewState["Year"]);


            try
            {
                #region First
                int first = Convert.ToInt32(hdnFirst.Value.ToString());
                string firstDay = GetWeekDayName(year, month, first);
                if (firstDay.Trim().Equals("Saturday") || firstDay.Trim().Equals("Sunday"))
                {
                    spnFirst.Style.Add("color", "Red");
                }
                spnFirst.InnerHtml = firstDay + " " + "1st";
                #endregion
                #region second
                int second = Convert.ToInt32(hdnSecond.Value.ToString());
                string secondDay = GetWeekDayName(year, month, second);
                if (secondDay.Trim().Equals("Saturday") || secondDay.Trim().Equals("Sunday"))
                {
                    spnSecond.Style.Add("color", "Red");
                }
                spnSecond.InnerHtml = secondDay + " " + "2nd";
                #endregion
                #region Third
                int third = Convert.ToInt32(hdnThird.Value.ToString());
                string thirdDay = GetWeekDayName(year, month, third);
                if (thirdDay.Trim().Equals("Saturday") || thirdDay.Trim().Equals("Sunday"))
                {
                    spnThird.Style.Add("color", "Red");
                }
                spnThird.InnerHtml = thirdDay + " " + "3rd";
                #endregion

                #region Fourth
                int Fourth = Convert.ToInt32(hdnFourth.Value.ToString());
                string FourthDay = GetWeekDayName(year, month, Fourth);
                if (FourthDay.Trim().Equals("Saturday") || FourthDay.Trim().Equals("Sunday"))
                {
                    spnFourth.Style.Add("color", "Red");
                }
                spnFourth.InnerHtml = FourthDay + " " + "4th";
                #endregion

                #region Fifth
                int Fifth = Convert.ToInt32(hdnFifth.Value.ToString());
                string FifthDay = GetWeekDayName(year, month, Fifth);
                if (FourthDay.Trim().Equals("Saturday") || FifthDay.Trim().Equals("Sunday"))
                {
                    spnFifth.Style.Add("color", "Red");
                }
                spnFifth.InnerHtml = FifthDay + " " + "5th";
                #endregion

                #region sixth
                int sixth = Convert.ToInt32(hdnsixth.Value.ToString());
                string sixthDay = GetWeekDayName(year, month, sixth);
                if (sixthDay.Trim().Equals("Saturday") || sixthDay.Trim().Equals("Sunday"))
                {
                    spnsixth.Style.Add("color", "Red");
                }
                spnsixth.InnerHtml = sixthDay + " " + "6th";
                #endregion

                #region seventh
                int seventh = Convert.ToInt32(hdnseventh.Value.ToString());
                string seventhDay = GetWeekDayName(year, month, seventh);
                if (seventhDay.Trim().Equals("Saturday") || seventhDay.Trim().Equals("Sunday"))
                {
                    spnseventh.Style.Add("color", "Red");
                }
                spnseventh.InnerHtml = seventhDay + " " + "7th";
                #endregion

                #region eighth
                int eighth = Convert.ToInt32(hdneighth.Value.ToString());
                string eighthDay = GetWeekDayName(year, month, eighth);
                if (eighthDay.Trim().Equals("Saturday") || eighthDay.Trim().Equals("Sunday"))
                {
                    spneighth.Style.Add("color", "Red");
                }
                spneighth.InnerHtml = eighthDay + " " + "8th";
                #endregion

                #region nineth
                int nineth = Convert.ToInt32(hdnnineth.Value.ToString());
                string ninethDay = GetWeekDayName(year, month, nineth);
                if (ninethDay.Trim().Equals("Saturday") || ninethDay.Trim().Equals("Sunday"))
                {
                    spnnineth.Style.Add("color", "Red");
                }
                spnnineth.InnerHtml = ninethDay + " " + "9th";
                #endregion

                #region tenth
                int tenth = Convert.ToInt32(hdntenth.Value.ToString());
                string tenthDay = GetWeekDayName(year, month, tenth);
                if (tenthDay.Trim().Equals("Saturday") || tenthDay.Trim().Equals("Sunday"))
                {
                    spntenth.Style.Add("color", "Red");
                }
                spntenth.InnerHtml = tenthDay + " " + "10th";
                #endregion

                #region eleventh
                int eleventh = Convert.ToInt32(hdneleventh.Value.ToString());
                string eleventhDay = GetWeekDayName(year, month, eleventh);
                if (eleventhDay.Trim().Equals("Saturday") || eleventhDay.Trim().Equals("Sunday"))
                {
                    spneleventh.Style.Add("color", "Red");
                }
                spneleventh.InnerHtml = eleventhDay + " " + "11th";
                #endregion
                #region twelveth

                int twelveth = Convert.ToInt32(hdntwelveth.Value.ToString());
                string twelvethDay = GetWeekDayName(year, month, twelveth);
                if (twelvethDay.Trim().Equals("Saturday") || twelvethDay.Trim().Equals("Sunday"))
                {
                    spnetwelveth.Style.Add("color", "Red");
                }
                spnetwelveth.InnerHtml = twelvethDay + " " + "12th";
                #endregion
                #region tirteenth
                int tirteenth = Convert.ToInt32(hdntirteenth.Value.ToString());
                string tirteenthDay = GetWeekDayName(year, month, tirteenth);
                if (tirteenthDay.Trim().Equals("Saturday") || tirteenthDay.Trim().Equals("Sunday"))
                {
                    spntirteenth.Style.Add("color", "Red");
                }
                spntirteenth.InnerHtml = tirteenthDay + " " + "13th";
                #endregion
                #region fourteenth
                int fourteenth = Convert.ToInt32(hdnfourteenth.Value.ToString());
                string fourteenthDay = GetWeekDayName(year, month, fourteenth);
                if (fourteenthDay.Trim().Equals("Saturday") || fourteenthDay.Trim().Equals("Sunday"))
                {
                    spnfourteenth.Style.Add("color", "Red");
                }
                spnfourteenth.InnerHtml = fourteenthDay + " " + "14th";

                #endregion
                #region fifteenth
                int fifteenth = Convert.ToInt32(hdnfifteenth.Value.ToString());
                string fifteenthDay = GetWeekDayName(year, month, fifteenth);
                if (fifteenthDay.Trim().Equals("Saturday") || fifteenthDay.Trim().Equals("Sunday"))
                {
                    spnfifteenth.Style.Add("color", "Red");
                }
                spnfifteenth.InnerHtml = fifteenthDay + " " + "15th";

                #endregion
                #region sixteenth
                int sixteenth = Convert.ToInt32(hdnsixteenth.Value.ToString());
                string sixteenthDay = GetWeekDayName(year, month, sixteenth);
                if (sixteenthDay.Trim().Equals("Saturday") || sixteenthDay.Trim().Equals("Sunday"))
                {
                    spnsixteenth.Style.Add("color", "Red");
                }
                spnsixteenth.InnerHtml = sixteenthDay + " " + "16th";
                #endregion
                #region seventeenth
                int seventeenth = Convert.ToInt32(hdnseventeenth.Value.ToString());
                string seventeenthDay = GetWeekDayName(year, month, seventeenth);
                if (seventeenthDay.Trim().Equals("Saturday") || seventeenthDay.Trim().Equals("Sunday"))
                {
                    spnseventeenth.Style.Add("color", "Red");
                }
                spnseventeenth.InnerHtml = seventeenthDay + " " + "17th";

                #endregion
                #region eighteenth
                int eighteenth = Convert.ToInt32(hdneighteenth.Value.ToString());
                string eighteenthDay = GetWeekDayName(year, month, eighteenth);
                if (eighteenthDay.Trim().Equals("Saturday") || eighteenthDay.Trim().Equals("Sunday"))
                {
                    spneighteenth.Style.Add("color", "Red");
                }
                spneighteenth.InnerHtml = eighteenthDay + " " + "18th";
                #endregion
                #region ninteenth
                int ninteenth = Convert.ToInt32(hdnninteenth.Value.ToString());
                string ninteenthDay = GetWeekDayName(year, month, ninteenth);
                if (ninteenthDay.Trim().Equals("Saturday") || ninteenthDay.Trim().Equals("Sunday"))
                {
                    spnninteenth.Style.Add("color", "Red");
                }
                spnninteenth.InnerHtml = ninteenthDay + " " + "19th";

                #endregion
                #region twenty

                int twenty = Convert.ToInt32(hdntwenty.Value.ToString());
                string twentyDay = GetWeekDayName(year, month, twenty);
                if (twentyDay.Trim().Equals("Saturday") || twentyDay.Trim().Equals("Sunday"))
                {
                    spntwenty.Style.Add("color", "Red");
                }
                spntwenty.InnerHtml = twentyDay + " " + "20th";


                #endregion
                #region twenty1st
                int twenty1st = Convert.ToInt32(hdntwenty1st.Value.ToString());
                string twenty1stDay = GetWeekDayName(year, month, twenty1st);
                if (twenty1stDay.Trim().Equals("Saturday") || twenty1stDay.Trim().Equals("Sunday"))
                {
                    spntwenty1st.Style.Add("color", "Red");
                }
                spntwenty1st.InnerHtml = twenty1stDay + " " + "21st";
                #endregion
                #region twenty2nd
                int twenty2nd = Convert.ToInt32(hdntwenty2nd.Value.ToString());
                string twenty2ndDay = GetWeekDayName(year, month, twenty2nd);
                if (twenty2ndDay.Trim().Equals("Saturday") || twenty2ndDay.Trim().Equals("Sunday"))
                {
                    spntwenty2nd.Style.Add("color", "Red");
                }
                spntwenty2nd.InnerHtml = twenty2ndDay + " " + "22nd";
                #endregion
                #region twenty3rd
                int twenty3rd = Convert.ToInt32(hdntwenty3rd.Value.ToString());
                string twenty3rdDay = GetWeekDayName(year, month, twenty3rd);
                if (twenty3rdDay.Trim().Equals("Saturday") || twenty3rdDay.Trim().Equals("Sunday"))
                {
                    spntwenty3rd.Style.Add("color", "Red");
                }
                spntwenty3rd.InnerHtml = twenty3rdDay + " " + "23rd";

                #endregion
                #region twentyfourth
                int twentyfourth = Convert.ToInt32(hdntwentyfourth.Value.ToString());
                string twentyfourthDay = GetWeekDayName(year, month, twentyfourth);
                if (twentyfourthDay.Trim().Equals("Saturday") || twentyfourthDay.Trim().Equals("Sunday"))
                {
                    spntwentyfourth.Style.Add("color", "Red");
                }
                spntwentyfourth.InnerHtml = twentyfourthDay + " " + "24th";
                #endregion
                #region twentyfifth

                int twentyfifth = Convert.ToInt32(hdntwentyfifth.Value.ToString());
                string twentyfifthDay = GetWeekDayName(year, month, twentyfifth);
                if (twentyfifthDay.Trim().Equals("Saturday") || twentyfifthDay.Trim().Equals("Sunday"))
                {
                    spntwentyfifth.Style.Add("color", "Red");
                }
                spntwentyfifth.InnerHtml = twentyfifthDay + " " + "25th";
                #endregion
                #region twentysixth
                int twentysixth = Convert.ToInt32(hdntwentysixth.Value.ToString());
                string twentysixthDay = GetWeekDayName(year, month, twentysixth);
                if (twentysixthDay.Trim().Equals("Saturday") || twentysixthDay.Trim().Equals("Sunday"))
                {
                    spntwentysixth.Style.Add("color", "Red");
                }
                spntwentysixth.InnerHtml = twentysixthDay + " " + "26th";
                #endregion
                #region twentyseventh
                int twentyseventh = Convert.ToInt32(hdntwentyseventh.Value.ToString());
                string twentyseventhDay = GetWeekDayName(year, month, twentyseventh);
                if (twentyseventhDay.Trim().Equals("Saturday") || twentyseventhDay.Trim().Equals("Sunday"))
                {
                    spntwentyseventh.Style.Add("color", "Red");
                }
                spntwentyseventh.InnerHtml = twentyseventhDay + " " + "27th";

                #endregion
                #region twentyeighth
                int twentyeighth = Convert.ToInt32(hdntwentyeighth.Value.ToString());
                string twentyeighthDay = GetWeekDayName(year, month, twentyeighth);
                if (twentyeighthDay.Trim().Equals("Saturday") || twentyeighthDay.Trim().Equals("Sunday"))
                {
                    spntwentyeighth.Style.Add("color", "Red");
                }
                spntwentyeighth.InnerHtml = twentyeighthDay + " " + "28th";
                #endregion
                #region twentynineth
                int twentynineth = Convert.ToInt32(hdntwentynineth.Value.ToString());
                int daysInMonth = DateTime.DaysInMonth(year, month);
                if (twentynineth <= daysInMonth)
                {
                    string twentyninethDay = GetWeekDayName(year, month, twentynineth);
                    if (twentyninethDay.Trim().Equals("Saturday") || twentyninethDay.Trim().Equals("Sunday"))
                    {
                        spntwentynineth.Style.Add("color", "Red");
                    }
                    spntwentynineth.InnerHtml = twentyninethDay + " " + "29th";
                }
                else
                {
                    spntwentynineth.Visible = false;
                    txttwentynineth.Visible = false;
                    txttwentyninethComment.Visible = false;
                }
                #endregion
                #region thirty
                int thirty = Convert.ToInt32(hdnthirty.Value.ToString());
                if (thirty <= daysInMonth)
                {
                    string thirtyDay = GetWeekDayName(year, month, thirty);
                    if (thirtyDay.Trim().Equals("Saturday") || thirtyDay.Trim().Equals("Sunday"))
                    {
                        spnthirty.Style.Add("color", "Red");
                    }
                    spnthirty.InnerHtml = twentyeighthDay + " " + "30th";
                }
                else
                {
                    spnthirty.Visible = false;
                    txtthirty.Visible = false;
                    txtthirtyComment.Visible = false;
                }
                #endregion
                #region thirtyone
                int thirtyone = Convert.ToInt32(hdnthirtyone.Value.ToString());
                if (thirtyone <= daysInMonth)
                {
                    string thirtyoneDay = GetWeekDayName(year, month, thirtyone);
                    if (thirtyoneDay.Trim().Equals("Saturday") || thirtyoneDay.Trim().Equals("Sunday"))
                    {
                        spnthirtyone.Style.Add("color", "Red");
                    }
                    spnthirtyone.InnerHtml = thirtyoneDay + " " + "31st";
                }
                else
                {
                    spnthirtyone.Visible = false;
                    txtthirtyoneComment.Visible = false;
                    txthirtyone.Visible = false;
                }
                #endregion
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
            return lstResourceEffort;
        }


        /// <summary>
        /// 
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
            return lstallresourceeffort;
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="yearId"></param>
        /// <param name="monthId"></param>
        /// <param name="segmentId"></param>
        /// <returns></returns>
        private List<ResourceEffortComment> GetAllResourceEffortComment(int yearId, int monthId, int segmentId)
        {
            List<ResourceEffortComment> lstAllResourceEffortComment = new List<ResourceEffortComment>();
            TimesheetRepository timeSheetRepository = new TimesheetRepository();
            try
            {
                lstAllResourceEffortComment = timeSheetRepository.GetAllResourceEffortComment(yearId, monthId, segmentId);
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
            return lstAllResourceEffortComment;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="yearId"></param>
        /// <param name="monthId"></param>
        private void ShowResourceEffort(int resourceId, int yearId, int monthId)
        {
            try
            {
                List<ResourceEffort> lstResourceEffort = new List<ResourceEffort>();
                lstResourceEffort = GetResourceEffort(resourceId, yearId, monthId);
                if (lstResourceEffort != null && lstResourceEffort.Count > 0)
                {
                    txtFirst.Text = lstResourceEffort[0].EOne.ToString();
                    txtSecond.Text = lstResourceEffort[0].ETwo.ToString();
                    txtThird.Text = lstResourceEffort[0].EThree.ToString();
                    txtFourth.Text = lstResourceEffort[0].EFour.ToString();
                    txtFifth.Text = lstResourceEffort[0].EFive.ToString();
                    txtsixth.Text = lstResourceEffort[0].ESix.ToString();
                    txtseventh.Text = lstResourceEffort[0].ESeven.ToString();
                    txteighth.Text = lstResourceEffort[0].EEight.ToString();
                    txtnineth.Text = lstResourceEffort[0].ENine.ToString();
                    txttenth.Text = lstResourceEffort[0].ETen.ToString();
                    txteleventh.Text = lstResourceEffort[0].EEleven.ToString();
                    txttwelveth.Text = lstResourceEffort[0].ETwelve.ToString();
                    txttirteen.Text = lstResourceEffort[0].EThirteen.ToString();
                    txtfourteenth.Text = lstResourceEffort[0].EFourteen.ToString();
                    txtfifteenth.Text = lstResourceEffort[0].EFifteen.ToString();
                    txtsixteenth.Text = lstResourceEffort[0].ESixteen.ToString();
                    txtseventeenth.Text = lstResourceEffort[0].ESeventeen.ToString();
                    txteighteenth.Text = lstResourceEffort[0].EEighteen.ToString();
                    txtninteenth.Text = lstResourceEffort[0].ENineteen.ToString();
                    txttwenty.Text = lstResourceEffort[0].ETwenty.ToString();
                    txttwenty1st.Text = lstResourceEffort[0].ETwentyOne.ToString();
                    txttwenty2nd.Text = lstResourceEffort[0].ETwentyTwo.ToString();
                    txttwenty3rd.Text = lstResourceEffort[0].ETwentyThree.ToString();
                    txttwentyfourth.Text = lstResourceEffort[0].ETwentyFour.ToString();
                    txttwentyfifth.Text = lstResourceEffort[0].ETwentyFive.ToString();
                    txttwentysixth.Text = lstResourceEffort[0].ETwentySix.ToString();
                    txttwentyseventh.Text = lstResourceEffort[0].ETwentySeven.ToString();
                    txttwentyeighth.Text = lstResourceEffort[0].ETwentyEight.ToString();
                    txttwentynineth.Text = lstResourceEffort[0].ETwentyNine.ToString();
                    txtthirty.Text = lstResourceEffort[0].EThirty.ToString();
                    txthirtyone.Text = lstResourceEffort[0].EThirtyOne.ToString();

                }

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
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="yearId"></param>
        /// <param name="monthId"></param>
        private void ShowResourceEffortComment(int resourceId, int yearId, int monthId)
        {
            try
            {
                List<ResourceEffortComment> lstResourceEffortComment = new List<ResourceEffortComment>();
                lstResourceEffortComment = GetResourceEffortComment(resourceId, yearId, monthId);
                if (lstResourceEffortComment != null && lstResourceEffortComment.Count > 0)
                {
                    txtFirstComment.Text = lstResourceEffortComment[0].EcommentOne.ToString();
                    txtSecondComment.Text = lstResourceEffortComment[0].EcommentTwo.ToString();
                    txtThirdComment.Text = lstResourceEffortComment[0].EcommentThree.ToString();
                    txtFourthComment.Text = lstResourceEffortComment[0].EcommentFour.ToString();
                    txtFifthComment.Text = lstResourceEffortComment[0].EcommentFive.ToString();
                    txtsixthComment.Text = lstResourceEffortComment[0].EcommentSix.ToString();
                    txtseventhComment.Text = lstResourceEffortComment[0].EcommentSeven.ToString();
                    txteighthComment.Text = lstResourceEffortComment[0].EcommentEight.ToString();
                    txtninethComment.Text = lstResourceEffortComment[0].EcommentNine.ToString();
                    txttenthComment.Text = lstResourceEffortComment[0].EcommentTen.ToString();
                    txteleventhComment.Text = lstResourceEffortComment[0].EcommentEleven.ToString();
                    txttwelvethComment.Text = lstResourceEffortComment[0].EcommentTwelve.ToString();
                    txttirteenComment.Text = lstResourceEffortComment[0].EcommentThirteen.ToString();
                    txtfourteenthComment.Text = lstResourceEffortComment[0].EcommentFourteen.ToString();
                    txtfifteenthComment.Text = lstResourceEffortComment[0].EcommentFifteen.ToString();
                    txtsixteenthComment.Text = lstResourceEffortComment[0].EcommentSixteen.ToString();
                    txtseventeenthComment.Text = lstResourceEffortComment[0].EcommentSeventeen.ToString();
                    txteighteenthComment.Text = lstResourceEffortComment[0].EcommentEighteen.ToString();
                    txtninteenthComment.Text = lstResourceEffortComment[0].EcommentNineteen.ToString();
                    txttwentyComment.Text = lstResourceEffortComment[0].EcommentTwenty.ToString();
                    txttwenty1stComment.Text = lstResourceEffortComment[0].EcommentTwentyOne.ToString();
                    txttwenty2ndComment.Text = lstResourceEffortComment[0].EcommentTwentyTwo.ToString();
                    txttwenty3rdComment.Text = lstResourceEffortComment[0].EcommentTwentyThree.ToString();
                    txttwentyfourthComment.Text = lstResourceEffortComment[0].EcommentTwentyFour.ToString();
                    txttwentyfifthComment.Text = lstResourceEffortComment[0].EcommentTwentyFive.ToString();
                    txttwentysixthComment.Text = lstResourceEffortComment[0].EcommentTwentySix.ToString();
                    txttwentyseventhComment.Text = lstResourceEffortComment[0].EcommentTwentySeven.ToString();
                    txttwentyeighthComment.Text = lstResourceEffortComment[0].EcommentTwentyEight.ToString();
                    txttwentyninethComment.Text = lstResourceEffortComment[0].EcommentTwentyNine.ToString();
                    txtthirtyComment.Text = lstResourceEffortComment[0].EcommentThirty.ToString();
                    txtthirtyoneComment.Text = lstResourceEffortComment[0].EcommentThirtyOne.ToString();

                }

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
        }

        /// <summary>
        /// To update the resource Effort
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="yearId"></param>
        /// <param name="monthId"></param>
        /// <returns></returns>
        private string UpdateResourceEffort(int resourceId, int yearId, int monthId)
        {
            string status = string.Empty;
            ResourceEffort resourceEffort = new ResourceEffort();
            TimesheetRepository timeSheetRepository = new TimesheetRepository();
            try
            {
                resourceEffort.ResourceId = resourceId;
                resourceEffort.YeadId = yearId;
                resourceEffort.MonthId = monthId;
                resourceEffort.EOne = !string.IsNullOrEmpty(txtFirst.Text) && CheckInputforNumeric(txtFirst.Text) ? txtFirst.Text : "0";
                resourceEffort.ETwo = !string.IsNullOrEmpty(txtSecond.Text) && CheckInputforNumeric(txtSecond.Text) ? txtSecond.Text : "0";
                resourceEffort.EThree = !string.IsNullOrEmpty(txtThird.Text) && CheckInputforNumeric(txtThird.Text) ? txtThird.Text : "0";
                resourceEffort.EFour = !string.IsNullOrEmpty(txtFourth.Text) && CheckInputforNumeric(txtFourth.Text) ? txtFourth.Text : "0";
                resourceEffort.EFive = !string.IsNullOrEmpty(txtFifth.Text) && CheckInputforNumeric(txtFifth.Text) ? txtFifth.Text : "0";
                resourceEffort.ESix = !string.IsNullOrEmpty(txtsixth.Text) && CheckInputforNumeric(txtsixth.Text) ? txtsixth.Text : "0";
                resourceEffort.ESeven = !string.IsNullOrEmpty(txtseventh.Text) && CheckInputforNumeric(txtseventh.Text) ? txtseventh.Text : "0";
                resourceEffort.EEight = !string.IsNullOrEmpty(txteighth.Text) && CheckInputforNumeric(txteighth.Text) ? txteighth.Text : "0";
                resourceEffort.ENine = !string.IsNullOrEmpty(txtnineth.Text) && CheckInputforNumeric(txtnineth.Text) ? txtnineth.Text : "0";
                resourceEffort.ETen = !string.IsNullOrEmpty(txttenth.Text) && CheckInputforNumeric(txttenth.Text) ? txttenth.Text : "0";
                resourceEffort.EEleven = !string.IsNullOrEmpty(txteleventh.Text) && CheckInputforNumeric(txteleventh.Text) ? txteleventh.Text : "0";
                resourceEffort.ETwelve = !string.IsNullOrEmpty(txttwelveth.Text) && CheckInputforNumeric(txttwelveth.Text) ? txttwelveth.Text : "0";
                resourceEffort.EThirteen = !string.IsNullOrEmpty(txttirteen.Text) && CheckInputforNumeric(txttirteen.Text) ? txttirteen.Text : "0";
                resourceEffort.EFourteen = !string.IsNullOrEmpty(txtfourteenth.Text) && CheckInputforNumeric(txtfourteenth.Text) ? txtfourteenth.Text : "0";
                resourceEffort.EFifteen = !string.IsNullOrEmpty(txtfifteenth.Text) && CheckInputforNumeric(txtfifteenth.Text) ? txtfifteenth.Text : "0";
                resourceEffort.ESixteen = !string.IsNullOrEmpty(txtsixteenth.Text) && CheckInputforNumeric(txtsixteenth.Text) ? txtsixteenth.Text : "0";
                resourceEffort.ESeventeen = !string.IsNullOrEmpty(txtseventeenth.Text) && CheckInputforNumeric(txtseventeenth.Text) ? txtseventeenth.Text : "0";
                resourceEffort.EEighteen = !string.IsNullOrEmpty(txteighteenth.Text) && CheckInputforNumeric(txteighteenth.Text) ? txteighteenth.Text : "0";
                resourceEffort.ENineteen = !string.IsNullOrEmpty(txtninteenth.Text) && CheckInputforNumeric(txtninteenth.Text) ? txtninteenth.Text : "0";
                resourceEffort.ETwenty = !string.IsNullOrEmpty(txttwenty.Text) && CheckInputforNumeric(txttwenty.Text) ? txttwenty.Text : "0";
                resourceEffort.ETwentyOne = !string.IsNullOrEmpty(txttwenty1st.Text) && CheckInputforNumeric(txttwenty1st.Text) ? txttwenty1st.Text : "0";
                resourceEffort.ETwentyTwo = !string.IsNullOrEmpty(txttwenty2nd.Text) && CheckInputforNumeric(txttwenty2nd.Text) ? txttwenty2nd.Text : "0";
                resourceEffort.ETwentyThree = !string.IsNullOrEmpty(txttwenty3rd.Text) && CheckInputforNumeric(txttwenty3rd.Text) ? txttwenty3rd.Text : "0";
                resourceEffort.ETwentyFour = !string.IsNullOrEmpty(txttwentyfourth.Text) && CheckInputforNumeric(txttwentyfourth.Text) ? txttwentyfourth.Text : "0";
                resourceEffort.ETwentyFive = !string.IsNullOrEmpty(txttwentyfifth.Text) && CheckInputforNumeric(txttwentyfifth.Text) ? txttwentyfifth.Text : "0";
                resourceEffort.ETwentySix = !string.IsNullOrEmpty(txttwentysixth.Text) && CheckInputforNumeric(txttwentysixth.Text) ? txttwentysixth.Text : "0";
                resourceEffort.ETwentySeven = !string.IsNullOrEmpty(txttwentyseventh.Text) && CheckInputforNumeric(txttwentyseventh.Text) ? txttwentyseventh.Text : "0";
                resourceEffort.ETwentyEight = !string.IsNullOrEmpty(txttwentyeighth.Text) && CheckInputforNumeric(txttwentyeighth.Text) ? txttwentyeighth.Text : "0";
                resourceEffort.ETwentyNine = !string.IsNullOrEmpty(txttwentynineth.Text) && CheckInputforNumeric(txttwentynineth.Text) ? txttwentynineth.Text : "0";
                resourceEffort.EThirty = !string.IsNullOrEmpty(txtthirty.Text) && CheckInputforNumeric(txtthirty.Text) ? txtthirty.Text : "0";
                resourceEffort.EThirtyOne = !string.IsNullOrEmpty(txthirtyone.Text) && CheckInputforNumeric(txthirtyone.Text) ? txthirtyone.Text : "0";
                status = timeSheetRepository.UpdateResourceEffort(resourceEffort);
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
            return status;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceEffortComment"></param>
        /// <returns></returns>
        private string UpdateResourceEffortComment(int resourceId, int yearId, int monthId)
        {

            string status = string.Empty;
            TimesheetRepository timeSheetRepository = new TimesheetRepository();
            ResourceEffortComment resourceEffortComment = new ResourceEffortComment();
            try
            {
                resourceEffortComment.ResourceId = resourceId;
                resourceEffortComment.YeadId = yearId;
                resourceEffortComment.MonthId = monthId;
                resourceEffortComment.EcommentOne = txtFirstComment.Text;
                resourceEffortComment.EcommentTwo = txtSecondComment.Text;
                resourceEffortComment.EcommentThree = txtThirdComment.Text;
                resourceEffortComment.EcommentFour = txtFourthComment.Text;
                resourceEffortComment.EcommentFive = txtFifthComment.Text;
                resourceEffortComment.EcommentSix = txtsixthComment.Text;
                resourceEffortComment.EcommentSeven = txtseventhComment.Text;
                resourceEffortComment.EcommentEight = txteighthComment.Text;
                resourceEffortComment.EcommentNine = txtninethComment.Text;
                resourceEffortComment.EcommentTen = txttenthComment.Text;
                resourceEffortComment.EcommentEleven = txteleventhComment.Text;
                resourceEffortComment.EcommentTwelve = txttwelvethComment.Text;
                resourceEffortComment.EcommentThirteen = txttirteenComment.Text;
                resourceEffortComment.EcommentFourteen = txtfourteenthComment.Text;
                resourceEffortComment.EcommentFifteen = txtfifteenthComment.Text;
                resourceEffortComment.EcommentSixteen = txtsixteenthComment.Text;
                resourceEffortComment.EcommentSeventeen = txtseventeenthComment.Text;
                resourceEffortComment.EcommentEighteen = txteighteenthComment.Text;
                resourceEffortComment.EcommentNineteen = txtninteenthComment.Text;
                resourceEffortComment.EcommentTwenty = txttwentyComment.Text;
                resourceEffortComment.EcommentTwentyOne = txttwenty1stComment.Text;
                resourceEffortComment.EcommentTwentyTwo = txttwenty2ndComment.Text;
                resourceEffortComment.EcommentTwentyThree = txttwenty3rdComment.Text;
                resourceEffortComment.EcommentTwentyFour = txttwentyfourthComment.Text;
                resourceEffortComment.EcommentTwentyFive = txttwentyfifthComment.Text;
                resourceEffortComment.EcommentTwentySix = txttwentysixthComment.Text;
                resourceEffortComment.EcommentTwentySeven = txttwentyseventhComment.Text;
                resourceEffortComment.EcommentTwentyEight = txttwentyeighthComment.Text;
                resourceEffortComment.EcommentTwentyNine = txttwentyninethComment.Text;
                resourceEffortComment.EcommentThirty = txtthirtyComment.Text;
                resourceEffortComment.EcommentThirtyOne = txtthirtyoneComment.Text;
                status = timeSheetRepository.UpdateResourceEffortComment(resourceEffortComment);
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
            return status;
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
        /// To show the resource details
        /// </summary>
        /// <param name="year"></param>
        /// <param name="Month"></param>
        /// <param name="resource"></param>
        private void ShowResourceDetails(int yId, int monthId, int resourceId)
        {

            try
            {
                string yearName = string.Empty;
                string monthName = string.Empty;
                string resourceName = string.Empty;
                string resourceEmail = string.Empty;
                string resourceContact = string.Empty;
                string segmentName = string.Empty;

                List<Year> lstYear = GetYear();
                if (lstYear != null && lstYear.Count > 0)
                {
                    yearName = (from item in lstYear
                                where !string.IsNullOrEmpty(item.YearId.ToString())
                                && item.YearId.ToString().Equals(yId.ToString())
                                select item.YearNumber).FirstOrDefault();

                }
                List<Month> lstMonth = GetMonth();
                if (lstMonth != null && lstMonth.Count > 0)
                {
                    monthName = (from item in lstMonth
                                 where !string.IsNullOrEmpty(item.MonthId.ToString())
                                 && item.MonthId.ToString().Equals(monthId.ToString())
                                 select item.MonthName).FirstOrDefault();
                }
                Resource resource = new Resource();
                List<Resource> lstResource = GetResources();
                if (lstResource != null && lstResource.Count > 0)
                {
                    resource = (from item in lstResource
                                where !string.IsNullOrEmpty(item.ResourceId.ToString())
                                && item.ResourceId.ToString().Equals(resourceId.ToString())
                                select item).FirstOrDefault();
                    if (resource != null)
                    {
                        resourceName = resource.ResourceName;
                        resourceEmail = resource.ResourceEmail;
                        resourceContact = resource.ResourceContact;
                        segmentName = resource.ResourceSegment;
                    }
                }
                lblContact.Text = resourceContact;
                lblEmail.Text = resourceEmail;
                lblMonth.Text = monthName;
                lblName.Text = resourceName;
                lblSegment.Text = segmentName;
                lblYear.Text = yearName;
                ViewState["Contact"] = resourceContact;
                ViewState["Email"] = resourceEmail;
                ViewState["Month"] = monthName;
                ViewState["Name"] = resourceName;
                ViewState["Segment"] = segmentName;
                ViewState["Year"] = yearName;
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
        }


        /// <summary>
        /// To check is the input value is an Integer
        /// </summary>
        /// <param name="inpVal"></param>
        /// <returns></returns>
        private bool CheckInputforNumeric(string inpVal)
        {
            bool isNumber = false;
            try
            {
                int numeric;
                isNumber = int.TryParse(inpVal, out numeric);
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
            return isNumber;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DataTable GetEmployeeEffortTable()
        {
            DataTable dtEffort = new DataTable("Resource-Effort");
            int yId = Convert.ToInt32(Request.QueryString.Get("YId"));
            int monthId = Convert.ToInt32(Request.QueryString.Get("MId"));
            int resourceId = Convert.ToInt32(Request.QueryString.Get("RId"));
            string name = (string)ViewState["Name"];
            string email = (string)ViewState["Email"];
            string segment = (string)ViewState["Segment"];
            string month = (string)ViewState["Month"];
            string year = (string)ViewState["Year"];

            try
            {
                List<ResourceEffort> lstResourceEffort = new List<ResourceEffort>();
                lstResourceEffort = GetResourceEffort(resourceId, yId, monthId);
                List<ResourceEffortComment> lstResourceEffortComment = new List<ResourceEffortComment>();
                lstResourceEffortComment = GetResourceEffortComment(resourceId, yId, monthId);
                if (lstResourceEffort != null && lstResourceEffort.Count > 0 && lstResourceEffortComment != null && lstResourceEffortComment.Count > 0)
                {
                    dtEffort.Columns.Add("Name", Type.GetType("System.String"));
                    dtEffort.Columns.Add("Email", Type.GetType("System.String"));
                    dtEffort.Columns.Add("Segment", Type.GetType("System.String"));
                    dtEffort.Columns.Add("Year", Type.GetType("System.String"));
                    dtEffort.Columns.Add("Month", Type.GetType("System.String"));
                    dtEffort.Columns.Add("Date", Type.GetType("System.String"));
                    dtEffort.Columns.Add("Effort", Type.GetType("System.String"));
                    dtEffort.Columns.Add("Effort-Comments", Type.GetType("System.String"));

                    DataRow dr = dtEffort.NewRow();
                    dr["Name"] = name;
                    dr["Email"] = email;
                    dr["Segment"] = segment;
                    dr["Year"] = year;
                    dr["Month"] = month;
                    dr["Date"] = "1st";
                    dr["Effort"] = lstResourceEffort[0].EOne.ToString();
                    dr["Effort-Comments"] = lstResourceEffortComment[0].EcommentOne.Trim();
                    dtEffort.Rows.Add(dr);

                    DataRow dr2 = dtEffort.NewRow();
                    dr2["Name"] = name;
                    dr2["Email"] = email;
                    dr2["Segment"] = segment;
                    dr2["Year"] = year;
                    dr2["Month"] = month;
                    dr2["Date"] = "2nd";
                    dr2["Effort"] = lstResourceEffort[0].ETwo.ToString();
                    dr2["Effort-Comments"] = lstResourceEffortComment[0].EcommentTwo.Trim();
                    dtEffort.Rows.Add(dr2);

                    DataRow dr3 = dtEffort.NewRow();
                    dr3["Name"] = name;
                    dr3["Email"] = email;
                    dr3["Segment"] = segment;
                    dr3["Year"] = year;
                    dr3["Month"] = month;
                    dr3["Date"] = "3rd";
                    dr3["Effort"] = lstResourceEffort[0].EThree.ToString();
                    dr3["Effort-Comments"] = lstResourceEffortComment[0].EcommentThree.Trim();
                    dtEffort.Rows.Add(dr3);

                    DataRow dr4 = dtEffort.NewRow();
                    dr4["Name"] = name;
                    dr4["Email"] = email;
                    dr4["Segment"] = segment;
                    dr4["Year"] = year;
                    dr4["Month"] = month;
                    dr4["Date"] = "4th";
                    dr4["Effort"] = lstResourceEffort[0].EFour.ToString();
                    dr4["Effort-Comments"] = lstResourceEffortComment[0].EcommentFour.Trim();
                    dtEffort.Rows.Add(dr4);

                    DataRow dr5 = dtEffort.NewRow();
                    dr5["Name"] = name;
                    dr5["Email"] = email;
                    dr5["Segment"] = segment;
                    dr5["Year"] = year;
                    dr5["Month"] = month;
                    dr5["Date"] = "5th";
                    dr5["Effort"] = lstResourceEffort[0].EFive.ToString();
                    dr5["Effort-Comments"] = lstResourceEffortComment[0].EcommentFive.Trim();
                    dtEffort.Rows.Add(dr5);

                    DataRow dr6 = dtEffort.NewRow();
                    dr6["Name"] = name;
                    dr6["Email"] = email;
                    dr6["Segment"] = segment;
                    dr6["Year"] = year;
                    dr6["Month"] = month;
                    dr6["Date"] = "6th";
                    dr6["Effort"] = lstResourceEffort[0].ESix.ToString();
                    dr6["Effort-Comments"] = lstResourceEffortComment[0].EcommentSix.Trim();
                    dtEffort.Rows.Add(dr6);

                    DataRow dr7 = dtEffort.NewRow();
                    dr7["Name"] = name;
                    dr7["Email"] = email;
                    dr7["Segment"] = segment;
                    dr7["Year"] = year;
                    dr7["Month"] = month;
                    dr7["Date"] = "7th";
                    dr7["Effort"] = lstResourceEffort[0].ESeven.ToString();
                    dr7["Effort-Comments"] = lstResourceEffortComment[0].EcommentSeven.Trim();
                    dtEffort.Rows.Add(dr7);

                    DataRow dr8 = dtEffort.NewRow();
                    dr8["Name"] = name;
                    dr8["Email"] = email;
                    dr8["Segment"] = segment;
                    dr8["Year"] = year;
                    dr8["Month"] = month;
                    dr8["Date"] = "8th";
                    dr8["Effort"] = lstResourceEffort[0].EEight.ToString();
                    dr8["Effort-Comments"] = lstResourceEffortComment[0].EcommentEight.Trim();
                    dtEffort.Rows.Add(dr8);

                    DataRow dr9 = dtEffort.NewRow();
                    dr9["Name"] = name;
                    dr9["Email"] = email;
                    dr9["Segment"] = segment;
                    dr9["Year"] = year;
                    dr9["Month"] = month;
                    dr9["Date"] = "9th";
                    dr9["Effort"] = lstResourceEffort[0].ENine.ToString();
                    dr9["Effort-Comments"] = lstResourceEffortComment[0].EcommentNine.Trim();
                    dtEffort.Rows.Add(dr9);

                    DataRow dr10 = dtEffort.NewRow();
                    dr10["Name"] = name;
                    dr10["Email"] = email;
                    dr10["Segment"] = segment;
                    dr10["Year"] = year;
                    dr10["Month"] = month;
                    dr10["Date"] = "10th";
                    dr10["Effort"] = lstResourceEffort[0].ETen.ToString();
                    dr10["Effort-Comments"] = lstResourceEffortComment[0].EcommentTen.Trim();
                    dtEffort.Rows.Add(dr10);

                    DataRow dr11 = dtEffort.NewRow();
                    dr11["Name"] = name;
                    dr11["Email"] = email;
                    dr11["Segment"] = segment;
                    dr11["Year"] = year;
                    dr11["Month"] = month;
                    dr11["Date"] = "11th";
                    dr11["Effort"] = lstResourceEffort[0].EEleven.ToString();
                    dr11["Effort-Comments"] = lstResourceEffortComment[0].EcommentEleven.Trim();
                    dtEffort.Rows.Add(dr11);

                    DataRow dr12 = dtEffort.NewRow();
                    dr12["Name"] = name;
                    dr12["Email"] = email;
                    dr12["Segment"] = segment;
                    dr12["Year"] = year;
                    dr12["Month"] = month;
                    dr12["Date"] = "12th";
                    dr12["Effort"] = lstResourceEffort[0].ETwelve.ToString();
                    dr12["Effort-Comments"] = lstResourceEffortComment[0].EcommentTwelve.Trim();
                    dtEffort.Rows.Add(dr12);

                    DataRow dr13 = dtEffort.NewRow();
                    dr13["Name"] = name;
                    dr13["Email"] = email;
                    dr13["Segment"] = segment;
                    dr13["Year"] = year;
                    dr13["Month"] = month;
                    dr13["Date"] = "13th";
                    dr13["Effort"] = lstResourceEffort[0].EThirteen.ToString();
                    dr13["Effort-Comments"] = lstResourceEffortComment[0].EcommentThirteen.Trim();
                    dtEffort.Rows.Add(dr13);

                    DataRow dr14 = dtEffort.NewRow();
                    dr14["Name"] = name;
                    dr14["Email"] = email;
                    dr14["Segment"] = segment;
                    dr14["Year"] = year;
                    dr14["Month"] = month;
                    dr14["Date"] = "14th";
                    dr14["Effort"] = lstResourceEffort[0].EFourteen.ToString();
                    dr14["Effort-Comments"] = lstResourceEffortComment[0].EcommentFourteen.Trim();
                    dtEffort.Rows.Add(dr14);

                    DataRow dr15 = dtEffort.NewRow();
                    dr15["Name"] = name;
                    dr15["Email"] = email;
                    dr15["Segment"] = segment;
                    dr15["Year"] = year;
                    dr15["Month"] = month;
                    dr15["Date"] = "15th";
                    dr15["Effort"] = lstResourceEffort[0].EOne.ToString();
                    dr15["Effort-Comments"] = lstResourceEffortComment[0].EcommentOne.Trim();
                    dtEffort.Rows.Add(dr15);

                    DataRow dr16 = dtEffort.NewRow();
                    dr16["Name"] = name;
                    dr16["Email"] = email;
                    dr16["Segment"] = segment;
                    dr16["Year"] = year;
                    dr16["Month"] = month;
                    dr16["Date"] = "16th";
                    dr16["Effort"] = lstResourceEffort[0].ESixteen.ToString();
                    dr16["Effort-Comments"] = lstResourceEffortComment[0].EcommentSixteen.Trim();
                    dtEffort.Rows.Add(dr16);

                    DataRow dr17 = dtEffort.NewRow();
                    dr17["Name"] = name;
                    dr17["Email"] = email;
                    dr17["Segment"] = segment;
                    dr17["Year"] = year;
                    dr17["Month"] = month;
                    dr17["Date"] = "17th";
                    dr17["Effort"] = lstResourceEffort[0].ESeventeen.ToString();
                    dr17["Effort-Comments"] = lstResourceEffortComment[0].EcommentSeventeen.Trim();
                    dtEffort.Rows.Add(dr17);

                    DataRow dr18 = dtEffort.NewRow();
                    dr18["Name"] = name;
                    dr18["Email"] = email;
                    dr18["Segment"] = segment;
                    dr18["Year"] = year;
                    dr18["Month"] = month;
                    dr18["Date"] = "18th";
                    dr18["Effort"] = lstResourceEffort[0].EEighteen.ToString();
                    dr18["Effort-Comments"] = lstResourceEffortComment[0].EcommentEighteen.Trim();
                    dtEffort.Rows.Add(dr18);

                    DataRow dr19 = dtEffort.NewRow();
                    dr19["Name"] = name;
                    dr19["Email"] = email;
                    dr19["Segment"] = segment;
                    dr19["Year"] = year;
                    dr19["Month"] = month;
                    dr19["Date"] = "19th";
                    dr19["Effort"] = lstResourceEffort[0].ENineteen.ToString();
                    dr19["Effort-Comments"] = lstResourceEffortComment[0].EcommentNineteen.Trim();
                    dtEffort.Rows.Add(dr19);

                    DataRow dr20 = dtEffort.NewRow();
                    dr20["Name"] = name;
                    dr20["Email"] = email;
                    dr20["Segment"] = segment;
                    dr20["Year"] = year;
                    dr20["Month"] = month;
                    dr20["Date"] = "20th";
                    dr20["Effort"] = lstResourceEffort[0].ETwenty.ToString();
                    dr20["Effort-Comments"] = lstResourceEffortComment[0].EcommentTwenty.Trim();
                    dtEffort.Rows.Add(dr20);

                    DataRow dr21 = dtEffort.NewRow();
                    dr21["Name"] = name;
                    dr21["Email"] = email;
                    dr21["Segment"] = segment;
                    dr21["Year"] = year;
                    dr21["Month"] = month;
                    dr21["Date"] = "21st";
                    dr21["Effort"] = lstResourceEffort[0].EOne.ToString();
                    dr21["Effort-Comments"] = lstResourceEffortComment[0].EcommentTwentyOne.Trim();
                    dtEffort.Rows.Add(dr21);

                    DataRow dr22 = dtEffort.NewRow();
                    dr22["Name"] = name;
                    dr22["Email"] = email;
                    dr22["Segment"] = segment;
                    dr22["Year"] = year;
                    dr22["Month"] = month;
                    dr22["Date"] = "22nd";
                    dr22["Effort"] = lstResourceEffort[0].ETwentyTwo.ToString();
                    dr22["Effort-Comments"] = lstResourceEffortComment[0].EcommentTwentyTwo.Trim();
                    dtEffort.Rows.Add(dr22);

                    DataRow dr23 = dtEffort.NewRow();
                    dr23["Name"] = name;
                    dr23["Email"] = email;
                    dr23["Segment"] = segment;
                    dr23["Year"] = year;
                    dr23["Month"] = month;
                    dr23["Date"] = "23rd";
                    dr23["Effort"] = lstResourceEffort[0].ETwentyThree.ToString();
                    dr23["Effort-Comments"] = lstResourceEffortComment[0].EcommentTwentyThree.Trim();
                    dtEffort.Rows.Add(dr23);

                    DataRow dr24 = dtEffort.NewRow();
                    dr24["Name"] = name;
                    dr24["Email"] = email;
                    dr24["Segment"] = segment;
                    dr24["Year"] = year;
                    dr24["Month"] = month;
                    dr24["Date"] = "24th";
                    dr24["Effort"] = lstResourceEffort[0].ETwentyFour.ToString();
                    dr24["Effort-Comments"] = lstResourceEffortComment[0].EcommentTwentyFour.Trim();
                    dtEffort.Rows.Add(dr24);

                    DataRow dr25 = dtEffort.NewRow();
                    dr25["Name"] = name;
                    dr25["Email"] = email;
                    dr25["Segment"] = segment;
                    dr25["Year"] = year;
                    dr25["Month"] = month;
                    dr25["Date"] = "25th";
                    dr25["Effort"] = lstResourceEffort[0].ETwentyFive.ToString();
                    dr25["Effort-Comments"] = lstResourceEffortComment[0].EcommentTwentyFive.Trim();
                    dtEffort.Rows.Add(dr25);

                    DataRow dr26 = dtEffort.NewRow();
                    dr26["Name"] = name;
                    dr26["Email"] = email;
                    dr26["Segment"] = segment;
                    dr26["Year"] = year;
                    dr26["Month"] = month;
                    dr26["Date"] = "26th";
                    dr26["Effort"] = lstResourceEffort[0].ETwentySix.ToString();
                    dr26["Effort-Comments"] = lstResourceEffortComment[0].EcommentTwentySix.Trim();
                    dtEffort.Rows.Add(dr26);

                    DataRow dr27 = dtEffort.NewRow();
                    dr27["Name"] = name;
                    dr27["Email"] = email;
                    dr27["Segment"] = segment;
                    dr27["Year"] = year;
                    dr27["Month"] = month;
                    dr27["Date"] = "27th";
                    dr27["Effort"] = lstResourceEffort[0].ETwentySeven.ToString();
                    dr27["Effort-Comments"] = lstResourceEffortComment[0].EcommentTwentySeven.Trim();
                    dtEffort.Rows.Add(dr27);

                    DataRow dr28 = dtEffort.NewRow();
                    dr28["Name"] = name;
                    dr28["Email"] = email;
                    dr28["Segment"] = segment;
                    dr28["Year"] = year;
                    dr28["Month"] = month;
                    dr28["Date"] = "28th";
                    dr28["Effort"] = lstResourceEffort[0].ETwentyEight.ToString();
                    dr28["Effort-Comments"] = lstResourceEffortComment[0].EcommentTwentyEight.Trim();
                    dtEffort.Rows.Add(dr28);

                    DataRow dr29 = dtEffort.NewRow();
                    dr29["Name"] = name;
                    dr29["Email"] = email;
                    dr29["Segment"] = segment;
                    dr29["Year"] = year;
                    dr29["Month"] = month;
                    dr29["Date"] = "29th";
                    dr29["Effort"] = lstResourceEffort[0].ETwentyNine.ToString();
                    dr29["Effort-Comments"] = lstResourceEffortComment[0].EcommentTwentyNine.Trim();
                    dtEffort.Rows.Add(dr29);

                    DataRow dr30 = dtEffort.NewRow();
                    dr30["Name"] = name;
                    dr30["Email"] = email;
                    dr30["Segment"] = segment;
                    dr30["Year"] = year;
                    dr30["Month"] = month;
                    dr30["Date"] = "30th";
                    dr30["Effort"] = lstResourceEffort[0].EThirty.ToString();
                    dr30["Effort-Comments"] = lstResourceEffortComment[0].EcommentThirty.Trim();
                    dtEffort.Rows.Add(dr30);

                    DataRow dr31 = dtEffort.NewRow();
                    dr31["Name"] = name;
                    dr31["Email"] = email;
                    dr31["Segment"] = segment;
                    dr31["Year"] = year;
                    dr31["Month"] = month;
                    dr31["Date"] = "31st";
                    dr31["Effort"] = lstResourceEffort[0].EThirtyOne.ToString();
                    dr31["Effort-Comments"] = lstResourceEffortComment[0].EcommentThirtyOne.Trim();
                    dtEffort.Rows.Add(dr31);

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
            return dtEffort;
        }


        /// <summary>
        /// 
        /// </summary>
        protected void ExportToExcel()
        {
            string yearName = (string)ViewState["Year"];
            string monthName = (string)ViewState["Month"];
            string[] resourceName = ((string)ViewState["Name"]).Split(' ');
            string fileName = resourceName[0].ToString() + "_" + yearName + "_" + monthName + "_" + "Effort" + ".xls";
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
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }


        /// <summary>
        /// To copy the Month effort to all the days of the month
        /// </summary>
        private void CopyMonthEffort(string effortValue)
        {
            //To retrive the Year and Month details dynamically based on the Id
            int month = Convert.ToInt32(Request.QueryString.Get("Mid"));
            int year = Convert.ToInt32((string)ViewState["Year"]);


            try
            {
                #region First
                int first = Convert.ToInt32(hdnFirst.Value.ToString());
                string firstDay = GetWeekDayName(year, month, first);
                if (firstDay.Trim().Equals("Saturday") || firstDay.Trim().Equals("Sunday"))
                {
                    txtFirst.Text = "0";
                }
                else { txtFirst.Text = "9"; }
                #endregion
                #region second
                int second = Convert.ToInt32(hdnSecond.Value.ToString());
                string secondDay = GetWeekDayName(year, month, second);
                if (secondDay.Trim().Equals("Saturday") || secondDay.Trim().Equals("Sunday"))
                {
                    txtSecond.Text = "0";
                }
                else { txtSecond.Text = "9"; }
                #endregion
                #region Third
                int third = Convert.ToInt32(hdnThird.Value.ToString());
                string thirdDay = GetWeekDayName(year, month, third);
                if (thirdDay.Trim().Equals("Saturday") || thirdDay.Trim().Equals("Sunday"))
                {
                    txtThird.Text = "0";
                }
                else { txtThird.Text = "9"; }
                #endregion

                #region Fourth
                int Fourth = Convert.ToInt32(hdnFourth.Value.ToString());
                string FourthDay = GetWeekDayName(year, month, Fourth);
                if (FourthDay.Trim().Equals("Saturday") || FourthDay.Trim().Equals("Sunday"))
                {
                    txtFourth.Text = "0";
                }
                else { txtFourth.Text = "9"; }
                #endregion

                #region Fifth
                int Fifth = Convert.ToInt32(hdnFifth.Value.ToString());
                string FifthDay = GetWeekDayName(year, month, Fifth);
                if (FifthDay.Trim().Equals("Saturday") || FifthDay.Trim().Equals("Sunday"))
                {
                    txtFifth.Text = "0";
                }
                else { txtFifth.Text = "9"; }
                #endregion

                #region sixth
                int sixth = Convert.ToInt32(hdnsixth.Value.ToString());
                string sixthDay = GetWeekDayName(year, month, sixth);
                if (sixthDay.Trim().Equals("Saturday") || sixthDay.Trim().Equals("Sunday"))
                {
                    txtsixth.Text = "0";
                }
                else { txtsixth.Text = "9"; }
                #endregion

                #region seventh
                int seventh = Convert.ToInt32(hdnseventh.Value.ToString());
                string seventhDay = GetWeekDayName(year, month, seventh);
                if (seventhDay.Trim().Equals("Saturday") || seventhDay.Trim().Equals("Sunday"))
                {
                    txtseventh.Text = "0";
                }
                else { txtseventh.Text = "9"; }
                #endregion

                #region eighth
                int eighth = Convert.ToInt32(hdneighth.Value.ToString());
                string eighthDay = GetWeekDayName(year, month, eighth);
                if (eighthDay.Trim().Equals("Saturday") || eighthDay.Trim().Equals("Sunday"))
                {
                    txteighth.Text = "0";
                }
                else { txteighth.Text = "9"; }
                #endregion

                #region nineth
                int nineth = Convert.ToInt32(hdnnineth.Value.ToString());
                string ninethDay = GetWeekDayName(year, month, nineth);
                if (ninethDay.Trim().Equals("Saturday") || ninethDay.Trim().Equals("Sunday"))
                {
                    txtnineth.Text = "0";
                }
                else { txtnineth.Text = "9"; }
                #endregion

                #region tenth
                int tenth = Convert.ToInt32(hdntenth.Value.ToString());
                string tenthDay = GetWeekDayName(year, month, tenth);
                if (tenthDay.Trim().Equals("Saturday") || tenthDay.Trim().Equals("Sunday"))
                {
                    txttenth.Text = "0";
                }
                else { txttenth.Text = "9"; }
                #endregion

                #region eleventh
                int eleventh = Convert.ToInt32(hdneleventh.Value.ToString());
                string eleventhDay = GetWeekDayName(year, month, eleventh);
                if (eleventhDay.Trim().Equals("Saturday") || eleventhDay.Trim().Equals("Sunday"))
                {
                    txteleventh.Text = "0";
                }
                else { txteleventh.Text = "9"; }
                #endregion
                #region twelveth

                int twelveth = Convert.ToInt32(hdntwelveth.Value.ToString());
                string twelvethDay = GetWeekDayName(year, month, twelveth);
                if (twelvethDay.Trim().Equals("Saturday") || twelvethDay.Trim().Equals("Sunday"))
                {
                    txttwelveth.Text = "0";
                }
                else { txttwelveth.Text = "9"; }
                #endregion
                #region tirteenth
                int tirteenth = Convert.ToInt32(hdntirteenth.Value.ToString());
                string tirteenthDay = GetWeekDayName(year, month, tirteenth);
                if (tirteenthDay.Trim().Equals("Saturday") || tirteenthDay.Trim().Equals("Sunday"))
                {
                    txttirteen.Text = "0";
                }
                else { txttirteen.Text = "9"; }
                #endregion
                #region fourteenth
                int fourteenth = Convert.ToInt32(hdnfourteenth.Value.ToString());
                string fourteenthDay = GetWeekDayName(year, month, fourteenth);
                if (fourteenthDay.Trim().Equals("Saturday") || fourteenthDay.Trim().Equals("Sunday"))
                {
                    txtfourteenth.Text = "0";
                }
                else { txtfourteenth.Text = "9"; }

                #endregion
                #region fifteenth
                int fifteenth = Convert.ToInt32(hdnfifteenth.Value.ToString());
                string fifteenthDay = GetWeekDayName(year, month, fifteenth);
                if (fifteenthDay.Trim().Equals("Saturday") || fifteenthDay.Trim().Equals("Sunday"))
                {
                    txtfifteenth.Text = "0";
                }
                else { txtfifteenth.Text = "9"; }

                #endregion
                #region sixteenth
                int sixteenth = Convert.ToInt32(hdnsixteenth.Value.ToString());
                string sixteenthDay = GetWeekDayName(year, month, sixteenth);
                if (sixteenthDay.Trim().Equals("Saturday") || sixteenthDay.Trim().Equals("Sunday"))
                {
                    txtsixteenth.Text = "0";
                }
                else { txtsixteenth.Text = "9"; }
                #endregion
                #region seventeenth
                int seventeenth = Convert.ToInt32(hdnseventeenth.Value.ToString());
                string seventeenthDay = GetWeekDayName(year, month, seventeenth);
                if (seventeenthDay.Trim().Equals("Saturday") || seventeenthDay.Trim().Equals("Sunday"))
                {
                    txtseventeenth.Text = "0";
                }
                else { txtseventeenth.Text = "9"; }

                #endregion
                #region eighteenth
                int eighteenth = Convert.ToInt32(hdneighteenth.Value.ToString());
                string eighteenthDay = GetWeekDayName(year, month, eighteenth);
                if (eighteenthDay.Trim().Equals("Saturday") || eighteenthDay.Trim().Equals("Sunday"))
                {
                    txteighteenth.Text = "0";
                }
                else { txteighteenth.Text = "9"; }
                #endregion
                #region ninteenth
                int ninteenth = Convert.ToInt32(hdnninteenth.Value.ToString());
                string ninteenthDay = GetWeekDayName(year, month, ninteenth);
                if (ninteenthDay.Trim().Equals("Saturday") || ninteenthDay.Trim().Equals("Sunday"))
                {
                    txtninteenth.Text = "0";
                }
                else { txtninteenth.Text = "9"; }

                #endregion
                #region twenty

                int twenty = Convert.ToInt32(hdntwenty.Value.ToString());
                string twentyDay = GetWeekDayName(year, month, twenty);
                if (twentyDay.Trim().Equals("Saturday") || twentyDay.Trim().Equals("Sunday"))
                {
                    txttwenty.Text = "0";
                }
                else { txttwenty.Text = "9"; }


                #endregion
                #region twenty1st
                int twenty1st = Convert.ToInt32(hdntwenty1st.Value.ToString());
                string twenty1stDay = GetWeekDayName(year, month, twenty1st);
                if (twenty1stDay.Trim().Equals("Saturday") || twenty1stDay.Trim().Equals("Sunday"))
                {
                    txttwenty1st.Text = "0";
                }
                else { txttwenty1st.Text = "9"; }
                #endregion
                #region twenty2nd
                int twenty2nd = Convert.ToInt32(hdntwenty2nd.Value.ToString());
                string twenty2ndDay = GetWeekDayName(year, month, twenty2nd);
                if (twenty2ndDay.Trim().Equals("Saturday") || twenty2ndDay.Trim().Equals("Sunday"))
                {
                    spntwenty2nd.Style.Add("color", "Red");
                }
                spntwenty2nd.InnerHtml = twenty2ndDay + " " + "22nd";
                #endregion
                #region twenty3rd
                int twenty3rd = Convert.ToInt32(hdntwenty3rd.Value.ToString());
                string twenty3rdDay = GetWeekDayName(year, month, twenty3rd);
                if (twenty3rdDay.Trim().Equals("Saturday") || twenty3rdDay.Trim().Equals("Sunday"))
                {
                    spntwenty3rd.Style.Add("color", "Red");
                }
                spntwenty3rd.InnerHtml = twenty3rdDay + " " + "23rd";

                #endregion
                #region twentyfourth
                int twentyfourth = Convert.ToInt32(hdntwentyfourth.Value.ToString());
                string twentyfourthDay = GetWeekDayName(year, month, twentyfourth);
                if (twentyfourthDay.Trim().Equals("Saturday") || twentyfourthDay.Trim().Equals("Sunday"))
                {
                    spntwentyfourth.Style.Add("color", "Red");
                }
                spntwentyfourth.InnerHtml = twentyfourthDay + " " + "24th";
                #endregion
                #region twentyfifth

                int twentyfifth = Convert.ToInt32(hdntwentyfifth.Value.ToString());
                string twentyfifthDay = GetWeekDayName(year, month, twentyfifth);
                if (twentyfifthDay.Trim().Equals("Saturday") || twentyfifthDay.Trim().Equals("Sunday"))
                {
                    spntwentyfifth.Style.Add("color", "Red");
                }
                spntwentyfifth.InnerHtml = twentyfifthDay + " " + "25th";
                #endregion
                #region twentysixth
                int twentysixth = Convert.ToInt32(hdntwentysixth.Value.ToString());
                string twentysixthDay = GetWeekDayName(year, month, twentysixth);
                if (twentysixthDay.Trim().Equals("Saturday") || twentysixthDay.Trim().Equals("Sunday"))
                {
                    spntwentysixth.Style.Add("color", "Red");
                }
                spntwentysixth.InnerHtml = twentysixthDay + " " + "26th";
                #endregion
                #region twentyseventh
                int twentyseventh = Convert.ToInt32(hdntwentyseventh.Value.ToString());
                string twentyseventhDay = GetWeekDayName(year, month, twentyseventh);
                if (twentyseventhDay.Trim().Equals("Saturday") || twentyseventhDay.Trim().Equals("Sunday"))
                {
                    spntwentyseventh.Style.Add("color", "Red");
                }
                spntwentyseventh.InnerHtml = twentyseventhDay + " " + "27th";

                #endregion
                #region twentyeighth
                int twentyeighth = Convert.ToInt32(hdntwentyeighth.Value.ToString());
                string twentyeighthDay = GetWeekDayName(year, month, twentyeighth);
                if (twentyeighthDay.Trim().Equals("Saturday") || twentyeighthDay.Trim().Equals("Sunday"))
                {
                    spntwentyeighth.Style.Add("color", "Red");
                }
                spntwentyeighth.InnerHtml = twentyeighthDay + " " + "28th";
                #endregion
                #region twentynineth
                int twentynineth = Convert.ToInt32(hdntwentynineth.Value.ToString());
                int daysInMonth = DateTime.DaysInMonth(year, month);
                if (twentynineth <= daysInMonth)
                {
                    string twentyninethDay = GetWeekDayName(year, month, twentynineth);
                    if (twentyninethDay.Trim().Equals("Saturday") || twentyninethDay.Trim().Equals("Sunday"))
                    {
                        spntwentynineth.Style.Add("color", "Red");
                    }
                    spntwentynineth.InnerHtml = twentyninethDay + " " + "29th";
                }
                else
                {
                    spntwentynineth.Visible = false;
                    txttwentynineth.Visible = false;
                    txttwentyninethComment.Visible = false;
                }
                #endregion
                #region thirty
                int thirty = Convert.ToInt32(hdnthirty.Value.ToString());
                if (thirty <= daysInMonth)
                {
                    string thirtyDay = GetWeekDayName(year, month, thirty);
                    if (thirtyDay.Trim().Equals("Saturday") || thirtyDay.Trim().Equals("Sunday"))
                    {
                        spnthirty.Style.Add("color", "Red");
                    }
                    spnthirty.InnerHtml = twentyeighthDay + " " + "30th";
                }
                else
                {
                    spnthirty.Visible = false;
                    txtthirty.Visible = false;
                    txtthirtyComment.Visible = false;
                }
                #endregion
                #region thirtyone
                int thirtyone = Convert.ToInt32(hdnthirtyone.Value.ToString());
                if (thirtyone <= daysInMonth)
                {
                    string thirtyoneDay = GetWeekDayName(year, month, thirtyone);
                    if (thirtyoneDay.Trim().Equals("Saturday") || thirtyoneDay.Trim().Equals("Sunday"))
                    {
                        spnthirtyone.Style.Add("color", "Red");
                    }
                    spnthirtyone.InnerHtml = thirtyoneDay + " " + "31st";
                }
                else
                {
                    spnthirtyone.Visible = false;
                    txtthirtyoneComment.Visible = false;
                    txthirtyone.Visible = false;
                }
                #endregion
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

        }
        #endregion


    }

}
