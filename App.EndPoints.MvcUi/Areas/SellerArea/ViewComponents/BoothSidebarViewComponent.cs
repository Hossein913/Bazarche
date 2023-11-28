using App.Domain.Core._Booth.Contracts.AppServices;
using App.EndPoints.MvcUi.Areas.SellerArea.Models.BoothViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.EndPoints.MvcUi.Areas.SellerArea.ViewComponents
{
    public class BoothSidebarViewComponent : ViewComponent
    {
        protected readonly IBoothAppServices _boothAppServices;
        public int CurrentBoothId
        {
            get
            {
                try
                {
                    var sellerId = ((ClaimsIdentity)HttpContext.User.Identity).Claims.Where(c => c.Type == "BoothId")
                        .Select(c => c.Value).SingleOrDefault();
                    return Convert.ToInt32(sellerId);
                }
                catch (Exception ex)
                {
                }
                return 0;
            }
        }
        public BoothSidebarViewComponent(IBoothAppServices boothAppServices)
        {
            _boothAppServices = boothAppServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(CancellationToken cancellationToken)
        {
            var booth = await _boothAppServices.GetDetailsWithRelations(CurrentBoothId, cancellationToken);
            BoothSidebarViewModel sidebar = new BoothSidebarViewModel
            {
                Id = booth.Id,
                Name = booth.Name,
                AvatarPictureFile = booth.AvatarPicture.ImageUrl,
                MedalType = booth.Medal.Name,
                AccountBalance = booth.AccountBalance,
                TotalSell = booth.TotalSell,
                Description = booth.Description
            };
            return View(sidebar);
        }
    }
}
