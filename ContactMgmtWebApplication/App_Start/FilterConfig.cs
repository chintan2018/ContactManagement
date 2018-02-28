using System.Web;
using System.Web.Mvc;
using ContactMgmtWebApplication.ErrorHandler;

namespace ContactMgmtWebApplication
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomErrorHandler());
        }
    }
}
