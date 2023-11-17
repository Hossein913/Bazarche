using App.Domain.Core._Booth.Dtos.BoothDtos;

namespace App.Domain.Core._Booth.Contracts.Services;

public interface IBoothServices
{
    Task<List<BoothOutputDto>> GetAllHome(CancellationToken cancellationToken);
    Task<BoothOutputDto> GetDetail(int BoothId, CancellationToken cancellationToken);
    Task Create(BoothCreateDto boothCreate, CancellationToken cancellationToken);
    Task Update(BoothUpdateDto boothUpdate, CancellationToken cancellationToken);
    Task SoftDelete(int BoothId, CancellationToken cancellationToken);
}
