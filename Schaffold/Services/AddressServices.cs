using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Dtos.AddresseDtos;
using App.Domain.Core._User.Entities;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Scaffold.Services;

public class AddressServices : IAddressServices
{
    private readonly BazarcheContext _context;
    public AddressServices(BazarcheContext context)
    {
        _context = context;
    }


    public async Task<int> Create(AddressCreateDto addressCreate, CancellationToken cancellationToken)
    {

    }

    //public Task<List<AddressOutputDto>> GetAll(CancellationToken cancellationToken)
    //{
    //    throw new NotImplementedException();
    //}

    public async Task<AddressOutputDto> GetDetail(int addressId, CancellationToken cancellationToken)
    {


    }

    //public Task SoftDelete(int addressId, CancellationToken cancellationToken)
    //{
    //    throw new NotImplementedException();
    //}

    public async Task Update(AddressUpdateDto addressUpdate, CancellationToken cancellationToken)
    {

    }
}


