using App.Domain.AppServices.User;
using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Dtos.Authenticate;
using App.Domain.Core._User.Dtos.CustommersDtos;
using App.Domain.Core._User.Dtos.SellersDtos.SellerAppServiceDto;
using App.Domain.Core._User.Entities;
using App.EndPoints.MvcUi.Models.Authenticate;
using Infrastructure.IdentityConfigs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading;

namespace App.EndPoints.MvcUi.Controllers
{
    [AllowAnonymous]
    public class AuthenticateController : Controller
    {
        private readonly IIdentityAppServices _identityApp;
        private readonly IAddressAppServices _addressApp;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public AuthenticateController(IIdentityAppServices appServices, IAddressAppServices addressApp, IWebHostEnvironment hostingEnvironment)
        {
            _identityApp = appServices;
            _addressApp = addressApp;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public async Task<ActionResult> Login()
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


                AppUser appUser = await _identityApp.GetAppUser(userLogin, cancellationToken);

                if (appUser != null)
                {
                    var result = await _identityApp.Login(appUser, userLogin, cancellationToken);
                    if (result != null)
                    {
                        if ( result.Succeeded)
                        {
                            var roles = await _identityApp.GetRoles(appUser, cancellationToken);


                            if (roles != null && roles.Contains("Admin"))
                                return RedirectToAction("Index", "AdminPanel", new { area = "AdminArea" });

                            else if (roles != null && roles.Contains("Seller"))
                                return RedirectToAction("Index", "SellerPanel", new { area = "SellerArea" });

                            else
                                return RedirectToAction("Index", "Customer");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "رمز عبور صحیح نمی باشد.");

                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "حساب شما به حالت تعلیق در آمده است.");

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
        public async Task<ActionResult> SellerRegister(CancellationToken cancellationToken)
        {
            var provinces = await _addressApp.GetAllProvinces(cancellationToken);
            SellerRegisterViewModel sellerRegister = new SellerRegisterViewModel
            {
                provinces = provinces
            };
            return View(sellerRegister);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SellerRegister(SellerRegisterViewModel sellerRegisterViewModel, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                SellerRegisterDto sellerRegister = new SellerRegisterDto
                {
                    FirstName =sellerRegisterViewModel.FirstName ,
                    LastName =sellerRegisterViewModel.LastName ,
                    ShabaNumber =sellerRegisterViewModel.ShabaNumber ,
                    Email =sellerRegisterViewModel.Email ,
                    Password =sellerRegisterViewModel.Password ,
                    ProvinceId =sellerRegisterViewModel.ProvinceId ,
                    City =sellerRegisterViewModel.City ,
                    Address =sellerRegisterViewModel.Address,
                    PostalCode =sellerRegisterViewModel.PostalCode ,
                    BoothName =sellerRegisterViewModel.BoothName ,
                    Description =sellerRegisterViewModel.Description ,
                    BoothAvatar =sellerRegisterViewModel.BoothAvatar ,
                };
                var resutl = await _identityApp.SellerRegister(sellerRegister, _hostingEnvironment.WebRootPath, cancellationToken);
                if (resutl == null)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    resutl.ForEach(e => ModelState.AddModelError(string.Empty, e.Description));

                }

            }
            sellerRegisterViewModel.provinces = await _addressApp.GetAllProvinces(cancellationToken);
            return View(sellerRegisterViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> CustomerRegister(CancellationToken cancellationToken)
        {
            var provinces = await _addressApp.GetAllProvinces(cancellationToken);
            CustomerRegisterViewModel customerRegister = new CustomerRegisterViewModel {
              provinces = provinces,
            };
            return View(customerRegister);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CustomerRegister(CustomerRegisterViewModel customerRegisterVM, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                CustomerRegisterDto customerRegister = new CustomerRegisterDto
                {
                    Email = customerRegisterVM.Email,
                    Password = customerRegisterVM.Password,
                    FirstName = customerRegisterVM.FirstName,
                    LastName = customerRegisterVM.LastName,
                    ProvinceId = customerRegisterVM.ProvinceId,
                    City = customerRegisterVM.City,
                    Address = customerRegisterVM.Address,
                    PostalCode = customerRegisterVM.PostalCode,
                };
                var resutl = await _identityApp.CustomerRegister(customerRegister, cancellationToken);
                if (resutl == null)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    resutl.ForEach(e => ModelState.AddModelError(string.Empty, e.Description));
                    
                }
            }
            customerRegisterVM.provinces = await _addressApp.GetAllProvinces(cancellationToken);
            
            return View(customerRegisterVM);
        }



        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            _identityApp.LogOut();
            return RedirectToAction("Index", "Home");
        }


    }
}
