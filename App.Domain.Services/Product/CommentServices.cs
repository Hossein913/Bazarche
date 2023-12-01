using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.CommentDtos;

namespace App.Domain.Services.Product;

public class CommentServices : ICommentServices
{
    protected readonly ICommentRepository _commentRepository;
    protected readonly IProductRepository _productRepository;

    public CommentServices(ICommentRepository commentRepository, IProductRepository productRepository)
    {
        _commentRepository = commentRepository;
        _productRepository = productRepository;
    }

    public async Task Create(CommentCreateDto comment, CancellationToken cancellationToken)
    {
        await _commentRepository.Create(comment, cancellationToken);

    }

    public async Task<List<CommentOutputDto>> GetAllForConfirm(CancellationToken cancellationToken)
    {
        var result = await _commentRepository.GetAllForConfirm(cancellationToken);
            return result;
    }

    public async Task<List<CommentOutputDto>> GetAllCustomer(int CustomerId, CancellationToken cancellationToken)
    {
        var result = await _commentRepository.GetAllCustomer(CustomerId,cancellationToken);

        List<int> productsId  = new List<int>();
        result.ForEach(c =>
        { productsId.Add(Convert.ToInt32(c.ProductId)); }
            );

        var product = await _productRepository.GetAllWithIdList(productsId, cancellationToken);

        result.ForEach(c =>c.Product = product.FirstOrDefault(p => p.Id == c.ProductId));

            return result;
    }

    public async Task<List<CommentOutputDto>> GetAllForBooth(int BoothId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<List<CommentOutputDto>> GetAllForProduct(int ProductId, CancellationToken cancellationToken)
    {
        var result = await _commentRepository.GetAllForProduct(ProductId, cancellationToken);
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
