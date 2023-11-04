using App.Domain.Core._Products.Dtos.OrderItemDtos;

namespace App.Domain.Core._Products.Contracts.Repositories;

public interface IOrderItemRepository
{
    Task<OrderItemOutputDto> GetDatail(int OrderItemId, CancellationToken cancellationToken);
    Task<List<OrderItemOutputDto>> GetAll(int OrderId, CancellationToken cancellationToken);
    Task Create(OrderItemCreateDto orderItem, CancellationToken cancellationToken);
    Task Update(OrderItemUpdateDto orderItem, CancellationToken cancellationToken);
    Task SoftDelete(int BoothProductId, CancellationToken cancellationToken);
}
