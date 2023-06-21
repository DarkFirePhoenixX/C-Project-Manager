#nullable disable

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectManager.Shared.Entities;
using System.ComponentModel.DataAnnotations;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace ProjectManager.Server.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly SignInManager<User> _signInManager;

        public LoginModel(SignInManager<User> signInManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

                                        [BindProperty]
        public InputModel Input { get; set; }

                                        public IList<AuthenticationScheme> ExternalLogins { get; set; }

                                        public string ReturnUrl { get; set; }

                                        [TempData]
        public string ErrorMessage { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

                        await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                                                SignInResult result = await _signInManager.PasswordSignInAsync(Input.Username, Input.Password, Input.RememberMe, false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa",
                    new
                    {
                        ReturnUrl = returnUrl,
                        Input.RememberMe
                    });
                }

                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                ModelState.AddModelError(string.Empty, "Wrong username or password.");
                return Page();
            }

                        return Page();
        }

                                        public class InputModel
        {
                                                            [Required]
            public string Username { get; set; }

                                                            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

                                                            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }
    }
}
