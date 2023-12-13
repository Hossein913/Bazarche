using App.Domain.Core._Booth.Contracts.AppServices;
using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Dtos.BoothDtos.BoothAppServiceDto;
using App.Domain.Core._User.Dtos.SellersDtos.SellerAppServiceDto;
using App.Domain.Core._User.Entities;
using App.EndPoints.MvcUi.Areas.SellerArea.Models.BoothViewModels;
using App.EndPoints.MvcUi.Areas.SellerArea.Models.SellerViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Controllers
{

    public class SellerPanelController : BaseController
    {
        protected readonly IWebHostEnvironment _webHostEnvironment;
        protected readonly ISellerAppServices _sellerAppServices;
        protected readonly IBoothAppServices _BoothAppServices;
        protected readonly IProductAppServices _productAppServices;
        protected readonly IIdentityAppServices _identityAppServices;
        protected readonly IAddressAppServices _addressAppServices;


        public SellerPanelController(
            ISellerAppServices sellerAppServices,
            IBoothAppServices boothAppServices,
            IProductAppServices productAppServices,
            IIdentityAppServices identityAppServices,
            IWebHostEnvironment webHostEnvironment,
            IAddressAppServices addressAppServices)
        {
            _sellerAppServices = sellerAppServices;
            _BoothAppServices = boothAppServices;
            _productAppServices = productAppServices;
            _identityAppServices = identityAppServices;
            _webHostEnvironment = webHostEnvironment;
            _addressAppServices = addressAppServices;
        }

        [HttpGet]
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            //ViewBag.BoothId = CurrentBoothId;
            //ViewBag.SellerAppUserId = CurrentUserId;
            var SellerUser = await _sellerAppServices.GetDetails(CurrentSellerId, cancellationToken);
            
            if (SellerUser != null)
            {
                

                var Booth = await _BoothAppServices.GetDetailsWithRelations(Convert.ToInt32(SellerUser.BoothId), cancellationToken);
                
                if (Booth.IsActive == true)
                {
                    var Products = await _productAppServices.GetAllForBooth(Convert.ToInt32(SellerUser.BoothId), cancellationToken);
                    Products.Select(
                        p => p.BoothProducts == Booth.BoothProducts.Where(bp => bp.ProductId == p.Id));

                    BoothDetailsViewModel boothDetails = new BoothDetailsViewModel 
                    {
                        BoothId = Booth.Id,
                        sellerId = SellerUser.Id,

                        Firstname = SellerUser.Firstname,
                        Lastname = SellerUser.Lastname,
                        BoothName = Booth.Name,
                        AccountBalance = Booth.AccountBalance,
                        TotalSell = Booth.TotalSell,
                        Description = Booth.Description,
                        Auctions = Booth.Auctions,
                        Products = Products,
                        AvatarPictureFile = Booth.AvatarPicture.ImageUrl,
                        MedalName = Booth.Medal.Name,

                    };
                    return View(boothDetails);
                }
            }
            _identityAppServices.LogOut();
            return RedirectToAction("Login", "Authenticate", new { area="" });
        }



        public async Task<ActionResult> EditBoothProfile(CancellationToken cancellationToken)
        {
            var Booth = await _BoothAppServices.GetDetails(CurrentBoothId, cancellationToken);
            EditBoothProfileViewModel editBoothProfile = new EditBoothProfileViewModel {
                BoothName = Booth.Name,
                Description = Booth.Description,
            };

            return View(editBoothProfile);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditBoothProfile(EditBoothProfileViewModel BoothProfile, CancellationToken cancellationToken)
        {

            if (ModelState.IsValid)
            {

                BoothAppServiceUpdateDto BoothUpdate = new BoothAppServiceUpdateDto
                {
                    BoothId = CurrentBoothId,
                    BoothName = BoothProfile.BoothName ,
                    Description = BoothProfile.Description ,
                    BoothAvatarFile = BoothProfile.BoothAvatarFile ,
                };

                await _BoothAppServices.Update(BoothUpdate, CurrentUserId, _webHostEnvironment.WebRootPath, cancellationToken);
                return RedirectToAction("Index");
            }
            return View(BoothProfile);

        }



            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditSellerProfile(EditSellerProfileViewModel sellerProfile, CancellationToken cancellationToken)
        {
            if(ModelState.IsValid) {

                SellerAppServiceUpdateDto SellerUpdate = new SellerAppServiceUpdateDto
                {
                    SellerId = CurrentSellerId,
                    SellerFirstName = sellerProfile.FirstName,
                    SellerLastName = sellerProfile.LastName,
                    SellerBirthdate = sellerProfile.Birthdate,
                    SellerShabaNumber = sellerProfile.ShabaNumber,
                    ProvinceId = 1,
                    City = sellerProfile.City,
                    FullAddress = sellerProfile.FullAddress,
                    PostalCode = sellerProfile.PostalCode,
                    ProfilePicId = sellerProfile.ProfilePicId,
                    SellerProfilePicFile = sellerProfile.ProfilePicFile,
                };

                await _sellerAppServices.Update(SellerUpdate, _webHostEnvironment.WebRootPath, cancellationToken);
                return RedirectToAction("Index");
            }
            sellerProfile.provinces = await _addressAppServices.GetAllProvinces(CancellationToken.None);
            return View(sellerProfile);
            
        }


        public async Task<ActionResult> Details(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int id, IFormCollection collectionEdit)
        {
            try
            {
                return View();
            }
            catch
            {
                return View();
            }
        }


        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

