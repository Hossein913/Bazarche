﻿using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._Products.Enums;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Threading;

namespace App.Infra.Data.Repos.Ef.Products;

public class ProductRepository : IProductRepository
{
    private readonly BazarcheContext _context;

    public ProductRepository(BazarcheContext context)
    {
        _context = context;
    }

    public async Task<int> Create(ProductCreateDto product, CancellationToken cancellationToken)
    {
        var newproduct = new Product
        {
            Name = product.Name,
            Brand = product.Brand,
            Grantee = product.Grantee,
            InformationDetails = product.InformationDetails,
            Description = product.Description,
            IncludedComponents = product.IncludedComponents,
            IsConfirmed = product.IsConfirmed,
            BasePrice = product.BasePrice,
            IsDeleted = false,
            Pictures = product.Pictures,
        };

                     await _context.Products.AddAsync(newproduct, cancellationToken);
        var result = await _context.SaveChangesAsync(cancellationToken);
        if (result != 0)
            return newproduct.Id;

        return 0;
    }

    // the not confirmed entities are not so much therefor All the product
    //  will return and at Home view not confirmed ons will get filter
    public async Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken)
    {

        var result = await _context.Products
            .AsNoTracking()
            .Where(p => p.IsDeleted == false)
            .Select<Product, ProductOutputDto>(c => new ProductOutputDto
            {
                Id = c.Id,
                Name = c.Name,
                Brand = c.Brand,
                Avatar = c.Pictures.FirstOrDefault().ImageUrl ?? null,
                Grantee = c.Grantee,
                Description = c.Description,
                IsConfirmed = c.IsConfirmed,
                MaxPrice = c.BoothProducts.Max(p => p.Price),
                MinPrice = c.BoothProducts.Min(p => p.Price),
             }).ToListAsync(cancellationToken);
        return result;
    }
    
    public async Task<List<ProductOutputDto>> GetAllByCategory(CancellationToken cancellationToken,params int[] categoriesId)
    {
        var result = await _context.Products
            .AsNoTracking()
            .Where(p => p.IsDeleted == false && categoriesId.Contains(p.CategoryId))
            .Select<Product, ProductOutputDto>(c => new ProductOutputDto
            {
                Id = c.Id,
                Name = c.Name,
                Brand = c.Brand,
                Avatar = c.Pictures.FirstOrDefault().ImageUrl ?? null,
                Grantee = c.Grantee,
                Description = c.Description,
                IsConfirmed = c.IsConfirmed,
                MaxPrice = c.BoothProducts.Max(p => p.Price) >= c.BasePrice ? c.BoothProducts.Max(p => p.Price): c.BasePrice,
                MinPrice = c.BoothProducts.Min(p => p.Price) >= c.BasePrice ? c.BoothProducts.Min(p => p.Price) : c.BasePrice,
            }).ToListAsync(cancellationToken);
        return result;
    }

    public async Task<List<ProductOutputDto>> GetAllForBooth(int BoothId, CancellationToken cancellationToken)
    {
        var result = await _context.Products
            .AsNoTracking()
            .Where(p => p.IsDeleted == false && p.BoothProducts.Any(bp => bp.BoothId== BoothId))
            .Select<Product, ProductOutputDto>(c => new ProductOutputDto
            {
                Id = c.Id,
                Name = c.Name,
                Brand = c.Brand,
                Avatar = c.Pictures.FirstOrDefault().ImageUrl ?? null,
                Grantee = c.Grantee,
                Description = c.Description,
                BoothProducts = c.BoothProducts.Where(bp => bp.BoothId == BoothId).ToList(),
                IsConfirmed = c.IsConfirmed,

            }).ToListAsync(cancellationToken);
        return result;
    }


    public async Task<List<ProductOutputDto>> GetAllForOrderItems(List<Dictionary<int,int>> ProductPrice, CancellationToken cancellationToken)
    {

        var result = await _context.Products
            .AsNoTracking()
            //.Where(p => p.IsDeleted == false && p.BoothProducts.Any(bp => bp.BoothId == BoothId))
            .Where(p => p.IsDeleted == false && ProductPrice.Any(pp => pp.Keys.Equals(p.Id)))
            .Select<Product, ProductOutputDto>(c => new ProductOutputDto
            {
                Id = c.Id,
                Name = c.Name,
                Brand = c.Brand,
                Avatar = c.Pictures.FirstOrDefault().ImageUrl ?? null,
                Grantee = c.Grantee,
                Description = c.Description,
                BoothProducts = c.BoothProducts.Where( bp => ProductPrice.Any(pp => pp.Values.Equals(bp.Id))).ToList(),
                IsConfirmed = c.IsConfirmed,

            }).ToListAsync(cancellationToken);
        return result;
    }

    public async Task<ProductOutputDto> GetDetail(int productId, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .Include(p => p.Pictures)
            .Include(p => p.Comments.Where(c => c.IsConfirmed == true))
            .Include(p => p.BoothProducts)
            .ThenInclude(bp => bp.Booth)
            .FirstOrDefaultAsync(p => p.Id ==productId && p.IsDeleted == false, cancellationToken);

        if (product != null)
        {
            var productrecord = new ProductOutputDto
            {
                Name = product.Name,
                Brand = product.Brand,
                Grantee = product.Grantee,
                InformationDetails = product.InformationDetails,
                Description = product.Description,
                IncludedComponents = product.IncludedComponents,
                IsConfirmed = product.IsConfirmed,
                BasePrice = product.BasePrice,
                Pictures = product.Pictures,
                BoothProducts = product.BoothProducts.ToList(),
                Comments = product.Comments
            };
            return productrecord;
        }
        else 
        {
            return null;
        }

    }

    public async Task SoftDelete(int productId, CancellationToken cancellationToken)
    {

        var productRecord = await _context.Products
            .FirstOrDefaultAsync(x => x.Id == productId,cancellationToken);

        if (productRecord != null)
        {
            productRecord.IsDeleted = true;

        }
        await _context.SaveChangesAsync(cancellationToken);

    }

    public async Task Update(ProductUpdateDto product, CancellationToken cancellationToken)
    {
        var productRecord= await _context.Products
             .FirstOrDefaultAsync(x => x.Id == product.Id,cancellationToken);
        if (productRecord != null)
        {
            productRecord.Name = product.Name;
            productRecord.Brand = product.Brand;
            productRecord.Grantee = product.Grantee;
            productRecord.InformationDetails = product.InformationDetails;
            productRecord.Description = product.Description;
            productRecord.IncludedComponents = product.IncludedComponents;
            productRecord.IsConfirmed = product.IsConfirmed;
            productRecord.BasePrice = product.BasePrice;
            productRecord.IsDeleted = product.IsDeleted;

        }
            await _context.SaveChangesAsync(cancellationToken);


    }
}
