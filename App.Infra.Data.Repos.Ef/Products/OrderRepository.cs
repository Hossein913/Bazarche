using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Dtos.OrderDtos;

namespace App.Infra.Data.Repos.Ef.Products;

public class OrderRepository : IOrderRepository
{
    public Task Create(OrderCreateDto order, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<OrderOutputDto>> GetAllBoothOrders(int BoothId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<OrderOutputDto>> GetAllOrders(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<OrderOutputDto>> GetAllUserOrders(int userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<OrderOutputDto> GetDatail(int orderId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task HardDelted(int orderId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SoftDelete(int orderId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(OrderUpdateDto order, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
