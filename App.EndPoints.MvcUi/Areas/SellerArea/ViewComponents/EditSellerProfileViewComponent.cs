using App.Domain.Core._Booth.Contracts.AppServices;
using App.Domain.Core._User.Contracts.AppServices;
using App.EndPoints.MvcUi.Areas.SellerArea.Models.BoothViewModels;
using App.EndPoints.MvcUi.Areas.SellerArea.Models.SellerViewModels;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MvcUi.Areas.SellerArea.ViewComponents
{
    public class EditSellerProfileViewComponent : ViewComponent
    {
        protected readonly ISellerAppServices _sellerAppServices;

        public EditSellerProfileViewComponent(ISellerAppServices sellerAppServices, IBoothAppServices boothAppServices)
        {
            _sellerAppServices = sellerAppServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(int SellerAppUserId, CancellationToken cancellationToken)
        {

            var seller = await _sellerAppServices.GetDetails(SellerAppUserId, cancellationToken);
            EditSellerProfileViewModel editSeller = new EditSellerProfileViewModel
            {
                FirstName = seller.Firstname,
                LastName = seller.Lastname,
                Birthdate = seller.Birthdate,
                ShabaNumber = seller.ShabaNumber,
                ProvinceId = seller.Address.ProvinceId,
                City = seller.Address.City,
                FullAddress = seller.Address.FullAddress,
                PostalCode = seller.Address.PostalCode,
                ProfilePicUrl = seller.ProfilePic.ImageUrl,
                ProfilePicId = seller.ProfilePic.Id
            };

            return View(editSeller);
        }
    }
}
