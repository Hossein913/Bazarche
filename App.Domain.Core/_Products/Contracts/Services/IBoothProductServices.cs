using App.Domain.Core._Products.Dtos.BoothProductDtos;
using App.Domain.Core._Products.Enums;

namespace App.Domain.Core._Products.Contracts.Services;

public interface IBoothProductServices
{
    Task<List<BoothProductOutputDto>> GetAllForProduct(int ProductId, CancellationToken cancellationToken);
    Task Create(BoothProductCreateDto boothProduct, CancellationToken cancellationToken);
    Task<int> GetProductIdAsync(int boothProductId, CancellationToken cancellationToken);
    Task Update(BoothProductUpdateDto boothProduct, CancellationToken cancellationToken);
    Task SoftDelete(int BoothProductId, CancellationToken cancellationToken);
    Task ChangeBoothProductState(int boothProductId, BoothProductStatus status, CancellationToken cancellationToken);
}
