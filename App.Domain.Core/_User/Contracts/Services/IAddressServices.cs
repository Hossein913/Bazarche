using App.Domain.Core._User.Dtos.AddresseDtos;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._User.Contracts.Services;

public interface IAddressServices
{
    Task<AddressOutputDto> GetDetail(int addressId, CancellationToken cancellationToken);
    Task<int> Create(AddressCreateDto addressCreate, CancellationToken cancellationToken);
    Task Update(AddressUpdateDto addressUpdate, CancellationToken cancellationToken);
}
