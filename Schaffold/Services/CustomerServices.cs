using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Dtos.AdminsDtos;
using App.Domain.Core._User.Dtos.CustommersDtos;
using App.Domain.Core._User.Entities;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Scaffold.Services;

public class CustomerServices : ICustomerRepository
{
    private readonly BazarcheContext _context;

    public CustomerServices(BazarcheContext context)
    {
        _context = context;
    }


    public async Task Create(CustomerCreateDto customerCreate, CancellationToken cancellationToken)
    {

    }

    public async Task<List<CustomerOutputDto>> GetAll(CancellationToken cancellationToken)
    {

    }

    public async Task<CustomerOutputDto> GetDetail(int customerId, CancellationToken cancellationToken)
    {

    }

    public async Task SoftDelete(int customerId, CancellationToken cancellationToken)
    {

    }

    public async Task Update(CustomerUpdateDto customerUpdate, CancellationToken cancellationToken)
    {

    }
}

