using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tronc.Timesheet.Common.Entities;

namespace tronc.Timesheet.Web.Utils
{
    public static class SessionManager
    {
        public static Resource UserDetails
        {
            get
            {
                if (HttpContext.Current.Session["UserDetails"] != null)
                {
                    return (Resource)(HttpContext.Current.Session["UserDetails"]);
                }
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session["UserDetails"] = value;
            }
        }
    }
}