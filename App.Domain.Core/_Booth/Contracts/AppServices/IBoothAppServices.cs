using App.Domain.Core._Booth.Dtos.BoothDtos;

namespace App.Domain.Core._Booth.Contracts.AppServices;

public interface IBoothAppServices
{
    Task<List<BoothOutputDto>> GetAllHome(CancellationToken cancellationToken);
    Task<BoothOutputDto> GetDetails(int BoothId, CancellationToken cancellationToken);
    Task<BoothOutputDto> GetDetailsWithRelations(int BoothId, CancellationToken cancellationToken);
    Task Create(BoothCreateDto boothCreate, CancellationToken cancellationToken);
    Task Update(BoothUpdateDto boothUpdate, CancellationToken cancellationToken);
    Task SoftDelete(int BoothId, CancellationToken cancellationToken);
}
