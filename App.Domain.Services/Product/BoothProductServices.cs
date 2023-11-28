using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.BoothProductDtos;

namespace App.Domain.Services.Product;

public class BoothProductServices : IBoothProductServices
{
    protected readonly IBoothProductRepository _boothProduct;

    public BoothProductServices(IBoothProductRepository boothProduct)
    {
        _boothProduct = boothProduct;
    }

    public async Task Create(BoothProductCreateDto boothProduct, CancellationToken cancellationToken)
    {
        await _boothProduct.Create(boothProduct, cancellationToken);
    }

    public async Task<List<BoothProductOutputDto>> GetAllForProduct(int ProductId, CancellationToken cancellationToken)
    {
        var result = await _boothProduct.GetAllForProduct(ProductId, cancellationToken);
        return result;

    }

    public async Task SoftDelete(int BoothProductId, CancellationToken cancellationToken)
    {
        await _boothProduct.SoftDelete(BoothProductId, cancellationToken);
    }

    public async Task Update(BoothProductUpdateDto boothProduct, CancellationToken cancellationToken)
    {
        await _boothProduct.Update(boothProduct, cancellationToken);
    }
}
