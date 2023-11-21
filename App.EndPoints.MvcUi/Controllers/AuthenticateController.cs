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
                            return RedirectToAction("Index", "AdminPanel", new { area = "AdminArea", id = appUser.Id });

                        else if (roles != null && roles.Contains("Seller"))
                            return RedirectToAction("index", "SellerPanel", new { area = "SellerArea", id= appUser.Id });

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


        [AllowAnonymous]
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult SellerRegister(SellerRegisterViewModel sellerRegisterViewModel)
        {
            return View();
        }

        [AllowAnonymous]
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
