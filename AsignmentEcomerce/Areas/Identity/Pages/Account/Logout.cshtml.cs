using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AsignmentEcomerce.IdentityServer;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;


namespace AsignmentEcomerce.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly IIdentityServerInteractionService _interaction;

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger, IIdentityServerInteractionService interaction)
        {
            _signInManager = signInManager;
            _logger = logger;
            _interaction = interaction;
        }
        public async Task<IActionResult> OnGet(string returnUrl = null)
        {
            return await this.OnPost(returnUrl);
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            var requestHeader = HttpContext.Request.Headers["Referer"].ToString();
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");

            var logoutId = this.Request.Query["logoutId"].ToString();
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else if (!string.IsNullOrEmpty(logoutId))
            {
                var logoutContext = await this._interaction.GetLogoutContextAsync(logoutId);
                returnUrl = logoutContext.PostLogoutRedirectUri;

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return this.Redirect(returnUrl);
                }
                else
                {
                    var clientIdtemp = logoutContext.ClientIds.ToArray()[0];
                    var referer = IdentityServerConfig.Clients(Startup.clientUrls).Where(item => item.ClientId == clientIdtemp).First();
                    if (referer != null) return this.Redirect(referer.FrontChannelLogoutUri);
                    return Page();
                }
            }
            else
            {
                return RedirectToPage();
            }
        }

        //[BindProperty]
        //public InputModel Input { get; set; }

        //public class InputModel
        //{
        //    [Required]
        //    public string LogoutId { get; set; }
        //}

        //public void OnGet(string logoutId)
        //{
        //    Input = new InputModel { LogoutId = logoutId };
        //}

        //public async Task<IActionResult> OnPost(string returnUrl = null)
        //{
        //    await _signInManager.SignOutAsync();
        //    _logger.LogInformation("User logged out.");

        //    var logout = await _interaction.GetLogoutContextAsync(Input.LogoutId);
        //    if (logout != null && !string.IsNullOrWhiteSpace(logout.PostLogoutRedirectUri))
        //    {
        //        return Redirect(logout.PostLogoutRedirectUri);
        //    }

        //    if (returnUrl != null)
        //    {
        //        return LocalRedirect(returnUrl);
        //    }
        //    else
        //    {
        //        return RedirectToPage();
        //    }
        //}

    }
}
