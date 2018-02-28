using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace ContactMgmtWebApplication.ErrorHandler
{
    public class CustomErrorHandler : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
           

                Exception ex = filterContext.Exception;
                filterContext.ExceptionHandled = true;
                
                //if (!EventLog.SourceExists("ContactManager"))
                //{
                //    EventLog.CreateEventSource("ContactManager", "ContactManagerLog");
                //}
                //EventLog.WriteEntry("ContactManager", ex.Message, EventLogEntryType.Error);

                var model = new HandleErrorInfo(ex, filterContext.RouteData.Values["controller"].ToString(), filterContext.RouteData.Values["action"].ToString());

                filterContext.Result = new ViewResult()
                {
                    ViewName = "Error",
                    ViewData = new ViewDataDictionary(model)
                };
            
        }
    }
}