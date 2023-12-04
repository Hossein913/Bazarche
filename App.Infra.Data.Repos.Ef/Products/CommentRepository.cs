

using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Dtos.CommentDtos;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace App.Infra.Data.Repos.Ef.Products;

public class CommentRepository : ICommentRepository
{
    private readonly BazarcheContext _context;

    public CommentRepository(BazarcheContext context)
    {
        _context = context;
    }

    public async Task Create(CommentCreateDto comment, CancellationToken cancellationToken)
    {
        var newComment = new Comment
        {
            CustomerId = comment.CustomerId,
            OrderItemId = comment.OrderItemId,
            ProductId = comment.ProductId,
            PictureId = null,
            Text = comment.Text,
            CreatedAt = DateTime.Now,
            IsConfirmed = null,
            IsDeleted = false,


        };
        await _context.Comments.AddAsync(newComment, cancellationToken);
        var result = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<CommentOutputDto>> GetAll(CancellationToken cancellationToken)
    {
            var result = await _context.Comments
        .AsNoTracking()
        .Where(p => p.IsDeleted != false)
        .Select<Comment, CommentOutputDto>(c => new CommentOutputDto
        {
            Id = c.Id,
            Customer = c.Customer,
            Product = new ProductOutputDto { Id= c.Product.Id,Name = c.Product.Name },
            OrderItemId = c.OrderItemId,
            PictureId = null,
            Text = c.Text,
            CreatedAt = c.CreatedAt,
            IsConfirmed = c.IsConfirmed,
            
        }).OrderBy(p => p.CreatedAt).ToListAsync(cancellationToken);
            return result.OrderBy(c => c.IsConfirmed).ToList();
    }
    
    public async Task<List<CommentOutputDto>> GetAllForBooth(int BoothId,CancellationToken cancellationToken)
    {
        var result = await _context.Comments
        .AsNoTracking()
        .Where(p => p.IsDeleted == false && p.IsConfirmed == true && p.OrderItem.BoothProduct.BoothId == BoothId)
        .Select<Comment, CommentOutputDto>(c => new CommentOutputDto
        {
            Id = c.Id,
            Customer = c.Customer,
            //Product = c.Product,
            OrderItemId = 1,
            PictureId = null,
            Text = c.Text,
            CreatedAt = c.CreatedAt,

        }).OrderBy(p => p.CreatedAt).ToListAsync(cancellationToken);
        return result;
    }

    public async Task<List<CommentOutputDto>> GetAllCustomer(int CustomerId, CancellationToken cancellationToken)
    {
        var result = await _context.Comments
        .AsNoTracking()
        .Where(p => p.IsDeleted == false && p.CustomerId == CustomerId)
        .Select<Comment, CommentOutputDto>(c => new CommentOutputDto
        {
            Id = c.Id,
            OrderItem = c.OrderItem,
            Text = c.Text,
            CreatedAt = c.CreatedAt,
            ProductId = c.ProductId,
            IsConfirmed = c.IsConfirmed,
        
        }).OrderBy(p => p.CreatedAt).ToListAsync(cancellationToken);
                return result;
    }

    public async Task<List<CommentOutputDto>> GetAllForProduct(int ProductId, CancellationToken cancellationToken)
    {
        var result = await _context.Comments
        .AsNoTracking()
        .Where(p => p.IsDeleted == false && p.IsConfirmed == true && p.ProductId == ProductId)
        .Select<Comment, CommentOutputDto>(c => new CommentOutputDto
        {
        Id = c.Id,
        Customer = c.Customer,
        Text = c.Text,
        CreatedAt = c.CreatedAt,
        
        }).OrderBy(p => p.CreatedAt).ToListAsync(cancellationToken);
        return result;
    }

    public async Task<CommentOutputDto> GetDetail(int commentId, CancellationToken cancellationToken)
    {
        var comment = await _context.Comments
        .FirstOrDefaultAsync(c => c.Id == commentId && c.IsDeleted == false, cancellationToken);

        if (comment != null)
        {
            var productRecord = new CommentOutputDto
            {
                Id = comment.Id,
                Text = comment.Text,
            };
            return productRecord;
        }
        else
        {
            return null;
        }
    }

    public async Task HardDeleted(int commentId, CancellationToken cancellationToken)
    {
        var commentRecord = await _context.Comments
        .FirstOrDefaultAsync(x => x.Id == commentId, cancellationToken);

        if (commentRecord != null)
        {
            _context.Comments.Remove(commentRecord);

        }
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task SoftDelete(int commentId, CancellationToken cancellationToken)
    {
        var commentRecord = await _context.Comments
        .FirstOrDefaultAsync(x => x.Id == commentId, cancellationToken);

        if (commentRecord != null)
        {
            commentRecord.IsDeleted = true;

        }
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(CommentUpdateDto commentDto, CancellationToken cancellationToken)
    {
        var CommentRecord = await _context.Comments
        .FirstOrDefaultAsync(x => x.Id == commentDto.Id, cancellationToken);
        if (CommentRecord != null)
        {

            CommentRecord.Text = commentDto.Text == null ? CommentRecord.Text : commentDto.Text;
            CommentRecord.IsConfirmed = null;

        }
        await _context.SaveChangesAsync(cancellationToken);
    }


}

