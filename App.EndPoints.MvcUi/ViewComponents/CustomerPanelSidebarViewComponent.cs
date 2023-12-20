using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._User.Contracts.AppServices;
using App.EndPoints.MvcUi.Models._Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace App.EndPoints.MvcUi.ViewComponents
{
    public class CustomerPanelSidebarViewComponent : ViewComponent
    {
        public int CurrentCustomerId
        {
            get
            {
                try
                {
                    var appUserId = ((ClaimsIdentity)HttpContext.User.Identity).Claims.Where(c => c.Type == "CustomerId")
                        .Select(c => c.Value).SingleOrDefault();
                    return Convert.ToInt32(appUserId);
                }
                catch (Exception ex)
                {
                }
                return 0;
            }
        }

        private readonly ICustomerAppServices _customerApp;
        public CustomerPanelSidebarViewComponent(ICustomerAppServices customerAppServices)
        {
            _customerApp = customerAppServices;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _customerApp.GetDetails(CurrentCustomerId, CancellationToken.None);
            CustomerDetailsViewModel customerDetailsView = new CustomerDetailsViewModel
            {
                FirstName =result.Firstname ,
                LastName =result.Lastname ,
                wallet =Convert.ToInt32( result.Wallet ) ,
                ProfileImgUrl =result.ProfilePic != null ? result.ProfilePic.ImageUrl : null ,
            };

            return View(customerDetailsView);
        }
    }
}
