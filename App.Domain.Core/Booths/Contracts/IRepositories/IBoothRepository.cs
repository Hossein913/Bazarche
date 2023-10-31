using App.Domain.Core.Booths.Dtos.Booths;
using App.Domain.Core.Products.Dtos.Categories;

namespace App.Domain.Core.Booths.Contracts.IRepositories;

public interface IBoothRepository
{
    Task<List<BoothOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<BoothOutputDto> GetDatail(int BoothId, CancellationToken cancellationToken);
    Task Create(BoothCreateDto boothCreate, CancellationToken cancellationToken);
    Task Update(BoothUpdateDto boothUpdate, CancellationToken cancellationToken);
    Task SoftDelete(int BoothId, CancellationToken cancellationToken);
}
