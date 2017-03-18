using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace tronc.Timesheet.Common.Entities
{
    [DataContract]
    public class FeedbackRequest
    {
        #region Attributes

        [DataMember(IsRequired = true)]
        private HeaderEntity _headerEntity;

        [DataMember(IsRequired = true)]
        private int _feedbackById;

        [DataMember(IsRequired = true)]
        private int _feedbackForId;

        [DataMember(IsRequired = true)]
        private string _feedbackFromDate;

        [DataMember(IsRequired = true)]
        private string _feedbackToDate;

        [DataMember(IsRequired = true)]
        private int _feedbackCategoryId;

        [DataMember(IsRequired = true)]
        private string _feedbackNotes;

       

       


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
        public string FeedbackFromDate
        {
            get { return _feedbackFromDate; }
            set { _feedbackFromDate = value; }
        }
        public string FeedbackToDate
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
        public HeaderEntity HeaderEntity
        {
            get { return _headerEntity; }
            set { _headerEntity = value; }
        }
        #endregion
    }
}
