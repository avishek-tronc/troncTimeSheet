using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tronc.Timesheet.Common.Entities
{
    public class Company
    {
        #region Attributes

        private int _companyId;
        private string _companyName;
       
        #endregion

        #region Properties
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

        #endregion

    }
}
