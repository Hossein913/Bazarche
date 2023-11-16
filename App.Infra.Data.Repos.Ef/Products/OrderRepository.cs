using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Dtos.OrderDtos;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._Products.Enums;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Products;

public class OrderRepository : IOrderRepository
{
    private readonly BazarcheContext _context;

    public OrderRepository(BazarcheContext context)
    {
        _context = context;
    }

    public async Task Create(OrderCreateDto order, CancellationToken cancellationToken)
    {
        var neworder = new Order
        {
            CustomerId = order.CustomerId,
            Status = order.Status,
            TotalPrice = order.TotalPrice,
            CreatedAt = order.CreatedAt,
            PayedAt = order.PayedAt,

        };

        await _context.Orders.AddAsync(neworder, cancellationToken);
        var result = await _context.SaveChangesAsync(cancellationToken);
    }


    public async Task<List<OrderOutputDto>> GetAllOrders(CancellationToken cancellationToken)
    {
        var result = await _context.Orders
        .AsNoTracking()
        .Where(o => o.Status == true )
        .Select<Order, OrderOutputDto>(o => new OrderOutputDto
        {
            Id = o.Id,
            Status = o.Status,
            TotalPrice = o.TotalPrice,
            PayedAt = o.PayedAt,// usable for orderby
            Customer = o.Customer,
            OrderItems = o.OrderItems

        }).ToListAsync(cancellationToken);
        return result;

    }

    public async Task<List<OrderOutputDto>> GetAllUserOrders(int userId, CancellationToken cancellationToken)
    {
        var result = await _context.Orders
        .AsNoTracking()
        .Where(o => o.Status == true && o.CustomerId == userId)
        .Select<Order, OrderOutputDto>(o => new OrderOutputDto
        {
            Id = o.Id,
            Status = o.Status,
            TotalPrice = o.TotalPrice,
            PayedAt = o.PayedAt,// usable for orderby
            OrderItems = o.OrderItems
        
        }).ToListAsync(cancellationToken);
        return result;
    }

    //public Task<OrderOutputDto> GetDetail(int orderId, CancellationToken cancellationToken)
    //{
    //    throw new NotImplementedException();
    //}


    public async Task SoftDelete(int orderId, CancellationToken cancellationToken)
    {
        //I think orders cant delete in my system business
        throw new NotImplementedException();
    }

    public async Task Update(OrderUpdateDto order, CancellationToken cancellationToken)
    {
        var OrderRecord = await _context.Orders
        .FirstOrDefaultAsync(x => x.Id == order.Id, cancellationToken);
        if (OrderRecord != null)
        {
            OrderRecord.CustomerId = order.CustomerId;
            OrderRecord.Status = order.Status;
            OrderRecord.TotalPrice = order.TotalPrice;

        }
        await _context.SaveChangesAsync(cancellationToken);
    }


}

