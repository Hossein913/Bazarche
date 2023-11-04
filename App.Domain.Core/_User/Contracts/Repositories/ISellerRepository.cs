﻿using App.Domain.Core._User.Dtos.SellersDtos;

namespace App.Domain.Core._User.Contracts.Repositories;

public interface ISellerRepository
{
    Task<List<SellerOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<SellerOutputDto> GetDatail(int sellerId, CancellationToken cancellationToken);
    Task Create(SellerCreateDto sellerCreate, CancellationToken cancellationToken);
    Task Update(SellerUpdateDto sellerUpdate, CancellationToken cancellationToken);
    Task SoftDelete(int sellerId, CancellationToken cancellationToken);

}