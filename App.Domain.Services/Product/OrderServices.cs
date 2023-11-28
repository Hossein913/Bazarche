
using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.OrderDtos;

namespace App.Domain.Services.Product;

public class OrderServices : IOrderServices
{
    protected readonly IOrderRepository _orderRepository;

    public OrderServices(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<int> Create(OrderCreateDto order, CancellationToken cancellationToken)
    {
        var result = await _orderRepository.Create(order, cancellationToken);
        return result;
    }

    public async Task<List<OrderOutputDto>> GetAllOrders(CancellationToken cancellationToken)
    {
        var result = await _orderRepository.GetAllOrders(cancellationToken);
            return result;
    }

    public async Task<List<OrderOutputDto>> GetUserAllOrders(int userId, CancellationToken cancellationToken)
    {
        var result = await _orderRepository.GetUserAllOrders(userId, cancellationToken);
            return result;
    }

    public async Task SoftDelete(int orderId, CancellationToken cancellationToken)
    {
        await _orderRepository.SoftDelete(orderId, cancellationToken);
    }

    public async Task Update(OrderUpdateDto order, CancellationToken cancellationToken, bool saveChange = true)
    {
         await _orderRepository.Update(order, cancellationToken, saveChange);

    }
}
