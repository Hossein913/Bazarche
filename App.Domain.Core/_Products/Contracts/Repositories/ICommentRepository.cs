using App.Domain.Core._Products.Dtos.CommentDtos;

namespace App.Domain.Core._Products.Contracts.Repositories;

public interface ICommentRepository
{
    Task<List<CommentOutputDto>> GetAllForConfirm(CancellationToken cancellationToken);
    Task<List<CommentOutputDto>> GetAllForBooth(int BoothId, CancellationToken cancellationToken);
    Task<List<CommentOutputDto>> GetAllCustomer(int CustomerId, CancellationToken cancellationToken);
    Task<List<CommentOutputDto>> GetAllForProduct(int ProductId, CancellationToken cancellationToken);
    Task<CommentOutputDto> GetDetail(int commentId, CancellationToken cancellationToken);
    Task Create(CommentCreateDto comment, CancellationToken cancellationToken);
    Task Update(CommentUpdateDto comment, CancellationToken cancellationToken);
    Task SoftDelete(int commentId, CancellationToken cancellationToken);
    Task HardDeleted(int commentId, CancellationToken cancellationToken);

}
