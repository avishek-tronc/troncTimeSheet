using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tronc.Timesheet.Common.Entities
{
    public class Resource
    {
        #region Attributes

        private int _resourceId;
        private string _resourceName;
        private string _resourceContact;
        private string _resourceEmail;
        private string _resourceSegment;
        private DateTime _resourceStartDate;
        private DateTime _resourceEndDate;
        private double _resourceRate;

        


        #endregion

        #region Properties
        public int ResourceId
        {
            get { return _resourceId; }
            set { _resourceId = value; }
        }
        public string ResourceName
        {
            get { return _resourceName; }
            set { _resourceName = value; }
        }
        public string ResourceEmail
        {
            get { return _resourceEmail; }
            set { _resourceEmail = value; }
        }
        public string ResourceSegment
        {
            get { return _resourceSegment; }
            set { _resourceSegment = value; }
        }
        public DateTime ResourceStartDate
        {
            get { return _resourceStartDate; }
            set { _resourceStartDate = value; }
        }
        public DateTime ResourceEndDate
        {
            get { return _resourceEndDate; }
            set { _resourceEndDate = value; }
        }
        public string ResourceContact
        {
            get { return _resourceContact; }
            set { _resourceContact = value; }
        }
        public double ResourceRate
        {
            get { return _resourceRate; }
            set { _resourceRate = value; }
        }
        #endregion
    }
}
