using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Dtos.AuctionDtos;
using App.Domain.Core._Products.Dtos.ProductDtos;
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

    public async Task<int> Create(AuctionCreateDto auction, CancellationToken cancellationToken)
    {
        var newAuction = new Auction
        {
            ProductId = auction.ProductId,
            BoothId = auction.BoothId,
            WinnerId = null,
            StartTime = auction.StartTime,
            EndTime = auction.EndTime,
            BasePrice = auction.BasePrice,
            Status = (int)AuctionStatus.Defined ,
            IsConfirmed = null,

        };

        await _context.Auctions.AddAsync(newAuction, cancellationToken);
        var result = await _context.SaveChangesAsync(cancellationToken);
        if (result > 0 )
        {
            return newAuction.Id;
        }
        return 0;
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
                Status = (AuctionStatus)a.Status
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

    public async Task<List<AuctionOutputDto>> GetAllForCustomer(int customerId, CancellationToken cancellationToken)
    {
        return await _context.Auctions
            .AsNoTracking()
            .Include(a => a.Bids) 
            .Include(a => a.Product) 
            .ThenInclude(p => p.Pictures)
            .Where<Auction>(p => p.Bids.Any(b => b.CustomerId == customerId))
            .Select<Auction, AuctionOutputDto>(a => new AuctionOutputDto
            {
                Id = a.Id ,
                WinnerId = a.WinnerId ,
                Status = (AuctionStatus)a.Status ,
                Bids = a.Bids.Where(b => b.CustomerId == customerId).ToList(),
                ProductDto = new ProductOutputDto
                {
                    Name = a.Product.Name,
                    Brand = a.Product.Brand,
                    Description = a.Product.Description,
                    Avatar = a.Product.Pictures.FirstOrDefault().ImageUrl,
                },

            }).ToListAsync(cancellationToken);
    }

    public async Task<AuctionOutputDto> GetDetail(int auctionId, CancellationToken cancellationToken)
    {

        var auction = await _context.Auctions
            .Include(a => a.Booth)
            .Include(a => a.Bids)
            .ThenInclude(b => b.CustomerId)
            .Include(a => a.Product)
            .ThenInclude(p => p.Pictures)
            .FirstOrDefaultAsync(p => p.Id == auctionId , cancellationToken);

        if (auction != null)
        {
            var auctionRecord = new AuctionOutputDto
            {

                WinnerId = auction.WinnerId,
                StartTime = auction.StartTime,
                EndTime = auction.EndTime,
                BasePrice = auction.BasePrice,
                Status = (AuctionStatus)auction.Status,
                IsConfirmed = auction.IsConfirmed,
                ProductDto = new ProductOutputDto {
                                  Name = auction.Product.Name,
                                  Brand = auction.Product.Brand,
                                  Description = auction.Product.Description,
                                 Avatar = auction.Product.Pictures.FirstOrDefault().ImageUrl,
                },
                Booth = auction.Booth,
                Bids = auction.Bids.OrderByDescending(b => b.BidPrice).ToList(),

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

    public async Task Update(AuctionUpdateDto auction, CancellationToken cancellationToken,bool saveChanges = true)
    {
        var AuctionRecord = await _context.Auctions
        .FirstOrDefaultAsync(x => x.Id == auction.Id, cancellationToken);
        if (AuctionRecord != null)
        {
            AuctionRecord.ProductId = auction.ProductId == null ? AuctionRecord.ProductId : auction.ProductId;
            AuctionRecord.BoothId = auction.BoothId == null ? AuctionRecord.BoothId : auction.BoothId;
            AuctionRecord.WinnerId = auction.WinnerId == null ? AuctionRecord.WinnerId : auction.WinnerId;
            AuctionRecord.StartTime = auction.StartTime == null ? AuctionRecord.StartTime : auction.StartTime;
            AuctionRecord.EndTime = auction.EndTime == null ? AuctionRecord.EndTime : auction.EndTime;
            AuctionRecord.BasePrice = auction.BasePrice == null ? AuctionRecord.BasePrice : auction.BasePrice;
            AuctionRecord.Status = auction.Status == null ? AuctionRecord.Status : (int)auction.Status;
            AuctionRecord.IsConfirmed = auction.IsConfirmed == null ? AuctionRecord.IsConfirmed : auction.IsConfirmed;

        }
        if (saveChanges)
        { await _context.SaveChangesAsync(cancellationToken);}
    }
}

