using App.Domain.Core._Products.Dtos.AuctionDtos;

namespace App.Domain.Core._Products.Contracts.Services;

public interface IAuctionServices
{
    Task<List<AuctionOutputDto>> GetAllActive(CancellationToken cancellationToken);
    Task<List<AuctionOutputDto>> GetAllForCustomer(int customerId, CancellationToken cancellationToken);
    Task<List<AuctionOutputDto>> GetAllForBooth(int BoothId, CancellationToken cancellationToken);
    Task<AuctionOutputDto> GetDetail(int auctionId, CancellationToken cancellationToken);
    Task<int> Create(AuctionCreateDto auction, CancellationToken cancellationToken);
    Task Update(AuctionUpdateDto auction, CancellationToken cancellationToken);
    Task SoftDelete(int ProductActionId, CancellationToken cancellationToken);
    Task GetStartAuction(int auctionId, CancellationToken cancellationToken);
    Task GetEndAuction(int auctionId, CancellationToken cancellationToken);
    Task Cancel(int auctionId, CancellationToken cancellationToken);
}
