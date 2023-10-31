using App.Domain.Core.Booths.Contracts.IRepositories;
using App.Domain.Core.Booths.Dtos.Booths;

namespace App.Infra.Data.Repos.Ef.Booths;

public class BoothRepository : IBoothRepository
{
    public Task Create(BoothCreateDto boothCreate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<BoothOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
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
