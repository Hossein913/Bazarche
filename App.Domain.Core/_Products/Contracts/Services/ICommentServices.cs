using App.Domain.Core._Products.Dtos.CommentDtos;

namespace App.Domain.Core._Products.Contracts.Services;

public interface ICommentServices
{
    Task<List<CommentOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<CommentOutputDto> GetDetail(int commentId, CancellationToken cancellationToken);
    Task Create(CommentCreateDto comment, CancellationToken cancellationToken);
    Task Update(CommentUpdateDto comment, CancellationToken cancellationToken);
    Task SoftDelete(int commentId, CancellationToken cancellationToken);
    Task HardDeleted(int commentId, CancellationToken cancellationToken);

}
