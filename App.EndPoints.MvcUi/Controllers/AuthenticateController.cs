using App.Domain.AppServices.User;
using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Dtos.Authenticate;
using App.Domain.Core._User.Entities;
using App.EndPoints.MvcUi.Models.Authenticate;
using Infrastructure.IdentityConfigs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace App.EndPoints.MvcUi.Controllers
{
    public class AuthenticateController : Controller
    {
        private readonly IIdentityAppServices _appServices;

        public AuthenticateController(IIdentityAppServices appServices)
        {
            _appServices = appServices;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel LoginModel, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {

                UserLoginDto userLogin = new UserLoginDto
                {
                    Email = LoginModel.Email,
                    Password = LoginModel.Password,
                    IsPersistent = LoginModel.RememberMe
                };


                AppUser appUser = await _appServices.GetAppUser(userLogin, cancellationToken);

                if (appUser != null)
                {
                    var result = await _appServices.Login(appUser, userLogin, cancellationToken);
                    if (result.Succeeded)
                    {
                        var roles = await _appServices.GetRoles(appUser, cancellationToken);

                        if (roles != null && roles.Contains("Admin"))
                            return RedirectToAction("Index", "AdminPanel", new { area = "Admin" });

                        else if (roles != null && roles.Contains("Customer"))
                            return RedirectToAction("index", "Panel", new { area = "Customer" });

                        else
                            return RedirectToAction("index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "رمز عبور صحیح نمی باشد.");

                    }
                }
                else 
                { 
                    ModelState.AddModelError(string.Empty, "کاربری با این مشخصات یافت نشد");     
                }
                
            }
            return View(LoginModel);

        }


        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            _appServices.LogOut();
            return RedirectToAction("Index", "Home");
        }


    }
}
