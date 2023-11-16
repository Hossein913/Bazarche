using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Dtos.AddresseDtos;
using App.Domain.Core._User.Entities;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace App.Infra.Data.Repos.Ef.Users;

public class AddressRepository : IAddressRepository
{
    private readonly BazarcheContext _context;
    public AddressRepository(BazarcheContext context)
    {
        _context = context;
    }


    public async Task<int> Create(AddressCreateDto addressCreate, CancellationToken cancellationToken)
    {
        var newrecord = new Address
        {
            ProvinceId = addressCreate.ProvinceId,
            City = addressCreate.City,
            FullAddress = addressCreate.FullAddress,
            PostalCode = addressCreate.PostalCode,
        };

        await _context.Addresses.AddAsync(newrecord, cancellationToken);
        var result = await _context.SaveChangesAsync(cancellationToken);
        if (result != 0)
            return newrecord.Id;

        return 0;
    }

    //public Task<List<AddressOutputDto>> GetAll(CancellationToken cancellationToken)
    //{
    //    throw new NotImplementedException();
    //}

    public async Task<AddressOutputDto> GetDetail(int addressId, CancellationToken cancellationToken)
    {
        var address = await _context.Addresses
            .Include(a => a.Province)
            .FirstOrDefaultAsync(p => p.Id == addressId, cancellationToken);

        if (address != null)
        {
            var addressrecord = new AddressOutputDto
            {
                ProvinceName = address.Province.Name,
                City = address.City,
                FullAddress = address.FullAddress,
                PostalCode = address.PostalCode
            };
            return addressrecord;
        }
        else
        {
            return null;
        }

    }

    //public Task SoftDelete(int addressId, CancellationToken cancellationToken)
    //{
    //    throw new NotImplementedException();
    //}

    public async Task Update(AddressUpdateDto addressUpdate, CancellationToken cancellationToken)
    {
        var addressRecord = await _context.Addresses.FirstOrDefaultAsync(p => p.Id == addressUpdate.Id, cancellationToken);

        if (addressRecord != null)
        {
            addressRecord.ProvinceId = addressUpdate.ProvinceId;
            addressRecord.City = addressUpdate.City;
            addressRecord.FullAddress = addressUpdate.FullAddress;
            addressRecord.PostalCode = addressUpdate.PostalCode;
        }
        await _context.SaveChangesAsync(cancellationToken);
    }
}


