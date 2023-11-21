using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Dtos.AuctionDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._Products.Enums;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Products;

public class AuctionRepository : IAuctionRepository
{

    private readonly BazarcheContext _context;

    public AuctionRepository(BazarcheContext context)
    {
        _context = context;
    }

    public async Task Create(AuctionCreateDto auction, CancellationToken cancellationToken)
    {
        var newAuction = new Auction
        {
            ProductId = auction.ProductId,
            BoothId = auction.BoothId,
            WinnerId = null,
            StartTime = auction.StartTime,
            EndTime = auction.EndTime,
            BasePrice = auction.BasePrice,
            Status = (int)AuctionStatus.Runing ,
            IsConfirmed = null,

        };

        await _context.Auctions.AddAsync(newAuction, cancellationToken);
        var result = await _context.SaveChangesAsync(cancellationToken);
    }
    
    public async Task<List<AuctionOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Auctions
            .AsNoTracking()
            .Select<Auction, AuctionOutputDto>(a => new AuctionOutputDto
            {
                Id = a.Id,
                WinnerId = a.WinnerId,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                BasePrice = a.Id,
                ProductId = a.ProductId,
                Booth = a.Booth,
                Status = a.Status
            }).ToListAsync(cancellationToken);
    }

    public async Task<List<AuctionOutputDto>> GetAllActive( CancellationToken cancellationToken)
    {
        return await _context.Auctions
            .AsNoTracking()
            .Where<Auction>(p => p.IsConfirmed==true && p.Status == (int)AuctionStatus.Runing)
            .Select<Auction, AuctionOutputDto>(a => new AuctionOutputDto
        {
                Id = a.Id,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                BasePrice = a.Id,
                ProductId = a.ProductId,
                Booth = a.Booth,

            }).ToListAsync(cancellationToken);
    }

    public async Task<List<AuctionOutputDto>> GetAllForBooth(int BoothId, CancellationToken cancellationToken)
    {
        return await _context.Auctions
            .AsNoTracking()
            .Include(a => a.Product)
            .ThenInclude(p => p.Pictures.FirstOrDefault())
            .Where<Auction>(p => p.BoothId == BoothId)
            .Select<Auction, AuctionOutputDto>(a => new AuctionOutputDto
            {
                Id = a.Id,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                BasePrice = a.Id,


            }).ToListAsync(cancellationToken);
    }

    public async Task<AuctionOutputDto> GetDetail(int auctionId, CancellationToken cancellationToken)
    {

        var auction = await _context.Auctions
            .Include(a => a.Booth)
            .Include(a => a.Bids)
            .FirstOrDefaultAsync(p => p.Id == auctionId , cancellationToken);

        if (auction != null)
        {
            var auctionRecord = new AuctionOutputDto
            {

                WinnerId = auction.WinnerId,
                StartTime = auction.StartTime,
                EndTime = auction.EndTime,
                BasePrice = auction.BasePrice,
                Status = auction.Status,
                IsConfirmed = auction.IsConfirmed,
                ProductId = auction.ProductId,

                Booth = auction.Booth,
                Bids = auction.Bids

            };
            return auctionRecord;
        }
        else
        {
            return null;
        }


    }

    public async Task SoftDelete(int ActionId, CancellationToken cancellationToken)
    {
        var auctionRecord = await _context.BoothProducts
        .FirstOrDefaultAsync(x => x.Id == ActionId, cancellationToken);

        if (auctionRecord != null)
        {
            auctionRecord.IsDeleted = true;

        }
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(AuctionUpdateDto auction, CancellationToken cancellationToken)
    {
        var AuctionRecord = await _context.Auctions
        .FirstOrDefaultAsync(x => x.Id == auction.Id, cancellationToken);
        if (AuctionRecord != null)
        {
            AuctionRecord.ProductId = auction.ProductId;
            AuctionRecord.BoothId = auction.BoothId;
            AuctionRecord.WinnerId = auction.WinnerId;
            AuctionRecord.StartTime = auction.StartTime;
            AuctionRecord.EndTime = auction.EndTime;
            AuctionRecord.BasePrice = auction.BasePrice;
            AuctionRecord.Status = auction.Status;
            AuctionRecord.IsConfirmed = auction.IsConfirmed;

        }
        await _context.SaveChangesAsync(cancellationToken);
    }
}