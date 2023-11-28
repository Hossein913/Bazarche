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

    public async Task<int> Create(OrderCreateDto order, CancellationToken cancellationToken)
    {
        var newOrder = new Order
        {
            CustomerId = order.CustomerId,
            TotalPrice = 0,
            Status = Convert.ToBoolean((int) OrderStatus.Cart),
            CreatedAt = DateTime.Now,

        };

        await _context.Orders.AddAsync(newOrder, cancellationToken);
        var saveResult = await _context.SaveChangesAsync(cancellationToken);
        if (saveResult >0)
        {
            return newOrder.Id;
        }
        return 0;
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
            PayedAt = Convert.ToDateTime( o.PayedAt),// usable for orderby
            Customer = o.Customer,
            OrderItems = o.OrderItems

        }).ToListAsync(cancellationToken);
        return result;

    }

    public async Task<List<OrderOutputDto>> GetUserAllOrders(int userId, CancellationToken cancellationToken)
    {
        var result = await _context.Orders
        .AsNoTracking()
        .Where(o => o.Status == Convert.ToBoolean((int) OrderStatus.Payed) && o.CustomerId == userId)
        .Select<Order, OrderOutputDto>(o => new OrderOutputDto
        {
            Id = o.Id,
            Status = o.Status,
            TotalPrice = o.TotalPrice,
            PayedAt = Convert.ToDateTime( o.PayedAt),// usable for orderby
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

    public async Task Update(OrderUpdateDto order, CancellationToken cancellationToken,bool saveChange = true)
    {
        var OrderRecord = await _context.Orders
        .FirstOrDefaultAsync(x => x.Id == order.Id, cancellationToken);
        if (OrderRecord != null)
        {
            OrderRecord.CustomerId = order.CustomerId != null ? order.CustomerId : OrderRecord.CustomerId;
            OrderRecord.Status = order.Status != null ? order.Status : OrderRecord.Status;
            OrderRecord.TotalPrice = order.TotalPrice != null ? order.TotalPrice : OrderRecord.TotalPrice;
            OrderRecord.PayedAt = order.PayedAt;
        }
        if (saveChange)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }


}

