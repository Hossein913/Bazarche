using App.Domain.Core.Products.Dtos.BoothProducts;
using App.Domain.Core.Products.Entities;

namespace App.Domain.Core.Products.Contracts.IRepositories;

public interface IBoothProductRepository
{
    Task<BoothProductOutputDto> GetDatail(int boothProductId, CancellationToken cancellationToken);
    Task<List<BoothProductOutputDto>> GetAllForBooth(int boothtId, CancellationToken cancellationToken);
    Task<List<BoothProductOutputDto>> GetAllForProduct(int ProductId, CancellationToken cancellationToken);
    Task Create(BoothProductCreateDto boothProduct, CancellationToken cancellationToken);
    Task Update(BoothProductUpdateDto boothProduct, CancellationToken cancellationToken);
    Task SoftDelete(int BoothProductId, CancellationToken cancellationToken);
}
