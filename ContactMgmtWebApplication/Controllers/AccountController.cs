using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactMgmtWebApplication.Models;
using System.Threading.Tasks;
using ContactMgmtWebApplication.ApiInfrastructure.Client;
using System.Net.Http;
using ContactMgmtWebApplication.ApiInfrastructure.ApiHelper;
using ContactMgmtWebApplication.ApiInfrastructure;
using ContactMgmtWebApplication.ApiInfrastructure.Responses;

namespace ContactMgmtWebApplication.Controllers
{
    public class AccountController : Controller
    {

        private readonly ILoginClient loginClient;
        private readonly ITokenContainer tokenContainer;

        public ActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }

        public ActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        /// <summary>
        /// Default parameterless constructor. 
        /// Delete this if you are using a DI container.
        /// </summary>
        public AccountController()
        {
            tokenContainer = new TokenContainer();
            var apiClient = new ApiClient(HttpClientInstance.Instance,tokenContainer);
            loginClient = new LoginClient(apiClient);
        }

        /// <summary>
        /// Default constructor with dependency.
        /// Delete this if you aren't planning on using a DI container.
        /// </summary>
        /// <param name="loginClient">The login client.</param>
        /// <param name="tokenContainer">The token container.</param>
        public AccountController(ILoginClient loginClient, ITokenContainer tokenContainer)
        {
            this.loginClient = loginClient;
            this.tokenContainer = tokenContainer;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            var response = await loginClient.Register(model);
            if (response.StatusIsSuccessful)
            {
                return RedirectToAction("Index", "Home");
            }

            AddResponseErrorsToModelState(response);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            var loginSuccess = await PerformLoginActions(model.Email, model.Password);
            if (loginSuccess)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.Clear();
            ModelState.AddModelError("", "The username or password is incorrect");
            return View(model);
        }

        // Register methods go here, removed for brevity

        private async Task<bool> PerformLoginActions(string email, string password)
        {
            var response = await loginClient.Login(email, password);
            if (response.StatusIsSuccessful)
            {
                tokenContainer.ApiToken = response.Data;
            }
            else
            {
                AddResponseErrorsToModelState(response);
            }

            return response.StatusIsSuccessful;
        }

        protected void AddResponseErrorsToModelState(ApiResponse response)
        {
            var errors = response.ErrorState.ModelState;
            if (errors == null)
            {
                return;
            }

            foreach (var error in errors)
            {
                foreach (var entry in
                    from entry in ModelState
                    let matchSuffix = string.Concat(".", entry.Key)
                    where error.Key.EndsWith(matchSuffix)
                    select entry)
                {
                    ModelState.AddModelError(entry.Key, error.Value[0]);
                }
            }
        }
    }
}