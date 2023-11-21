using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Dtos.CategorieDtos;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;
using System;

namespace App.Infra.Data.Repos.Ef.Products;

public class CategoryRepository : ICategoryRepository
{
    private readonly BazarcheContext _context;

    public CategoryRepository(BazarcheContext context)
    {
        _context = context;
    }
    public async Task Create(CategoryCreateDto category, CancellationToken cancellationToken)
    {
        var newcategory = new Category
        {
            Title = category.Title,
            ParentId = category.ParentId,
            PictureId = category.PictureId,
        };

        await _context.Categories.AddAsync(newcategory, cancellationToken);
        var result = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        //------Attention ---> I have used the where clause to separate the parent Categories and child ones
        var result = await _context.Categories
            .AsNoTracking().Where(c => c.ParentId == null)
            .Select<Category, CategoryOutputDto>(c => new CategoryOutputDto
            {
                 Id = c.Id,
                 Title = c.Title,
                 ParentId = c.ParentId,
                 Subcategories = c.Subcategories.ToList(),
                 Picture = c.Picture
            }).ToListAsync(cancellationToken);
        return result;
    }

    public async Task<CategoryOutputDto> GetById(int Id,CancellationToken cancellationToken)
    {
        var result = await _context.Categories
            .Include(c => c.Subcategories)
            .Include(c => c.Picture)
            .FirstOrDefaultAsync(c => c.Id == Id);

             CategoryOutputDto categorydto= new CategoryOutputDto
            {
                Id = result.Id,
                Title = result.Title,
                ParentId = result.ParentId,
                Subcategories = result.Subcategories.ToList(),
                Picture = result.Picture
            };

        return categorydto;
    }

    //--- Attention --> it will make a larg join in sql Server and isn't optimized
    //public async Task<CategoryOutputDto> GetAllWithProduct(int categoryId,CancellationToken cancellationToken)
    //{
    //    var CategoryRecord = await _context.Categories
    //        .Include(c => c.Subcategories)
    //        .ThenInclude(c => c.Products)
    //        .FirstOrDefaultAsync(c => c.Id == categoryId);
    //    var newCategory = new CategoryOutputDto
    //    {
    //        Id = CategoryRecord.Id,
    //        Title = CategoryRecord.Title,
    //        ParentId = CategoryRecord.ParentId,
    //        Subcategories = CategoryRecord.Subcategories,
    //        products = CategoryRecord.Subcategories.Select(x => x.Products.ToList()).Where(P => P.Count > 0)

    //    };
    //    //CategoryRecord.Subcategories.Any(c => newCategory.products.ToList().AddRange(c.Products));

    //    return newCategory;
    //}


    //public async Task<CategoryOutputDto> GetDetail(int categoryId, CancellationToken cancellationToken)
    //{
    //    var categoryRecord = await _context.Categories
    //.Include(c => c.Picture)
    //.ThenInclude(bp => bp.Booth)
    //.FirstOrDefaultAsync(p => p.Id == categoryId && p.IsDeleted == false, cancellationToken);

    //    if (categoryRecord != null)
    //    {
    //        var newcategory = new ProductOutputDto
    //        {

    //        };
    //        return newcategory;
    //    }
    //    else
    //    {
    //        return null;
    //    }
    //}

    public async Task HardDelete(int categoryId, CancellationToken cancellationToken)
    {
        var categoryRecord = await _context.Categories
        .FirstOrDefaultAsync(x => x.Id == categoryId, cancellationToken);

        if (categoryRecord != null)
        {
            _context.Categories.Remove(categoryRecord);

        }
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(CategoryUpdateDto category, CancellationToken cancellationToken)
    {
        var CategoryRecord = await _context.Categories
        .FirstOrDefaultAsync(x => x.Id == category.Id, cancellationToken);
        if (CategoryRecord != null)
        {
            CategoryRecord.Title = category.Title;
            CategoryRecord.ParentId = category.ParentId;
            CategoryRecord.PictureId = category.PictureId;

        }
        await _context.SaveChangesAsync(cancellationToken);
    }
}

