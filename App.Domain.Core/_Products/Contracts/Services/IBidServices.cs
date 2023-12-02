using App.Domain.Core._Products.Dtos.BidDtos;
using App.Domain.Core._Products.Enums;

namespace App.Domain.Core._Products.Contracts.Services;

public interface IBidServices
{
    Task<List<BidOutputDto>> GetAll(int producAuctiontId, CancellationToken cancellationToken);
    Task<List<BidOutputDto>> GetUserBids(int userID, CancellationToken cancellationToken);
    Task<AddBidResult> Create(BidCreateDto bidCreate, CancellationToken cancellationToken);
    Task Delete(int bidId, CancellationToken cancellationToken);
}
