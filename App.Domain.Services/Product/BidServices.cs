using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.BidDtos;

namespace App.Domain.Services.Product;

public class BidServices : IBidServices
{
    protected readonly IBidRepository _bidRepository;

    public BidServices(IBidRepository bidRepository)
    {
        _bidRepository = bidRepository;
    }

    public async Task Create(BidCreateDto bidCreate, CancellationToken cancellationToken)
    {
        await _bidRepository.Create(bidCreate, cancellationToken);
    }

    public async Task Delete(int bidId, CancellationToken cancellationToken)
    {
         await _bidRepository.Delete(bidId, cancellationToken);

    }

    public async Task<List<BidOutputDto>> GetAll(int ProducActiontId, CancellationToken cancellationToken)
    {
        var result = await _bidRepository.GetAll(ProducActiontId, cancellationToken);
            return result;
    }

    public async Task<List<BidOutputDto>> GetUserBids(int userID, CancellationToken cancellationToken)
    {
        var result = await _bidRepository.GetUserBids(userID, cancellationToken);
            return result;
    }

    public async Task Update(BidUpdateDto bidUpdate, CancellationToken cancellationToken)
    {
        await _bidRepository.Update(bidUpdate, cancellationToken);
    }
}
