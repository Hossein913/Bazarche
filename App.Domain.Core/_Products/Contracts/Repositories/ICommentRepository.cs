using App.Domain.Core._Products.Dtos.CommentDtos;

namespace App.Domain.Core._Products.Contracts.Repositories;

public interface ICommentRepository
{
    Task<List<CommentOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<CommentOutputDto> GetDatail(int commentId, CancellationToken cancellationToken);
    Task Create(CommentCreateDto comment, CancellationToken cancellationToken);
    Task Update(CommentUpdateDto comment, CancellationToken cancellationToken);
    Task SoftDelete(int commentId, CancellationToken cancellationToken);
    Task HardDelted(int commentId, CancellationToken cancellationToken);

}
