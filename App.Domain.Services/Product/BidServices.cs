using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.BidDtos;
using App.Domain.Core._Products.Enums;
using App.Infra.Data.Repos.Ef.Products;

namespace App.Domain.Services.Product;

public class BidServices : IBidServices
{
    protected readonly IBidRepository _bidRepository;
    protected readonly IAuctionRepository _auctionRepository;

    public BidServices(IBidRepository bidRepository, IAuctionRepository auctionRepository)
    {
        _bidRepository = bidRepository;
        _auctionRepository = auctionRepository;
    }

    public async Task<AddBidResult> Create(BidCreateDto bidCreate, CancellationToken cancellationToken)
    {
        var auction = await _auctionRepository.GetDetail(bidCreate.AuctionId, cancellationToken);
        if (bidCreate.BidPrice >= auction.BasePrice) {

            if ((auction.Bids.Count == 0 ) ||(auction.Bids.Count > 0 && bidCreate.BidPrice > auction.Bids.Max(b => b.BidPrice)))
            {
                await _bidRepository.Create(bidCreate, cancellationToken);
                return AddBidResult.Succeeded;
            }
            return AddBidResult.LessThanMaxBid;
        }
        return AddBidResult.LessThanBasePrice;
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
