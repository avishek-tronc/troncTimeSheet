using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tronc.Timesheet.Common.Entities
{
    public class Messages
    {
        #region Attributes

        private string _feedbackSaveSuccess;
        private string _feedbackSaveFailure;
        private string _duplicateFeedbackCategory;

        #endregion

        #region Properties
        public string FeedbackSaveSuccess
        {
            get { return _feedbackSaveSuccess; }
            set { _feedbackSaveSuccess = value; }
        }
        public string FeedbackSaveFailure
        {
            get { return _feedbackSaveFailure; }
            set { _feedbackSaveFailure = value; }
        }

        public string DuplicateFeedbackCategory
        {
            get { return _duplicateFeedbackCategory; }
            set { _duplicateFeedbackCategory = value; }
        }

        #endregion

    }
}
