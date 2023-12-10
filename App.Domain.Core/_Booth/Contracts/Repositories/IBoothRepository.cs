using App.Domain.Core._Booth.Dtos.BoothDtos;

namespace App.Domain.Core._Booth.Contracts.Repositories;

public interface IBoothRepository
{
    Task<List<BoothOutputDto>> GetAllHome(CancellationToken cancellationToken);
    Task<List<BoothOutputDto>> GetAllWithListId(List<int> boothId, CancellationToken cancellationToken);
    Task<BoothOutputDto> GetDetailsWithRelations(int BoothId, CancellationToken cancellationToken);
    Task<BoothOutputDto> GetDetails(int BoothId, CancellationToken cancellationToken);
    Task<int> Create(BoothCreateDto boothCreate, CancellationToken cancellationToken,bool saveChanges = true);
    Task Update(BoothUpdateDto boothUpdate, CancellationToken cancellationToken, bool saveChanges = true);
    Task GroupUpdate(List<BoothUpdateDto> boothUpdate, CancellationToken cancellationToken, bool saveChanges = true);
    Task SoftDelete(int BoothId, CancellationToken cancellationToken);
}
