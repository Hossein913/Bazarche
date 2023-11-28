using App.Domain.Core._Products.Dtos.OrderItemDtos;

namespace App.Domain.Core._Products.Contracts.AppServices;

public interface IOrderItemAppServices
{
    Task<List<OrderItemOutputDto>> GetAnOrderItems(int OrderId, CancellationToken cancellationToken);
    Task<List<OrderItemOutputDto>> GetAllForBooth(int BoothId, CancellationToken cancellationToken);
    Task<List<int>> GetPopularOrderedProductsId(int countOfProduct, CancellationToken cancellationToken);
    Task Create(OrderItemCreateDto orderItem, CancellationToken cancellationToken);
    Task Update(OrderItemUpdateDto orderItem, CancellationToken cancellationToken);
    Task HardDelete(int BoothProductId, CancellationToken cancellationToken);
}
