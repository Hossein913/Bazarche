﻿using App.Domain.Core._Products.Dtos.AuctionDtos;

namespace App.Domain.Core._Products.Contracts.AppServices;

public interface IAuctionAppServices
{
    Task<List<AuctionOutputDto>> GetAllAuctions(CancellationToken cancellationToken);
    Task<List<AuctionOutputDto>> GetAllForCustomer(int customerId, CancellationToken cancellationToken);
    Task<AuctionOutputDto> GetDetail(int auctionId, CancellationToken cancellationToken);
    Task Create(AuctionCreateDto createAuction, CancellationToken cancellationToken);
    Task Update(AuctionUpdateDto auction, CancellationToken cancellationToken);
    Task SoftDelete(int ProductActionId, CancellationToken cancellationToken);
}
