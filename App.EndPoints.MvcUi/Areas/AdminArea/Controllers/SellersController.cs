using App.Domain.AppServices.User;
using App.Domain.Core._Booth.Dtos.MedalDtos;
using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Common.Dtos.PictureDtos;
using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Dtos.SellersDtos.SellerAppServiceDto;
using App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Sellers;
using App.Frameworks.Web.DateConverter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MvcUi.Areas.AdminArea.Controllers
{
    public class SellersController : AdminBaseController
    {
        protected readonly ISellerAppServices _SellerApp;
        protected readonly IAddressAppServices _addressApp;
        protected readonly IWebHostEnvironment _webHostEnvironment;

        public SellersController(ISellerAppServices sellerApp, IAddressAppServices addressApp, IWebHostEnvironment webHostEnvironment)
        {
            _SellerApp = sellerApp;
            _addressApp = addressApp;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var result = await _SellerApp.GetAll(cancellationToken);
            var viewModel = result.Select(s => new GetAllSellersViewModel
            {
                SellerId = s.Id ,
                Firstname = s.Firstname ,
                Lastname = s.Lastname ,
                BoothId = s.Booth.Id ,
                BoothName = s.Booth.Name ,
                IsBoothActive = s.Booth.IsActive,
                AvatarPicture = new PictureOutputDto { Id = s.Booth.AvatarPicture.Id, ImageUrl = s.Booth.AvatarPicture.ImageUrl },
                Medal = new MedalOutputDto{ Name = s.Booth.Medal.Name },
                Email = s.AppUser.Email ,
                AppUserId = s.AppUser.Id ,
                IsUserActive = s.AppUser.IsActive,
                CreatedAt = s.AppUser.CreatedAt.ToPersianAlfabeticDate(),
            }).ToList();
            return View(viewModel);
        }

        public async Task<ActionResult> Details(int sellerId, CancellationToken cancellationToken)
        {
            var result = await _SellerApp.GetDetailWithRilations(sellerId,cancellationToken);
            GetSellerDetailsViewModel sellerViewModel = new GetSellerDetailsViewModel
            {
                Id = result.Id,
                FirstName = result.Firstname,
                LastName = result.Lastname,
                Birthdate = result.Birthdate.ToPersianAlfabeticDate(),
                ShabaNumber = result.ShabaNumber,
                Address = result.Address,
                //ProfilePicUrl = result.ProfilePic.ImageUrl,
                Booth = result.Booth,
                AppUser = result.AppUser,
            };
            return View(sellerViewModel);
        }

        public async Task<ActionResult> Edit(int sellerId, CancellationToken cancellationToken)
        {
            var result = await _SellerApp.GetDetail(sellerId, cancellationToken);
            var provinces = await _addressApp.GetAllProvinces(cancellationToken);
            UpdateSellerViewModel updateSeller = new UpdateSellerViewModel
            {
                Id= result.Id,
                FirstName = result.Firstname,
                LastName = result.Lastname,
                Birthdate = result.Birthdate.ToPersianNumericDate(),
                ShabaNumber = result.ShabaNumber,
                ProvinceId = result.Address.ProvinceId,
                City = result.Address.City,
                FullAddress = result.Address.FullAddress,
                PostalCode = result.Address.PostalCode,
                //ProfilePicUrl = result.ProfilePic.ImageUrl,
                //ProfilePicId = result.ProfilePic.Id,
                Provinces = provinces,
            };


            return View(updateSeller);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UpdateSellerViewModel updateSeller, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid) {

                SellerAppServiceUpdateDto sellerAppServiceUpdate = new SellerAppServiceUpdateDto 
                {
                    Id = updateSeller.Id ,
                    FirstName = updateSeller.FirstName,
                    LastName = updateSeller.LastName,
                    Birthdate = ConvertTo.GregorianDate( updateSeller.Birthdate ),
                    ShabaNumber = updateSeller.ShabaNumber,
                    ProvinceId = updateSeller.ProvinceId,
                    City = updateSeller.City ,
                    FullAddress = updateSeller.FullAddress, 
                    PostalCode = updateSeller.PostalCode ,
                };

                await _SellerApp.Update(sellerAppServiceUpdate, _webHostEnvironment.WebRootPath,cancellationToken);
                return RedirectToAction("Details",new { sellerId = updateSeller.Id});
            }
            var provinces = await _addressApp.GetAllProvinces(cancellationToken);
            updateSeller.Provinces = provinces;
            return View(updateSeller);
        }

        public async Task<ActionResult> Delete(int sellerId, int boothId, CancellationToken cancellationToken)
        {
            await _SellerApp.SoftDelete(sellerId, boothId, cancellationToken);
            return Redirect(Request.Headers["Referer"].ToString());
        }


        public async Task<ActionResult> SetActivity(int sellerId, bool status, CancellationToken cancellationToken)
        {
            await _SellerApp.SetActivity(sellerId, status, cancellationToken);
            return Redirect(Request.Headers["Referer"].ToString());
        }


        public async Task<ActionResult> Create(CancellationToken cancellationToken)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection, CancellationToken cancellationToken)
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


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Delete(int id, IFormCollection collection, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //return View();
        //    }
        //}
    }
}
