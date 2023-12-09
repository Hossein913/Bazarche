using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.OrderDtos;
using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Contracts.Services;
using App.Domain.Core._User.Dtos.AddresseDtos;
using App.Domain.Core._User.Dtos.Authenticate;
using App.Domain.Core._User.Dtos.CustommersDtos;
using App.Domain.Core._User.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace App.Domain.AppServices.User
{
    public class IdentityAppServices : IIdentityAppServices
    {

        protected readonly UserManager<AppUser> _userManager;
        protected readonly SignInManager<AppUser> _signInManager;
        protected readonly ICustomerServices _customerServices;
        protected readonly IOrderServices _orderServices;

        public IdentityAppServices(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            SignInManager<AppUser> signInManager,
            ICustomerServices customerServices,
            IOrderServices orderServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _customerServices = customerServices;
            _orderServices = orderServices;
        }
        public async Task<List<IdentityError>> CustomerRegister(CustomerRegisterDto command, CancellationToken cancellationToken)
        {
            var user = new AppUser { Email = command.Email, UserName = command.Email };
            var result = await _userManager.CreateAsync(user, command.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");


                AddressCreateDto addressCreateDto = new AddressCreateDto {
                     ProvinceId = command.ProvinceId,
                     City = command.City,
                     FullAddress = command.Address,
                     PostalCode = command.PostalCode,
                };

                CustomerCreateDto customerCreate = new CustomerCreateDto
                {
                    Firstname = command.FirstName ,
                    Lastname = command.LastName ,
                    AppUserId = user.Id,
                    Address = addressCreateDto,
                };

                var cutomerId = await _customerServices.Create(customerCreate, cancellationToken);

                OrderCreateDto orderCreateDto = new OrderCreateDto {
                    CustomerId = cutomerId,
                };
                var orderId = await _orderServices.Create(orderCreateDto, cancellationToken);

                CustomerUpdateDto customerUpdate = new CustomerUpdateDto
                {
                        CartOrderId = orderId
                };
                await _customerServices.Update(customerUpdate, cancellationToken);

                await _userManager.AddClaimAsync(user, new Claim("UserId", user.Id.ToString()));
                await _userManager.AddClaimAsync(user, new Claim("Customer", cutomerId.ToString()));
                await _userManager.AddClaimAsync(user, new Claim("BoothId", orderId.ToString()));
                
                return null;
            }
            return result.Errors.ToList();

        }

 
        public async Task<AppUser> GetAppUser(UserLoginDto userLoginDto, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(userLoginDto.Email);
            if (user != null)
            {

                return user;
            }

            return null;
        }

        public async Task<SignInResult> Login(AppUser appUser, UserLoginDto userLoginDto, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(appUser, userLoginDto.Password, userLoginDto.IsPersistent, true);
            return result;
        }

        public async Task<IList<string>> GetRoles(AppUser user, CancellationToken cancellationToken)
        {
           var roles = await _userManager.GetRolesAsync(user);
            if (roles != null)
            {
                return roles;
            }
            return null;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }


    }
}



