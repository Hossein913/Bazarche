using App.Domain.Core._User.Dtos.CustommersDtos;

namespace App.Domain.Core._User.Contracts.Repositories;

public interface ICustomerRepository
{
    Task<List<CustomerOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<CustomerOutputDto> GetDetail(int customerId, CancellationToken cancellationToken);
    Task<int> Create(CustomerCreateDto customerCreate, CancellationToken cancellationToken);
    Task Update(CustomerUpdateDto customerUpdate, CancellationToken cancellationToken, bool saveChanges = true);
    Task SoftDelete(int customerId, CancellationToken cancellationToken);

}
