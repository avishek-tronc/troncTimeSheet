using Log4NetLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tronc.Timesheet.Common.Entities;


namespace tronc.Timesheet.DAL.Adapter
{
    public class TimesheetAdapter
    {
        private static string connectionString = string.Empty;

        public TimesheetAdapter()
        {
            connectionString = ConfigurationManager.ConnectionStrings["timesheetDBConnectionString"].ConnectionString.ToString(); ;
        }

        /* To get list of Year*/
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Year> GetYear()
        {

            List<Year> lstYear = new List<Year>();
            Year year = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.[getyear]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        cmd.Connection = conn;

                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (rdr.Read())
                            {
                                year = new Year();
                                year.YearId = Convert.ToInt32(rdr["YId"].ToString());
                                year.YearNumber = rdr["YName"].ToString();
                                lstYear.Add(year);
                            }
                            rdr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
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


        /* To get list of Month*/
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Month> GetMonth()
        {

            List<Month> lstmonth = new List<Month>();
            Month month = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.[getMonth]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        cmd.Connection = conn;

                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (rdr.Read())
                            {
                                month = new Month();
                                month.MonthId = Convert.ToInt32(rdr["MonthId"].ToString());
                                month.MonthName = rdr["MonthName"].ToString();
                                lstmonth.Add(month);
                            }
                            rdr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
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
            return lstmonth;
        }

        /* To get list of Segment*/
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Segment> GetSegment()
        {

            List<Segment> listsegment = new List<Segment>();
            Segment segment = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.[getSegment]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        cmd.Connection = conn;

                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (rdr.Read())
                            {
                                segment = new Segment();
                                segment.SegmentId = Convert.ToInt32(rdr["SegmentId"].ToString());
                                segment.SegmentName = rdr["SegmentName"].ToString();
                                listsegment.Add(segment);
                            }
                            rdr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
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
            return listsegment;
        }


        /// <summary>
        /// To get the list of available resources (Floor and Pool)
        /// </summary>
        /// <returns></returns>
        public List<Resource> GetResources()
        {

            List<Resource> lstResource = new List<Resource>();
            Resource resource = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.[getResource]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        cmd.Connection = conn;

                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (rdr.Read())
                            {
                                resource = new Resource();
                                resource.ResourceName = rdr["Name"].ToString();
                                resource.ResourceEmail = rdr["Email"].ToString();
                                resource.ResourceContact = rdr["Contact"].ToString();
                                resource.ResourceSegment = rdr["SegmentName"].ToString();
                                resource.ResourceStartDate = Convert.ToDateTime(rdr["StartDate"].ToString());
                                resource.ResourceEndDate = Convert.ToDateTime(rdr["EndDate"].ToString());
                                resource.ResourceId = Convert.ToInt32(rdr["Id"].ToString());
                                resource.ResourceRate = Convert.ToDouble(rdr["Rate"].ToString());
                                lstResource.Add(resource);
                            }
                            rdr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
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
        /// To get resources effort for a resource
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="yearId"></param>
        /// <param name="monthId"></param>
        /// <returns></returns>
        public List<ResourceEffort> GetResourceEffort(int resourceId, int yearId, int monthId)
        {
            List<ResourceEffort> lstResourceEffort = new List<ResourceEffort>();
            ResourceEffort resourceeffort = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.[getResourceEffort]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.Parameters.Add(new SqlParameter("@ResourceId", resourceId));
                        cmd.Parameters.Add(new SqlParameter("@Yid", yearId));
                        cmd.Parameters.Add(new SqlParameter("@MonthId", monthId));

                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (rdr.Read())
                            {
                                resourceeffort = new ResourceEffort();
                                resourceeffort.ResourceId = Convert.ToInt32(rdr["ResourceId"].ToString());
                                resourceeffort.ResourceName = rdr["Name"].ToString();
                                resourceeffort.ResourceContact = rdr["Contact"].ToString();
                                resourceeffort.ResourceEmail = rdr["Email"].ToString();
                                resourceeffort.YeadId = Convert.ToInt32(rdr["Yid"].ToString());
                                resourceeffort.YearName = rdr["YName"].ToString();
                                resourceeffort.MonthId = Convert.ToInt32(rdr["MonthId"].ToString());
                                resourceeffort.MonthName = rdr["MonthName"].ToString();
                                resourceeffort.SegmentId = Convert.ToInt32(rdr["SegmentId"].ToString());
                                resourceeffort.SegmentName = rdr["SegmentName"].ToString();
                                resourceeffort.EOne = rdr["One"].ToString();
                                resourceeffort.ETwo = rdr["Two"].ToString();
                                resourceeffort.EThree = rdr["Three"].ToString();
                                resourceeffort.EFour = rdr["Four"].ToString();
                                resourceeffort.EFive = rdr["Five"].ToString();
                                resourceeffort.ESix = rdr["Six"].ToString();
                                resourceeffort.ESeven = rdr["Seven"].ToString();
                                resourceeffort.EEight = rdr["Eight"].ToString();
                                resourceeffort.ENine = rdr["Nine"].ToString();
                                resourceeffort.ETen = rdr["Ten"].ToString();
                                resourceeffort.EEleven = rdr["Eleven"].ToString();
                                resourceeffort.ETwelve = rdr["Twelve"].ToString();
                                resourceeffort.EThirteen = rdr["Thirteen"].ToString();
                                resourceeffort.EFourteen = rdr["Fourteen"].ToString();
                                resourceeffort.EFifteen = rdr["Fiveteen"].ToString();
                                resourceeffort.ESixteen = rdr["Sixteen"].ToString();
                                resourceeffort.ESeventeen = rdr["Seventeen"].ToString();
                                resourceeffort.EEighteen = rdr["Eighteen"].ToString();
                                resourceeffort.ENineteen = rdr["Nineteen"].ToString();
                                resourceeffort.ETwenty = rdr["Twenty"].ToString();
                                resourceeffort.ETwentyOne = rdr["TwentyOne"].ToString();
                                resourceeffort.ETwentyTwo = rdr["TwentyTwo"].ToString();
                                resourceeffort.ETwentyThree = rdr["TwentyThree"].ToString();
                                resourceeffort.ETwentyFour = rdr["TwentyFour"].ToString();
                                resourceeffort.ETwentyFive = rdr["TwentyFive"].ToString();
                                resourceeffort.ETwentySix = rdr["TwentySix"].ToString();
                                resourceeffort.ETwentySeven = rdr["TwentySeven"].ToString();
                                resourceeffort.ETwentyEight = rdr["TwentyEight"].ToString();
                                resourceeffort.ETwentyNine = rdr["TwentyNine"].ToString();
                                resourceeffort.EThirty = rdr["Thirty"].ToString();
                                resourceeffort.EThirtyOne = rdr["ThirtyOne"].ToString();
                                resourceeffort.ResourceRate = Convert.ToDouble(rdr["Rate"].ToString());
                                lstResourceEffort.Add(resourceeffort);
                            }
                            rdr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
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
        /// To get the list of available resources Effort for yearid,monthid,segmentid
        /// </summary>
        /// <param name="yearId"></param>
        /// <param name="monthId"></param>
        /// <param name="segmentId"></param>
        /// <returns></returns>
        public List<ResourceEffort> GetAllResourceEffort(int yearId, int monthId, int segmentId)
        {

            List<ResourceEffort> lstallresourceeffort = new List<ResourceEffort>();
            ResourceEffort resourceeffort = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.[getAllResourceEffort]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Yid", yearId));
                        cmd.Parameters.Add(new SqlParameter("@MonthId", monthId));
                        cmd.Parameters.Add(new SqlParameter("@SegmentId", segmentId));
                        conn.Open();
                        cmd.Connection = conn;

                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (rdr.Read())
                            {
                                resourceeffort = new ResourceEffort();
                                resourceeffort.ResourceId = Convert.ToInt32(rdr["ResourceId"].ToString());
                                resourceeffort.ResourceName = rdr["Name"].ToString();
                                resourceeffort.ResourceContact = rdr["Contact"].ToString();
                                resourceeffort.ResourceEmail = rdr["Email"].ToString();
                                resourceeffort.YeadId = Convert.ToInt32(rdr["Yid"].ToString());
                                resourceeffort.YearName = rdr["YName"].ToString();
                                resourceeffort.MonthId = Convert.ToInt32(rdr["MonthId"].ToString());
                                resourceeffort.MonthName = rdr["MonthName"].ToString();
                                resourceeffort.SegmentId = Convert.ToInt32(rdr["SegmentId"].ToString());
                                resourceeffort.SegmentName = rdr["SegmentName"].ToString();
                                resourceeffort.ResourceId = Convert.ToInt32(rdr["ResourceId"].ToString());
                                resourceeffort.EOne = rdr["One"].ToString();
                                resourceeffort.ETwo = rdr["Two"].ToString();
                                resourceeffort.EThree = rdr["Three"].ToString();
                                resourceeffort.EFour = rdr["Four"].ToString();
                                resourceeffort.EFive = rdr["Five"].ToString();
                                resourceeffort.ESix = rdr["Six"].ToString();
                                resourceeffort.ESeven = rdr["Seven"].ToString();
                                resourceeffort.EEight = rdr["Eight"].ToString();
                                resourceeffort.ENine = rdr["Nine"].ToString();
                                resourceeffort.ETen = rdr["Ten"].ToString();
                                resourceeffort.EEleven = rdr["Eleven"].ToString();
                                resourceeffort.ETwelve = rdr["Twelve"].ToString();
                                resourceeffort.EThirteen = rdr["Thirteen"].ToString();
                                resourceeffort.EFourteen = rdr["Fourteen"].ToString();
                                resourceeffort.EFifteen = rdr["Fiveteen"].ToString();
                                resourceeffort.ESixteen = rdr["Sixteen"].ToString();
                                resourceeffort.ESeventeen = rdr["Seventeen"].ToString();
                                resourceeffort.EEighteen = rdr["Eighteen"].ToString();
                                resourceeffort.ENineteen = rdr["Nineteen"].ToString();
                                resourceeffort.ETwenty = rdr["Twenty"].ToString();
                                resourceeffort.ETwentyOne = rdr["TwentyOne"].ToString();
                                resourceeffort.ETwentyTwo = rdr["TwentyTwo"].ToString();
                                resourceeffort.ETwentyThree = rdr["TwentyThree"].ToString();
                                resourceeffort.ETwentyFour = rdr["TwentyFour"].ToString();
                                resourceeffort.ETwentyFive = rdr["TwentyFive"].ToString();
                                resourceeffort.ETwentySix = rdr["TwentySix"].ToString();
                                resourceeffort.ETwentySeven = rdr["TwentySeven"].ToString();
                                resourceeffort.ETwentyEight = rdr["TwentyEight"].ToString();
                                resourceeffort.ETwentyNine = rdr["TwentyNine"].ToString();
                                resourceeffort.EThirty = rdr["Thirty"].ToString();
                                resourceeffort.EThirtyOne = rdr["ThirtyOne"].ToString();
                                resourceeffort.ResourceRate = Convert.ToDouble(rdr["Rate"].ToString());

                                lstallresourceeffort.Add(resourceeffort);
                            }
                            rdr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
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
        /// To get the list of available resources Effort Comment for resourceId,yearid,monthid
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="yearId"></param>
        /// <param name="monthId"></param>
        /// <returns></returns>
        public List<ResourceEffortComment> GetResourceEffortComment(int resourceId, int yearId, int monthId)
        {

            List<ResourceEffortComment> lstResourceEffortComment = new List<ResourceEffortComment>();
            ResourceEffortComment resourceeffortComment = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.[getResourceEffortcomment]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.Parameters.Add(new SqlParameter("@Id", resourceId));
                        cmd.Parameters.Add(new SqlParameter("@Yid", yearId));
                        cmd.Parameters.Add(new SqlParameter("@MonthId", monthId));

                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (rdr.Read())
                            {
                                resourceeffortComment = new ResourceEffortComment();
                                resourceeffortComment.ResourceId = Convert.ToInt32(rdr["ResourceId"].ToString());
                                resourceeffortComment.ResourceName = rdr["Name"].ToString();
                                resourceeffortComment.ResourceEmail = rdr["Email"].ToString();
                                resourceeffortComment.YeadId = Convert.ToInt32(rdr["Yid"].ToString());
                                resourceeffortComment.YearName = rdr["YName"].ToString();
                                resourceeffortComment.MonthId = Convert.ToInt32(rdr["MonthId"].ToString());
                                resourceeffortComment.MonthName = rdr["MonthName"].ToString();
                                resourceeffortComment.SegmentId = Convert.ToInt32(rdr["SegmentId"].ToString());
                                resourceeffortComment.SegmentName = rdr["SegmentName"].ToString();
                                resourceeffortComment.EcommentOne = rdr["OneComment"].ToString();
                                resourceeffortComment.EcommentTwo = rdr["TwoComment"].ToString();
                                resourceeffortComment.EcommentThree = rdr["ThreeComment"].ToString();
                                resourceeffortComment.EcommentFour = rdr["FourComment"].ToString();
                                resourceeffortComment.EcommentFive = rdr["FiveComment"].ToString();
                                resourceeffortComment.EcommentSix = rdr["SixComment"].ToString();
                                resourceeffortComment.EcommentSeven = rdr["SevenComment"].ToString();
                                resourceeffortComment.EcommentEight = rdr["EightComment"].ToString();
                                resourceeffortComment.EcommentNine = rdr["NineComment"].ToString();
                                resourceeffortComment.EcommentTen = rdr["TenComment"].ToString();
                                resourceeffortComment.EcommentEleven = rdr["ElevenComment"].ToString();
                                resourceeffortComment.EcommentTwelve = rdr["TwelveComment"].ToString();
                                resourceeffortComment.EcommentThirteen = rdr["ThirteenComment"].ToString();
                                resourceeffortComment.EcommentFourteen = rdr["FourteenComment"].ToString();
                                resourceeffortComment.EcommentFifteen = rdr["FiveteenComment"].ToString();
                                resourceeffortComment.EcommentSixteen = rdr["SixteenComment"].ToString();
                                resourceeffortComment.EcommentSeventeen = rdr["SeventeenComment"].ToString();
                                resourceeffortComment.EcommentEighteen = rdr["EighteenComment"].ToString();
                                resourceeffortComment.EcommentNineteen = rdr["NineteenComment"].ToString();
                                resourceeffortComment.EcommentTwenty = rdr["TwentyComment"].ToString();
                                resourceeffortComment.EcommentTwentyOne = rdr["TwentyOneComment"].ToString();
                                resourceeffortComment.EcommentTwentyTwo = rdr["TwentyTwoComment"].ToString();
                                resourceeffortComment.EcommentTwentyThree = rdr["TwentyThreeComment"].ToString();
                                resourceeffortComment.EcommentTwentyFour = rdr["TwentyFourComment"].ToString();
                                resourceeffortComment.EcommentTwentyFive = rdr["TwentyFiveComment"].ToString();
                                resourceeffortComment.EcommentTwentySix = rdr["TwentySixComment"].ToString();
                                resourceeffortComment.EcommentTwentySeven = rdr["TwentySevenComment"].ToString();
                                resourceeffortComment.EcommentTwentyEight = rdr["TwentyEightComment"].ToString();
                                resourceeffortComment.EcommentTwentyNine = rdr["TwentyNineComment"].ToString();
                                resourceeffortComment.EcommentThirty = rdr["ThirtyComment"].ToString();
                                resourceeffortComment.EcommentThirtyOne = rdr["ThirtyOneComment"].ToString();
                                lstResourceEffortComment.Add(resourceeffortComment);
                            }
                            rdr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
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
        /// To get all resource effort comment
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="yearId"></param>
        /// <param name="monthId"></param>
        /// <returns></returns>
        public List<ResourceEffortComment> GetAllResourceEffortComment(int yearId, int monthId, int segmentId)
        {

            List<ResourceEffortComment> lstAllResourceEffortComment = new List<ResourceEffortComment>();
            ResourceEffortComment resourceeffortComment = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.[getAllResourceEffortcomment]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Yid", yearId));
                        cmd.Parameters.Add(new SqlParameter("@MonthId", monthId));
                        cmd.Parameters.Add(new SqlParameter("@SegmentId", segmentId));
                        conn.Open();
                        cmd.Connection = conn;


                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (rdr.Read())
                            {
                                resourceeffortComment = new ResourceEffortComment();
                                resourceeffortComment.ResourceId = Convert.ToInt32(rdr["ResourceId"].ToString());
                                resourceeffortComment.ResourceName = rdr["Name"].ToString();
                                resourceeffortComment.ResourceEmail = rdr["Email"].ToString();
                                resourceeffortComment.YeadId = Convert.ToInt32(rdr["Yid"].ToString());
                                resourceeffortComment.YearName = rdr["YName"].ToString();
                                resourceeffortComment.MonthId = Convert.ToInt32(rdr["MonthId"].ToString());
                                resourceeffortComment.MonthName = rdr["MonthName"].ToString();
                                resourceeffortComment.SegmentId = Convert.ToInt32(rdr["SegmentId"].ToString());
                                resourceeffortComment.SegmentName = rdr["SegmentName"].ToString();
                                resourceeffortComment.EcommentOne = rdr["OneComment"].ToString();
                                resourceeffortComment.EcommentTwo = rdr["TwoComment"].ToString();
                                resourceeffortComment.EcommentThree = rdr["ThreeComment"].ToString();
                                resourceeffortComment.EcommentFour = rdr["FourComment"].ToString();
                                resourceeffortComment.EcommentFive = rdr["FiveComment"].ToString();
                                resourceeffortComment.EcommentSix = rdr["SixComment"].ToString();
                                resourceeffortComment.EcommentSeven = rdr["SevenComment"].ToString();
                                resourceeffortComment.EcommentEight = rdr["EightComment"].ToString();
                                resourceeffortComment.EcommentNine = rdr["NineComment"].ToString();
                                resourceeffortComment.EcommentTen = rdr["TenComment"].ToString();
                                resourceeffortComment.EcommentEleven = rdr["ElevenComment"].ToString();
                                resourceeffortComment.EcommentTwelve = rdr["TwelveComment"].ToString();
                                resourceeffortComment.EcommentThirteen = rdr["ThirteenComment"].ToString();
                                resourceeffortComment.EcommentFourteen = rdr["FourteenComment"].ToString();
                                resourceeffortComment.EcommentFifteen = rdr["FiveteenComment"].ToString();
                                resourceeffortComment.EcommentSixteen = rdr["SixteenComment"].ToString();
                                resourceeffortComment.EcommentSeventeen = rdr["SeventeenComment"].ToString();
                                resourceeffortComment.EcommentEighteen = rdr["EighteenComment"].ToString();
                                resourceeffortComment.EcommentNineteen = rdr["NineteenComment"].ToString();
                                resourceeffortComment.EcommentTwenty = rdr["TwentyComment"].ToString();
                                resourceeffortComment.EcommentTwentyOne = rdr["TwentyOneComment"].ToString();
                                resourceeffortComment.EcommentTwentyTwo = rdr["TwentyTwoComment"].ToString();
                                resourceeffortComment.EcommentTwentyThree = rdr["TwentyThreeComment"].ToString();
                                resourceeffortComment.EcommentTwentyFour = rdr["TwentyFourComment"].ToString();
                                resourceeffortComment.EcommentTwentyFive = rdr["TwentyFiveComment"].ToString();
                                resourceeffortComment.EcommentTwentySix = rdr["TwentySixComment"].ToString();
                                resourceeffortComment.EcommentTwentySeven = rdr["TwentySevenComment"].ToString();
                                resourceeffortComment.EcommentTwentyEight = rdr["TwentyEightComment"].ToString();
                                resourceeffortComment.EcommentTwentyNine = rdr["TwentyNineComment"].ToString();
                                resourceeffortComment.EcommentThirty = rdr["ThirtyComment"].ToString();
                                resourceeffortComment.EcommentThirtyOne = rdr["ThirtyOneComment"].ToString();
                                lstAllResourceEffortComment.Add(resourceeffortComment);
                            }
                            rdr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
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
        /// update resource effort 
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="yearId"></param>
        /// <param name="monthId"></param>
        /// <returns></returns>
        public string UpdateResourceEffort(ResourceEffort resourceEffort)
        {
            string success = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.[updateResource_effort]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.Parameters.Add(new SqlParameter("@ResourceId", resourceEffort.ResourceId));
                        cmd.Parameters.Add(new SqlParameter("@Yid", resourceEffort.YeadId));
                        cmd.Parameters.Add(new SqlParameter("@MonthId", resourceEffort.MonthId));
                        cmd.Parameters.Add(new SqlParameter("@One", resourceEffort.EOne));
                        cmd.Parameters.Add(new SqlParameter("@Two", resourceEffort.ETwo));
                        cmd.Parameters.Add(new SqlParameter("@Three", resourceEffort.EThree));
                        cmd.Parameters.Add(new SqlParameter("@Four", resourceEffort.EFour));
                        cmd.Parameters.Add(new SqlParameter("@Five", resourceEffort.EFive));
                        cmd.Parameters.Add(new SqlParameter("@Six", resourceEffort.ESix));
                        cmd.Parameters.Add(new SqlParameter("@Seven", resourceEffort.ESeven));
                        cmd.Parameters.Add(new SqlParameter("@Eight", resourceEffort.EEight));
                        cmd.Parameters.Add(new SqlParameter("@Nine", resourceEffort.ENine));
                        cmd.Parameters.Add(new SqlParameter("@Ten", resourceEffort.ETen));
                        cmd.Parameters.Add(new SqlParameter("@Eleven", resourceEffort.EEleven));
                        cmd.Parameters.Add(new SqlParameter("@Tweleve", resourceEffort.ETwelve));
                        cmd.Parameters.Add(new SqlParameter("@Thirteen", resourceEffort.EThirteen));
                        cmd.Parameters.Add(new SqlParameter("@Fourteen", resourceEffort.EFourteen));
                        cmd.Parameters.Add(new SqlParameter("@Fifteen", resourceEffort.EFifteen));
                        cmd.Parameters.Add(new SqlParameter("@Sixteen", resourceEffort.ESixteen));
                        cmd.Parameters.Add(new SqlParameter("@Seventeen", resourceEffort.ESeventeen));
                        cmd.Parameters.Add(new SqlParameter("@Eighteen", resourceEffort.EEighteen));
                        cmd.Parameters.Add(new SqlParameter("@Nineteen", resourceEffort.ENineteen));
                        cmd.Parameters.Add(new SqlParameter("@Twenty", resourceEffort.ETwenty));
                        cmd.Parameters.Add(new SqlParameter("@TwentyOne", resourceEffort.ETwentyOne));
                        cmd.Parameters.Add(new SqlParameter("@TwentyTwo", resourceEffort.ETwentyTwo));
                        cmd.Parameters.Add(new SqlParameter("@TwentyThree", resourceEffort.ETwentyThree));
                        cmd.Parameters.Add(new SqlParameter("@TwentyFive", resourceEffort.ETwentyFive));
                        cmd.Parameters.Add(new SqlParameter("@TwentyFour", resourceEffort.ETwentyFour));
                        cmd.Parameters.Add(new SqlParameter("@TwentySix", resourceEffort.ETwentySix));
                        cmd.Parameters.Add(new SqlParameter("@TwentySeven", resourceEffort.ETwentySeven));
                        cmd.Parameters.Add(new SqlParameter("@TwentyEight", resourceEffort.ETwentyEight));
                        cmd.Parameters.Add(new SqlParameter("@TwentyNine", resourceEffort.ETwentyNine));
                        cmd.Parameters.Add(new SqlParameter("@Thirty", resourceEffort.EThirty));
                        cmd.Parameters.Add(new SqlParameter("@ThirtyOne", resourceEffort.EThirtyOne));
                        cmd.Parameters.Add(new SqlParameter("@userId", resourceEffort.ResourceId));
                        int suc = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
                StringBuilder strbError = new StringBuilder();
                strbError.AppendLine(ex.StackTrace.ToString());
                strbError.AppendLine(ex.Message.ToString());
                if (ex.InnerException != null)
                {
                    strbError.AppendLine(ex.InnerException.ToString());
                }
                logService.Error(strbError.ToString());
                success = "The resource effort has not been updated";
                throw new Exception(ex.Message);
            }
            return success;
        }

        /// <summary>
        /// Update Resource Effort Comment
        /// </summary>
        /// <param name="resourceEffort"></param>
        /// <returns></returns>
        public string UpdateResourceEffortComment(ResourceEffortComment resourceEffortComment)
        {
            string success = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.[updateResource_effort_Comment]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.Parameters.Add(new SqlParameter("@ResourceId", resourceEffortComment.ResourceId));
                        cmd.Parameters.Add(new SqlParameter("@Yid", resourceEffortComment.YeadId));
                        cmd.Parameters.Add(new SqlParameter("@MonthId", resourceEffortComment.MonthId));
                        cmd.Parameters.Add(new SqlParameter("@OneComment", resourceEffortComment.EcommentOne.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@TwoComment", resourceEffortComment.EcommentTwo.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@ThreeComment", resourceEffortComment.EcommentThree.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@FourComment", resourceEffortComment.EcommentFour.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@FiveComment", resourceEffortComment.EcommentFive.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@SixComment", resourceEffortComment.EcommentSix.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@SevenComment", resourceEffortComment.EcommentSeven.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@EightComment", resourceEffortComment.EcommentEight.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@NineComment", resourceEffortComment.EcommentNine.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@TenComment", resourceEffortComment.EcommentTen.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@ElevenComment", resourceEffortComment.EcommentEleven.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@TweleveComment", resourceEffortComment.EcommentTwelve.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@ThirteenComment", resourceEffortComment.EcommentThirteen.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@FourteenComment", resourceEffortComment.EcommentFourteen.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@FifteenComment", resourceEffortComment.EcommentFifteen.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@SixteenComment", resourceEffortComment.EcommentSixteen.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@SeventeenComment", resourceEffortComment.EcommentSeventeen.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@EighteenComment", resourceEffortComment.EcommentEighteen.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@NineteenComment", resourceEffortComment.EcommentNineteen.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@TwentyComment", resourceEffortComment.EcommentTwenty.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@TwentyOneComment", resourceEffortComment.EcommentTwentyOne.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@TwentyTwoComment", resourceEffortComment.EcommentTwentyTwo.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@TwentyThreeComment", resourceEffortComment.EcommentTwentyThree.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@TwentyFiveComment", resourceEffortComment.EcommentTwentyFive.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@TwentyFourComment", resourceEffortComment.EcommentTwentyFour.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@TwentySixComment", resourceEffortComment.EcommentTwentySix.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@TwentySevenComment", resourceEffortComment.EcommentTwentySeven.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@TwentyEightComment", resourceEffortComment.EcommentTwentyEight.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@TwentyNineComment", resourceEffortComment.EcommentTwentyNine.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@ThirtyComment", resourceEffortComment.EcommentThirty.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@ThirtyOneComment", resourceEffortComment.EcommentThirtyOne.Trim()));
                        cmd.Parameters.Add(new SqlParameter("@userId", resourceEffortComment.ResourceId));
                        int suc = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
                StringBuilder strbError = new StringBuilder();
                strbError.AppendLine(ex.StackTrace.ToString());
                strbError.AppendLine(ex.Message.ToString());
                if (ex.InnerException != null)
                {
                    strbError.AppendLine(ex.InnerException.ToString());
                }
                logService.Error(strbError.ToString());
                success = "Resource Effort for Resource Id = " + resourceEffortComment.ResourceId.ToString() + " could not be saved";
                throw new Exception(ex.Message);
            }
            return success;
        }

        /// <summary>
        /// To get the resource details based on the Email address
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public Resource GetResourceDetails(string emailAddress)
        {

            Resource resource = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("[dbo].[getResourceDetails]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        cmd.Connection = conn;
                        cmd.Parameters.Add(new SqlParameter("@ResourceEmail", emailAddress));
                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (rdr.Read())
                            {
                                resource = new Resource();
                                resource.ResourceName = rdr["Name"].ToString();
                                resource.ResourceEmail = rdr["Email"].ToString();
                                resource.ResourceContact = rdr["Contact"].ToString();
                                resource.ResourceSegment = rdr["SegmentName"].ToString();
                                resource.ResourceStartDate = Convert.ToDateTime(rdr["StartDate"].ToString());
                                resource.ResourceEndDate = Convert.ToDateTime(rdr["EndDate"].ToString());
                                resource.ResourceId = Convert.ToInt32(rdr["Id"].ToString());
                                resource.ResourceRate = Convert.ToDouble(rdr["Rate"].ToString());
                            }
                            rdr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
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
            return resource;
        }

        /// <summary>
        /// To update the resource Leave
        /// </summary>
        /// <param name="leave"></param>
        /// <returns></returns>
        public string SaveResourceLeavePlan(Leave leave)
        {
            string success = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("[dbo].[updateResourceLeave]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.Parameters.Add(new SqlParameter("@ResourceId", leave.ResourceId));
                        cmd.Parameters.Add(new SqlParameter("@yid", leave.YId));
                        cmd.Parameters.Add(new SqlParameter("@monthid", leave.MonthId));
                        cmd.Parameters.Add(new SqlParameter("@lday", leave.LDay));
                        cmd.Parameters.Add(new SqlParameter("@date", leave.LDay));
                        cmd.Parameters.Add(new SqlParameter("@leaveDate", leave.LeaveDate));
                        cmd.Parameters.Add(new SqlParameter("@UltimatixLeaveId", leave.UltimatixId));
                        cmd.Parameters.Add(new SqlParameter("@LeaveReason", leave.LeaveReason));
                        cmd.Parameters.Add(new SqlParameter("@BackupPlan", leave.BackupPlan));
                        cmd.Parameters.Add(new SqlParameter("@CreatedBy", leave.CreatedBy));
                        cmd.Parameters.Add(new SqlParameter("@CreatedDate", leave.CreatedDate));
                        cmd.Parameters.Add(new SqlParameter("@ModifiedBy", leave.CreatedBy));
                        cmd.Parameters.Add(new SqlParameter("@ModifiedDate", leave.CreatedDate));

                        int suc = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
                StringBuilder strbError = new StringBuilder();
                strbError.AppendLine(ex.StackTrace.ToString());
                strbError.AppendLine(ex.Message.ToString());
                if (ex.InnerException != null)
                {
                    strbError.AppendLine(ex.InnerException.ToString());
                }
                logService.Error(strbError.ToString());
                success = "Resource Leave for Resource Id = " + leave.ResourceId.ToString() + " could not be saved";
                throw new Exception(ex.Message);
            }
            return success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leave"></param>
        /// <returns></returns>
        public string CancelLeave(Leave leave)
        {
            string success = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("[dbo].[cancelLeave]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.Parameters.Add(new SqlParameter("@leaveId", leave.LeaveId));


                        int suc = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
                StringBuilder strbError = new StringBuilder();
                strbError.AppendLine(ex.StackTrace.ToString());
                strbError.AppendLine(ex.Message.ToString());
                if (ex.InnerException != null)
                {
                    strbError.AppendLine(ex.InnerException.ToString());
                }
                logService.Error(strbError.ToString());
                success = "Resource Leave for Resource Id = " + leave.ResourceId.ToString() + " could not be saved";
                throw new Exception(ex.Message);
            }
            return success;
        }

        /// <summary>
        /// To edit the Resource Leave
        /// </summary>
        /// <param name="leave"></param>
        /// <returns></returns>
        public string EditResourceLeavePlan(Leave leave)
        {
            string success = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("[dbo].[editResourceLeave]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.Parameters.Add(new SqlParameter("@LeaveId", leave.LeaveId));
                        cmd.Parameters.Add(new SqlParameter("@ResourceId", leave.ResourceId));
                        cmd.Parameters.Add(new SqlParameter("@yid", leave.YId));
                        cmd.Parameters.Add(new SqlParameter("@monthid", leave.MonthId));
                        cmd.Parameters.Add(new SqlParameter("@date", leave.LDay));
                        cmd.Parameters.Add(new SqlParameter("@leaveDate", leave.LeaveDate));
                        cmd.Parameters.Add(new SqlParameter("@UltimatixLeaveId", leave.UltimatixId));
                        cmd.Parameters.Add(new SqlParameter("@LeaveReason", leave.LeaveReason));
                        cmd.Parameters.Add(new SqlParameter("@BackupPlan", leave.BackupPlan));
                        cmd.Parameters.Add(new SqlParameter("@ModifiedBy", leave.CreatedBy));
                        cmd.Parameters.Add(new SqlParameter("@ModifiedDate", leave.CreatedDate));

                        int suc = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
                StringBuilder strbError = new StringBuilder();
                strbError.AppendLine(ex.StackTrace.ToString());
                strbError.AppendLine(ex.Message.ToString());
                if (ex.InnerException != null)
                {
                    strbError.AppendLine(ex.InnerException.ToString());
                }
                logService.Error(strbError.ToString());
                success = "Resource Leave for Resource Id = " + leave.ResourceId.ToString() + " could not be saved";
                throw new Exception(ex.Message);
            }
            return success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="leaveId"></param>
        /// <returns></returns>
        public Leave GetResourceLeave(int resourceId, int leaveId)
        {
            Leave leave = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("[dbo].[getResourceLeave]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        cmd.Connection = conn;
                        cmd.Parameters.Add(new SqlParameter("@LeaveId", leaveId));
                        cmd.Parameters.Add(new SqlParameter("@ResourceId", resourceId));
                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (rdr.Read())
                            {
                                leave = new Leave();
                                leave.LeaveId = Convert.ToInt32(rdr["leaveid"].ToString());
                                leave.ResourceId = Convert.ToInt32(rdr["resourceid"].ToString());
                                leave.MonthId = Convert.ToInt32(rdr["monthid"].ToString());
                                leave.YId = Convert.ToInt32(rdr["yid"].ToString());
                                leave.LDay = Convert.ToInt32(rdr["lday"].ToString());
                                leave.LeaveDate = Convert.ToDateTime(rdr["leavedate"].ToString());
                                leave.UltimatixId = rdr["ultimatixlid"].ToString();
                                leave.LeaveReason = rdr["leavereason"].ToString();
                                leave.BackupPlan = rdr["backupplan"].ToString();
                                leave.CreatedBy = rdr["createdby"].ToString();
                                leave.CreatedDate = Convert.ToDateTime(rdr["createddate"].ToString());
                                leave.ModifiedBy = rdr["modifiedby"].ToString();
                                leave.ModifiedDate = Convert.ToDateTime(rdr["modifieddate"].ToString());
                                leave.IsActive = rdr["isactive"].ToString();
                            }
                            rdr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
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
            return leave;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="leaveId"></param>
        /// <returns></returns>
        public List<Leave> GetYMResourceLeaves(int yearId, int monthId)
        {
            List<Leave> lstLeave = new List<Leave>();
            Leave leave = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("[dbo].[getYMLeaveDetails]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        cmd.Connection = conn;
                        cmd.Parameters.Add(new SqlParameter("@YearId", yearId));
                        cmd.Parameters.Add(new SqlParameter("@MonthId", monthId));
                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (rdr.Read())
                            {
                                leave = new Leave();
                                leave.LeaveId = Convert.ToInt32(rdr["leaveid"].ToString());
                                leave.ResourceId = Convert.ToInt32(rdr["resourceid"].ToString());
                                leave.ResourceName = rdr["name"].ToString();
                                leave.ResourceEmail = rdr["Email"].ToString();
                                leave.ProjectName = rdr["ProjectName"].ToString();
                                leave.RoleName = rdr["RoleName"].ToString();
                                leave.SegmentName = rdr["SegmentName"].ToString();
                                leave.MonthId = Convert.ToInt32(rdr["monthid"].ToString());
                                leave.YId = Convert.ToInt32(rdr["yid"].ToString());
                                leave.LDay = Convert.ToInt32(rdr["lday"].ToString());
                                leave.LeaveDate = Convert.ToDateTime(rdr["leavedate"].ToString());
                                leave.UltimatixId = rdr["ultimatixlid"].ToString();
                                leave.LeaveReason = rdr["leavereason"].ToString();
                                leave.BackupPlan = rdr["backupplan"].ToString();
                                leave.CreatedBy = rdr["createdby"].ToString();
                                leave.CreatedDate = Convert.ToDateTime(rdr["createddate"].ToString());
                                leave.ModifiedBy = rdr["modifiedby"].ToString();
                                leave.ModifiedDate = Convert.ToDateTime(rdr["modifieddate"].ToString());
                                leave.IsActive = rdr["isactive"].ToString();
                                leave.ResourceLeaveId = rdr["resourceid"].ToString() + "|" + rdr["leaveid"].ToString();
                                lstLeave.Add(leave);
                            }
                            rdr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
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
            return lstLeave;
        }

        /// <summary>
        /// Get Company list
        /// </summary>
        /// <returns></returns>
        public List<Company> GetCompany()
        {

            List<Company> lstCompany = new List<Company>();
            Company company = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.[getCompany]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        cmd.Connection = conn;

                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (rdr.Read())
                            {
                                company = new Company();
                                company.CompanyId = Convert.ToInt32(rdr["CompanyId"].ToString());
                                company.CompanyName = rdr["CompanyName"].ToString();
                                lstCompany.Add(company);
                            }
                            rdr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
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
            return lstCompany;
        }

        /// <summary>
        /// Get all Feedback
        /// </summary>
        /// <returns></returns>
        public List<FeedbackEnt> GetAllFeedback()
        {

            List<FeedbackEnt> lstFeedback = new List<FeedbackEnt>();
            FeedbackEnt feedback = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.[getAllFeedback]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        cmd.Connection = conn;

                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (rdr.Read())
                            {
                                feedback = new FeedbackEnt();
                                feedback.FeedbackId = Convert.ToInt32(rdr["FeedbackId"].ToString());
                                feedback.FeedbackName = rdr["fName"].ToString();
                                //feedback.EmailAddress = rdr["EmailAddress"].ToString();
                                //feedback.EmployeeFeedback = rdr["feedback"].ToString();
                                feedback.IpAddress = rdr["ipaddress"].ToString();
                                feedback.Browser = rdr["browser"].ToString();
                                feedback.CreatedBy = rdr["createdby"].ToString();
                                feedback.CreatedDate = Convert.ToDateTime(rdr["createddate"].ToString());
                                feedback.CompanyId = Convert.ToInt32(rdr["companyid"].ToString());
                                feedback.CompanyName = rdr["companyname"].ToString();
                                //feedback.TowerId = Convert.ToInt32(rdr["towerid"].ToString());
                                //feedback.TowerName = rdr["towername"].ToString();
                                lstFeedback.Add(feedback);
                            }
                            rdr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
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
            return lstFeedback;
        }

        /// <summary>
        /// To get the individual feedback
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <returns></returns>
        public List<FeedbackEnt> GetIndividualFeedback(int feedbackId)
        {
            List<FeedbackEnt> lstFeedback = new List<FeedbackEnt>();
            FeedbackEnt feedback = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("[dbo].[getFeedbackById]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        cmd.Connection = conn;
                        cmd.Parameters.Add(new SqlParameter("@feedbackId", feedbackId));

                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (rdr.Read())
                            {
                                feedback = new FeedbackEnt();
                                feedback.FeedbackId = Convert.ToInt32(rdr["FeedbackId"].ToString());
                                feedback.FeedbackName = rdr["fName"].ToString();
                                //feedback.EmailAddress = rdr["EmailAddress"].ToString();
                                //feedback.EmployeeFeedback = rdr["feedback"].ToString();
                                feedback.IpAddress = rdr["ipaddress"].ToString();
                                feedback.Browser = rdr["browser"].ToString();
                                feedback.CreatedBy = rdr["createdby"].ToString();
                                feedback.CreatedDate = Convert.ToDateTime(rdr["createddate"].ToString());
                                feedback.CompanyId = Convert.ToInt32(rdr["companyid"].ToString());
                                feedback.CompanyName = rdr["companyname"].ToString();
                                //feedback.TowerId = Convert.ToInt32(rdr["towerid"].ToString());
                                //feedback.TowerName = rdr["towername"].ToString();
                                lstFeedback.Add(feedback);
                            }
                            rdr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
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
            return lstFeedback;
        }

        /// <summary>
        /// To save an individual feedback
        /// </summary>
        /// <param name="feedBack"></param>
        /// <returns></returns>
        public string SaveEmployeeFeedback(List<FeedbackEnt> lstFeedBack)
        {
            string success = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    foreach (FeedbackEnt feedBack in lstFeedBack)
                    {
                        using (SqlCommand cmd = new SqlCommand("dbo.[SaveFeedback]"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            conn.Open();
                            cmd.Connection = conn;
                            cmd.Parameters.Add(new SqlParameter("@ResourceName", feedBack.FeedbackName));
                            cmd.Parameters.Add(new SqlParameter("@CompanyId", feedBack.CompanyId));
                            cmd.Parameters.Add(new SqlParameter("@FeedbackOnId", feedBack.FeedbackOnId));
                            cmd.Parameters.Add(new SqlParameter("@EmployeeCatagoryId", feedBack.EmployeeCatagoryId));
                            cmd.Parameters.Add(new SqlParameter("@FeedbackOnEmployeeNameOrGroup", feedBack.FeedbackOnEmployeeNameOrGroup));
                            cmd.Parameters.Add(new SqlParameter("@FeedbackCategoryId", feedBack.FeedbackCategoryId));
                            cmd.Parameters.Add(new SqlParameter("@FeedbackNote", feedBack.FeedbackNote));
                            cmd.Parameters.Add(new SqlParameter("@FeedbackTypeId", feedBack.FeedbackTypeId));
                            cmd.Parameters.Add(new SqlParameter("@ipAddress", feedBack.IpAddress));
                            cmd.Parameters.Add(new SqlParameter("@browser", feedBack.Browser));
                            cmd.Parameters.Add(new SqlParameter("@createdBy", feedBack.CreatedBy));
                            cmd.Parameters.Add(new SqlParameter("@isActive", "Y"));
                            cmd.Parameters.Add(new SqlParameter("@FeedbackPurpose", feedBack.FeedbackPurpose));
                            cmd.Parameters.Add(new SqlParameter("@IncidentNumber", feedBack.IncidentNumber));
                            cmd.Parameters.Add(new SqlParameter("@FeedbackFollowUp", feedBack.FeedbackFollowUp));
                            cmd.Parameters.Add(new SqlParameter("@ContactNumber", feedBack.ContactNumber));
                            int suc = cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
                StringBuilder strbError = new StringBuilder();
                strbError.AppendLine(ex.StackTrace.ToString());
                strbError.AppendLine(ex.Message.ToString());
                if (ex.InnerException != null)
                {
                    strbError.AppendLine(ex.InnerException.ToString());
                }
                logService.Error(strbError.ToString());
                success = "Feedback for Employee Name = " + lstFeedBack[0].FeedbackName + " could not be saved";
                throw new Exception(ex.Message);
            }
            return success;
        }

        /// <summary>
        /// To Get List of Employee Catagory Details
        /// </summary>
        /// <returns></returns>
        public List<EmployeeCatagory> GetEmployeeCatagory()
        {

            List<EmployeeCatagory> lstEmployeeCatagory = new List<EmployeeCatagory>();
            EmployeeCatagory employeeCatagory = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.[getEmployeeCatagories]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        cmd.Connection = conn;

                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (rdr.Read())
                            {
                                employeeCatagory = new EmployeeCatagory();
                                employeeCatagory.EmployeeCatagoryId = Convert.ToInt32(rdr["EmployeeCatagoryId"].ToString());
                                employeeCatagory.EmployeeCatagoryName = rdr["EmployeeCatagoryName"].ToString();
                                lstEmployeeCatagory.Add(employeeCatagory);
                            }
                            rdr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
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
            return lstEmployeeCatagory;
        }

        /// <summary>
        /// To Get List of Feedback Catagory Details
        /// </summary>
        /// <returns></returns>
        public List<FeedbackCatagory> GetFeedbackCatagory()
        {

            List<FeedbackCatagory> lstFeedbackCatagory = new List<FeedbackCatagory>();
            FeedbackCatagory feedbackCatagory = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.[getFeedbackCatagories]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        cmd.Connection = conn;

                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (rdr.Read())
                            {
                                feedbackCatagory = new FeedbackCatagory();
                                feedbackCatagory.FeedbackCatagoryId = Convert.ToInt32(rdr["FeedbackCatagoryId"].ToString());
                                feedbackCatagory.FeedbackCatagoryName = rdr["FeedbackCatagoryName"].ToString();
                                lstFeedbackCatagory.Add(feedbackCatagory);
                            }
                            rdr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
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
            return lstFeedbackCatagory;
        }

        /// <summary>
        /// To Get List of Feedback Type Details
        /// </summary>
        /// <returns></returns>
        public List<FeedbackType> GetFeedbackType()
        {

            List<FeedbackType> lstFeedbackType = new List<FeedbackType>();
            FeedbackType feedbackType = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.[getFeedbackType]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        cmd.Connection = conn;

                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (rdr.Read())
                            {
                                feedbackType = new FeedbackType();
                                feedbackType.FeedbackTypeId = Convert.ToInt32(rdr["FeedbackTypeId"].ToString());
                                feedbackType.FeedbackTypeName = rdr["FeedbackTypeName"].ToString();
                                lstFeedbackType.Add(feedbackType);
                            }
                            rdr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
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
            return lstFeedbackType;
        }


        /// <summary>
        /// To get all the feedback based on the filter criterias selected
        /// </summary>
        /// <param name="feedbackLookup"></param>
        /// <returns></returns>
        public List<FeedbackEnt> GetCompanyFeedback(FeedbackLookup feedbackLookup)
        {
            List<FeedbackEnt> lstFeedback = new List<FeedbackEnt>();
            FeedbackEnt feedback = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("[dbo].[getFeedback]"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        cmd.Connection = conn;
                        cmd.Parameters.Add(new SqlParameter("@fromDate", feedbackLookup.FeedbackFromDate));
                        cmd.Parameters.Add(new SqlParameter("@toDate", feedbackLookup.FeedbackToDate));
                        cmd.Parameters.Add(new SqlParameter("@incidentNumber", feedbackLookup.IncidentNumber));
                        cmd.Parameters.Add(new SqlParameter("@feedbackCategoryId", feedbackLookup.FeedbackCategoryId));
                        cmd.Parameters.Add(new SqlParameter("@name", feedbackLookup.Name));
                        cmd.Parameters.Add(new SqlParameter("@feedbackFollowUp", feedbackLookup.FeedbackFollowUp));

                        using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (rdr.Read())
                            {
                                feedback = new FeedbackEnt();
                                feedback.FeedbackName = rdr["Employee_Name"].ToString();
                                feedback.CreatedDate = Convert.ToDateTime(rdr["Feedback_Date"].ToString());
                                feedback.FeedbackPurpose =Convert.ToString(rdr["Feedback_Purpose"]);
                                feedback.FeedbackCategory = rdr["Feedback_Category"].ToString();
                                feedback.FeedbackNote = rdr["Feedback"].ToString();
                                feedback.IncidentNumber = Convert.ToString(rdr["Incident_Number"]);
                                feedback.FeedbackFollowUp = Convert.ToString(rdr["Feedback_Follow_Up"]);
                                lstFeedback.Add(feedback);
                            }
                            rdr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetAdapter));
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
            return lstFeedback;
        }

    }
}
