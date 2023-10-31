using App.Domain.Core.Products.Contracts.IRepositories;
using App.Domain.Core.Products.Dtos.Categories;
using App.Domain.Core.Products.Dtos.Products;
using App.Domain.Core.Products.Entities;
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
            Describtion = product.Describtion,
            IncludedComponentes = product.IncludedComponentes,
            IsConfirmed = product.IsConfirmed,
            BasePrise = product.BasePrise,
            IsDeleted = false
        };

                     await _context.Products.AddAsync(newproduct);
        var result = await _context.SaveChangesAsync(cancellationToken);
        if (result != 0)
            return newproduct.Id;

        return 0;
    }

    public async Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Products.AsNoTracking().Where(p => p.IsDeleted == false).Select<Product, ProductOutputDto>(c => new ProductOutputDto
        {
            Name = c.Name,
            Brand = c.Brand,
            Grantee = c.Grantee,
            InformationDetails = c.InformationDetails,
            Describtion = c.Describtion,
            IncludedComponentes = c.IncludedComponentes,
            IsConfirmed = c.IsConfirmed,
            BasePrise = c.BasePrise,

        }).ToListAsync(cancellationToken);

    }

    public async Task<ProductOutputDto> GetDatail(int productId, CancellationToken cancellationToken)
    {
        var product= await _context.Products.FindAsync(productId);
        if (product != null)
        {
            var productrecord = new ProductOutputDto
            {
                Name = product.Name,
                Brand = product.Brand,
                Grantee = product.Grantee,
                InformationDetails = product.InformationDetails,
                Describtion = product.Describtion,
                IncludedComponentes = product.IncludedComponentes,
                IsConfirmed = product.IsConfirmed,
                BasePrise = product.BasePrise,
                IsDeleted = false
            };
            return productrecord;
        }
        else 
        {
            throw new Exception();
        }

    }

    public async Task SoftDelete(int productId, CancellationToken cancellationToken)
    {
        var productRecord = await _context.Products
     .Where(x => x.Id == productId)
     .FirstOrDefaultAsync(cancellationToken);
        if (productRecord != null)
        {
            productRecord.IsDeleted = productRecord.IsDeleted;

        }
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(ProductUpdateDto product, CancellationToken CancellationToken)
    {
        var productRecord= await _context.Products
             .Where(x => x.Id == product.Id)
             .FirstOrDefaultAsync(CancellationToken);
        if (productRecord != null)
        {
            productRecord.Name = product.Name;
            productRecord.Brand = product.Brand;
            productRecord.Grantee = product.Grantee;
            productRecord.InformationDetails = product.InformationDetails;
            productRecord.Describtion = product.Describtion;
            productRecord.IncludedComponentes = product.IncludedComponentes;
            productRecord.IsConfirmed = product.IsConfirmed;
            productRecord.BasePrise = product.BasePrise;
            productRecord.IsDeleted = product.IsDeleted;

        }
            await _context.SaveChangesAsync(CancellationToken);


    }
}
