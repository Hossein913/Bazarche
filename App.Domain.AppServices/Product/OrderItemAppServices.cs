using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.OrderItemDtos;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class OrderItemAppServices : IOrderItemAppServices
    {
        protected readonly IOrderItemServices _orderItemServices;
        protected readonly IBoothProductServices _boothProductServices;
        protected readonly IProductServices  _productServices;


        public OrderItemAppServices(
            IOrderItemServices orderItemServices,
            IProductServices productServices, 
            IBoothProductServices boothProductServices)
        {
            this._orderItemServices = orderItemServices;
            _productServices = productServices;
            _boothProductServices = boothProductServices;
        }

        public async Task Create(OrderItemCreateDto orderItem, CancellationToken cancellationToken)
        {
            orderItem.ProductId = await _boothProductServices.GetProductIdAsync(orderItem.Id,cancellationToken);
           await  _orderItemServices.Create(orderItem, cancellationToken);
        }

        public async Task<List<OrderItemOutputDto>> GetAnOrderItems(int OrderId, CancellationToken cancellationToken)
        {
            var orderItems = await _orderItemServices.GetAll(OrderId, cancellationToken);

            //List<Dictionary<int, int>> ProductAndPriceList = new List<Dictionary<int, int>>();
            //orderItems.ForEach(x => {
            //    Dictionary<int, int> ProductAndPriceId = new Dictionary<int, int>();
            //    ProductAndPriceId.Add(x.BoothProduct.ProductId, x.BoothProductid);
            //    ProductAndPriceList.Add(ProductAndPriceId);
            //});
            //var productAndPrice = await _productServices.GetAllForOrderItems(ProductAndPriceList, cancellationToken);

            List<int> ProductsId = new List<int>();

            orderItems.ForEach(x => {
                ProductsId.Add(x.BoothProduct.ProductId);
            });

            var products = await _productServices.GetAllWithIdList(ProductsId,cancellationToken);

            orderItems.ForEach(
                x => {
                    ProductOutputDto productOutputDto = products.FirstOrDefault(p => p.Id == x.BoothProduct.ProductId && p.IsConfirmed == true);
                    x.BoothProduct.Product = new Core._Products.Entities.Product {
                        Id = x.BoothProduct.ProductId,
                        Name = productOutputDto.Name,
                        Brand = productOutputDto.Brand,
                        Pictures = new List<Picture> { 
                            new Picture { ImageUrl = productOutputDto.Avatar }
                        }
                    };}
                );


                return orderItems;
        }

        public async Task<List<OrderItemOutputDto>> GetAllForBooth(int BoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task<OrderItemOutputDto> GetDetail(int OrderItemId, CancellationToken cancellationToken)
        {
            var result = _orderItemServices.GetDetail(OrderItemId, cancellationToken);
            return result;
        }

        //public async Task<List<int>> GetPopularOrderedProductsId(int countOfProduct, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task HardDelete(int BoothProductId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task Update(OrderItemUpdateDto orderItem, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


    }
}
