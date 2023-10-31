using App.Domain.Core.Products.Dtos.Bids;

namespace App.Domain.Core.Products.Contracts.IRepositories;

public interface IBidRepository
{
    Task<List<BidOutputDto>> GetAll(int ProducActiontId, CancellationToken cancellationToken);
    Task<List<BidOutputDto>> GetUserBids(int userID, CancellationToken cancellationToken);
    Task Create(BidCreateDto bidCreate, CancellationToken cancellationToken);
    Task Delete(int bidId, CancellationToken cancellationToken);
    Task Delete(BidUpdateDto bidUpdate, CancellationToken cancellationToken);
}
