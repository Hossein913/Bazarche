using App.Domain.Core._User.Contracts.AppServices;
using App.EndPoints.MvcUi.Areas.AdminArea.ViewModels._Admin;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MvcUi.Areas.AdminArea.ViewComponents
{
    public class AdminProfileViewComponent : ViewComponent
    {
        protected readonly IAdminAppServices _appServices;
        public AdminProfileViewComponent(IAdminAppServices appServices)
        {
            _appServices = appServices;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var resutl = await _appServices.GetDetail(CancellationToken.None);
            AdminDitailsViewModel ditailsViewModel = new AdminDitailsViewModel
            {
                FirstName = resutl.Firstname,
                LastName = resutl.Lastname,
                Wallet = Convert.ToInt32(resutl.Wallet),
            };
            return View(ditailsViewModel);
        }
    }
}
