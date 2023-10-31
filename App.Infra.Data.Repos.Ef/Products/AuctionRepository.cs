using App.Domain.Core.Products.Contracts.IRepositories;
using App.Domain.Core.Products.Dtos.Auctions;

namespace App.Infra.Data.Repos.Ef.Products;

public class AuctionRepository : IAuctionRepository
{
    public Task Create(AuctionCreateDto auction, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<AuctionOutputDto>> GetAll(int boothId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<AuctionOutputDto> GetDatail(int auctionId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SoftDelete(int ProductActionId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(AuctionUpdateDto auction, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
