using App.Domain.Core._Products.Dtos.BoothProductDtos;

namespace App.Domain.Core._Products.Contracts.AppServices;

public interface IBoothProductAppServices
{
    Task<List<BoothProductOutputDto>> GetAllForProduct(int ProductId, CancellationToken cancellationToken);
    Task Create(BoothProductCreateDto boothProduct, CancellationToken cancellationToken);
    Task<int> GetProductIdAsync(int boothProductId, CancellationToken cancellationToken);
    Task Update(BoothProductUpdateDto boothProduct, CancellationToken cancellationToken);
    Task SoftDelete(int BoothProductId, CancellationToken cancellationToken);
    Task SetActivity(int BoothProductId, CancellationToken cancellationToken);
    Task ChangeBoothProductState(int boothProductId, bool status, CancellationToken cancellationToken);
}
