using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.CommentDtos;

namespace App.Domain.Services.Product;

public class CommentServices : ICommentServices
{
    protected readonly ICommentRepository _commentRepository;

    public CommentServices(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task Create(CommentCreateDto comment, CancellationToken cancellationToken)
    {
        await _commentRepository.Create(comment, cancellationToken);

    }

    public async Task<List<CommentOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _commentRepository.GetAll(cancellationToken);
            return result;
    }

    public async Task<CommentOutputDto> GetDetail(int commentId, CancellationToken cancellationToken)
    {
        var result = await _commentRepository.GetDetail(commentId, cancellationToken);
            return result;
    }

    public async Task HardDeleted(int commentId, CancellationToken cancellationToken)
    {
        await _commentRepository.HardDeleted(commentId, cancellationToken);
    }

    public async Task SoftDelete(int commentId, CancellationToken cancellationToken)
    {
        await _commentRepository.SoftDelete(commentId, cancellationToken);
    }

    public async Task Update(CommentUpdateDto comment, CancellationToken cancellationToken)
    {
        await _commentRepository.Update(comment, cancellationToken);
    }
}
