using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RnD.MySqlCoreSample.Core;
using RnD.MySqlCoreSample.Helpers;
using RnD.MySqlCoreSample.Identity;
using RnD.MySqlCoreSample.ViewModels;
using System;
using System.Threading.Tasks;

namespace RnD.MySqlCoreSample.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        #region Global Variable Declaration
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger<AccountController> _logger;
        #endregion

        #region Constructor
        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _logger = logger;
        }
        #endregion

        #region Actions

        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            try
            {
                LoginViewModel model = new LoginViewModel();
                model.ReturnUrl = returnUrl;
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return View("Error");
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ApplicationUser user = await _userManager.FindByNameAsync(model.Email);
                    if (user != null)
                    {
                        await _signInManager.SignOutAsync();
                        // This doesn't count login failures towards account lockout
                        // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                        if (result.Succeeded)
                        {
                            var isAdmin = await _userManager.IsInRoleAsync(user, AppConstants.AppUserRole.Admin);
                            if (isAdmin)
                            {
                                if (string.IsNullOrEmpty(model.ReturnUrl))
                                {
                                    return RedirectToAction("Index", "Admin");
                                }
                                return Redirect(model.ReturnUrl);
                            }
                            else
                            {
                                return RedirectToLocal(model.ReturnUrl);
                            }

                        }

                        if (result.IsLockedOut)
                        {
                            return View("Lockout");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                            return View(model);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, MessageHelper.Error);
                _logger.LogError(ex.Message);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        //
        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            try
            {
                RegisterViewModel model = new RegisterViewModel();
                model.ReturnUrl = returnUrl;
                model.RoleName = AppConstants.AppUserRole.Admin.ToString();
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return View("Error");
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string userName = ((model.Email).Split('@')[0]).Trim(); // you are get here username.

                    var user = new ApplicationUser
                    {
                        UserName = model.Email,
                        Email = model.Email
                    };

                    var isEmailExists = await IsEmailExists(user);
                    if (isEmailExists)
                    {
                        ModelState.AddModelError(string.Empty, MessageHelper.AlreadyExists);
                        return View(model);
                    }

                    var role = new ApplicationRole
                    {
                        Id = model.RoleName,
                        Name = model.RoleName,
                        IsActive = true
                    };

                    IdentityResult resultRole = await _roleManager.CreateAsync(role);

                    if (resultRole.Succeeded)
                    {
                        var result = await _userManager.CreateAsync(user, model.Password);
                        if (result.Succeeded)
                        {
                            await _userManager.AddToRoleAsync(user, model.RoleName);
                            await _signInManager.SignInAsync(user, isPersistent: false);

                            var isAdmin = await _userManager.IsInRoleAsync(user, AppConstants.AppUserRole.Admin);
                            if (isAdmin)
                            {
                                if (string.IsNullOrEmpty(model.ReturnUrl))
                                {
                                    return RedirectToAction("Index", "Admin");
                                }
                                return Redirect(model.ReturnUrl);
                            }
                            else
                            {
                                return RedirectToLocal(model.ReturnUrl);
                            }

                        }

                        AddErrors(result);
                    }

                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, MessageHelper.Error);
                _logger.LogError(ex.Message);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await _signInManager.SignOutAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return RedirectToAction("Login", "Account");
        }

        private async Task<bool> IsEmailExists(ApplicationUser user)
        {
            try
            {
                var isExists = await _userManager.FindByEmailAsync(user.Email);

                if (isExists != null)
                {
                    string isEmailExistsMessage = string.Format(MessageHelper.IsEmailExists, user.Email);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, MessageHelper.Error);
                _logger.LogError(ex.Message);
                return false;
            }
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion

        #endregion
    }
}