using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Dtos.AuctionDtos;
using App.Domain.Core._Products.Dtos.CategorieDtos;
using App.Domain.Core._Products.Entities;
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

    public Task Create(AuctionCreateDto auction, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<List<AuctionOutputDto>> GetAllActive( CancellationToken cancellationToken)
    {
        return await _context.Auctions.AsNoTracking().Where<Auction>(p => p.IsConfirmed==true && p.Status.Equals(1)).Select<Auction, AuctionOutputDto>(a => new AuctionOutputDto
        {
            Id = a.Id,

        }).ToListAsync(cancellationToken);
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
