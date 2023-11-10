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

    public async Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        return await _categoryServices.GetAll(cancellationToken);
    }
}
