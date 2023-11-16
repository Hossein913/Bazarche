using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Dtos.AdminsDtos;
using App.Domain.Core._User.Dtos.CustommersDtos;
using App.Domain.Core._User.Entities;
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


    public async Task Create(CustomerCreateDto customerCreate, CancellationToken cancellationToken)
    {
        var newrecord = new Customer
        {
            FirstName = customerCreate.Firstname,
            LastName = customerCreate.Lastname,
            Sexuality = customerCreate.Sexuality,
            ProfilePicId = customerCreate.ProfilePicId,
            AddressId = customerCreate.AddressId,
            Birthdate = customerCreate.Birthdate,
            Wallet = customerCreate.Wallet,
            AppUserId = customerCreate.AppUserId,
            CartOrderId = customerCreate.CartOrderId,
        };

        await _context.Customers.AddAsync(newrecord, cancellationToken);
        var result = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<CustomerOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Customers
            .AsNoTracking()
            .Where(p => p.AppUser.IsDeleted == false)
            .Select<Customer, CustomerOutputDto>(c => new CustomerOutputDto
             {
                    Id = c.Id,
                    Firstname = c.FirstName,
                    Lastname = c.LastName,
                    Sexuality = c.Sexuality,
                    ProfilePicFile = c.ProfilePic.ImageUrl ?? null,
                    AddressId = c.AddressId,
                    Birthdate = c.Birthdate,
                    Wallet = c.Wallet,
                    AppUserId = c.AppUserId

             }).ToListAsync(cancellationToken);
    }

    public async Task<CustomerOutputDto> GetDetail(int customerId, CancellationToken cancellationToken)
    {
        var customerUser = await _context.Customers
            .Include(a => a.ProfilePic)
            .Include(a => a.AppUser)
            .FirstOrDefaultAsync(a => a.Id == customerId && a.AppUser.IsDeleted == false, cancellationToken);

        if (customerUser != null)
        {
            var customerrecord = new CustomerOutputDto
            {
                Id = customerId,
                Firstname = customerUser.FirstName,
                Lastname = customerUser.LastName,
                Sexuality = customerUser.Sexuality,
                Birthdate = customerUser.Birthdate,
                Wallet = customerUser.Wallet,
                ProfilePic = customerUser.ProfilePic,
                AppUser = customerUser.AppUser
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

    public async Task Update(CustomerUpdateDto customerUpdate, CancellationToken cancellationToken)
    {
        var customerRecord = await _context.Customers
        .FirstOrDefaultAsync(x => x.Id == customerUpdate.Id, cancellationToken);
        if (customerRecord != null)
        {
            customerRecord.FirstName = customerUpdate.Firstname;
            customerRecord.LastName = customerUpdate.Lastname;
            customerRecord.Sexuality = customerUpdate.Sexuality;
            customerRecord.ProfilePicId = customerUpdate.ProfilePicId;
            customerRecord.Birthdate = customerUpdate.Birthdate;
            customerRecord.Wallet = customerUpdate.Wallet;
        }
        await _context.SaveChangesAsync(cancellationToken);
    }
}

