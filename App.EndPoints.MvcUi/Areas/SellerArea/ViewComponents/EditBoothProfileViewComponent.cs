using App.Domain.Core._Booth.Contracts.AppServices;
using App.Domain.Core._User.Contracts.AppServices;
using App.EndPoints.MvcUi.Areas.SellerArea.Models.BoothViewModels;
using App.EndPoints.MvcUi.Areas.SellerArea.Models.SellerViewModels;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MvcUi.Areas.SellerArea.ViewComponents
{
    public class EditBoothProfileViewComponent : ViewComponent
    {
        protected readonly IBoothAppServices _boothAppServices;

        public EditBoothProfileViewComponent(ISellerAppServices sellerAppServices, IBoothAppServices boothAppServices)
        {
            _boothAppServices = boothAppServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int SellerAppUserId, CancellationToken cancellationToken)
        {

            //var seller = await _sellerAppServices.GetDetails(SellerAppUserId, cancellationToken);
            //var booth = await _boothAppServices.GetDetails(seller.Id, cancellationToken);
            //EditSellerProfileViewModel editSeller = new EditSellerProfileViewModel
            //{
            //    FirstName = seller.Firstname,
            //    LastName = seller.Lastname,
            //    Birthdate = seller.Birthdate,
            //    ShabaNumber = seller.ShabaNumber,
            //    ProvinceId = seller.Address.ProvinceId,
            //    City = seller.Address.City,
            //    FullAddress = seller.Address.FullAddress,
            //    PostalCode = seller.Address.PostalCode,
            //    ProfilePicUrl = seller.ProfilePic.ImageUrl,
            //    BoothName = booth.Name,
            //    Description = booth.Description,
            //    AvatarPictureUrl = booth.AvatarPicture.ImageUrl

            //};

            return View();
        }
    }
}
