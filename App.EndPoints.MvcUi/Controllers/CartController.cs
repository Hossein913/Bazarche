using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Dtos.OrderItemDtos;
using App.Domain.Core._User.Entities;
using App.EndPoints.MvcUi.Models._Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.EndPoints.MvcUi.Controllers
{
    public class CartController : CustomerBaseController
    {
        protected readonly IOrderItemAppServices _orderItemApp;
        protected readonly IOrderAppServices _orderAppServices;

        protected readonly UserManager<AppUser> _userManager;
        protected readonly SignInManager<AppUser> _signInManager;

        public CartController(IOrderItemAppServices orderItemApp, IOrderAppServices orderAppServices, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _orderItemApp = orderItemApp;
            _orderAppServices = orderAppServices;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> AddToCart(int priceId, CancellationToken cancellationToken)
        {
            OrderItemCreateDto orderItem = new OrderItemCreateDto
            {
                OrderId = CurrentCartId,
                BoothProductid = priceId,
                Count = 1

            };
                await _orderItemApp.Create(orderItem, cancellationToken);
 
              return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<ActionResult> DeleteOrderItem(int BoothProductId, CancellationToken cancellationToken)
        {
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> Payment(CancellationToken cancellationToken)
        {
            int newCartid = await _orderAppServices.PaymentOrder(CurrentCartId, CurrentCustomerId, cancellationToken);

            if (newCartid > 0 ) 
            {
                var user = await _userManager.GetUserAsync(User);
                var claim = new Claim("CartId", newCartid.ToString());
                var oldClaim = User.FindFirst("CartId");
                var result = await _userManager.ReplaceClaimAsync(user, oldClaim, claim);

                // Get User and a claims-based identity
                //AppUser appUser = await _userManager.FindByIdAsync(CurrentUserId.ToString());
                //var Identity = new ClaimsIdentity(User.Identity);

                //// Remove existing claim and replace with a new value
                //await _userManager.RemoveClaimAsync(appUser, Identity.FindFirst("CartId"));
                //await _userManager.AddClaimAsync(appUser, new Claim("CartId", newCartid.ToString()));
                
                // Refresh the value of the claim
                await _signInManager.SignInAsync(user, isPersistent: false);

                return RedirectToAction("Index", "Customer");
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Payment(CancellationToken cancellationToken)
        //{
        //    return View();
        //}


    }
}
