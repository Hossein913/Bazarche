using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Dtos.OrderItemDtos;
using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Dtos.CustomersDtos.CustomerAppServiceDto;
using App.EndPoints.MvcUi.Models._Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MvcUi.Controllers
{
    public class CustomerController : CustomerBaseController
    {
        protected readonly IOrderAppServices _orderAppServices;
        protected readonly IOrderItemAppServices _orderItemAppServices;
        protected readonly ICustomerAppServices _customerAppServices;

        public CustomerController(IOrderAppServices orderAppServices, IOrderItemAppServices orderItemAppServices, ICustomerAppServices customerAppServices)
        {
            _orderAppServices = orderAppServices;
            _orderItemAppServices = orderItemAppServices;
            _customerAppServices = customerAppServices;
        }

        [HttpGet]
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var result = await _orderAppServices.GetUserAllOrders(CurrentCustomerId, cancellationToken);
            List<CustomerOrderViewModel> orders = new List<CustomerOrderViewModel>();
            result.ForEach(o => {
                orders.Add(new CustomerOrderViewModel {
                    Id = o.Id, 
                    TotalPrice = o.TotalPrice,
                    PayedAt = o.PayedAt,
                });

            }) ;
            return View(orders);
        }

        [HttpGet]
        public async Task<ActionResult> OrderDetails(int OrderId,CancellationToken cancellationToken)
        {
            var orderItems = await _orderItemAppServices.GetAnOrderItems(OrderId, CancellationToken.None);
            var CartViewModel = orderItems.Select<OrderItemOutputDto, OrderItemViewModel>(oi => new OrderItemViewModel
            {
                OrderItemId = oi.Id,
                price = oi.BoothProduct.Price,
                count = oi.BoothProduct.Count,
                ProductName = oi.BoothProduct.Product.Name,
                Productbrand = oi.BoothProduct.Product.Brand,
                ProductPictureUrl = oi.BoothProduct.Product.Pictures.FirstOrDefault().ImageUrl,

            }).ToList();

            return View(CartViewModel);
        }
        
        [HttpGet]
        public async Task<ActionResult> Profile(CancellationToken cancellationToken)
        {
            var customer = await _customerAppServices.GetDetail(CurrentCustomerId, cancellationToken); ;
            EditCustomerViewModel editCustomerViewModel = new EditCustomerViewModel{
                FirstName  =customer.Firstname ,
                LastName  =customer.Lastname ,
                Birthdate  =customer .Birthdate,
                City  =customer.Address.City ,
                FullAddress  =customer.Address.FullAddress ,
                PostalCode  =customer.Address.PostalCode,
                //ProvinceId  =customer.pr ,
            };
            return View(editCustomerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditProfile(EditCustomerViewModel customerViewModel,CancellationToken cancellationToken)
        {
            CustomerAppServiceUpdateDto customerAppServiceDto = new CustomerAppServiceUpdateDto{
                CustomerId = CurrentCustomerId ,
                CustomerFirstName = customerViewModel.FirstName ,
                CustomerLastName = customerViewModel.LastName ,
                CustomerBirthdate = customerViewModel.Birthdate ,
                ProvinceId = 1 ,
                City = customerViewModel.City , 
                FullAddress = customerViewModel.FullAddress , 
                PostalCode = customerViewModel.PostalCode , 
            };
            await _customerAppServices.Update(customerAppServiceDto, cancellationToken);
            return RedirectToAction("Profile", "Customer");
        }



        //[HttpGet]
        //public async Task<ActionResult> CreateComment(int orderItemId,CancellationToken cancellationToken)
        //{
        //    var customer = await _customerAppServices.GetDetail(CurrentCustomerId, cancellationToken);
        //    var Orderitem = await _customerAppServices.GetDetail(CurrentCustomerId, cancellationToken);
        //    CommentViewModel commentView = new CommentViewModel
        //    {
        //      CustomerFullName = customer.Firstname + customer.Lastname
        //    };
        //    return View(commentView);
        //}

        [HttpPost]
        public async Task<ActionResult> DeleteComment(int id)
        {
            return View();
        }

    }
}

