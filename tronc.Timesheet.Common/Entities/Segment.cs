using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tronc.Timesheet.Common.Entities
{
    public class Segment
    {
        #region Attributes

        private int _segmentId;   
        private string _segmentName;
          
        

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
        #endregion


    }
}
