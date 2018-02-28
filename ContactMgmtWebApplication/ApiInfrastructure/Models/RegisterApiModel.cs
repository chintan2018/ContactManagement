using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactMgmtWebApplication.ApiInfrastructure.Models
{
    public class RegisterApiModel : ApiModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}