using System.Web.Mvc;
using ContactMgmtWebApplication.ApiInfrastructure.ApiHelper;

namespace ContactMgmtWebApplication.Filters
{
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        private readonly ITokenContainer tokenContainer;

        public AuthenticationAttribute()
        {
            tokenContainer = new TokenContainer();
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (tokenContainer.ApiToken == null)
            {
                filterContext.HttpContext.Response.RedirectToRoute(RouteConfig.logInView);
            }
        }
    }
}