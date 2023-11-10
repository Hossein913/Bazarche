using App.Domain.Core._Booth.Dtos.BoothDtos;

namespace App.Domain.Core._Booth.Contracts.Repositories;

public interface IBoothRepository
{
    Task<List<BoothOutputDto>> GetAllHome(CancellationToken cancellationToken);
    Task<BoothOutputDto> GetDatail(int BoothId, CancellationToken cancellationToken);
    Task Create(BoothCreateDto boothCreate, CancellationToken cancellationToken);
    Task Update(BoothUpdateDto boothUpdate, CancellationToken cancellationToken);
    Task SoftDelete(int BoothId, CancellationToken cancellationToken);
}
