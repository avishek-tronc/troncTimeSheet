using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tronc.Timesheet.Common.Entities
{
    public class EmailEnt
    {
        private string _to;
        private string _from;
        private string _subject;
        private string _body;
        private string _userName;
        private string _password;
        private string _host;
        private int _port;

        public string To
        {
            get { return _to; }
            set { _to = value; }
        }

        public string From
        {
            get { return _from; }
            set { _from = value; }
        }

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public string Body
        {
            get { return _body; }
            set { _body = value; }
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

        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }

        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

     
    }
}
