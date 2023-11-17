using App.Domain.Core._Products.Dtos.CategorieDtos;

namespace App.Domain.Core._Products.Contracts.Services;

public interface ICategoryServices
{
    Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken);
    Task Create(CategoryCreateDto category, CancellationToken cancellationToken);
    Task Update(CategoryUpdateDto categor, CancellationToken cancellationToken);
    Task HardDelte(int categoryId, CancellationToken cancellationToken);

}
