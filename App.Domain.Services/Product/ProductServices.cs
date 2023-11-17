using App.Domain.Core._Common.Contracts.Repositories;
using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.ProductDtos;
using System.Reflection.Metadata.Ecma335;

namespace App.Domain.Services.Product;

public class ProductServices : IProductServices
{
    protected readonly IProductRepository _productRepository;

    public ProductServices(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<int> Create(ProductCreateDto product, CancellationToken cancellationToken)
    {
        var result = await _productRepository.Create(product, cancellationToken);
            return result;
    }

    public async Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetAll(cancellationToken);
            return result;
    }

    public async Task<List<ProductOutputDto>> GetAllByCategory(CancellationToken cancellationToken, params int[] categoriesId)
    {
        var result = await _productRepository.GetAllByCategory(cancellationToken, categoriesId);
            return result;
    }

    public async Task<ProductOutputDto> GetDetail(int productId, CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetDetail(productId, cancellationToken);
            return result;
    }

    public async Task SoftDelete(int productId, CancellationToken cancellationToken)
    {
        await _productRepository.SoftDelete(productId, cancellationToken);
    }

    public async Task Update(ProductUpdateDto product, CancellationToken cancellationToken)
    {
        await _productRepository.Update(product, cancellationToken);
    }
}
