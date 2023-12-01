
using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.OrderItemDtos;
using App.Domain.Core._Products.Entities;

namespace App.Domain.Services.Product;

public class OrderItemServices : IOrderItemServices
{
    protected readonly IOrderItemRepository _orderItemRepository;
    protected readonly IProductRepository _productRepository;

    public OrderItemServices(IOrderItemRepository orderItemRepository, IProductRepository productRepository)
    {
        _orderItemRepository = orderItemRepository;
        _productRepository = productRepository;
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

    public async Task<OrderItemOutputDto> GetDetail(int OrderItemId, CancellationToken cancellationToken)
    {

        var OrderItem = await _orderItemRepository.GetDetail(OrderItemId, cancellationToken);
        if (OrderItem != null)
        {
            var product = await _productRepository.GetDetail(OrderItem.ProductId, cancellationToken);
            if (product != null)
            {
                OrderItem.BoothProduct.Product = new Core._Products.Entities.Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Brand = product.Brand,
                    

                };
                return OrderItem;

            }

        }
        return null;
    }

    public async Task<List<int>> GetPopularOrderedProductsId(int countOfProduct, CancellationToken cancellationToken)
    {
        var result = await _orderItemRepository.GetPopularOrderedProductsId(countOfProduct, cancellationToken);
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
