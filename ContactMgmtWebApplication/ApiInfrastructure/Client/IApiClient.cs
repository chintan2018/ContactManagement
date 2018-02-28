using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using ContactMgmtWebApplication.ApiInfrastructure.Models;

namespace ContactMgmtWebApplication.ApiInfrastructure.Client
{
    public interface IApiClient
    {
        Task<HttpResponseMessage> GetFormEncodedContent(string requestUri, params KeyValuePair<string, string>[] values);
        Task<HttpResponseMessage> PostFormEncodedContent(string requestUri, params KeyValuePair<string, string>[] values);
        Task<HttpResponseMessage> PostJsonEncodedContent<T>(string requestUri, T content) where T : ApiModel;
    }
}
