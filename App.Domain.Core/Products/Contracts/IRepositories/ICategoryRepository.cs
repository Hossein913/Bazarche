using App.Domain.Core.Products.Dtos.Categories;

namespace App.Domain.Core.Products.Contracts.IRepositories;

public interface ICategoryRepository
{
    Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<CategoryOutputDto> GetDatail(int categoryId, CancellationToken cancellationToken);
    Task Create(CategoryCreateDto category, CancellationToken cancellationToken);
    Task Update(CategoryUpdateDto categor, CancellationToken cancellationToken);
    Task HardDelted(int categoryId, CancellationToken cancellationToken);

}
