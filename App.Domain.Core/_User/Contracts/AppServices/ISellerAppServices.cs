﻿using App.Domain.Core._User.Dtos.SellersDtos;
using App.Domain.Core._User.Dtos.SellersDtos.SellerAppServiceDto;

namespace App.Domain.Core._User.Contracts.AppServices;

public interface ISellerAppServices
{
    Task<List<SellerOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<SellerOutputDto> GetDetailWithRilations(int sellerAppUserId, CancellationToken cancellationToken);
    Task<SellerOutputDto> GetDetail(int sellerAppUserId, CancellationToken cancellationToken);
    Task Create(SellerRegisterDto sellerCreate, CancellationToken cancellationToken);
    Task Update(SellerAppServiceUpdateDto sellerUpdate, string projectRouteAddress, CancellationToken cancellationToken);
    Task SoftDelete(int sellerId, int boothId, CancellationToken cancellationToken);

    Task SetActivity(int appUserId, bool status, CancellationToken cancellationToken);
}
