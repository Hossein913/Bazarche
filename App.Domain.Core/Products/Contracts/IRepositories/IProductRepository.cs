using App.Domain.Core.Products.Dtos.Products;

namespace App.Domain.Core.Products.Contracts.IRepositories;

public interface IProductRepository
{
    Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<ProductOutputDto> GetDatail(int productId, CancellationToken cancellationToken);
    Task<int> Create(ProductCreateDto product, CancellationToken cancellationToken);
    Task Update(ProductUpdateDto product, CancellationToken CancellationToken);
    Task SoftDelete(int productId, CancellationToken cancellationToken);

}
