using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tronc.Timesheet.Common.Entities
{
    public class FeedbackType
    {

        #region Attributes

        private int _feedbackTypeId;
        private string _feedbackTypeName;

        #endregion

        #region Properties
        public int FeedbackTypeId
        {
            get { return _feedbackTypeId; }
            set { _feedbackTypeId = value; }
        }
        public string FeedbackTypeName
        {
            get { return _feedbackTypeName; }
            set { _feedbackTypeName = value; }
        }

        #endregion

    }
}
