using App.Domain.Core.Products.Contracts.IRepositories;
using App.Domain.Core.Products.Dtos.Categories;

namespace App.Infra.Data.Repos.Ef.Products;

public class CategoryRepository : ICategoryRepository
{
    public Task Create(CategoryCreateDto category, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryOutputDto> GetDatail(int categoryId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task HardDelted(int categoryId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(CategoryUpdateDto categor, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
