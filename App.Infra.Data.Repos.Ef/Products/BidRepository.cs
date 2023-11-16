using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Dtos.BidDtos;
using App.Domain.Core._Products.Dtos.CommentDtos;
using App.Domain.Core._Products.Entities;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Products;

public class BidRepository : IBidRepository
{
    private readonly BazarcheContext _context;

    public BidRepository(BazarcheContext context)
    {
        _context = context;
    }
    public async Task Create(BidCreateDto bidCreate, CancellationToken cancellationToken)
    {
        var newBid = new Bid
        {
            CustomerId = bidCreate.CustomerId,
            AuctionId = bidCreate.AuctionId,
            BidPrice = bidCreate.BidPrice,
            IsCancelled = false,
            CreatedAt = DateTime.Now
        };

        await _context.Bids.AddAsync(newBid, cancellationToken);
        var result = await _context.SaveChangesAsync(cancellationToken);
    }
    public async Task<List<BidOutputDto>> GetAll(int AuctionId, CancellationToken cancellationToken)
    {
        var result = await _context.Bids
        .AsNoTracking()
        .Where(p => p.AuctionId == AuctionId && p.IsCancelled == false)
        .Select<Bid, BidOutputDto>(c => new BidOutputDto
        {
        Id = c.Id,
        Customer = c.Customer,
        BidPrice = c.BidPrice,

        }).OrderBy(p => p.BidPrice).ToListAsync(cancellationToken);
        return result;
    }
    public async Task<List<BidOutputDto>> GetUserBids(int userId, CancellationToken cancellationToken)
    {
        var result = await _context.Bids
        .AsNoTracking()
        .Where(p => p.CustomerId == userId )
        .Select<Bid, BidOutputDto>(c => new BidOutputDto
        {
            Id = c.Id,
            Auction = c.Auction,
            BidPrice = c.BidPrice,
        
        }).OrderBy(p => p.CreatedAt).ToListAsync(cancellationToken);
        return result;
    }

    public async Task Delete(int bidId, CancellationToken cancellationToken)
    {
        var commentRecord = await _context.Bids
        .FirstOrDefaultAsync(x => x.Id == bidId, cancellationToken);

        if (commentRecord != null)
        {
            commentRecord.IsCancelled = true;

        }
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(BidUpdateDto bidUpdate, CancellationToken cancellationToken)
    {
        var BidRecord = await _context.Bids
        .FirstOrDefaultAsync(x => x.Id == bidUpdate.Id, cancellationToken);
        if (BidRecord != null)
        {
            BidRecord.BidPrice = bidUpdate.BidPrice;
            BidRecord.IsCancelled = bidUpdate.IsCancelled;

        }
        await _context.SaveChangesAsync(cancellationToken);
    }


}