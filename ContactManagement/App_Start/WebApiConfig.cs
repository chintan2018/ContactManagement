using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using ContactModel.POCOClasses;
using ContactModel.Repository;
using Microsoft.Owin.Security.OAuth;

namespace ContactManagement
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Security using bearer token
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            
            
            //Dependency injection code
            var container = new UnityContainer();
            container.RegisterType<IRepository<Contact>, Repository<Contact>>();
            config.DependencyResolver = new UnityResolver(container);
            
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
