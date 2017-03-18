using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tronc.Timesheet.Common.Entities
{
    public class Month
    {
        #region Attributes

        private int _monthId;
        private string _monthName;    


        #endregion

        #region Properties
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
        #endregion
    }
}
