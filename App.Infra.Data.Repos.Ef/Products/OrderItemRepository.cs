using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Dtos.OrderItemDtos;

namespace App.Infra.Data.Repos.Ef.Products;

public class OrderItemRepository : IOrderItemRepository
{
    public Task Create(OrderItemCreateDto orderItem, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<OrderItemOutputDto>> GetAll(int OrderId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<OrderItemOutputDto> GetDatail(int OrderItemId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SoftDelete(int BoothProductId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(OrderItemUpdateDto orderItem, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
