using App.Domain.Core._Booth.Dtos.MedalDtos;

namespace App.Domain.Core._Booth.Contracts.Services;

public interface IMedalServices
{
    Task<List<MedalOutputDto>> GetAll(CancellationToken cancellationToken);
    Task Create(MedalCreateDto medalCreate, CancellationToken cancellationToken);
    Task Update(MedalUpdateDto medalUpdate, CancellationToken cancellationToken);
    Task HardDelete(int medalId, CancellationToken cancellationToken);

}
