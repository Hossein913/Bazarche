using App.Domain.Core._Products.Dtos.ProductDtos;

namespace App.Domain.Core._Products.Contracts.Repositories;

public interface IProductRepository
{
    Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<List<ProductOutputDto>> GetAllToConfirm(CancellationToken cancellationToken);
    Task<List<ProductOutputDto>> GetAllByCategory(CancellationToken cancellationToken, params int[] categoriesId);
    Task<List<ProductOutputDto>> GetAllForBooth(int BoothId, CancellationToken cancellationToken);
    Task<List<ProductOutputDto>> GetAllForOrderItems(List<Dictionary<int, int>> ProductPrice, CancellationToken cancellationToken);
    Task<List<ProductOutputDto>> GetAllWithIdList(List<int> ProductIdList, CancellationToken cancellationToken);

    Task<ProductOutputDto> GetDetail(int productId, CancellationToken cancellationToken);
    Task<int> Create(ProductCreateDto product, CancellationToken cancellationToken);
    Task Update(ProductUpdateDto product, CancellationToken CancellationToken);
    Task SoftDelete(int productId, CancellationToken cancellationToken);

}
