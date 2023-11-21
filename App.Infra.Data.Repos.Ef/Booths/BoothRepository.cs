using App.Domain.Core._Booth.Contracts.Repositories;
using App.Domain.Core._Booth.Dtos.BoothDtos;
using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._User.Dtos.SellersDtos;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;

namespace App.Infra.Data.Repos.Ef.Booths;

public class BoothRepository : IBoothRepository
{
    private readonly BazarcheContext _context;

    public BoothRepository(BazarcheContext context)
    {
        _context = context;
    }

    public async Task Create(BoothCreateDto boothCreate, CancellationToken cancellationToken)
    {
        var newBooth = new Booth
        {
            Name = boothCreate.Name,
            AvatarPictureId = boothCreate.AvatarPictureId,
            MedalId = boothCreate.MedalId,
            AccountBalance = boothCreate.AccountBalance,
            Description = boothCreate.Description,
            IsActive = false,
            IsDeleted = false,
        };

        await _context.Booths.AddAsync(newBooth, cancellationToken);
        var result = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<BoothOutputDto>> GetAllHome(CancellationToken cancellationToken)
    {
        var result = await _context.Booths
            .AsNoTracking()
            .Where(p => p.IsDeleted == false && p.IsActive == true)
            .Select<Booth, BoothOutputDto>(b => new BoothOutputDto
            {
            Id = b.Id,
            Name = b.Name,
            AvatarPictureFile = b.AvatarPicture.ImageUrl,
            Description = b.Description,
            }).ToListAsync(cancellationToken);

        return result;
    }

    public async Task<BoothOutputDto> GetDetail(int BoothId, CancellationToken cancellationToken)
    {
        var booth = await _context.Booths
        .Include(a => a.Auctions)
        .Include(a => a.BoothProducts)
        .Include(a => a.AvatarPicture)
        .Include(a => a.Medal)
        .FirstOrDefaultAsync(a => a.Id == BoothId, cancellationToken);

        if (booth != null)
        {
            var boothRecord = new BoothOutputDto
            {
                Id = booth.Id,
                Name = booth.Name,
                AccountBalance = booth.AccountBalance,
                TotalSell = booth.TotalSell,
                Description = booth.Description,
                IsActive = booth.IsActive,
                Auctions = booth.Auctions,
                AvatarPicture = booth.AvatarPicture,
                BoothProducts = booth.BoothProducts,
                Medal = booth.Medal,
            };
            return boothRecord;
        }
        else
        {
            return null;
        }
    }

    public async Task SoftDelete(int BoothId, CancellationToken cancellationToken)
    {
        var commentRecord = await _context.Booths
        .FirstOrDefaultAsync(x => x.Id == BoothId, cancellationToken);

        if (commentRecord != null)
        {
            commentRecord.IsDeleted = true;

        }
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(BoothUpdateDto boothUpdate, CancellationToken cancellationToken)
    {
        var BoothRecord = await _context.Booths
        .FirstOrDefaultAsync(x => x.Id == boothUpdate.Id, cancellationToken);
        if (BoothRecord != null)
        {
            BoothRecord.Name = boothUpdate.Name;
            BoothRecord.AvatarPictureId = boothUpdate.AvatarPictureId;
            BoothRecord.MedalId = boothUpdate.MedalId;
            BoothRecord.AccountBalance = boothUpdate.AccountBalance;
            BoothRecord.Description = boothUpdate.Description;
            BoothRecord.IsActive = boothUpdate.IsActive;
            BoothRecord.IsDeleted = boothUpdate.IsDeleted;

        }
        await _context.SaveChangesAsync(cancellationToken);
    }
}

