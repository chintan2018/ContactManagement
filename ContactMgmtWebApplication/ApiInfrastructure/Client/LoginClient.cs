using System.Collections.Generic;
using ContactMgmtWebApplication.ApiInfrastructure.Models;
using ContactMgmtWebApplication.ApiInfrastructure.Responses;
using ContactMgmtWebApplication.Models;
using System.Threading.Tasks;
using System.Net.Http;

namespace ContactMgmtWebApplication.ApiInfrastructure.Client
{
    public class LoginClient : ClientBase, ILoginClient
    {
        private const string RegisterUri = "http://localhost/contactmanagement/api/register";
        private const string TokenUri = "http://localhost/contactmanagement/Token";
        //private const string RegisterUri = "http://localhost:3045/api/register";
        //private const string TokenUri = "http://localhost:3045/Token";

        public LoginClient(IApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<RegisterResponse> Register(RegisterViewModel viewModel)
        {
            var apiModel = new RegisterApiModel
            {
                ConfirmPassword = viewModel.ConfirmPassword,
                Email = viewModel.Email,
                Password = viewModel.Password
            };
            var response = await ApiClient.PostJsonEncodedContent(RegisterUri, apiModel);
            var registerResponse = await CreateJsonResponse<RegisterResponse>(response);
            return registerResponse;
        }

        public async Task<TokenResponse> Login(string email, string password)
        {
            var response = await ApiClient.PostFormEncodedContent(TokenUri, "grant_type".AsPair("password"),
                "username".AsPair(email), "password".AsPair(password));
            //(TokenUri,password,
            //    "username".AsPair(email), "password".AsPair(password));
            var tokenResponse = await CreateJsonResponse<TokenResponse>(response);
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await DecodeContent<dynamic>(response);
                tokenResponse.ErrorState = new ErrorStateResponse
                {
                    ModelState = new Dictionary<string, string[]>
                {
                    {errorContent["error"],
                    new string[] {errorContent["error_description"]}}
                }
                };
                return tokenResponse;
            }

            var tokenData = await DecodeContent<dynamic>(response);
            tokenResponse.Data = tokenData["access_token"];
            return tokenResponse;
        }

       
    }
}