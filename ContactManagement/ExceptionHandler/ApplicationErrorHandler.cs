﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace ContactManagement.ExceptionHandler
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Server.ClearError();
            if (!EventLog.SourceExists("ContactManagerAPI"))
            {
                EventLog.CreateEventSource("ContactManagerAPI", "ContactManagerAPILog");
            }
            EventLog.WriteEntry("ContactManagerAPI", exception.Message, EventLogEntryType.Error);
            Response.Redirect("/Home/Error");
        }
    }
}