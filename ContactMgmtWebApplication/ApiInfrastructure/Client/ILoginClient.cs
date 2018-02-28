using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactMgmtWebApplication.ApiInfrastructure.Responses;
using ContactMgmtWebApplication.Models;

namespace ContactMgmtWebApplication.ApiInfrastructure.Client
{
    public interface ILoginClient
    {
        Task<RegisterResponse> Register(RegisterViewModel viewModel);
        Task<TokenResponse> Login(string email, string password);
    }

}
