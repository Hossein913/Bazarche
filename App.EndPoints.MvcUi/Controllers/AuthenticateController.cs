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
    [AllowAnonymous]
    public class AuthenticateController : Controller
    {
        private readonly IIdentityAppServices _appServices;

        public AuthenticateController(IIdentityAppServices appServices)
        {
            _appServices = appServices;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

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
                            return RedirectToAction("Index", "AdminPanel", new { area = "AdminArea" });

                        else if (roles != null && roles.Contains("Seller"))
                            return RedirectToAction("Index", "SellerPanel", new { area = "SellerArea" });

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

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SellerRegister(SellerRegisterViewModel sellerRegisterViewModel)
        {
            return View();
        }


        [HttpPost]
        public ActionResult CustomerRegister(CustomerRegisterViewModel customerRegisterVM)
        {
            return View();
        }



        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            _appServices.LogOut();
            return RedirectToAction("Index", "Home");
        }


    }
}
