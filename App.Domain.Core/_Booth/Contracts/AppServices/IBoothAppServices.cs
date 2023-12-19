using App.Domain.Core._Booth.Dtos.BoothDtos;
using App.Domain.Core._User.Dtos.BoothDtos.BoothAppServiceDto;

namespace App.Domain.Core._Booth.Contracts.AppServices;

public interface IBoothAppServices
{
    Task<List<BoothOutputDto>> GetAllHome(CancellationToken cancellationToken);
    Task<BoothOutputDto> GetDetails(int BoothId, CancellationToken cancellationToken);
    Task<BoothOutputDto> GetDetailsWithRelations(int BoothId, CancellationToken cancellationToken);
    Task Create(BoothCreateDto boothCreate, CancellationToken cancellationToken);
    Task Update(BoothAppServiceUpdateDto boothUpdate, int CurrentUserId, string ProjectRouteAddress, CancellationToken cancellationToken);
    Task SoftDelete(int BoothId, CancellationToken cancellationToken);
    Task SetActivity(int sellerId, bool status, CancellationToken cancellationToken);
}
