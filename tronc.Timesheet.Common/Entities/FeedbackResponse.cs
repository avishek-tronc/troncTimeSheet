using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tronc.Timesheet.Common.Entities
{
    public class FeedbackResponse
    {
        #region Attributes

        private List<FeedbackEnt> _lstFeedback;
        private string _errMessage;

        

        #endregion

        #region Properties
        public List<FeedbackEnt> LstFeedback
        {
            get { return _lstFeedback; }
            set { _lstFeedback = value; }
        }
        public string ErrMessage
        {
            get { return _errMessage; }
            set { _errMessage = value; }
        }
        #endregion
    }
}
