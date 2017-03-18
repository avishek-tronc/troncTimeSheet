using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace tronc.Timesheet.Common.Entities
{
    [DataContract]
    public class HeaderEntity
    {
        #region Attributes

        [DataMember(IsRequired = true)]
        private string _guid;

        [DataMember(IsRequired = true)]
        private string _userName;

        [DataMember(IsRequired = true)]
        private string _password;

        


        #endregion

        #region Properties
        public string Guid
        {
            get { return _guid; }
            set { _guid = value; }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        #endregion
    }
}
