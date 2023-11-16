using App.Domain.Core._Booth.Contracts.Repositories;
using App.Domain.Core._Booth.Dtos.BoothDtos;
using App.Domain.Core._Booth.Dtos.MedalDtos;
using App.Domain.Core._Booth.Entities;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Booths;

public class MedalRepository : IMedalRepository
{
    private readonly BazarcheContext _context;

    public MedalRepository(BazarcheContext context)
    {
        _context = context;
    }

    public async Task Create(MedalCreateDto medalCreate, CancellationToken cancellationToken)
    {
        var newMedal = new Medal
        {
            Name = medalCreate.Name,
            FeePercentage = medalCreate.FeePercentage,
            MinSalesRequired = medalCreate.MinSalesRequired,
        };

        await _context.Medals.AddAsync(newMedal, cancellationToken);
        var result = await _context.SaveChangesAsync(cancellationToken);
    }
    public async Task<List<MedalOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _context.Medals
        .AsNoTracking()
        .Select<Medal, MedalOutputDto>(b => new MedalOutputDto
        {
            Id = b.Id,
            Name = b.Name,
            FeePercentage = b.FeePercentage,
            MinSalesRequired = b.MinSalesRequired

        }).ToListAsync(cancellationToken);

        return result;
    }

    //public Task<MedalOutputDto> GetDetail(int medalId, CancellationToken cancellationToken)
    //{
    //    throw new NotImplementedException();
    //}

    public async Task HardDelete(int medalId, CancellationToken cancellationToken)
    {
        var medalRecord = await _context.Medals
        .FirstOrDefaultAsync(x => x.Id == medalId, cancellationToken);

        if (medalRecord != null)
        {
            _context.Medals.Remove(medalRecord);

        }
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(MedalUpdateDto medalUpdate, CancellationToken cancellationToken)
    {
        var MedalRecord = await _context.Medals
        .FirstOrDefaultAsync(x => x.Id == medalUpdate.Id, cancellationToken);
        if (MedalRecord != null)
        {
            MedalRecord.Name = medalUpdate.Name;
            MedalRecord.FeePercentage = medalUpdate.FeePercentage;
            MedalRecord.MinSalesRequired = medalUpdate.MinSalesRequired;

        }
        await _context.SaveChangesAsync(cancellationToken);
    }
}

