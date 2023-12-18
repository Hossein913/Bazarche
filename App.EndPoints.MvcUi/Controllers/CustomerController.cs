using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Dtos.CommentDtos;
using App.Domain.Core._Products.Dtos.OrderItemDtos;
using App.Domain.Core._Products.Enums;
using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Dtos.CustomersDtos.CustomerAppServiceDto;
using App.EndPoints.MvcUi.Models._Auctions;
using App.EndPoints.MvcUi.Models._Customer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MvcUi.Controllers
{
    public class CustomerController : CustomerBaseController
    {
        protected readonly IOrderAppServices _orderAppServices;
        protected readonly IOrderItemAppServices _orderItemAppServices;
        protected readonly ICustomerAppServices _customerAppServices;
        protected readonly ICommentAppServices _commentAppServices;
        protected readonly IAuctionAppServices _auctionAppServices;
        protected readonly IWebHostEnvironment _webHostEnvironment;

        public CustomerController(IOrderAppServices orderAppServices, IOrderItemAppServices orderItemAppServices, ICustomerAppServices customerAppServices, IAuctionAppServices auctionAppServices, IWebHostEnvironment webHostEnvironment)
        {
            _orderAppServices = orderAppServices;
            _orderItemAppServices = orderItemAppServices;
            _customerAppServices = customerAppServices;
            _auctionAppServices = auctionAppServices;
            _webHostEnvironment = webHostEnvironment;
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
                ProductId= oi.BoothProduct.Product.Id,
                Productbrand = oi.BoothProduct.Product.Brand,
                ProductPictureUrl = oi.BoothProduct.Product.Pictures.FirstOrDefault().ImageUrl,

            }).ToList();

            return View(CartViewModel);
        }

        [HttpGet]
        public async Task<ActionResult> AllAuctions(CancellationToken cancellationToken)
        {
            var result = await _auctionAppServices.GetAllForCustomer(CurrentCustomerId, cancellationToken);

            List<CustomerAuctionsBidViewModel> customerAuctionsBid = null;
            if (result != null)
            {
                customerAuctionsBid = new List<CustomerAuctionsBidViewModel>();
                result.ForEach( a => 
                {
                     customerAuctionsBid.Add(
                         new CustomerAuctionsBidViewModel
                         {
                             Id = a.Id,
                             Status = a.Status ,
                             WinnerId = a.WinnerId,
                             CurrentCustomerId = CurrentCustomerId,
                             Bids = a.Bids,
                             ProductDto = a.ProductDto
                         }
                     );
                });


            }

            return View(customerAuctionsBid);
        }

        [HttpGet]
        public async Task<ActionResult> Profile(CancellationToken cancellationToken)
        {
            var customer = await _customerAppServices.GetDetailsWithRelation(CurrentCustomerId, cancellationToken); ;
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
                Id = CurrentCustomerId ,
                FirstName = customerViewModel.FirstName ,
                LastName = customerViewModel.LastName ,
                Birthdate = customerViewModel.Birthdate ,
                ProvinceId = 1 ,
                City = customerViewModel.City , 
                FullAddress = customerViewModel.FullAddress , 
                PostalCode = customerViewModel.PostalCode , 
            };
            await _customerAppServices.Update(customerAppServiceDto,CurrentUserId, _webHostEnvironment.WebRootPath, cancellationToken);
            return RedirectToAction("Profile", "Customer");
        }

    }
}

