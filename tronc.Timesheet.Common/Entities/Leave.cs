using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tronc.Timesheet.Common.Entities
{
    public class Leave
    {
        #region Attributes

        private int _leaveId;
        private int _resourceId;
        private string _resourceName;
        private string _resourceEmail;
        private int _yId;
        private int _monthId;
        private int _lDay;
        private DateTime _leaveDate;
        private string _ultimatixId;
        private string _leaveReason;
        private string _backupPlan;
        private string _createdBy;
        private DateTime _createdDate;
        private string _modifiedBy;
        private DateTime _modifiedDate;
        private string _isActive;
        private string _resourceLeaveId;
        private string _projectName;
        private string _roleName; 
        private string _segmentName;
        

      

        #endregion

        #region Properties
        public int ResourceId
        {
            get { return _resourceId; }
            set { _resourceId = value; }
        }
        public int YId
        {
            get { return _yId; }
            set { _yId = value; }
        }
        public int MonthId
        {
            get { return _monthId; }
            set { _monthId = value; }
        }
        public int LDay
        {
            get { return _lDay; }
            set { _lDay = value; }
        }
        public DateTime LeaveDate
        {
            get { return _leaveDate; }
            set { _leaveDate = value; }
        }
        public string UltimatixId
        {
            get { return _ultimatixId; }
            set { _ultimatixId = value; }
        }
        public string LeaveReason
        {
            get { return _leaveReason; }
            set { _leaveReason = value; }
        }
        public string BackupPlan
        {
            get { return _backupPlan; }
            set { _backupPlan = value; }
        }
        public string CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
        public int LeaveId
        {
            get { return _leaveId; }
            set { _leaveId = value; }
        }
        public string ModifiedBy
        {
            get { return _modifiedBy; }
            set { _modifiedBy = value; }
        }
        public DateTime ModifiedDate
        {
            get { return _modifiedDate; }
            set { _modifiedDate = value; }
        }
        public string IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
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
        public string ResourceLeaveId
        {
            get { return _resourceLeaveId; }
            set { _resourceLeaveId = value; }
        }
        public string ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; }
        }
        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
        }
        public string SegmentName
        {
            get { return _segmentName; }
            set { _segmentName = value; }
        }
        #endregion
    }
}
