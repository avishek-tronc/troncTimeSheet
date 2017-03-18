using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tronc.Timesheet.Common.Entities
{
    public class Tower
    {
        #region Attributes

        private int _towerId;
        private string _towerName;

        #endregion

        #region Properties
        public int TowerId
        {
            get { return _towerId; }
            set { _towerId = value; }
        }
        public string TowerName
        {
            get { return _towerName; }
            set { _towerName = value; }
        }
        #endregion
    }
}
