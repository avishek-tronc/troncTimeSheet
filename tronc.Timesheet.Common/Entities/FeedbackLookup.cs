using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tronc.Timesheet.Common.Entities
{
    public class FeedbackLookup
    {
        #region Attributes

        private int _feedbackById;
        private int _feedbackForId;
        private DateTime _feedbackFromDate;
        private DateTime _feedbackToDate;
        private int _feedbackCategoryId;
        private string _feedbackNotes;
        private string _incidentNumber;
        private string _feedbackFollowUp;
        private string _name;


        #endregion

        #region Properties
        public int FeedbackById
        {
            get { return _feedbackById; }
            set { _feedbackById = value; }
        }
        public int FeedbackForId
        {
            get { return _feedbackForId; }
            set { _feedbackForId = value; }
        }
        public DateTime FeedbackFromDate
        {
            get { return _feedbackFromDate; }
            set { _feedbackFromDate = value; }
        }
        public DateTime FeedbackToDate
        {
            get { return _feedbackToDate; }
            set { _feedbackToDate = value; }
        }
        public int FeedbackCategoryId
        {
            get { return _feedbackCategoryId; }
            set { _feedbackCategoryId = value; }
        }
        public string FeedbackNotes
        {
            get { return _feedbackNotes; }
            set { _feedbackNotes = value; }
        }
        public string IncidentNumber
        {
            get { return _incidentNumber; }
            set { _incidentNumber = value; }
        }
        public string FeedbackFollowUp
        {
            get { return _feedbackFollowUp; }
            set { _feedbackFollowUp = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion
    }
}
