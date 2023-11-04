using App.Domain.Core._Booth.Contracts.Repositories;
using App.Domain.Core._Booth.Dtos.MedalDtos;

namespace App.Infra.Data.Repos.Ef.Booths;

public class MedalRepository : IMedalRepository
{
    public Task Create(MedalCreateDto medalCreate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<MedalOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<MedalOutputDto> GetDatail(int medalId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SoftDelete(int medalId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(MedalUpdateDto medalUpdate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
