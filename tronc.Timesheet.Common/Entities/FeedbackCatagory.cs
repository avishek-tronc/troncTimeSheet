using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tronc.Timesheet.Common.Entities
{
    public class FeedbackCatagory
    {
        #region Attributes

        private int _feedbackCatagoryId;
        private string _feedbackCatagoryName;

        #endregion

        #region Properties
        public int FeedbackCatagoryId
        {
            get { return _feedbackCatagoryId; }
            set { _feedbackCatagoryId = value; }
        }
        public string FeedbackCatagoryName
        {
            get { return _feedbackCatagoryName; }
            set { _feedbackCatagoryName = value; }
        }

        #endregion
    }
}
