using App.Domain.Core._Products.Dtos.OrderDtos;

namespace App.Domain.Core._Products.Contracts.Services;

public interface IOrderServices
{
    Task<List<OrderOutputDto>> GetAllOrders(CancellationToken cancellationToken);
    Task<List<OrderOutputDto>> GetUserAllOrders(int userId, CancellationToken cancellationToken);
    //Task<int> GetCustomerOrdreItemByProductId(int customerId, int productId, CancellationToken cancellationToken);
    Task<int> Create(OrderCreateDto order, CancellationToken cancellationToken);
    Task Update(OrderUpdateDto order, CancellationToken cancellationToken, bool saveChange = true);
    Task SoftDelete(int orderId, CancellationToken cancellationToken);


}
