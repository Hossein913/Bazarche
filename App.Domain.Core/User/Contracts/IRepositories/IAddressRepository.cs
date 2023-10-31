using App.Domain.Core.Booths.Dtos.Booths;
using App.Domain.Core.User.Dtos.Addresses;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.User.Contracts.IRepositories;

public interface IAddressRepository
{
    Task<List<AddressOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<AddressOutputDto> GetDatail(int addressId, CancellationToken cancellationToken);
    Task Create(AddressCreateDto addressCreate, CancellationToken cancellationToken);
    Task Update(AddressUpdateDto addressUpdate, CancellationToken cancellationToken);
    Task SoftDelete(int addressId, CancellationToken cancellationToken);

}
