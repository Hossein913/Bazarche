using App.Domain.Core.Products.Dtos.BoothProducts;
using App.Domain.Core.Products.Dtos.OrderItems;
using App.Domain.Core.Products.Entities;

namespace App.Domain.Core.Products.Contracts.IRepositories;

public interface IOrderItemRepository
{
    Task<OrderItemOutputDto> GetDatail(int OrderItemId, CancellationToken cancellationToken);
    Task<List<OrderItemOutputDto>> GetAll(int OrderId, CancellationToken cancellationToken);
    Task Create(OrderItemCreateDto orderItem , CancellationToken cancellationToken);
    Task Update(OrderItemUpdateDto orderItem , CancellationToken cancellationToken);
    Task SoftDelete(int BoothProductId, CancellationToken cancellationToken);
}
