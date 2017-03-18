using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tronc.Timesheet.Common.Entities
{
    public class Year
    {
        #region Attributes

        private int _yearId;
        private string _yearNumber;


        #endregion

        #region Properties
        public int YearId
        {
            get { return _yearId; }
            set { _yearId = value; }
        }
        public string YearNumber
        {
            get { return _yearNumber; }
            set { _yearNumber = value; }
        }
        #endregion
    }
}
