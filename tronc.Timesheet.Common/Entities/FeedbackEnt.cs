using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tronc.Timesheet.Common.Entities
{
    public class FeedbackEnt
    {
        #region Attributes

        private int _feedbackId;
        private string _feedbackName;
        private int _companyId;
        private string _companyName;
        private int _employeeCatagoryId;
        private int _feedbackOnId;
        private string _feedbackOnEmployeeNameOrGroup;
        private int _feedbackCategoryId;
        private string _feedbackNote;
        private int _feedbackTypeId;
        private string _ipAddress;
        private string _browser;
        private string _createdBy;
        private DateTime _createdDate;
        private DateTime _fromDate;
        private DateTime _toDate;
        private string _feedbackForCompany;
        private string _employeeCategory;
        private string _feedbackCategory;
        private string _feedbackPurpose;
        private string _incidentNumber;
        private string _feedbackFollowUp;
        private string _contactNumber;
   
        #endregion

        #region Properties
        public int FeedbackId
        {
            get { return _feedbackId; }
            set { _feedbackId = value; }
        }
        public string FeedbackName
        {
            get { return _feedbackName; }
            set { _feedbackName = value; }
        }      
        public int CompanyId
        {
            get { return _companyId; }
            set { _companyId = value; }
        }
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }
        public int EmployeeCatagoryId
        {
            get { return _employeeCatagoryId; }
            set { _employeeCatagoryId = value; }
        }
        public int FeedbackOnId
        {
            get { return _feedbackOnId; }
            set { _feedbackOnId = value; }
        }
        public string FeedbackOnEmployeeNameOrGroup
        {
            get { return _feedbackOnEmployeeNameOrGroup; }
            set { _feedbackOnEmployeeNameOrGroup = value; }
        }
        public int FeedbackCategoryId
        {
            get { return _feedbackCategoryId; }
            set { _feedbackCategoryId = value; }
        }
        public string FeedbackNote
        {
            get { return _feedbackNote; }
            set { _feedbackNote = value; }
        }
        public int FeedbackTypeId
        {
            get { return _feedbackTypeId; }
            set { _feedbackTypeId = value; }
        }
        public string IpAddress
        {
            get { return _ipAddress; }
            set { _ipAddress = value; }
        }
        public string Browser
        {
            get { return _browser; }
            set { _browser = value; }
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
        public DateTime FromDate
        {
            get { return _fromDate; }
            set { _fromDate = value; }
        }
        public DateTime ToDate
        {
            get { return _toDate; }
            set { _toDate = value; }
        }
        public string FeedbackForCompany
        {
            get { return _feedbackForCompany; }
            set { _feedbackForCompany = value; }
        }
        public string EmployeeCategory
        {
            get { return _employeeCategory; }
            set { _employeeCategory = value; }
        }
        public string FeedbackCategory
        {
            get { return _feedbackCategory; }
            set { _feedbackCategory = value; }
        }

        public string FeedbackPurpose
        {
            get { return _feedbackPurpose; }
            set { _feedbackPurpose = value; }
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

        public string ContactNumber
        {
            get { return _contactNumber; }
            set { _contactNumber = value; }
        }
        #endregion
    }
}
