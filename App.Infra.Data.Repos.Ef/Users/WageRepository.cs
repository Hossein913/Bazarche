using App.Domain.Core._Products.Entities;
using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Contracts.Services;
using App.Domain.Core._User.Dtos.SellersDtos;
using App.Domain.Core._User.Dtos.WageDtos;
using App.Domain.Core._User.Entities;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Users
{
    public class WageRepository: IWageRepository
    {
        private readonly BazarcheContext _context;

        public WageRepository(BazarcheContext context)
        {
            _context = context;
        }

        public async Task Create(WageCreateDto WageCreate, CancellationToken cancellationToken)
        {
            var newrecord = new Wage
            {
                OrderitemId = WageCreate.OrderitemId,
                FeePercenteage = WageCreate.FeePercenteage,
                WageAmount = WageCreate.WageAmount
            };

            await _context.Wages.AddAsync(newrecord, cancellationToken);
            var result = await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<WageOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Wages.AsNoTracking().Select<Wage, WageOutputDto>(w => new WageOutputDto
            {
                //Id = c.Id,//Will we be requared to Edite the Table records later?
                Booth = w.Orderitem.BoothProduct.Booth.Name,
                customerfullName = w.Orderitem.Order.Customer.FirstName +' '+ w.Orderitem.Order.Customer.FirstName,
                product = w.Orderitem.BoothProduct.Product.Name,
                price = w.Orderitem.BoothProduct.Price,
                Count = w.Orderitem.Count,
                FeePercenteage = w.FeePercenteage,
                WageAmount = w.WageAmount,


            }).ToListAsync(cancellationToken);
        }
    
    
    
    }
}

