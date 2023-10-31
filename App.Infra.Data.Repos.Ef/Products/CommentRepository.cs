using App.Domain.Core.Products.Contracts.IRepositories;
using App.Domain.Core.Products.Dtos.Comments;

namespace App.Infra.Data.Repos.Ef.Products;

public class CommentRepository : ICommentRepository
{
    public Task Create(CommentCreateDto comment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<CommentOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CommentOutputDto> GetDatail(int commentId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task HardDelted(int commentId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SoftDelete(int commentId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(CommentUpdateDto comment, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
