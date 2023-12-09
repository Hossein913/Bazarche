using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Contracts.Services;
using App.Domain.Core._User.Dtos.CustomersDtos.CustomerAppServiceDto;
using App.Domain.Core._User.Dtos.CustommersDtos;
using App.Domain.Core._User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Domain.AppServices.User
{
    public class CustomerAppServices : ICustomerAppServices
    {
        protected readonly ICustomerServices _customerServices;
        public CustomerAppServices(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        public async Task<int> Create(CustomerCreateDto customerCreate, CancellationToken cancellationToken)
        {
           var result = await _customerServices.Create(customerCreate, cancellationToken);
            return result;
        }

        public async Task<List<CustomerOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerOutputDto> GetDetail(int customerId, CancellationToken cancellationToken)
        {
            var result = await _customerServices.GetDetail(customerId, cancellationToken);
            return result;
        }

        public async Task SoftDelete(int customerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task Update(CustomerAppServiceUpdateDto customerUpdate, CancellationToken cancellationToken)
        {
            Address address = new Address {

                ProvinceId = customerUpdate.ProvinceId,
                City = customerUpdate.City,
                FullAddress = customerUpdate.FullAddress,
                PostalCode = customerUpdate.PostalCode,
            };
            CustomerUpdateDto customerUpdateDto = new CustomerUpdateDto {
                Id = customerUpdate.CustomerId,
                Firstname = customerUpdate.CustomerFirstName,
                Lastname = customerUpdate.CustomerLastName,
                Birthdate = customerUpdate.CustomerBirthdate,
                Address = address,
            };
            await _customerServices.Update(customerUpdateDto,cancellationToken);
        }
    }
}

