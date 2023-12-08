using App.Domain.Core._Products.Dtos.ProductDtos;

namespace App.Domain.Core._Products.Contracts.Services;

public interface IProductServices
{
    Task<List<ProductOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<List<ProductOutputDto>> GetAllToConfirm(CancellationToken cancellationToken);
    Task<List<ProductOutputDto>> GetAllByCategory(CancellationToken cancellationToken, params int[] categoriesId);
    Task<List<ProductOutputDto>> GetAllForBooth(int BoothId, CancellationToken cancellationToken);
    Task<List<ProductOutputDto>> GetAllForOrderItems(List<Dictionary<int, int>> ProductPrice, CancellationToken cancellationToken);
    Task<List<ProductOutputDto>> GetAllWithIdList(List<int> ProductIdList, CancellationToken cancellationToken);
    Task<ProductOutputDto> GetDetails(int productId, CancellationToken cancellationToken);
    Task<ProductOutputDto> GetDetailWithRelation(int productId, CancellationToken cancellationToken);
    Task<int> Create(ProductCreateDto product, CancellationToken cancellationToken);
    Task Update(ProductUpdateDto product, CancellationToken CancellationToken);
    Task SoftDelete(int productId, CancellationToken cancellationToken);
    Task ConfirmProduct(int productId, bool status, CancellationToken cancellationToken);

}
