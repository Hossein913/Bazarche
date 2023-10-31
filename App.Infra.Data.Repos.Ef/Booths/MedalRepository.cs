using App.Domain.Core.Booths.Contracts.IRepositories;
using App.Domain.Core.Booths.Dtos.Medals;

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
