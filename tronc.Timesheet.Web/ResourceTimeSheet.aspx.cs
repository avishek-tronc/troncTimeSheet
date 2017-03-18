using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using tronc.Timesheet.BL.Repository;
using tronc.Timesheet.Common.Entities;

namespace tronc.Timesheet.Web
{
    public partial class ResourceTimeSheet : System.Web.UI.Page
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int resourceId = 1;//To be taken from query string parameter
                int monthId = 10;//To be taken from query string parameter
                int yId = 1;//To be taken from query string parameter
                int segmentId = 1;//To be taken from query string parameter
                List<ResourceEffort> lstResourceEffort = GetResourceEffort(resourceId, yId, monthId);
                if (lstResourceEffort != null && lstResourceEffort.Count > 0)
                {

                }

                List<ResourceEffort> lstallresourceeffort = GetAllResourceEffort(yId, monthId, segmentId);
                if (lstallresourceeffort != null && lstallresourceeffort.Count > 0)
                {

                }
                List<ResourceEffortComment> lstResourceEffortComment = GetResourceEffortComment(resourceId, yId, monthId);
                if (lstResourceEffortComment != null && lstResourceEffortComment.Count > 0)
                {

                }

                List<ResourceEffortComment> lstAllResourceEffortComment = GetAllResourceEffortComment(yId, monthId, segmentId);
                if (lstAllResourceEffortComment != null && lstAllResourceEffortComment.Count > 0)
                {


                }

              

                //To retrive the resource details dynamically based on the resource id
                lblName.Text = "ABC";
                lblEmail.Text = "abc@xyz.com";
                lblContact.Text = "XXXXXXXXXX";
                lblSegment.Text = "Floor";
                //To retrive the Year and Month details dynamically based on the Id
                string month = System.DateTime.Now.ToString("MMMM");
                string year = System.DateTime.Now.Year.ToString();
                lblDuration.Text = month + " " + " - " + year;
                ShowDayLabels();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Private Methods
        private void ShowDayLabels()
        {
            //To retrive the Year and Month details dynamically based on the Id
            int month = Convert.ToInt32(System.DateTime.Now.Month.ToString());
            int year = Convert.ToInt32(System.DateTime.Now.Year.ToString());

            
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
                if (FourthDay.Trim().Equals("Saturday") || sixthDay.Trim().Equals("Sunday"))
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
                spneleventh.InnerHtml =eleventhDay + " " + "11th";
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
                spntwenty1st.InnerHtml = twenty1stDay + " " + "21th";
                #endregion
                #region twenty2nd
                int twenty2nd = Convert.ToInt32(hdntwenty2nd.Value.ToString());
                string twenty2ndDay = GetWeekDayName(year, month, twenty2nd);
                if (twenty2ndDay.Trim().Equals("Saturday") || twenty2ndDay.Trim().Equals("Sunday"))
                {
                    spntwenty2nd.Style.Add("color", "Red");
                }
                  spntwenty2nd.InnerHtml = twenty2ndDay + " " + "22th";
                #endregion
                #region twenty3rd
                int twenty3rd = Convert.ToInt32(hdntwenty3rd.Value.ToString());
                string twenty3rdDay = GetWeekDayName(year, month, twenty3rd);
                if (twenty3rdDay.Trim().Equals("Saturday") || twenty3rdDay.Trim().Equals("Sunday"))
                {
                    spntwenty3rd.Style.Add("color", "Red");
                }
                spntwenty3rd.InnerHtml = twenty3rdDay + " " + "23th";

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
                //#region twentynineth
                //int twentynineth = Convert.ToInt32(hdntwentynineth.Value.ToString());
                //string twentyninethDay = GetWeekDayName(year, month, twentynineth);
                //if (twentyninethDay.Trim().Equals("Saturday") || twentyninethDay.Trim().Equals("Sunday"))
                //{
                //    spntwentynineth.Style.Add("color", "Red");
                //}
                //spntwentynineth.InnerHtml = twentyninethDay + " " + "29th";
                //#endregion
                //#region thirty
                //int thirty = Convert.ToInt32(hdnthirty.Value.ToString());
                //string thirtyDay = GetWeekDayName(year, month, thirty);
                //if (thirtyDay.Trim().Equals("Saturday") || thirtyDay.Trim().Equals("Sunday"))
                //{
                //    spnthirty.Style.Add("color", "Red");
                //}
                //spntwentyeighth.InnerHtml = twentyeighthDay + " " + "30th";
                //#endregion
                //#region thirtyone
                //int thirtyone = Convert.ToInt32(hdnthirtyone.Value.ToString());
                //string thirtyoneDay = GetWeekDayName(year, month, thirtyone);
                //if (thirtyoneDay.Trim().Equals("Saturday") || thirtyoneDay.Trim().Equals("Sunday"))
                //{
                //    spnthirtyone.Style.Add("color", "Red");
                //}
                //spnthirtyone.InnerHtml = thirtyoneDay + " " + "31th";
                //#endregion
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion


        /// <summary>
        /// To get the Day of the Week based on the Year, Month and Date
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
        public List<ResourceEffort> GetResourceEffort(int resourceId, int yearId, int monthId)
        {
            List<ResourceEffort> lstResourceEffort = new List<ResourceEffort>();
            TimesheetRepository timeSheetRepository = new TimesheetRepository();
            try
            {
                lstResourceEffort = timeSheetRepository.GetResourceEffort(resourceId, yearId, monthId);

            }
            catch (Exception ex)
            {
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
        public List<ResourceEffort> GetAllResourceEffort(int yearId, int monthId, int segmentId)
        {
            List<ResourceEffort> lstallresourceeffort = new List<ResourceEffort>();
            TimesheetRepository timeSheetRepository = new TimesheetRepository();
            try
            {
                lstallresourceeffort = timeSheetRepository.GetAllResourceEffort(yearId, monthId, segmentId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lstallresourceeffort;
        }


        /// <summary>
        /// To  get resource effort Comment
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="yearId"></param>
        /// <param name="monthId"></param>
        /// <returns></returns>
        public List<ResourceEffortComment> GetResourceEffortComment(int resourceId, int yearId, int monthId)
        {
            List<ResourceEffortComment> lstResourceEffortComment = new List<ResourceEffortComment>();
            TimesheetRepository timeSheetRepository = new TimesheetRepository();
            try
            {
                lstResourceEffortComment = timeSheetRepository.GetResourceEffortComment(resourceId, yearId, monthId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lstResourceEffortComment;
        }
        /// <summary>
        /// To  get all resource effort Comment
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="yearId"></param>
        /// <param name="monthId"></param>
        /// <returns></returns>

        public List<ResourceEffortComment> GetAllResourceEffortComment(int yearId, int monthId, int segmentId)
        {
            List<ResourceEffortComment> lstAllResourceEffortComment = new List<ResourceEffortComment>();
            TimesheetRepository timeSheetRepository = new TimesheetRepository();
            try
            {
                lstAllResourceEffortComment = timeSheetRepository.GetAllResourceEffortComment(yearId, monthId, segmentId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lstAllResourceEffortComment;
        }

       
       /// <summary>
       /// update resource effort
       /// </summary>
       /// <param name="resourceEffort"></param>
       /// <returns></returns>
        public int UpdateResourceEffort(ResourceEffort resourceEffort)
        {

            int status = 0;
            TimesheetRepository timeSheetRepository = new TimesheetRepository();
            try
            {
                resourceEffort.ResourceId = Convert.ToInt32(Request.QueryString.Get("Rid"));
                resourceEffort.YeadId = Convert.ToInt32(Request.QueryString.Get("Yid"));
                resourceEffort.MonthId = Convert.ToInt32(Request.QueryString.Get("Mid"));
                resourceEffort.EOne = txtFirst.Text;
                resourceEffort.ETwo = txtSecond.Text;
                resourceEffort.EThree = txtThird.Text;
                resourceEffort.EFour = txtFourth.Text;
                resourceEffort.EFive = txtFifth.Text;
                resourceEffort.ESix = txtsixteenth.Text;
                resourceEffort.ESeven = txtseventh.Text;
                resourceEffort.EEight = txteighth.Text;
                resourceEffort.ENine = txtnineth.Text;
                resourceEffort.ETen = txttenth.Text;
                resourceEffort.EEleven = txteleventh.Text;
                resourceEffort.ETwelve = txttwelveth.Text;
                resourceEffort.EThirteen = txttirteen.Text;
                resourceEffort.EFourteen = txtfourteenth.Text;
                resourceEffort.EFifteen = txtfifteenth.Text;
                resourceEffort.ESixteen = txtsixteenth.Text;
                resourceEffort.ESeventeen = txtseventeenth.Text;
                resourceEffort.EEighteen = txteighteenth.Text;
                resourceEffort.ENineteen = txtninteenth.Text;
                resourceEffort.ETwenty = txttwenty.Text;
                resourceEffort.ETwentyOne = txttwenty1st.Text;
                resourceEffort.ETwentyTwo = txttwenty2nd.Text;
                resourceEffort.ETwentyThree = txttwenty3rd.Text;
                resourceEffort.ETwentyFour = txttwentyfourth.Text;
                resourceEffort.ETwentyFive = txttwentyfifth.Text;
                resourceEffort.ETwentySix = txttwentysixth.Text;
                resourceEffort.ETwentySeven = txttwentyseventh.Text;
                resourceEffort.ETwentyEight = txttwentyeighth.Text;
                resourceEffort.ETwentyNine = txttwentynineth.Text;
                resourceEffort.EThirty = txtthirty.Text;
                resourceEffort.EThirtyOne = txthirtyone.Text;
               //status = timeSheetRepository.UpdateResourceEffort(resourceEffort);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return status;
        }
/// <summary>
/// update resource effort comment
/// </summary>
/// <param name="resourceEffort"></param>
/// <returns></returns>
        public int UpdateResourceEffortComment(ResourceEffortComment resourceEffortComment)
        {

            int status = 0;
            TimesheetRepository timeSheetRepository = new TimesheetRepository();
            try
            {
                resourceEffortComment.ResourceId = Convert.ToInt32(Request.QueryString.Get("Rid"));
                resourceEffortComment.YeadId = Convert.ToInt32(Request.QueryString.Get("Yid"));
                resourceEffortComment.MonthId = Convert.ToInt32(Request.QueryString.Get("Mid"));
                resourceEffortComment.EcommentOne = txtFirstComment.Text;
                resourceEffortComment.EcommentTwo = txtSecondComment.Text;
                resourceEffortComment.EcommentThree = txtThirdComment.Text;
                resourceEffortComment.EcommentFour = txtFourthComment.Text;
                resourceEffortComment.EcommentFive = txtFifthComment.Text;
                resourceEffortComment.EcommentSix = txtsixteenthComment.Text;
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
               //status = timeSheetRepository.UpdateResourceEffortComment(resourceEffortComment);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return status;
        }
       
    }
}