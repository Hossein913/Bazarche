using App.Domain.Core._Products.Dtos.CategorieDtos;

namespace App.Domain.Core._Products.Contracts.Repositories;

public interface ICategoryRepository
{
    Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken);

    //Task<CategoryOutputDto> GetAllWithProduct(int categoryId, CancellationToken cancellationToken);
    //Task<CategoryOutputDto> GetDetail(int categoryId, CancellationToken cancellationToken);
    Task Create(CategoryCreateDto category, CancellationToken cancellationToken);
    Task Update(CategoryUpdateDto categor, CancellationToken cancellationToken);
    Task HardDelte(int categoryId, CancellationToken cancellationToken);

}
