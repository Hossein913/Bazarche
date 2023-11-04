using App.Domain.Core._User.Dtos.AddresseDtos;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._User.Contracts.Repositories;

public interface IAddressRepository
{
    Task<List<AddressOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<AddressOutputDto> GetDatail(int addressId, CancellationToken cancellationToken);
    Task Create(AddressCreateDto addressCreate, CancellationToken cancellationToken);
    Task Update(AddressUpdateDto addressUpdate, CancellationToken cancellationToken);
    Task SoftDelete(int addressId, CancellationToken cancellationToken);

}
