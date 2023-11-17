using App.Domain.Core._Products.Dtos.BoothProductDtos;

namespace App.Domain.Core._Products.Contracts.Services;

public interface IBoothProductServices
{
    Task Create(BoothProductCreateDto boothProduct, CancellationToken cancellationToken);
    Task Update(BoothProductUpdateDto boothProduct, CancellationToken cancellationToken);
    Task SoftDelete(int BoothProductId, CancellationToken cancellationToken);
}
