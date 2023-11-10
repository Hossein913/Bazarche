using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.CategorieDtos;

namespace App.Domain.Services.Product;

public class CategoryServices : ICategoryServices
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryServices(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _categoryRepository.GetAll(cancellationToken);
        return result;
    }

}
