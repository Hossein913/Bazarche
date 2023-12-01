using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Dtos.BoothProductDtos;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._Products.Enums;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace App.Infra.Data.Repos.Ef.Products;

public class BoothProductRepository : IBoothProductRepository
{
    private readonly BazarcheContext _context;

    public BoothProductRepository(BazarcheContext context)
    {
        _context = context;
    }

    public async Task Create(BoothProductCreateDto boothProduct, CancellationToken cancellationToken)
    {
        var newBoothProduct = new BoothProduct
        {
            ProductId = boothProduct.ProductId,
            BoothId = boothProduct.BoothId,
            Price = boothProduct.Price,
            Count = boothProduct.Count,
            Status = Convert.ToBoolean(BoothProductStatus.Active),
            CreatedAt = DateTime.Now,
            IsDeleted = false
            

        };

        await _context.BoothProducts.AddAsync(newBoothProduct, cancellationToken);
        var result = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<BoothProductOutputDto>> GetAllForProduct(int ProductId, CancellationToken cancellationToken)
    {
            var boothProductRecord = await _context.BoothProducts
            .AsNoTracking()
            .Include(bp => bp.Booth)
            .ThenInclude(b => b.Medal)
            .Where( p => p.ProductId == ProductId && p.IsDeleted == false )
             .Select<BoothProduct, BoothProductOutputDto>(c => new BoothProductOutputDto
                {
                 Id = c.Id,
                 Price = c.Price,
                 Count = c.Count,
                 Status = c.Status,
                 CreatedAt = c.CreatedAt,
                 Booth = c.Booth

             }).ToListAsync(cancellationToken);
            return boothProductRecord;
    }

    public async Task<int> GetProductIdAsync(int boothProductId, CancellationToken cancellationToken)
    {
        var boothProductRecord = await _context.BoothProducts
        .FirstOrDefaultAsync(p => p.Id == boothProductId && p.IsDeleted == false);
               return boothProductRecord.ProductId;
    }


    // ------- Attention --> Boothproducts are not seprated entities therefor the shoulde load with its product
    //public async Task<List<BoothProductOutputDto>> GetAllForBooth(int boothId, CancellationToken cancellationToken)
    //{
    //    var boothProductRecord = await _context.BoothProducts
    //    .AsNoTracking()
    //    .Where(
    //        p => p.BoothId == boothId &&
    //        p.IsDeleted == false &&
    //        p.Status == Convert.ToBoolean(BoothProductStatus.Active)
    //        )
    //     .Select<BoothProduct, BoothProductOutputDto>(c => new BoothProductOutputDto
    //        {
    //         Id = c.Id,
    //         BoothId = c.BoothId,
    //         Price = c.Price,
    //         Count = c.Count,
    //         Product = c.Product,

    //     }).ToListAsync(cancellationToken);

    //    return boothProductRecord;
    //}

    //------Attention --> Product price is part of a product properties therefor it should be inside the product

    //public Task<BoothProductOutputDto> GetDetail(int boothProductId, CancellationToken cancellationToken)
    //{
    //    throw new NotImplementedException();
    //}


    public async Task SoftDelete(int BoothProductId, CancellationToken cancellationToken)// Is usable for admin to remove a BoothProduct
    {
        var boothProductRecord = await _context.BoothProducts
    .FirstOrDefaultAsync(x => x.Id == BoothProductId, cancellationToken);

        if (boothProductRecord != null)
        {
            boothProductRecord.IsDeleted = true;

        }
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(BoothProductUpdateDto boothProduct, CancellationToken cancellationToken)
    {
        var BoothProductRecord = await _context.BoothProducts
        .FirstOrDefaultAsync(x => x.Id == boothProduct.Id, cancellationToken);
        if (BoothProductRecord != null)
        {
            BoothProductRecord.ProductId = boothProduct.ProductId;
            BoothProductRecord.BoothId = boothProduct.BoothId;
            BoothProductRecord.Price = boothProduct.Price;
            BoothProductRecord.Count = boothProduct.Count;
            BoothProductRecord.Status = boothProduct.Status;
            BoothProductRecord.IsDeleted = boothProduct.IsDeleted;
        }
        await _context.SaveChangesAsync(cancellationToken);
    }
}


