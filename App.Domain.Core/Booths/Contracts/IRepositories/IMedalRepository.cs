using App.Domain.Core.Booths.Dtos.Booths;
using App.Domain.Core.Booths.Dtos.Medals;

namespace App.Domain.Core.Booths.Contracts.IRepositories;

public interface IMedalRepository
{
    Task<List<MedalOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<MedalOutputDto> GetDatail(int medalId, CancellationToken cancellationToken);
    Task Create(MedalCreateDto medalCreate, CancellationToken cancellationToken);
    Task Update(MedalUpdateDto medalUpdate, CancellationToken cancellationToken);
    Task SoftDelete(int medalId, CancellationToken cancellationToken);

}
