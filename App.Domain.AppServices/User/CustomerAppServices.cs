using App.Domain.Core._Common.Contracts.Services;
using App.Domain.Core._Common.Entities;
using App.Domain.Core._Common.Enums;
using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Contracts.Services;
using App.Domain.Core._User.Dtos.CustomersDtos.CustomerAppServiceDto;
using App.Domain.Core._User.Dtos.CustommersDtos;
using App.Domain.Core._User.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.AppServices.User
{
    public class CustomerAppServices : ICustomerAppServices
    {
        protected readonly ICustomerServices _customerServices;
        protected readonly UserManager<AppUser> _userManager ;
        protected readonly IFileServices _fileServices;

        public CustomerAppServices(ICustomerServices customerServices, UserManager<AppUser> userManager, IFileServices fileServices)
        {
            _customerServices = customerServices;
            _userManager = userManager;
            _fileServices = fileServices;
        }

        public async Task<int> Create(CustomerCreateDto customerCreate, CancellationToken cancellationToken)
        {
           var result = await _customerServices.Create(customerCreate, cancellationToken);
            return result;
        }

        public async Task<List<CustomerOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _customerServices.GetAll(cancellationToken);
            return result;
        }

        public async Task<CustomerOutputDto> GetDetailsWithRelation(int customerId, CancellationToken cancellationToken)
        {
            var result = await _customerServices.GetDetailsWithRelation(customerId, cancellationToken);
            return result;
        }

        public async Task<CustomerOutputDto> GetDetails(int customerId, CancellationToken cancellationToken)
        {
            var result = await _customerServices.GetDetails(customerId, cancellationToken);
            return result;
        }

        public async Task SoftDelete(int customerId, CancellationToken cancellationToken)
        {
            await _customerServices.SoftDelete(customerId, cancellationToken);

        }

        public async Task<string> Update(CustomerAppServiceUpdateDto customerUpdate, int CurrentUserId, string ProjectRouteAddress, CancellationToken cancellationToken)
        {
            if (DateTime.Compare(DateTime.Now, Convert.ToDateTime(customerUpdate.Birthdate)) >0)
            {
                Picture newprofilePic = null;

                if (customerUpdate.UploadProfilePic != null)
                {
                    if (customerUpdate.ProfilePicId != null)
                    {
                        CustomerUpdateDto customerPicUpdateDto = new CustomerUpdateDto
                        {
                            ProfilePic = new Picture { Id = Convert.ToInt32(customerUpdate.ProfilePicId), IsDeleted = true, }
                        };
                        await _customerServices.Update(customerPicUpdateDto, cancellationToken);
                    }
                    var photoName = await _fileServices.FileUploadAsync(customerUpdate.UploadProfilePic, FileServicesEntityType.Profiles, ProjectRouteAddress);
                    newprofilePic = new Picture
                    {
                        ImageUrl = photoName,
                        CreatedBy = CurrentUserId,
                    };
                }
        
                Address address = new Address {

                    ProvinceId = customerUpdate.ProvinceId,
                    City = customerUpdate.City,
                    FullAddress = customerUpdate.FullAddress,
                    PostalCode = customerUpdate.PostalCode,
                };

                CustomerUpdateDto customerUpdateDto = new CustomerUpdateDto {
                    Id = customerUpdate.Id,
                    Firstname = customerUpdate.FirstName,
                    Lastname = customerUpdate.LastName,
                    Birthdate = customerUpdate.Birthdate,
                    Address = address,
                    ProfilePic = newprofilePic,
                };
                await _customerServices.Update(customerUpdateDto,cancellationToken);
                return "success";
            }
            else
            {
                return "تاریخ تولد باید زمانی در گذشته باشد.";
            }


        }

        public async Task SetActivity(int appUserId, bool status, CancellationToken cancellationToken)
        {
            var appUser = await _userManager.FindByIdAsync(appUserId.ToString());
            appUser.IsActive = status;
            await _userManager.UpdateAsync(appUser);
        }

        public async Task IncreaseWallet(int customerId, int Amount, CancellationToken cancellationToken)
        {
            await _customerServices.IncreaseWallet(customerId, Amount, cancellationToken);
        }
    }
}

