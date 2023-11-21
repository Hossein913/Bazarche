using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.CategorieDtos;

namespace App.Domain.AppServices.Product;

public class CategoryAppServices : ICategoryAppServices
{
    private readonly ICategoryServices _categoryServices;
    public CategoryAppServices(ICategoryServices categoryRepository)
    {
        _categoryServices = categoryRepository;
    }

    public Task Create(CategoryCreateDto category, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        return await _categoryServices.GetAll(cancellationToken);
    }

    public async Task<CategoryOutputDto> GetById(int Id, CancellationToken cancellationToken)
    {
        var result = await _categoryServices.GetById(Id, cancellationToken);
        return result;
    }

    public Task HardDelte(int categoryId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(CategoryUpdateDto categor, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
