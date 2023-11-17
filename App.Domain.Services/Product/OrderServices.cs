
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

    public async Task Create(OrderCreateDto order, CancellationToken cancellationToken)
    {
        await _orderRepository.Create(order, cancellationToken);

    }

    public async Task<List<OrderOutputDto>> GetAllOrders(CancellationToken cancellationToken)
    {
        var result = await _orderRepository.GetAllOrders(cancellationToken);
            return result;
    }

    public async Task<List<OrderOutputDto>> GetAllUserOrders(int userId, CancellationToken cancellationToken)
    {
        var result = await _orderRepository.GetAllUserOrders(userId, cancellationToken);
            return result;
    }

    public async Task SoftDelete(int orderId, CancellationToken cancellationToken)
    {
        await _orderRepository.SoftDelete(orderId, cancellationToken);
    }

    public async Task Update(OrderUpdateDto order, CancellationToken cancellationToken)
    {
        await _orderRepository.Update(order, cancellationToken);
    }
}
