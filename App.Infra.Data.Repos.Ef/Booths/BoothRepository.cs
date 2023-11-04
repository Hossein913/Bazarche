using App.Domain.Core._Booth.Contracts.Repositories;
using App.Domain.Core._Booth.Dtos.BoothDtos;

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
