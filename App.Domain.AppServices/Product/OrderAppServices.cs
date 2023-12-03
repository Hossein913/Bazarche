using App.Domain.Core._Booth.Contracts.Services;
using App.Domain.Core._Booth.Dtos.BoothDtos;
using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Common.Contracts.Services;
using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.OrderDtos;
using App.Domain.Core._Products.Dtos.OrderItemDtos;
using App.Domain.Core._Products.Enums;
using App.Domain.Core._User.Contracts.Services;
using App.Domain.Core._User.Dtos.AdminsDtos;
using App.Domain.Core._User.Dtos.CustommersDtos;
using App.Domain.Core._User.Dtos.WageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Domain.AppServices.Product
{
    public class OrderAppServices : IOrderAppServices
    {
        protected readonly IOrderServices _orderServices;
        protected readonly IOrderItemServices _orderItemServices ;
        protected readonly ICustomerServices _customerServices ;
        protected readonly IBoothServices _boothServices ;
        protected readonly IWageServices _wageServices ;
        protected readonly IAdminServices _adminServices ;
        protected readonly ISaveChangesService saveChangesService ;

        public OrderAppServices(
            IOrderServices orderServices,
            IOrderItemServices orderItemServices,
            ICustomerServices customerServices,
            IBoothServices boothServices,
            IWageServices wageServices,
            IAdminServices adminServices,
            ISaveChangesService saveChangesService)
        {
            _orderServices = orderServices;
            _orderItemServices = orderItemServices;
            _customerServices = customerServices;
            _boothServices = boothServices;
            _wageServices = wageServices;
            _adminServices = adminServices;
            this.saveChangesService = saveChangesService;
        }


        public async Task<int> PaymentOrder(int orderId,int CustomerId, CancellationToken cancellationToken)
        {
            int TotalCustomerPayment = 0;

            List<int> boothsId = new List<int>();
           var orderItems = await _orderItemServices.GetAll(orderId, cancellationToken);

            foreach (var item in orderItems)
            {
                TotalCustomerPayment += (item.BoothProduct.Price * item.Count);
                boothsId.Add(item.BoothProduct.BoothId);
            }

            var customer = await _customerServices.GetDetail(CustomerId, cancellationToken);
            if (TotalCustomerPayment > customer.Wallet)
            {
                return -1;
            }

            foreach (var oi in orderItems)
            {
                if ((oi.BoothProduct.Count - oi.Count) <= 0)
                  return -2;
            }
            //----------Controls---id---checked----

            var booths = await _boothServices.GetAllWithListId(boothsId,cancellationToken);
            orderItems.ForEach(I => {
                BoothOutputDto boothOutputDto = booths.SingleOrDefault(b => b.Id == I.BoothProduct.BoothId);
                I.BoothProduct.Booth = new Core._Booth.Entities.Booth
                {
                    Id = boothOutputDto.Id,
                    Name = boothOutputDto.Name,
                    AccountBalance = boothOutputDto.AccountBalance,
                    TotalSell = boothOutputDto.TotalSell,
                    Medal = boothOutputDto.Medal,
                };
            });

            List<BoothUpdateDto> BoothWithSale = new List<BoothUpdateDto>();
            List<WageCreateDto> Wages = new List<WageCreateDto>();

            foreach (var oi in orderItems)
            {
                decimal wagePercentage = ((decimal)(oi.BoothProduct.Booth.Medal.FeePercentage))/100;
                int OrderItemTotalPrice = oi.BoothProduct.Price * oi.Count ;
                int BoothIncome = Convert.ToInt32(OrderItemTotalPrice - (OrderItemTotalPrice * wagePercentage));
                int wageAmount = OrderItemTotalPrice - BoothIncome;

                if (!BoothWithSale.Any(b => b.Id == oi.BoothProduct.BoothId))
                {
                    BoothWithSale.Add(new BoothUpdateDto
                    {
                        Id = oi.BoothProduct.BoothId,
                        TotalSell = (oi.BoothProduct.Booth.TotalSell + BoothIncome),
                        AccountBalance = (oi.BoothProduct.Booth.AccountBalance + BoothIncome)
                    });

                }
                else
                {
                    BoothWithSale.FirstOrDefault(b => b.Id == oi.BoothProduct.BoothId).TotalSell += BoothIncome;
                    BoothWithSale.FirstOrDefault(b => b.Id == oi.BoothProduct.BoothId).AccountBalance += BoothIncome;

                }


                WageCreateDto AdminWage = new WageCreateDto {
                     
                    OrderitemId = oi.Id,
                    FeePercenteage = Convert.ToInt32(wagePercentage *100),
                    WageAmount = wageAmount
                };
                Wages.Add(AdminWage);

            }

            CustomerUpdateDto customerUpdate = new CustomerUpdateDto 
            { 
             Id = CustomerId,
             Wallet = customer.Wallet - TotalCustomerPayment,
            };
            await _customerServices.Update(customerUpdate, cancellationToken, false);
            await _boothServices.GroupUpdate(BoothWithSale, cancellationToken, false);
            await _wageServices.Create(Wages,cancellationToken,false);

            int AdminWageAmount = 0;
                Wages.ForEach(w =>  AdminWageAmount += w.WageAmount );

            var admin = await _adminServices.GetDetail(cancellationToken);
            AdminUpdateDto adminDto = new AdminUpdateDto 
            { 
                Id = admin.Id,
                Wallet = (admin.Wallet+ AdminWageAmount),
            };

            await _adminServices.Update(adminDto, cancellationToken, false);

            OrderUpdateDto orderUpdateDto = new OrderUpdateDto
            { 
                Id = orderId,
                CustomerId = CustomerId,
                Status = Convert.ToBoolean((int)OrderStatus.Payed),
                TotalPrice = TotalCustomerPayment,
                PayedAt = DateTime.Now,
            };
            await _orderServices.Update(orderUpdateDto,cancellationToken,false);

            await saveChangesService.SaveChanges(cancellationToken);
            await _boothServices.ChangeMedal(boothsId, cancellationToken);

            OrderCreateDto newOrder = new OrderCreateDto
            {
                CustomerId = customer.Id,
            };
            var CartId = await _orderServices.Create(newOrder, cancellationToken);

            return CartId;
        }


        public async Task<List<OrderOutputDto>> GetAllOrders(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderOutputDto>> GetUserAllOrders(int userId, CancellationToken cancellationToken)
        {
            var result = await _orderServices.GetUserAllOrders(userId, cancellationToken);
            return result;
        }



        //public async Task<int> GetCustomerOrdreItemByProductId(int customerId, int productId, CancellationToken cancellationToken)
        //{
        //    var result = await _orderServices.GetCustomerOrdreItemByProductId(customerId, productId, cancellationToken);
        //    return result;
        //}

        public async Task SoftDelete(int orderId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task Update(OrderUpdateDto order, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


    }
}
