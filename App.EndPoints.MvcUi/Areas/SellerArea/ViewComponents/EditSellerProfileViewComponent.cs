using App.Domain.Core._Booth.Contracts.AppServices;
using App.Domain.Core._User.Contracts.AppServices;
using App.EndPoints.MvcUi.Areas.SellerArea.Models.BoothViewModels;
using App.EndPoints.MvcUi.Areas.SellerArea.Models.SellerViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.EndPoints.MvcUi.Areas.SellerArea.ViewComponents
{
    public class EditSellerProfileViewComponent : ViewComponent
    {
        public int CurrentSellerId
        {
            get
            {
                try
                {
                    var sellerId = ((ClaimsIdentity)HttpContext.User.Identity).Claims.Where(c => c.Type == "SellerId")
                        .Select(c => c.Value).SingleOrDefault();
                    return Convert.ToInt32(sellerId);
                }
                catch (Exception ex)
                {
                }
                return 0;
            }
        }

        protected readonly ISellerAppServices _sellerAppServices;
        protected readonly IAddressAppServices _addressAppServices;

        public EditSellerProfileViewComponent(ISellerAppServices sellerAppServices, IBoothAppServices boothAppServices, IAddressAppServices addressAppServices)
        {
            _sellerAppServices = sellerAppServices;
            _addressAppServices = addressAppServices;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var seller = await _sellerAppServices.GetDetails(CurrentSellerId, CancellationToken.None);
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
                //ProfilePicUrl = seller.ProfilePic.ImageUrl,
            };
            editSeller.provinces = await _addressAppServices.GetAllProvinces(CancellationToken.None);
            return View(editSeller);
        }
    }
}
