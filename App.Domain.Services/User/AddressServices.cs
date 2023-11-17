using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Contracts.Services;
using App.Domain.Core._User.Dtos.AddresseDtos;
using System;
using System.Collections.Generic;

namespace App.Domain.Services.User;

public class AddressServices : IAddressServices
{
    protected readonly IAddressRepository _addressRepository;

    public AddressServices(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<int> Create(AddressCreateDto addressCreate, CancellationToken cancellationToken)
    {
        var result = await _addressRepository.Create(addressCreate, cancellationToken);
        return result;
    }

    public async Task<AddressOutputDto> GetDetail(int addressId, CancellationToken cancellationToken)
    {
        var result = await _addressRepository.GetDetail(addressId, cancellationToken);
            return result;
    }

    public async Task Update(AddressUpdateDto addressUpdate, CancellationToken cancellationToken)
    {
       await _addressRepository.Update(addressUpdate, cancellationToken);
    }
}
