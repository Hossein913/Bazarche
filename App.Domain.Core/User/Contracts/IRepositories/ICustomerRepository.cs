using App.Domain.Core.User.Dtos.Custommers;

namespace App.Domain.Core.User.Contracts.IRepositories;

public interface ICustomerRepository
{
    Task<List<CustomerOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<CustomerOutputDto> GetDatail(int customerId, CancellationToken cancellationToken);
    Task Create(CustomerCreateDto customerCreate, CancellationToken cancellationToken);
    Task Update(CustomerUpdateDto customerUpdate, CancellationToken cancellationToken);
    Task SoftDelete(int customerId, CancellationToken cancellationToken);

}
