using App.Domain.Core._Products.Dtos.AuctionDtos;

namespace App.Domain.Core._Products.Contracts.Repositories;

public interface IAuctionRepository
{
    Task<List<AuctionOutputDto>> GetAllActive( CancellationToken cancellationToken);
    Task<AuctionOutputDto> GetDatail(int auctionId, CancellationToken cancellationToken);
    Task Create(AuctionCreateDto auction, CancellationToken cancellationToken);
    Task Update(AuctionUpdateDto auction, CancellationToken cancellationToken);
    Task SoftDelete(int ProductActionId, CancellationToken cancellationToken);
}
