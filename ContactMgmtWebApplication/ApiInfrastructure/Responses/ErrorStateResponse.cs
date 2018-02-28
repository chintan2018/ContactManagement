using System.Collections.Generic;
namespace ContactMgmtWebApplication.ApiInfrastructure.Responses
{
    public class ErrorStateResponse
    {
        public string Message { get; set; }
        public IDictionary<string, string[]> ModelState { get; set; }
    }
}