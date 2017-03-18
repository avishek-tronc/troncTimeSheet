using Log4NetLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using tronc.Timesheet.BL.Repository;
using tronc.Timesheet.Common.Entities;
using tronc.Timesheet.DAL.Adapter;

namespace Feedback
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Feedback" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Feedback.svc or Feedback.svc.cs at the Solution Explorer and start debugging.
    public class Feedback : IFeedback
    {
        /// <summary>
        /// To get all the feedback based on the request parameters passed
        /// </summary>
        /// <param name="feedbackRequest"></param>
        /// <returns></returns>
        public FeedbackResponse GetAllFeedback(FeedbackRequest feedbackRequest)
        {
            FeedbackResponse feedbackResponse = new FeedbackResponse();
            TimesheetRepository timesheetRepository = new TimesheetRepository();
            TimesheetAdapter t = new TimesheetAdapter();
            FeedbackLookup feedbackLookup = new FeedbackLookup();
            FeedBackValidator feedbackValidator = new FeedBackValidator();
            try
            {
                if (feedbackRequest.HeaderEntity != null)
                {
                    if (feedbackValidator.ValidateServiceRequest(feedbackRequest.HeaderEntity))
                    {
                        feedbackLookup.FeedbackById = feedbackRequest.FeedbackById;
                        feedbackLookup.FeedbackCategoryId = feedbackRequest.FeedbackCategoryId;
                        feedbackLookup.FeedbackForId = feedbackRequest.FeedbackForId;
                        feedbackLookup.FeedbackFromDate = Convert.ToDateTime(feedbackRequest.FeedbackFromDate);
                        feedbackLookup.FeedbackNotes = feedbackRequest.FeedbackNotes;
                        feedbackLookup.FeedbackToDate = Convert.ToDateTime(feedbackRequest.FeedbackToDate);
                        List<FeedbackEnt> lstFeedback = timesheetRepository.GetCompanyFeedback(feedbackLookup);
                        if (lstFeedback != null && lstFeedback.Count > 0)
                        {
                            feedbackResponse.LstFeedback = lstFeedback;
                            feedbackResponse.ErrMessage = string.Empty;
                        }
                        else
                        {
                            feedbackResponse.ErrMessage = "No results found for the entered search criterias";
                        }
                    }
                    else
                    {
                        feedbackResponse.ErrMessage = "Service Authentication Error";
                    }
                }
                else
                {
                    feedbackResponse.ErrMessage = "Service Authentication Error";
                }

            }
            catch (Exception ex)
            {
                ILogService logService = new FileLogService(typeof(Feedback));
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
            return feedbackResponse;
        }
    }
}
