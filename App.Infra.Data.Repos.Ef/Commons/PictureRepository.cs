﻿using App.Domain.Core._Common.Contracts.Repositories;
using App.Domain.Core._Common.Dtos.PictureDtos;
using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Entities;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Commons;

public class PictureRepository : IPictureRepository
{
    private readonly BazarcheContext _context;

    public PictureRepository(BazarcheContext context)
    {
        _context = context;
    }
    public async Task<int> Create(PictureCreateDto pictureCreate, CancellationToken cancellationToken)
    {
        var newPicture = new Picture
        {
            ImageUrl= pictureCreate.ImageUrl,
            CreatedBy = pictureCreate.CreatedBy,
            CreatedAt = DateTime.Now
        };

        await _context.Pictures.AddAsync(newPicture, cancellationToken);
        var result = await _context.SaveChangesAsync(cancellationToken);
        if (result != 0)
            return newPicture.Id;
        return 0;
    }

    public async Task HardDeleted(int pictureId, CancellationToken cancellationToken)
    {
        var pictureRecord = await _context.Pictures
    .FirstOrDefaultAsync(x => x.Id == pictureId, cancellationToken);

        if (pictureRecord != null)
        {
            _context.Pictures.Remove(pictureRecord);
        }
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task SoftDeleted(int pictureId, CancellationToken cancellationToken)
    {
        var pictureRecord = await _context.Pictures
    .FirstOrDefaultAsync(x => x.Id == pictureId, cancellationToken);

        if (pictureRecord != null)
        {
            pictureRecord.IsDeleted = true;
        }
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(PictureUpdateDto pictureDto, CancellationToken cancellationToken)
    {
        var pictureRecord = await _context.Pictures
    .FirstOrDefaultAsync(x => x.Id == pictureDto.Id, cancellationToken);

        if (pictureRecord != null)
        {
            pictureRecord.ImageUrl = pictureDto.ImageUrl;
            
        }
        await _context.SaveChangesAsync(cancellationToken);
    }
}
