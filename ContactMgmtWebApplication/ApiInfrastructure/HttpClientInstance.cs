using System;
using System.Net.Http;

namespace ContactMgmtWebApplication.ApiInfrastructure
{
    /// <summary>
    /// Creates a Singleton instance of HttpClient - note that this is for demo purposes only. 
    /// I would recommend that you use a Dependency Injection container such as Autofac for managing the lifecycle of your objects.
    /// If we used Autofac here there would be no need for this class.
    /// </summary>
    public static class HttpClientInstance
    {
        private const string BaseUri = "Http://localhost/ContactsManager/";
        //private const string BaseUri = "Http://localhost:13961/";
        private static readonly HttpClient instance = new HttpClient { BaseAddress = new Uri(BaseUri) };

        public static HttpClient Instance
        {
            get { return instance; }
        }
    }
}