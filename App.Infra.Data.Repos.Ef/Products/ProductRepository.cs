using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Dtos.CommentDtos;
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
            CategoryId = product.CategoryId,
            CreatedBy = product.CreatedBy,
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
            .Where(p => p.IsDeleted == false && p.IsConfirmed != null)
            .Select<Product, ProductOutputDto>(c => new ProductOutputDto
            {
                Id = c.Id,
                Name = c.Name,
                Brand = c.Brand,
                Avatar = c.Pictures.FirstOrDefault(p => p.IsDeleted ==false).ImageUrl ?? null,
                Grantee = c.Grantee,
                Description = c.Description,
                IsConfirmed = c.IsConfirmed,
                MaxPrice = c.BoothProducts.Max(p => p.Price),
                MinPrice = c.BoothProducts.Min(p => p.Price),
             }).ToListAsync(cancellationToken);
        return result;
    }

    public async Task<List<ProductOutputDto>> GetAllToConfirm(CancellationToken cancellationToken)
    {

        var result = await _context.Products
            .AsNoTracking()
            .Where(p => p.IsDeleted == false && p.IsConfirmed == null)
            .Select<Product, ProductOutputDto>(c => new ProductOutputDto
            {
                Id = c.Id,
                Name = c.Name,
                Brand = c.Brand,
                Avatar = c.Pictures.FirstOrDefault(p => p.IsDeleted == false).ImageUrl ?? null,
                Grantee = c.Grantee,
                Description = c.Description,
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
                Avatar = c.Pictures.FirstOrDefault(p => p.IsDeleted == false).ImageUrl ?? null,
                Grantee = c.Grantee,
                Description = c.Description,
                IsConfirmed = c.IsConfirmed,
                MaxPrice = c.BoothProducts.Max(p => p.Price) >= c.BasePrice ? c.BoothProducts.Max(p => p.Price): c.BasePrice,
                MinPrice = c.BoothProducts.Min(p => p.Price) >= c.BasePrice ? c.BoothProducts.Min(p => p.Price) : c.BasePrice,
            }).ToListAsync(cancellationToken);
        return result;
    }

    //-------BoothProduct are list to show the Price hostory in seller panel
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
                Avatar = c.Pictures.FirstOrDefault(p => p.IsDeleted == false).ImageUrl ?? null,
                Grantee = c.Grantee,
                Description = c.Description,
                BoothProducts = c.BoothProducts.Where(bp => bp.BoothId == BoothId).ToList(),
                IsConfirmed = c.IsConfirmed,

            }).ToListAsync(cancellationToken);
        return result;
    }

    public async Task<List<ProductOutputDto>> GetAllByOwner(int appuserId, CancellationToken cancellationToken)
    {
        var result = await _context.Products
            .AsNoTracking()
            .Where(p => p.IsDeleted == false && p.CreatedBy == appuserId)
            .Select<Product, ProductOutputDto>(c => new ProductOutputDto
            {
                Id = c.Id,
                Name = c.Name,
                Brand = c.Brand,
                BasePrice = c.BasePrice,
                Avatar = c.Pictures.FirstOrDefault(p => p.IsDeleted == false).ImageUrl ?? null,
                Grantee = c.Grantee,
                Description = c.Description,
                BoothProducts = c.BoothProducts.ToList(),
                IsConfirmed = c.IsConfirmed,
                CategoryTitle = c.Category.Title,
                CreatedAt = c.CreatedAt,

            }).OrderBy(p => p.CreatedAt).ToListAsync(cancellationToken);
        return result;
    }

    public async Task<List<ProductOutputDto>> GetAllForOrderItems(List<Dictionary<int,int>> ProductPrice, CancellationToken cancellationToken)
    {

        var result = await _context.Products
            .AsNoTracking()
            //.Where(p => p.IsDeleted == false && p.BoothProducts.Any(bp => bp.BoothId == BoothId))
            .Where(p => p.IsDeleted == false && p.IsConfirmed == true && ProductPrice.Any(pp => pp.Keys.Equals(p.Id)))
            .Select<Product, ProductOutputDto>(c => new ProductOutputDto
            {
                Id = c.Id,
                Name = c.Name,
                Brand = c.Brand,
                Avatar = c.Pictures.FirstOrDefault(p => p.IsDeleted == false).ImageUrl ?? null,
                Grantee = c.Grantee,
                Description = c.Description,
                BoothProducts = c.BoothProducts.Where( bp => ProductPrice.Any(pp => pp.Values.Equals(bp.Id))).ToList(),

            }).ToListAsync(cancellationToken);
        return result;
    }
    public async Task<List<ProductOutputDto>> GetAllWithIdList(List<int> ProductIdList, CancellationToken cancellationToken)
    {

        var result = await _context.Products
            .AsNoTracking()
            .Where(p => p.IsDeleted == false && ProductIdList.Contains(p.Id))
            .Select<Product, ProductOutputDto>(c => new ProductOutputDto
            {
                Id = c.Id,
                Name = c.Name,
                Brand = c.Brand,
                Avatar = c.Pictures.FirstOrDefault(p => p.IsDeleted == false).ImageUrl,
                Grantee = c.Grantee,
                Description = c.Description,
                IsConfirmed = c.IsConfirmed,
                MaxPrice = c.BoothProducts.Max(p => p.Price) >= c.BasePrice ? c.BoothProducts.Max(p => p.Price) : c.BasePrice,
                MinPrice = c.BoothProducts.Min(p => p.Price) >= c.BasePrice ? c.BoothProducts.Min(p => p.Price) : c.BasePrice
            }).ToListAsync(cancellationToken);
        return result;
    }

    public async Task<ProductOutputDto> GetDetail(int productId, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .Include(p => p.Pictures)
            .FirstOrDefaultAsync(p => p.Id ==productId && p.IsDeleted == false, cancellationToken);

        if (product != null)
        {
            var productRecord = new ProductOutputDto
            {
                Id = product.Id,
                Name = product.Name,
                Brand = product.Brand,
                Grantee = product.Grantee,
                InformationDetails = product.InformationDetails,
                Description = product.Description,
                IncludedComponents = product.IncludedComponents,
                IsConfirmed = product.IsConfirmed,
                BasePrice = product.BasePrice,
                Pictures = product.Pictures.Where(p => p.IsDeleted == false).ToList(),
                CategoryId = product.CategoryId,
                CreatedBy = product.CreatedBy,
            };
            return productRecord;
        }

            return null;
    }

    public async Task<ProductOutputDto> GetDetailWithRelation(int productId, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .Include(p => p.Pictures)
            .Include(p => p.BoothProducts).ThenInclude(bp => bp.Booth)
            .Include(p => p.Comments).ThenInclude(c => c.Customer)
            .FirstOrDefaultAsync(p => p.Id == productId && p.IsDeleted == false, cancellationToken);

        List<CommentOutputDto> comments = new List<CommentOutputDto>();
        foreach (var item in product.Comments.Where(c => c.IsDeleted == false && c.IsConfirmed == true))
        {
            comments.Add(
            new CommentOutputDto
            {
                Id = item.Id ,
                CustomerId = item.CustomerId ,
                Text = item.Text ,
                CreatedAt = item.CreatedAt ,
                Customer = item.Customer ,
            });
        }
        if (product != null)
        {
            var productRecord = new ProductOutputDto
            {
                Id = product.Id,
                Name = product.Name,
                Brand = product.Brand,
                Grantee = product.Grantee,
                InformationDetails = product.InformationDetails,
                Description = product.Description,
                IncludedComponents = product.IncludedComponents,
                IsConfirmed = product.IsConfirmed,
                BasePrice = product.BasePrice,
                Pictures = product.Pictures.Where(p => p.IsDeleted == false).ToList(),
                Comments = comments,
                BoothProducts = product.BoothProducts.ToList(),
                Auctions = product.Auctions,
            };
            return productRecord;
        }

        return null;


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
            productRecord.Name = product.Name != null ? product.Name  : productRecord.Name;
            productRecord.Brand = product.Brand != null ? product.Brand : productRecord.Brand;
            productRecord.Grantee = product.Grantee != null ? product.Grantee : productRecord.Grantee;
            productRecord.InformationDetails = product.InformationDetails != null ? product.InformationDetails : productRecord.InformationDetails;
            productRecord.Description = product.Description != null ? product.Description : productRecord.Description;
            productRecord.IncludedComponents = product.IncludedComponents != null ? product.IncludedComponents : productRecord.IncludedComponents;
            productRecord.IsConfirmed = product.IsConfirmed != null ? product.IsConfirmed : productRecord.IsConfirmed;
            productRecord.BasePrice = product.BasePrice != 0 ? product.BasePrice : productRecord.BasePrice;
            productRecord.CategoryId = product.CategoryId != 0 ? product.CategoryId : productRecord.CategoryId;
            productRecord.IsDeleted = product.IsDeleted != null ? product.IsDeleted : productRecord.IsDeleted;
            productRecord.Pictures = product.Pictures != null ? product.Pictures : productRecord.Pictures;


        }
            await _context.SaveChangesAsync(cancellationToken);



    }
}

