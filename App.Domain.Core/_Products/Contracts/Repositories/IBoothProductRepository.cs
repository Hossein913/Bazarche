using App.Domain.Core._Products.Dtos.BoothProductDtos;

namespace App.Domain.Core._Products.Contracts.Repositories;

public interface IBoothProductRepository
{
    //Task<BoothProductOutputDto> GetDetail(int boothProductId, CancellationToken cancellationToken);
    //Task<List<BoothProductOutputDto>> GetAllForBooth(int boothId, CancellationToken cancellationToken);

    Task<List<BoothProductOutputDto>> GetAllForProduct(int ProductId, CancellationToken cancellationToken);
    Task Create(BoothProductCreateDto boothProduct, CancellationToken cancellationToken);
    Task<int> GetProductIdAsync(int boothProductId, CancellationToken cancellationToken);
    Task Update(BoothProductUpdateDto boothProduct, CancellationToken cancellationToken);
    Task SoftDelete(int BoothProductId, CancellationToken cancellationToken);
}
