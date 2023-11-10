using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Dtos.CategorieDtos;
using App.Domain.Core._Products.Entities;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;

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

    }

    public async Task<List<CategoryOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Categories.AsNoTracking().Select<Category, CategoryOutputDto>(c => new CategoryOutputDto
        {
            Id = c.Id,
            Title = c.Title, 
            PictureFileName = c.Picture.ImageUrl ?? null,
            ParentId = c.ParentId

        }).ToListAsync(cancellationToken);
    }

    public Task<CategoryOutputDto> GetDatail(int categoryId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task HardDelted(int categoryId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(CategoryUpdateDto categor, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}


