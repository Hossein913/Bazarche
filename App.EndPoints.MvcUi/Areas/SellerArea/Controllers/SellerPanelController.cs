using App.Domain.Core._Booth.Contracts.AppServices;
using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Entities;
using App.EndPoints.MvcUi.Areas.SellerArea.Models.BoothViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Controllers
{

    public class SellerPanelController : BaseController
    {
        protected readonly ISellerAppServices _sellerAppServices;
        protected readonly IBoothAppServices _BoothAppServices;
        protected readonly IProductAppServices _productAppServices;
        protected readonly IIdentityAppServices _identityAppServices;


        public SellerPanelController(
            ISellerAppServices sellerAppServices,
            IBoothAppServices boothAppServices,
            IProductAppServices productAppServices
,
            IIdentityAppServices identityAppServices)
        {
            _sellerAppServices = sellerAppServices;
            _BoothAppServices = boothAppServices;
            _productAppServices = productAppServices;
            _identityAppServices = identityAppServices;
        }

        public async Task<ActionResult> Index(int id, CancellationToken cancellationToken)
        {
            var SellerUser = await _sellerAppServices.GetDetail(id, cancellationToken);
            
            if (SellerUser != null)
            {
                var Booth = await _BoothAppServices.GetDetail(Convert.ToInt32(SellerUser.BoothId), cancellationToken);
                
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
            return RedirectToAction("Login", "Authenticate");
        }


        public async Task<ActionResult> Details(int id)
        {
            return View();
        }


        public async Task<ActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
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


        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
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
