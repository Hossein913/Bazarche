using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Dtos.AddresseDtos;
using System;
using System.Collections.Generic;

namespace App.Infra.Data.Repos.Ef.Users;

public class AddressRepository : IAddressRepository
{
    public Task Create(AddressCreateDto addressCreate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<AddressOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<AddressOutputDto> GetDatail(int addressId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SoftDelete(int addressId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(AddressUpdateDto addressUpdate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
