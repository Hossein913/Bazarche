using App.Domain.Core._Common.Contracts.Services;
using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.CategorieDtos;
using RedisCache;
using System.Collections.Generic;

namespace App.Domain.AppServices.Product;

public class CategoryAppServices : ICategoryAppServices
{

    private readonly IRedisCacheServices _redisCacheServices;
    private readonly ICategoryServices _categoryServices;

    public CategoryAppServices(ICategoryServices categoryRepository, IRedisCacheServices redisCacheServices)
    {
        _categoryServices = categoryRepository;
        _redisCacheServices = redisCacheServices;
    }

    public Task Create(CategoryCreateDto category, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    //public async Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken)
    //{
    //    List<CategoryOutputDto> categoriesResult = _redisCacheServices.Get<List<CategoryOutputDto>>(CacheKey.Categories);

    //    if (!_redisCacheServices.HasCache(CacheKey.Categories))
    //    {
    //        categoriesResult = await _categoryServices.GetAll(cancellationToken);
    //        _redisCacheServices.Set(CacheKey.Categories, categoriesResult, 1);
    //    }

    //    return categoriesResult;
    //}

    public async Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken)
    {

        var categoriesResult = await _categoryServices.GetAll(cancellationToken);
        return categoriesResult;
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
