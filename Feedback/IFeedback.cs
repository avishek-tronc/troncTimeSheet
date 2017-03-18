using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using tronc.Timesheet.Common.Entities;

namespace Feedback
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFeedback" in both code and config file together.
    [ServiceContract]
    public interface IFeedback
    {
        [OperationContract]
        FeedbackResponse GetAllFeedback(FeedbackRequest feedbackRequest);
    }
}
