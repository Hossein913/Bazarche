using App.Domain.Core._Products.Dtos.ProductDtos;

namespace App.Domain.Core._Products.Contracts.Repositories;

public interface IProductRepository
{
    Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<List<ProductOutputDto>> GetAllByCategory(CancellationToken cancellationToken, params int[] categoriesId);
    Task<ProductOutputDto> GetDetail(int productId, CancellationToken cancellationToken);
    Task<int> Create(ProductCreateDto product, CancellationToken cancellationToken);
    Task Update(ProductUpdateDto product, CancellationToken CancellationToken);
    Task SoftDelete(int productId, CancellationToken cancellationToken);

}
