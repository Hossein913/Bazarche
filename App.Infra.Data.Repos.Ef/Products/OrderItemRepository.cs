using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Dtos.OrderDtos;
using App.Domain.Core._Products.Dtos.OrderItemDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._Products.Enums;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace App.Infra.Data.Repos.Ef.Products;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly BazarcheContext _context;

    public OrderItemRepository(BazarcheContext context)
    {
        _context = context;
    }

    public async Task Create(OrderItemCreateDto orderItem, CancellationToken cancellationToken)
    {
        var newOrderItem = new OrderItem
        {
            OrderId = orderItem.OrderId,
            BoothProductid = orderItem.BoothProductid,
            Count = orderItem.Count,
            IsActive = true,

        };

        await _context.OrderItems.AddAsync(newOrderItem, cancellationToken);
        var result = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<OrderItemOutputDto>> GetAll(int OrderId, CancellationToken cancellationToken)
    {
        var result = await _context.OrderItems
        .AsNoTracking()
        .Where(oi => oi.OrderId == OrderId)
        .Select<OrderItem, OrderItemOutputDto>(o => new OrderItemOutputDto
        {
            Id = o.Id,
            Count = o.Count,
            IsActive = o.IsActive,
            BoothProduct = o.BoothProduct

        }).ToListAsync(cancellationToken);
        return result;
    }

    public async Task<List<OrderItemOutputDto>> GetAllForBooth(int BoothId, CancellationToken cancellationToken)
    {
        var result = await _context.OrderItems
        .AsNoTracking()
        .Where(oi => oi.BoothProduct.BoothId == BoothId)
        .Select<OrderItem, OrderItemOutputDto>(o => new OrderItemOutputDto
        {
            Count = o.Count,
            BoothProduct = o.BoothProduct,
            Order = o.Order

        }).ToListAsync(cancellationToken);
        return result;
    }

    public async Task<List<int>> GetPopularOrderedProductsId(int countOfProduct, CancellationToken cancellationToken)
    {
        var result = await _context.OrderItems
         .AsNoTracking()
         .Where(oi => oi.Order.Status == Convert.ToBoolean((int)OrderStatus.Payed))
         .GroupBy(oi => oi.BoothProduct.ProductId)
         .OrderBy(g => g.Count())
         .Take(countOfProduct)
         .Select(x => new { productId = x.Key })
         .Select(x => x.productId)
         .ToListAsync();         

        return result;
    }

    //public Task<OrderItemOutputDto> GetDetail(int OrderItemId, CancellationToken cancellationToken)
    //{
    //    throw new NotImplementedException();
    //}

    public async Task HardDelete(int OrderItemId, CancellationToken cancellationToken)
    {
        var OrderItemRecord = await _context.OrderItems
        .FirstOrDefaultAsync(x => x.Id == OrderItemId, cancellationToken);

        if (OrderItemRecord != null)
        {
            _context.OrderItems.Remove(OrderItemRecord);

        }
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(OrderItemUpdateDto orderItem, CancellationToken cancellationToken)
    {
        var OrderItemRecord = await _context.OrderItems
        .FirstOrDefaultAsync(x => x.Id == orderItem.Id, cancellationToken);
        if (OrderItemRecord != null)
        {
            OrderItemRecord.OrderId = orderItem.OrderId;
            OrderItemRecord.BoothProductid = orderItem.BoothProductid;
            OrderItemRecord.Count = orderItem.Count;
            OrderItemRecord.IsActive = orderItem.IsActive;

        }
        await _context.SaveChangesAsync(cancellationToken);
    }
}

