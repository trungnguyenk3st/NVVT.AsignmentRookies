using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSite.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult SignIn()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" });
        }
        public new IActionResult SignOut()
        {
            return SignOut(new AuthenticationProperties { RedirectUri = "/" }, "Cookies", "oidc");
        }

        [Authorize]
        public ActionResult MyProfile()
        {
            return View();
        }
    }
}
