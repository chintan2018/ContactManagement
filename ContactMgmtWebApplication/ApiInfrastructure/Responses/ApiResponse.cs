using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace ContactMgmtWebApplication.ApiInfrastructure.Responses
{
    public class ApiResponse
    {
        public bool StatusIsSuccessful { get; set; }
        public ErrorStateResponse ErrorState { get; set; }
        public HttpStatusCode ResponseCode { get; set; }
        public string ResponseResult { get; set; }
    }

    public abstract class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }
    }
}