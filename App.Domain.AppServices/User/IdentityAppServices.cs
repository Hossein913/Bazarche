using App.Domain.Core._Booth.Contracts.Services;
using App.Domain.Core._Booth.Dtos.BoothDtos;
using App.Domain.Core._Common.Contracts.Services;
using App.Domain.Core._Common.Dtos.PictureDtos;
using App.Domain.Core._Common.Enums;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.OrderDtos;
using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Contracts.Services;
using App.Domain.Core._User.Dtos.AddresseDtos;
using App.Domain.Core._User.Dtos.Authenticate;
using App.Domain.Core._User.Dtos.CustommersDtos;
using App.Domain.Core._User.Dtos.SellersDtos;
using App.Domain.Core._User.Dtos.SellersDtos.SellerAppServiceDto;
using App.Domain.Core._User.Entities;
using Microsoft.AspNetCore.Identity;

using System.Security.Claims;


namespace App.Domain.AppServices.User
{
    public class IdentityAppServices : IIdentityAppServices
    {

        //protected readonly ISaveChangesService _saveChangesService ;
        protected readonly SignInManager<AppUser> _signInManager;
        protected readonly UserManager<AppUser> _userManager;
        protected readonly ICustomerServices _customerServices;
        protected readonly IOrderServices _orderServices;
        protected readonly ISellerServices _sellerServices;
        protected readonly IBoothServices _boothServices;
        protected readonly IFileServices _fileServices;

        public IdentityAppServices(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            SignInManager<AppUser> signInManager,
            ICustomerServices customerServices,
            IOrderServices orderServices,
            ISellerServices sellerServices,
            IBoothServices boothServices,
            IFileServices fileServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _customerServices = customerServices;
            _orderServices = orderServices;
            _sellerServices = sellerServices;
            _boothServices = boothServices;
            _fileServices = fileServices;
        }


        public async Task<List<IdentityError>> SellerRegister(SellerRegisterDto sellerRegister, string ProjectRouteAddress,CancellationToken cancellationToken)
        {
            var user = new AppUser { Email = sellerRegister.Email, UserName = sellerRegister.Email };
            var result = await _userManager.CreateAsync(user, sellerRegister.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Seller");


                AddressCreateDto addressCreateDto = new AddressCreateDto
                {
                    ProvinceId = sellerRegister.ProvinceId,
                    City = sellerRegister.City,
                    FullAddress = sellerRegister.Address,
                    PostalCode = sellerRegister.PostalCode,
                };

                SellerCreateDto customerCreate = new SellerCreateDto
                {
                    Firstname = sellerRegister.FirstName,
                    Lastname = sellerRegister.LastName,
                    ShabaNumber = sellerRegister.ShabaNumber,
                    AppUserId = user.Id,
                    Address = addressCreateDto,
                };

                var seller = await _sellerServices.Create(customerCreate, cancellationToken);

                var boothAvatarFileName = await _fileServices.FileUploadAsync(sellerRegister.BoothAvatar,FileServicesEntityType.BoothAvatar, ProjectRouteAddress);
             
                PictureCreateDto boothAvatorCreateDto = new PictureCreateDto
                {
                     ImageUrl = boothAvatarFileName,
                     CreatedBy = user.Id
                };


                BoothCreateDto boothCreate = new BoothCreateDto
                {
                  Name = sellerRegister.BoothName,
                  Description = sellerRegister.Description,
                  AvatarPicture = boothAvatorCreateDto
                };

                var boothId = await _boothServices.Create(boothCreate, cancellationToken);

                SellerUpdateDto customerUpdate = new SellerUpdateDto
                {
                    Id = seller.Id,
                    BoothId = boothId,
                };
               
                await _sellerServices.Update(customerUpdate, cancellationToken);

                await _userManager.AddClaimAsync(user, new Claim("UserId", user.Id.ToString()));
                await _userManager.AddClaimAsync(user, new Claim("SellerId", seller.Id.ToString()));
                await _userManager.AddClaimAsync(user, new Claim("BoothId", boothId.ToString()));

                //await _saveChangesService.SaveChanges(cancellationToken);


                return null;
            }
            return result.Errors.ToList();

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
                    Id = cutomerId,
                        CartOrderId = orderId
                };
                await _customerServices.Update(customerUpdate, cancellationToken);

                await _userManager.AddClaimAsync(user, new Claim("UserId", user.Id.ToString()));
                await _userManager.AddClaimAsync(user, new Claim("Customer", cutomerId.ToString()));
                await _userManager.AddClaimAsync(user, new Claim("CartId", orderId.ToString()));
                
                return null;
            }
            return result.Errors.ToList();

        }

 
        public async Task<AppUser> GetAppUser(UserLoginDto userLoginDto, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(userLoginDto.Email);
            if (user != null && user.IsDeleted == false)
            {
                return user;
            }

            return null;
        }

        public async Task<SignInResult> Login(AppUser appUser, UserLoginDto userLoginDto, CancellationToken cancellationToken)
        {
            if (appUser != null  && appUser.IsActive == true)
            {
                var result = await _signInManager.PasswordSignInAsync(appUser, userLoginDto.Password, userLoginDto.IsPersistent, true);
                return result;
            }
            return null;

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



