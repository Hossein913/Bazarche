using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.BoothProductDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._Products.Enums;

namespace App.Domain.Services.Product;

public class BoothProductServices : IBoothProductServices
{
    protected readonly IBoothProductRepository _boothProduct;

    public BoothProductServices(IBoothProductRepository boothProduct)
    {
        _boothProduct = boothProduct;
    }

    public async Task ChangeBoothProductState(int boothProductId, BoothProductStatus status, CancellationToken cancellationToken)
    {
        BoothProductUpdateDto boothProductUpdateDto = new BoothProductUpdateDto {Id = boothProductId ,Status = status };
        await _boothProduct.Update(boothProductUpdateDto,cancellationToken);
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

    public async Task<int> GetProductIdAsync(int boothProductId, CancellationToken cancellationToken)
    {
        var resutl = await _boothProduct.GetProductIdAsync(boothProductId, cancellationToken);
        return resutl;
    }

    public async Task SetActivity(int BoothProductId, CancellationToken cancellationToken)
    {
        await _boothProduct.SetActivity(BoothProductId, cancellationToken);
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
