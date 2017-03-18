using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tronc.Timesheet.Common.Entities
{
    public class EmployeeCatagory
    {
        #region Attributes

        private int _employeeCatagoryId;
        private string _employeeCatagoryName;

        #endregion

        #region Properties
        public int EmployeeCatagoryId
        {
            get { return _employeeCatagoryId; }
            set { _employeeCatagoryId = value; }
        }
        public string EmployeeCatagoryName
        {
            get { return _employeeCatagoryName; }
            set { _employeeCatagoryName = value; }
        }

        #endregion

    }
}
