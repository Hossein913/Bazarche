using App.Domain.Core._Products.Dtos.OrderDtos;
using App.Domain.Core._Products.Dtos.OrderItemDtos;

namespace App.Domain.Core._Products.Contracts.AppServices;

public interface IOrderAppServices
{

    Task<List<OrderOutputDto>> GetAllOrders(CancellationToken cancellationToken);
    Task<List<OrderOutputDto>> GetUserAllOrders(int userId, CancellationToken cancellationToken);
    //Task<int> GetCustomerOrdreItemByProductId(int customerId, int productId, CancellationToken cancellationToken);
    Task<int> PaymentOrder(int orderId, int CustomerId, CancellationToken cancellationToken);
    Task Update(OrderUpdateDto order, CancellationToken cancellationToken);
    Task SoftDelete(int orderId, CancellationToken cancellationToken);

}
