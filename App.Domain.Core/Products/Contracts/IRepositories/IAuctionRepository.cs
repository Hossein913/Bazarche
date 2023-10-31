using App.Domain.Core.Products.Dtos.Auctions;

namespace App.Domain.Core.Products.Contracts.IRepositories;

public interface IAuctionRepository
{
    Task<AuctionOutputDto> GetDatail(int auctionId, CancellationToken cancellationToken);
    Task Create(AuctionCreateDto auction, CancellationToken cancellationToken);
    Task<List<AuctionOutputDto>> GetAll(int boothId, CancellationToken cancellationToken);
    Task Update(AuctionUpdateDto auction, CancellationToken cancellationToken);
    Task SoftDelete(int ProductActionId, CancellationToken cancellationToken);
}
