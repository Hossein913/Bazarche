using App.Domain.Core._Booth.Contracts.Repositories;
using App.Domain.Core._Booth.Dtos.BoothDtos;
using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;
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
        throw new NotImplementedException();
    }

    public async Task<List<BoothOutputDto>> GetAllHome(CancellationToken cancellationToken)
    {
        return await _context.Booths.AsNoTracking().Where(p => p.IsDeleted == false && p.IsActive == true).Select<Booth, BoothOutputDto>(b => new BoothOutputDto
        {
            Id = b.Id,
            Name = b.Name,
            AvatarPictureFile = b.AvatarPicture.ImageUrl,
            Description = b.Description,
        }).ToListAsync(cancellationToken);
    }

    public Task<BoothOutputDto> GetDatail(int BoothId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SoftDelete(int BoothId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(BoothUpdateDto boothUpdate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

