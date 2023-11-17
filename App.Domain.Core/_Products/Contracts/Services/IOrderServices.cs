using App.Domain.Core._Products.Dtos.OrderDtos;

namespace App.Domain.Core._Products.Contracts.Services;

public interface IOrderServices
{
    Task<List<OrderOutputDto>> GetAllOrders(CancellationToken cancellationToken);
    Task<List<OrderOutputDto>> GetAllUserOrders(int userId, CancellationToken cancellationToken);
    Task Create(OrderCreateDto order, CancellationToken cancellationToken);
    Task Update(OrderUpdateDto order, CancellationToken cancellationToken);
    Task SoftDelete(int orderId, CancellationToken cancellationToken);


}
