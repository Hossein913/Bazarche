
using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.OrderItemDtos;

namespace App.Domain.Services.Product;

public class OrderItemServices : IOrderItemServices
{
    protected readonly IOrderItemRepository _orderItemRepository;

    public OrderItemServices(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }

    public async Task Create(OrderItemCreateDto orderItem, CancellationToken cancellationToken)
    {
        await _orderItemRepository.Create(orderItem, cancellationToken);
    }

    public async Task<List<OrderItemOutputDto>> GetAll(int OrderId, CancellationToken cancellationToken)
    {
        var result = await _orderItemRepository.GetAll(OrderId, cancellationToken);
            return result;
    }

    public async Task<List<OrderItemOutputDto>> GetAllForBooth(int BoothId, CancellationToken cancellationToken)
    {
        var result = await _orderItemRepository.GetAllForBooth(BoothId, cancellationToken);
            return result;
    }

    public async Task HardDelete(int BoothProductId, CancellationToken cancellationToken)
    {
        await _orderItemRepository.HardDelete(BoothProductId, cancellationToken);
    }

    public async Task Update(OrderItemUpdateDto orderItem, CancellationToken cancellationToken)
    {
        await _orderItemRepository.Update(orderItem, cancellationToken);
    }
}
