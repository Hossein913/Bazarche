using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Dtos.OrderItemDtos;
using App.EndPoints.MvcUi.Models._Customer;
using App.EndPoints.MvcUi.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.EndPoints.MvcUi.ViewComponents
{
    public class CustomerCartViewComponent : ViewComponent
    {
        protected readonly IOrderItemAppServices _orderItemApp;

        public CustomerCartViewComponent(IOrderItemAppServices orderItemApp)
        {
            _orderItemApp = orderItemApp;
        }

        private int CurrentCartId
        {
            get
            {
                try
                {
                    var appUserId = ((ClaimsIdentity)HttpContext.User.Identity).Claims.Where(c => c.Type == "CartId")
                        .Select(c => c.Value).SingleOrDefault();
                    return Convert.ToInt32(appUserId);
                }
                catch (Exception ex)
                {
                }
                return 0;
            }
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var orderItems = await _orderItemApp.GetAnOrderItems(CurrentCartId, CancellationToken.None);

            var CartViewModel = orderItems.Select<OrderItemOutputDto, CustomerCartViewModel>(oi => new CustomerCartViewModel
            {
                OrderItemId = oi.Id,
                price = oi.BoothProduct.Price,
                ProductName = oi.BoothProduct.Product.Name,
                Productbrand = oi.BoothProduct.Product.Brand,
                ProductPictureUrl = oi.BoothProduct.Product.Pictures.FirstOrDefault().ImageUrl,

            }).ToList();

            return View(CartViewModel);
        }
    }
}

