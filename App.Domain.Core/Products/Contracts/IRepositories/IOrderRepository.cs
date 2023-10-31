using App.Domain.Core.Products.Dtos.Orders;

namespace App.Domain.Core.Products.Contracts.IRepositories;

public interface IOrderRepository
{
    Task<List<OrderOutputDto>> GetAllBoothOrders(int BoothId, CancellationToken cancellationToken);
    Task<List<OrderOutputDto>> GetAllOrders(CancellationToken cancellationToken);
    Task<List<OrderOutputDto>> GetAllUserOrders(int userId, CancellationToken cancellationToken);
    Task<OrderOutputDto> GetDatail(int orderId, CancellationToken cancellationToken);
    Task Create(OrderCreateDto order, CancellationToken cancellationToken);
    Task Update(OrderUpdateDto order, CancellationToken cancellationToken);
    Task SoftDelete(int orderId, CancellationToken cancellationToken);
    Task HardDelted(int orderId, CancellationToken cancellationToken);


}
