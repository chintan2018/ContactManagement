using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace ContactManagement.ExceptionHandler
{
    public class CustomErrorHandler : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            if (!EventLog.SourceExists("ContactManagerAPI"))
            {
                EventLog.CreateEventSource("ContactManagerAPI", "ContactManagerAPILog");
            }
            EventLog.WriteEntry("ContactManagerAPI", ex.Message, EventLogEntryType.Error);
        }
    }
}