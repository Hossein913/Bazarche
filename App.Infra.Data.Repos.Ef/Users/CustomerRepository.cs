using App.Domain.Core._Common.Entities;
using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._Products.Enums;
using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Dtos.AdminsDtos;
using App.Domain.Core._User.Dtos.CustommersDtos;
using App.Domain.Core._User.Entities;
using App.Domain.Core._User.Enums;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace App.Infra.Data.Repos.Ef.Users;

public class CustomerRepository : ICustomerRepository
{
    private readonly BazarcheContext _context;

    public CustomerRepository(BazarcheContext context)
    {
        _context = context;
    }


    public async Task<int> Create(CustomerCreateDto customerCreate, CancellationToken cancellationToken)
    {
        Address address = new Address 
        { 
            ProvinceId = customerCreate.Address.ProvinceId,
            City = customerCreate.Address.City,
            PostalCode = customerCreate.Address.PostalCode,
            FullAddress = customerCreate.Address.FullAddress,

        };
        Customer newrecord = new Customer
        {
            FirstName = customerCreate.Firstname,
            LastName = customerCreate.Lastname,
            Sexuality = customerCreate.Sexuality,
            Birthdate = customerCreate.Birthdate,
            Wallet = 0,
            AppUserId = customerCreate.AppUserId,
            AddressId = address.Id,
            Address = address
        };

        await _context.Customers.AddAsync(newrecord, cancellationToken);
        var result = await _context.SaveChangesAsync(cancellationToken);
        if (result > 0)
        {
            return newrecord.Id;
        }
        return 0;
    }

    public async Task<List<CustomerOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        var reuslt = await _context.Customers
            .AsNoTracking()
            .Where(c => c.AppUser.IsDeleted == false)
            .Select<Customer, CustomerOutputDto>(c => new CustomerOutputDto
            {
                    Id = c.Id,
                    Firstname = c.FirstName,
                    Lastname = c.LastName,
                    Sexuality = c.Sexuality == null ? CustomerSexuality.None : c.Sexuality == true ? CustomerSexuality.Male : CustomerSexuality.Female,
                    ProfilePicFile = c.ProfilePic.ImageUrl ?? null,
                    AddressId = c.AddressId,
                    Birthdate = c.Birthdate,
                    Wallet = c.Wallet,
                    CartOrderId = c.CartOrderId,
                    OrdersCount = c.Orders.Count,
                    AppUser = c.AppUser,

            }).ToListAsync(cancellationToken);
             reuslt.ForEach(c => c.OrdersCount -= 1);
             return reuslt;

    }

    public async Task<CustomerOutputDto> GetDetailsWithRelation(int customerId, CancellationToken cancellationToken)
    {
        var customerUser = await _context.Customers
            .Include(a => a.Address)
            .ThenInclude(a => a.Province)
            .Include(a => a.AppUser)
            .Include(a => a.Orders)
            .Include(a => a.ProfilePic)
            .FirstOrDefaultAsync(a => a.Id == customerId && a.AppUser.IsDeleted == false, cancellationToken);

        if (customerUser != null)
        {
            var customerrecord = new CustomerOutputDto
            {
                Id = customerId,
                Firstname = customerUser.FirstName,
                Lastname = customerUser.LastName,
                Sexuality = customerUser.Sexuality == null ? CustomerSexuality.None: customerUser.Sexuality == true ? CustomerSexuality.Male : CustomerSexuality.Female,
                Birthdate = customerUser.Birthdate,
                Wallet = customerUser.Wallet,
                Address = customerUser.Address,
                AppUser = customerUser.AppUser,
                ProfilePicFile = customerUser.ProfilePic!= null ? customerUser.ProfilePic.ImageUrl: null ,
                Orders = customerUser.Orders.Where(O => O.Status == Convert.ToBoolean(OrderStatus.Payed)).ToList(),
            };
            return customerrecord;
        }
        else
        {
            return null;
        }
    }

    public async Task<CustomerOutputDto> GetDetails(int customerId, CancellationToken cancellationToken)
    {
        var customerUser = await _context.Customers
            .Include(a => a.Address)
            .ThenInclude(a => a.Province)
            .Include(a => a.AppUser)
            .Include(a => a.ProfilePic)
            .FirstOrDefaultAsync(a => a.Id == customerId && a.AppUser.IsDeleted == false, cancellationToken);

        if (customerUser != null)
        {
            var customerrecord = new CustomerOutputDto
            {
                Id = customerId,
                Firstname = customerUser.FirstName,
                Lastname = customerUser.LastName,
                Sexuality = customerUser.Sexuality == null ? CustomerSexuality.None : customerUser.Sexuality == true ? CustomerSexuality.Male : CustomerSexuality.Female,
                Birthdate = customerUser.Birthdate,
                Wallet = customerUser.Wallet,
                Address = customerUser.Address,
                AppUser = customerUser.AppUser,
                ProfilePicId = customerUser.ProfilePicId,
                ProfilePicFile = customerUser.ProfilePic != null ? customerUser.ProfilePic.ImageUrl : null,
            };
            return customerrecord;
        }
        else
        {
            return null;
        }
    }

    public async Task SoftDelete(int customerId, CancellationToken cancellationToken)
    {
        var customerRecord = await _context.Customers.Include(a => a.AppUser)
        .FirstOrDefaultAsync(x => x.Id == customerId, cancellationToken);

        if (customerRecord != null)
        {
            customerRecord.AppUser.IsDeleted = true;

        }
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(CustomerUpdateDto customerUpdate, CancellationToken cancellationToken,bool saveChanges = true)
    {
        Picture ProfilePictuer = null;
        if (customerUpdate.ProfilePic !=null)
        {
            ProfilePictuer = new Picture
            {
                ImageUrl = customerUpdate.ProfilePic.ImageUrl,
                CreatedAt = DateTime.Now,
                CreatedBy = customerUpdate.ProfilePic.CreatedBy,
                IsDeleted = false,
            };
        }
        var customerRecord = await _context.Customers
        .FirstOrDefaultAsync(x => x.Id == customerUpdate.Id, cancellationToken);
        if (customerRecord != null)
        {
            customerRecord.FirstName = customerUpdate.Firstname != null ? customerUpdate.Firstname: customerRecord.FirstName;
            customerRecord.LastName = customerUpdate.Lastname != null ? customerUpdate.Lastname : customerRecord.LastName;
            customerRecord.Birthdate = customerUpdate.Birthdate != null ? customerUpdate.Birthdate : customerRecord.Birthdate;
            customerRecord.Wallet = customerUpdate.Wallet != null ? customerUpdate.Wallet : customerRecord.Wallet;
            customerRecord.Address = customerUpdate.Address != null ? customerUpdate.Address : customerRecord.Address;
            customerRecord.CartOrderId = customerUpdate.CartOrderId != null ? customerUpdate.CartOrderId : customerRecord.CartOrderId;
            customerRecord.ProfilePic = customerUpdate.ProfilePic != null ? ProfilePictuer : customerRecord.ProfilePic;
            customerRecord.ProfilePicId = customerUpdate.ProfilePic != null ? ProfilePictuer.Id : customerRecord.ProfilePicId;
        }
        if (saveChanges)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

