using App.Domain.Core._Products.Dtos.BidDtos;

namespace App.Domain.Core._Products.Contracts.Repositories;

public interface IBidRepository
{
    Task<List<BidOutputDto>> GetAll(int ProducActiontId, CancellationToken cancellationToken);
    Task<List<BidOutputDto>> GetUserBids(int userID, CancellationToken cancellationToken);
    Task Create(BidCreateDto bidCreate, CancellationToken cancellationToken);
    Task Delete(int bidId, CancellationToken cancellationToken);
    Task Update(BidUpdateDto bidUpdate, CancellationToken cancellationToken);
}
