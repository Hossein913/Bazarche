using App.Domain.Core._Booth.Dtos.BoothDtos;
using System.Net;

namespace App.Domain.Core._Booth.Contracts.Services;

public interface IBoothServices
{
    Task<List<BoothOutputDto>> GetAllHome(CancellationToken cancellationToken);
    Task<List<BoothOutputDto>> GetAllWithListId(List<int> boothId, CancellationToken cancellationToken);
    Task<BoothOutputDto> GetDetailsWithRelations(int BoothId, CancellationToken cancellationToken);
    Task<BoothOutputDto> GetDetail(int BoothId, CancellationToken cancellationToken);
    Task<int> Create(BoothCreateDto boothCreate, CancellationToken cancellationToken, bool saveChanges = true);
    Task Update(BoothUpdateDto boothUpdate, CancellationToken cancellationToken);
    Task ChangeMedal(List<int> BoothIds, CancellationToken cancellationToken);
    Task GroupUpdate(List<BoothUpdateDto> boothUpdate, CancellationToken cancellationToken, bool saveChanges = true);
    Task SoftDelete(int BoothId, CancellationToken cancellationToken);
    Task SetActivity(int sellerId, bool status, CancellationToken cancellationToken);
}
