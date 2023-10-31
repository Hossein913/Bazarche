using App.Domain.Core.Products.Dtos.Comments;

namespace App.Domain.Core.Products.Contracts.IRepositories;

public interface ICommentRepository
{
    Task<List<CommentOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<CommentOutputDto> GetDatail(int commentId, CancellationToken cancellationToken);
    Task Create(CommentCreateDto comment, CancellationToken cancellationToken);
    Task Update(CommentUpdateDto comment, CancellationToken cancellationToken);
    Task SoftDelete(int commentId, CancellationToken cancellationToken);
    Task HardDelted(int commentId, CancellationToken cancellationToken);

}
