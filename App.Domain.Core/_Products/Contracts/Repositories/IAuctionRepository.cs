using App.Domain.Core._Products.Dtos.AuctionDtos;
using App.Domain.Core._Products.Enums;

namespace App.Domain.Core._Products.Contracts.Repositories;

public interface IAuctionRepository
{
    Task<List<AuctionOutputDto>> GetAll(AuctionStatus auctionStatus, CancellationToken cancellationToken);
    Task<List<AuctionOutputDto>> GetAllActive( CancellationToken cancellationToken);
    Task<List<AuctionOutputDto>> GetAllForCustomer(int customerId, CancellationToken cancellationToken);
    Task<List<AuctionOutputDto>> GetAllForBooth(int BoothId, CancellationToken cancellationToken);
    Task<AuctionOutputDto> GetDetail(int auctionId, CancellationToken cancellationToken);
    Task<int> Create(AuctionCreateDto auction, CancellationToken cancellationToken);
    Task Update(AuctionUpdateDto auction, CancellationToken cancellationToken, bool saveChanges = true);
    Task SoftDelete(int ProductActionId, CancellationToken cancellationToken);
}
