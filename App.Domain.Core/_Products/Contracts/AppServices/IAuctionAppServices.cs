using App.Domain.Core._Products.Dtos.AuctionDtos;
using App.Domain.Core._Products.Enums;

namespace App.Domain.Core._Products.Contracts.AppServices;

public interface IAuctionAppServices
{
    Task<List<AuctionOutputDto>> GetAllRegistered(CancellationToken cancellationToken);
    Task<List<AuctionOutputDto>> GetAllRuning(CancellationToken cancellationToken);
    Task<List<AuctionOutputDto>> GetAllEnded(CancellationToken cancellationToken);
    Task<List<AuctionOutputDto>> GetAllAuctions(CancellationToken cancellationToken);
    Task<List<AuctionOutputDto>> GetAllForCustomer(int customerId, CancellationToken cancellationToken);
    Task<List<AuctionOutputDto>> GetAllForBooth(int BoothId, CancellationToken cancellationToken);
    Task<AuctionOutputDto> GetDetail(int auctionId, CancellationToken cancellationToken);
    Task<string> Create(AuctionCreateDto createAuction, CancellationToken cancellationToken);
    Task Update(AuctionUpdateDto auction, CancellationToken cancellationToken);
    Task SoftDelete(int ProductActionId, CancellationToken cancellationToken);
    Task Cancel(int auctionId, CancellationToken cancellationToken);
    Task GetEndAuction(int auctionId, CancellationToken cancellationToken);
}
