using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tronc.Timesheet.Common.Entities
{
    public class ResourceEffort
    {
        #region Attributes

        private int _segmentId;
        private string _segmentName;
        private int _resourceId;
        private string _resourceName;
        private string _resourceEmail;
        private string _resourceContact;

       
        private int _yeadId;
        private string _yearName;
        private int _monthId;
        private string _monthName;
        private string _eOne;
        private string _eTwo;
        private string _eThree;
        private string _eFour;
        private string _eFive;
        private string _eSix;
        private string _eSeven;
        private string _eEight;
        private string _eNine;
        private string _eTen;
        private string _eEleven;
        private string _eTwelve;
        private string _eThirteen;
        private string _eFourteen;
        private string _eFifteen;
        private string _eSixteen;
        private string _eSeventeen;
        private string _eEighteen;
        private string _eNineteen;
        private string _eTwenty;
        private string _eTwentyOne;
        private string _eTwentyTwo;
        private string _eTwentyThree;
        private string _eTwentyFour;
        private string _eTwentyFive;
        private string _eTwentySix;
        private string _eTwentySeven;
        private string _eTwentyEight;
        private string _eTwentyNine;
        private string _eThirty;
        private string _eThirtyOne;
        private int _totalEffort;
        private string _queryParameters;
        private double _resourceRate;
        private double _totalMonthRate;

        

       




        #endregion

        #region Properties
        public int SegmentId
        {
            get { return _segmentId; }
            set { _segmentId = value; }
        }
        public string SegmentName
        {
            get { return _segmentName; }
            set { _segmentName = value; }
        }
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
        public string ResourceContact
        {
            get { return _resourceContact; }
            set { _resourceContact = value; }
        }
        public int YeadId
        {
            get { return _yeadId; }
            set { _yeadId = value; }
        }
        public string YearName
        {
            get { return _yearName; }
            set { _yearName = value; }
        }
        public int MonthId
        {
            get { return _monthId; }
            set { _monthId = value; }
        }
        public string MonthName
        {
            get { return _monthName; }
            set { _monthName = value; }
        }
        public string EOne
        {
            get { return _eOne; }
            set { _eOne = value; }
        }
        public string ETwo
        {
            get { return _eTwo; }
            set { _eTwo = value; }
        }
        public string EThree
        {
            get { return _eThree; }
            set { _eThree = value; }
        }
        public string EFour
        {
            get { return _eFour; }
            set { _eFour = value; }
        }
        public string EFive
        {
            get { return _eFive; }
            set { _eFive = value; }
        }
        public string ESix
        {
            get { return _eSix; }
            set { _eSix = value; }
        }
        public string ESeven
        {
            get { return _eSeven; }
            set { _eSeven = value; }
        }
        public string EEight
        {
            get { return _eEight; }
            set { _eEight = value; }
        }
        public string ENine
        {
            get { return _eNine; }
            set { _eNine = value; }
        }
        public string ETen
        {
            get { return _eTen; }
            set { _eTen = value; }
        }
        public string EEleven
        {
            get { return _eEleven; }
            set { _eEleven = value; }
        }
        public string ETwelve
        {
            get { return _eTwelve; }
            set { _eTwelve = value; }
        }
        public string EThirteen
        {
            get { return _eThirteen; }
            set { _eThirteen = value; }
        }
        public string EFourteen
        {
            get { return _eFourteen; }
            set { _eFourteen = value; }
        }
        public string EFifteen
        {
            get { return _eFifteen; }
            set { _eFifteen = value; }
        }
        public string ESixteen
        {
            get { return _eSixteen; }
            set { _eSixteen = value; }
        }
        public string ESeventeen
        {
            get { return _eSeventeen; }
            set { _eSeventeen = value; }
        }
        public string EEighteen
        {
            get { return _eEighteen; }
            set { _eEighteen = value; }
        }
        public string ENineteen
        {
            get { return _eNineteen; }
            set { _eNineteen = value; }
        }
        public string ETwenty
        {
            get { return _eTwenty; }
            set { _eTwenty = value; }
        }
        public string ETwentyOne
        {
            get { return _eTwentyOne; }
            set { _eTwentyOne = value; }
        }
        public string ETwentyTwo
        {
            get { return _eTwentyTwo; }
            set { _eTwentyTwo = value; }
        }
        public string ETwentyThree
        {
            get { return _eTwentyThree; }
            set { _eTwentyThree = value; }
        }
        public string ETwentyFour
        {
            get { return _eTwentyFour; }
            set { _eTwentyFour = value; }
        }
        public string ETwentyFive
        {
            get { return _eTwentyFive; }
            set { _eTwentyFive = value; }
        }
        public string ETwentySix
        {
            get { return _eTwentySix; }
            set { _eTwentySix = value; }
        }
        public string ETwentySeven
        {
            get { return _eTwentySeven; }
            set { _eTwentySeven = value; }
        }
        public string ETwentyEight
        {
            get { return _eTwentyEight; }
            set { _eTwentyEight = value; }
        }
        public string ETwentyNine
        {
            get { return _eTwentyNine; }
            set { _eTwentyNine = value; }
        }
        public string EThirty
        {
            get { return _eThirty; }
            set { _eThirty = value; }
        }
        public string EThirtyOne
        {
            get { return _eThirtyOne; }
            set { _eThirtyOne = value; }
        }
        public int TotalEffort
        {
            get { return _totalEffort; }
            set { _totalEffort = value; }
        }
        public string QueryParameters
        {
            get { return _queryParameters; }
            set { _queryParameters = value; }
        }
        public double TotalMonthRate
        {
            get { return _totalMonthRate; }
            set { _totalMonthRate = value; }
        }
        public double ResourceRate
        {
            get { return _resourceRate; }
            set { _resourceRate = value; }
        }
        #endregion
    }
}
