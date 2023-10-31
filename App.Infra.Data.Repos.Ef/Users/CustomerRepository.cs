using App.Domain.Core.User.Contracts.IRepositories;
using App.Domain.Core.User.Dtos.Custommers;

namespace App.Infra.Data.Repos.Ef.Users;

public class CustomerRepository : ICustomerRepository
{
    public Task Create(CustomerCreateDto customerCreate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<CustomerOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CustomerOutputDto> GetDatail(int customerId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SoftDelete(int customerId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(CustomerUpdateDto customerUpdate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
