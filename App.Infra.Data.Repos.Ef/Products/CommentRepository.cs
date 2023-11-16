

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
            PictureId = null,
            Text = comment.Text,
            CreatedAt = DateTime.Now,
            IsConfirmed = false,
            IsDeleted = false,


        };
        await _context.Comments.AddAsync(newComment, cancellationToken);
        var result = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<CommentOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _context.Comments
    .AsNoTracking()
    .Where(p => p.IsDeleted == false)
    .Select<Comment, CommentOutputDto>(c => new CommentOutputDto
    {
        Id = c.Id,
        Customer = c.Customer,
        Product = c.Product,
        OrderItemId = 1,
        PictureId = null,
        Text = c.Text,
        CreatedAt = c.CreatedAt,
        IsConfirmed = c.IsConfirmed,
        
    }).OrderBy(p => p.CreatedAt).ToListAsync(cancellationToken);
        return result;
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
            Product = c.Product,
            OrderItemId = 1,
            PictureId = null,
            Text = c.Text,
            CreatedAt = c.CreatedAt,
            IsConfirmed = c.IsConfirmed,

        }).OrderBy(p => p.CreatedAt).ToListAsync(cancellationToken);
        return result;
    }

    public async Task<CommentOutputDto> GetDetail(int commentId, CancellationToken cancellationToken)
    {
        var comment = await _context.Comments
    .Include(c => c.Customer)
    .Include(c => c.Product)
    .Include(c => c.OrderItem)
    .ThenInclude(oi => oi.BoothProductid)
    .FirstOrDefaultAsync(c => c.Id == commentId && c.IsDeleted == false, cancellationToken);

        if (comment != null)
        {
            var productRecord = new CommentOutputDto
            {
                Id = comment.Id,
                Customer = comment.Customer,
                Product = comment.Product,
                OrderItem = comment.OrderItem,
                PictureId = null,
                Text = comment.Text,
                CreatedAt = comment.CreatedAt,
                IsConfirmed = comment.IsConfirmed,
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

    public async Task Update(CommentUpdateDto comment, CancellationToken cancellationToken)
    {
        var CommentRecord = await _context.Comments
        .FirstOrDefaultAsync(x => x.Id == comment.Id, cancellationToken);
        if (CommentRecord != null)
        {
            CommentRecord.CustomerId = comment.CustomerId;
            CommentRecord.OrderItemId = comment.OrderItemId;
            CommentRecord.PictureId = comment.ProductId;
            CommentRecord.Text = comment.Text;
            CommentRecord.IsConfirmed = comment.IsConfirmed;

        }
        await _context.SaveChangesAsync(cancellationToken);
    }
}

