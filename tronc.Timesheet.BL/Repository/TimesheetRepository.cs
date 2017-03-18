using Log4NetLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tronc.Timesheet.Common.Entities;
using tronc.Timesheet.DAL.Adapter;

namespace tronc.Timesheet.BL.Repository
{
    public class TimesheetRepository
    {

        /* To get year*/
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Year> GetYear()
        {
            List<Year> lstYear = new List<Year>();
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            try
            {
                lstYear = timesheetAdapter.GetYear();
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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

        /* To get Month*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Month> GetMonth()
        {
            List<Month> lstmonth = new List<Month>();
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            try
            {
                lstmonth = timesheetAdapter.GetMonth();
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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

        /* To get Segment*/
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Segment> GetSegment()
        {
            List<Segment> lstsegment = new List<Segment>();
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            try
            {
                lstsegment = timesheetAdapter.GetSegment();
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
            return lstsegment;
        }


        /// <summary>
        /// To get all the resources
        /// </summary>
        /// <returns></returns>
        public List<Resource> GetResources()
        {
            List<Resource> lstResource = new List<Resource>();
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            try
            {
                lstResource = timesheetAdapter.GetResources();
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
        /*Get  resource effort*/
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
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            try
            {
                lstResourceEffort = timesheetAdapter.GetResourceEffort(resourceId, yearId, monthId);
                foreach (ResourceEffort rcEffort in lstResourceEffort)
                {
                    if (rcEffort != null)
                    {
                        rcEffort.TotalEffort += Convert.ToInt32(rcEffort.EOne) + Convert.ToInt32(rcEffort.ETwo) + Convert.ToInt32(rcEffort.EThree) + Convert.ToInt32(rcEffort.EFour) + Convert.ToInt32(rcEffort.EFive) + Convert.ToInt32(rcEffort.ESix) + Convert.ToInt32(rcEffort.ESeven) + Convert.ToInt32(rcEffort.EEight) + Convert.ToInt32(rcEffort.ENine) + Convert.ToInt32(rcEffort.ETen) +
                                                Convert.ToInt32(rcEffort.EEleven) + Convert.ToInt32(rcEffort.ETwelve) + Convert.ToInt32(rcEffort.EThirteen) + Convert.ToInt32(rcEffort.EFourteen) + Convert.ToInt32(rcEffort.EFifteen) + Convert.ToInt32(rcEffort.ESixteen) + Convert.ToInt32(rcEffort.ESeventeen) + Convert.ToInt32(rcEffort.EEighteen) + Convert.ToInt32(rcEffort.ENineteen) + Convert.ToInt32(rcEffort.ETwenty) +
                                                Convert.ToInt32(rcEffort.ETwentyOne) + Convert.ToInt32(rcEffort.ETwentyTwo) + Convert.ToInt32(rcEffort.ETwentyThree) + Convert.ToInt32(rcEffort.ETwentyFour) + Convert.ToInt32(rcEffort.ETwentyFive) + Convert.ToInt32(rcEffort.ETwentySix) + Convert.ToInt32(rcEffort.ETwentySeven) + Convert.ToInt32(rcEffort.ETwentyEight) + Convert.ToInt32(rcEffort.ETwentyNine) + Convert.ToInt32(rcEffort.EThirty) + Convert.ToInt32(rcEffort.EThirtyOne);
                        rcEffort.QueryParameters = rcEffort.YeadId.ToString() + "|" + rcEffort.MonthId.ToString() + "|" + rcEffort.ResourceId.ToString();
                        rcEffort.TotalMonthRate = rcEffort.TotalEffort * rcEffort.ResourceRate;
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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


        /*Get all resource effort*/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yearId"></param>
        /// <param name="monthId"></param>
        /// <param name="segmentId"></param>
        /// <returns></returns>
        public List<ResourceEffort> GetAllResourceEffort(int yearId, int monthId, int segmentId)
        {
            List<ResourceEffort> lstAllResourceEffort = new List<ResourceEffort>();
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            try
            {
                lstAllResourceEffort = timesheetAdapter.GetAllResourceEffort(yearId, monthId, segmentId);
                if (lstAllResourceEffort != null && lstAllResourceEffort.Count > 0)
                {
                    foreach (ResourceEffort rcEffort in lstAllResourceEffort)
                    {
                        if (rcEffort != null)
                        {
                            rcEffort.TotalEffort += Convert.ToInt32(rcEffort.EOne) + Convert.ToInt32(rcEffort.ETwo) + Convert.ToInt32(rcEffort.EThree) + Convert.ToInt32(rcEffort.EFour) + Convert.ToInt32(rcEffort.EFive) + Convert.ToInt32(rcEffort.ESix) + Convert.ToInt32(rcEffort.ESeven) + Convert.ToInt32(rcEffort.EEight) + Convert.ToInt32(rcEffort.ENine) + Convert.ToInt32(rcEffort.ETen) +
                                                    Convert.ToInt32(rcEffort.EEleven) + Convert.ToInt32(rcEffort.ETwelve) + Convert.ToInt32(rcEffort.EThirteen) + Convert.ToInt32(rcEffort.EFourteen) + Convert.ToInt32(rcEffort.EFifteen) + Convert.ToInt32(rcEffort.ESixteen) + Convert.ToInt32(rcEffort.ESeventeen) + Convert.ToInt32(rcEffort.EEighteen) + Convert.ToInt32(rcEffort.ENineteen) + Convert.ToInt32(rcEffort.ETwenty) +
                                                    Convert.ToInt32(rcEffort.ETwentyOne) + Convert.ToInt32(rcEffort.ETwentyTwo) + Convert.ToInt32(rcEffort.ETwentyThree) + Convert.ToInt32(rcEffort.ETwentyFour) + Convert.ToInt32(rcEffort.ETwentyFive) + Convert.ToInt32(rcEffort.ETwentySix) + Convert.ToInt32(rcEffort.ETwentySeven) + Convert.ToInt32(rcEffort.ETwentyEight) + Convert.ToInt32(rcEffort.ETwentyNine) + Convert.ToInt32(rcEffort.EThirty) + Convert.ToInt32(rcEffort.EThirtyOne);
                            rcEffort.QueryParameters = rcEffort.YeadId.ToString() + "|" + rcEffort.MonthId.ToString() + "|" + rcEffort.ResourceId.ToString();
                            rcEffort.TotalMonthRate = rcEffort.TotalEffort * rcEffort.ResourceRate;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
            return lstAllResourceEffort;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="yearId"></param>
        /// <param name="monthId"></param>
        /// <returns></returns>
        public List<ResourceEffortComment> GetResourceEffortComment(int resourceId, int yearId, int monthId)
        {
            List<ResourceEffortComment> lstResourceEffortComment = new List<ResourceEffortComment>();
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            try
            {
                lstResourceEffortComment = timesheetAdapter.GetResourceEffortComment(resourceId, yearId, monthId);
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
        ///Get All Resource Effort Comment
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="yearId"></param>
        /// <param name="monthId"></param>
        /// <returns></returns>
        public List<ResourceEffortComment> GetAllResourceEffortComment(int yearId, int monthId, int segmentId)
        {
            List<ResourceEffortComment> lstAllResourceEffortComment = new List<ResourceEffortComment>();
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            try
            {
                lstAllResourceEffortComment = timesheetAdapter.GetAllResourceEffortComment(yearId, monthId, segmentId);

            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
        /// <param name="resourceEffort"></param>
        /// <returns></returns>
        public string UpdateResourceEffort(ResourceEffort resourceEffort)
        {
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            string success = string.Empty;
            try
            {
                success = timesheetAdapter.UpdateResourceEffort(resourceEffort);
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
            return success;

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceEffortComment"></param>
        /// <returns></returns>
        public string UpdateResourceEffortComment(ResourceEffortComment resourceEffortComment)
        {
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            string success = string.Empty;
            try
            {
                success = timesheetAdapter.UpdateResourceEffortComment(resourceEffortComment);
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
            return success;
        }


        /// <summary>
        /// To get the resource details based on the Email Address entered
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public Resource GetResourceDetails(string emailAddress)
        {
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            Resource resource = null;
            try
            {
                resource = timesheetAdapter.GetResourceDetails(emailAddress);
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
        /// To apply for the leave
        /// </summary>
        /// <param name="leave"></param>
        /// <returns></returns>
        public string SaveResourceLeavePlan(Leave leave)
        {
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            string leaveUpdateFlag = string.Empty;
            try
            {
                leaveUpdateFlag = timesheetAdapter.SaveResourceLeavePlan(leave);
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
            return leaveUpdateFlag;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="leave"></param>
        /// <returns></returns>
        public string EditResourceLeavePlan(Leave leave)
        {
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            string leaveUpdateFlag = string.Empty;
            try
            {
                leaveUpdateFlag = timesheetAdapter.EditResourceLeavePlan(leave);
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
            return leaveUpdateFlag;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leave"></param>
        /// <returns></returns>
        public string CancelLeave(Leave leave)
        {
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            string leaveUpdateFlag = string.Empty;
            try
            {
                leaveUpdateFlag = timesheetAdapter.CancelLeave(leave);
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
            return leaveUpdateFlag;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceId"></param>
        /// <param name="leaveId"></param>
        /// <returns></returns>
        public Leave GetResourceLeave(int resourceId, int leaveId)
        {
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            Leave leave = new Leave();
            try
            {
                leave = timesheetAdapter.GetResourceLeave(resourceId, leaveId);
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
        /// <param name="yearId"></param>
        /// <param name="monthId"></param>
        /// <returns></returns>
        public List<Leave> GetYMResourceLeaves(int yearId, int monthId)
        {
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            List<Leave> lstLeave = new List<Leave>();
            try
            {
                lstLeave = timesheetAdapter.GetYMResourceLeaves(yearId, monthId);
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
        /// Get Company List
        /// </summary>
        /// <returns></returns>
        public List<Company> GetCompany()
        {
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            List<Company> lstCompany = new List<Company>();
            try
            {
                lstCompany = timesheetAdapter.GetCompany();
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
        /// Get All Feedback
        /// </summary>
        /// <returns></returns>
        public List<FeedbackEnt> GetAllFeedback()
        {
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            List<FeedbackEnt> lstFeedback = new List<FeedbackEnt>();
            try
            {
                lstFeedback = timesheetAdapter.GetAllFeedback();
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
        /// Get Individula Feedback
        /// </summary>
        /// <param name="feedbackId"></param>
        /// <returns></returns>
        public List<FeedbackEnt> GetIndividualFeedback(int feedbackId)
        {
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            List<FeedbackEnt> lstFeedback = new List<FeedbackEnt>();
            try
            {
                lstFeedback = timesheetAdapter.GetIndividualFeedback(feedbackId);
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
        /// Save Feedback details
        /// </summary>
        /// <param name="lstFeedBack"></param>
        /// <returns></returns>
        public string SaveEmployeeFeedback(List<FeedbackEnt> lstFeedBack)
        {
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            string suc = string.Empty;
            try
            {
                suc = timesheetAdapter.SaveEmployeeFeedback(lstFeedBack);
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
            return suc;
        }

        /// <summary>
        /// To Get List of Employee Catagory
        /// </summary>
        /// <returns></returns>
        public List<EmployeeCatagory> GetEmployeeCatagory()
        {
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            List<EmployeeCatagory> lstEmployeeCatagory = new List<EmployeeCatagory>();
            try
            {
                lstEmployeeCatagory = timesheetAdapter.GetEmployeeCatagory();
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
        /// To Get List of Feedback Catagory
        /// </summary>
        /// <returns></returns>
        public List<FeedbackCatagory> GetFeedbackCatagory()
        {
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            List<FeedbackCatagory> lstFeedbackCatagory = new List<FeedbackCatagory>();
            try
            {
                lstFeedbackCatagory = timesheetAdapter.GetFeedbackCatagory();
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
        /// To Get List of Feedback Type
        /// </summary>
        /// <returns></returns>
        public List<FeedbackType> GetFeedbackType()
        {
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            List<FeedbackType> lstFeedbackType = new List<FeedbackType>();
            try
            {
                lstFeedbackType = timesheetAdapter.GetFeedbackType();
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
            TimesheetAdapter timesheetAdapter = new TimesheetAdapter();
            List<FeedbackEnt> lstFeedback = new List<FeedbackEnt>();
            try
            {
                lstFeedback = timesheetAdapter.GetCompanyFeedback(feedbackLookup);
                //if (lstFeedback != null && lstFeedback.Count > 0)
                //{
                //    lstFeedback = (from item in lstFeedback
                //                   where !string.IsNullOrEmpty(item.FeedbackId.ToString())
                //                   select item).Take(30).ToList<FeedbackEnt>();
                //}
            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(TimesheetRepository));
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
