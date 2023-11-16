using App.Domain.Core._User.Dtos.AddresseDtos;
using System;
using System.Collections.Generic;
using System.Threading;

namespace App.Domain.Core._User.Contracts.Repositories;

public interface IAddressRepository
{
    //Task<List<AddressOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<AddressOutputDto> GetDetail(int addressId, CancellationToken cancellationToken);
    Task<int> Create(AddressCreateDto addressCreate,CancellationToken cancellationToken);
    Task Update(AddressUpdateDto addressUpdate, CancellationToken cancellationToken);
    //Task SoftDelete(int addressId , CancellationToken cancellationToken);

}
