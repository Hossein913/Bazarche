﻿using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Dtos.BidDtos;

namespace App.Infra.Data.Repos.Ef.Products;

public class BidRepository : IBidRepository
{
    public Task Create(BidCreateDto bidCreate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int bidId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Delete(BidUpdateDto bidUpdate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<BidOutputDto>> GetAll(int ProducActiontId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<BidOutputDto>> GetUserBids(int userID, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
