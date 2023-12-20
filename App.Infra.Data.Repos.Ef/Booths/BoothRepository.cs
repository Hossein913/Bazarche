using App.Domain.Core._Booth.Contracts.Repositories;
using App.Domain.Core._Booth.Dtos.BoothDtos;
using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Common.Entities;
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

    public async Task<int> Create(BoothCreateDto boothCreate, CancellationToken cancellationToken, bool saveChanges = true)
    {
        Picture picture = new Picture
        {
            ImageUrl = boothCreate.AvatarPicture.ImageUrl,
            CreatedBy = boothCreate.AvatarPicture.CreatedBy,
            CreatedAt = DateTime.Now,
            IsDeleted = false,
        };
        var newBooth = new Booth
        {
            Name = boothCreate.Name,
            AvatarPictureId = picture.Id,
            MedalId = 1,
            AccountBalance = boothCreate.AccountBalance,
            Description = boothCreate.Description,
            IsActive = false,
            IsDeleted = false,
            AvatarPicture = picture,
        };

        await _context.Booths.AddAsync(newBooth, cancellationToken);
        if (saveChanges)
        {
            var result = await _context.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                return newBooth.Id;
            }
            return 0;

        }
        return newBooth.Id;

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
            MedalName = b.Medal.Name
            }).ToListAsync(cancellationToken);

        return result;
    }

    public async Task<List<BoothOutputDto>> GetAllWithListId(List<int> boothId, CancellationToken cancellationToken)
    {
        var result = await _context.Booths
        .AsNoTracking()
        .Where(p => p.IsDeleted == false && p.IsActive == true && boothId.Contains(p.Id))
        .Select<Booth, BoothOutputDto>(b => new BoothOutputDto
        {
            Id = b.Id,
            Name = b.Name,
            AvatarPictureFile = b.AvatarPicture.ImageUrl,
            Description = b.Description,
            Medal = b.Medal,
            AccountBalance = b.AccountBalance,
            TotalSell = b.TotalSell
        }).ToListAsync(cancellationToken);

        return result;
    }
        public async Task<BoothOutputDto> GetDetailsWithRelations(int BoothId, CancellationToken cancellationToken)
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

    public async Task<BoothOutputDto> GetDetails(int BoothId, CancellationToken cancellationToken)
    {
        var booth = await _context.Booths
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

    public async Task Update(BoothUpdateDto boothUpdate, CancellationToken cancellationToken, bool saveChanges = true)
    {

        var BoothRecord = await _context.Booths
        .FirstOrDefaultAsync(x => x.Id == boothUpdate.Id, cancellationToken);
        if (BoothRecord != null)
        {
            BoothRecord.Name = boothUpdate.Name != null ? boothUpdate.Name : BoothRecord.Name;
            BoothRecord.MedalId = boothUpdate.MedalId > 1 ? boothUpdate.MedalId : BoothRecord.MedalId;
            BoothRecord.Description = boothUpdate.Description != null ? boothUpdate.Description : BoothRecord.Description;
            BoothRecord.AccountBalance = boothUpdate.AccountBalance != null ? Convert.ToInt32( boothUpdate.AccountBalance) : BoothRecord.AccountBalance;
            BoothRecord.TotalSell = boothUpdate.TotalSell != null ? Convert.ToInt32(boothUpdate.TotalSell) : BoothRecord.TotalSell;
            BoothRecord.IsActive = boothUpdate.IsActive != null ? Convert.ToBoolean( boothUpdate.IsActive) : BoothRecord.IsActive;
            BoothRecord.IsDeleted = boothUpdate.IsDeleted != null ? Convert.ToBoolean(boothUpdate.IsDeleted) : BoothRecord.IsDeleted;
            BoothRecord.AvatarPictureId = boothUpdate.AvatarPicture != null ? boothUpdate.AvatarPicture.Id : BoothRecord.AvatarPictureId;
            if (boothUpdate.AvatarPicture != null)
            {
                BoothRecord.AvatarPicture = boothUpdate.AvatarPicture;
            }
        }
        if (saveChanges)
        { await _context.SaveChangesAsync(cancellationToken); }
    }

    public async Task GroupUpdate(List<BoothUpdateDto> boothsUpdate, CancellationToken cancellationToken, bool saveChanges = true)
    {
        List<int> BoothsId = boothsUpdate.Select(x => x.Id).ToList();

        var BoothRecord = await _context.Booths
        .Where(b => BoothsId.Contains( b.Id) )
        .ToListAsync();

        BoothRecord.ForEach(b => {
            BoothUpdateDto boothUpdate = boothsUpdate.SingleOrDefault( ub => ub.Id == b.Id);
        if (BoothRecord != null)
        {
            b.Name = boothUpdate.Name != null ? boothUpdate.Name : b.Name;
            b.AvatarPictureId = boothUpdate.AvatarPictureId != null ? boothUpdate.AvatarPictureId : b.AvatarPictureId;
            b.MedalId = boothUpdate.MedalId != 0 ? boothUpdate.MedalId : b.MedalId;
            b.Description = boothUpdate.Description != null ? boothUpdate.Description : b.Description;
            b.AccountBalance = boothUpdate.AccountBalance != null ? Convert.ToInt32(boothUpdate.AccountBalance) : b.AccountBalance;
            b.TotalSell = boothUpdate.TotalSell != null ? Convert.ToInt32(boothUpdate.TotalSell) : b.TotalSell;

        }});
        if (saveChanges)
        { await _context.SaveChangesAsync(cancellationToken); }
    }

    public async Task SetActivity(int BoothId, bool status, CancellationToken cancellationToken)
    {
        var commentRecord = await _context.Booths
        .FirstOrDefaultAsync(x => x.Id == BoothId, cancellationToken);

        if (commentRecord != null)
        {
            commentRecord.IsActive = status;

        }
        await _context.SaveChangesAsync(cancellationToken);

    }
}

