using App.Domain.Core._Booth.Entities;
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

    public async Task<List<ProductOutputDto>> GetAllForBooth(int BoothId, CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetAllForBooth(BoothId, cancellationToken);
        return result;
    }

    public async Task<List<ProductOutputDto>> GetAllForOrderItems(List<Dictionary<int, int>> ProductPrice, CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetAllForOrderItems(ProductPrice, cancellationToken);
        return result;
    }

    public async Task<List<ProductOutputDto>> GetAllToConfirm(CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetAllToConfirm(cancellationToken);
        return result;
    }

    public async Task<List<ProductOutputDto>> GetAllWithIdList(List<int> ProductIdList, CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetAllWithIdList(ProductIdList, cancellationToken);
        return result;
    }

    public async Task<ProductOutputDto> GetDetails(int productId, CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetDetail(productId, cancellationToken);
            return result;
    }

    public async Task<ProductOutputDto> GetDetailWithRelation(int productId, CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetDetailWithRelation(productId, cancellationToken);
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

    public async Task ConfirmProduct(int productId, bool status, CancellationToken cancellationToken)
    {
        ProductUpdateDto productUpdateDto = new ProductUpdateDto { Id = productId , IsConfirmed = status };
        await _productRepository.Update(productUpdateDto, cancellationToken);
    }

}
