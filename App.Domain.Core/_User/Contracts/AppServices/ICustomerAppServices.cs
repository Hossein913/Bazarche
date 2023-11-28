using App.Domain.Core._User.Dtos.CustomersDtos.CustomerAppServiceDto;
using App.Domain.Core._User.Dtos.CustommersDtos;

namespace App.Domain.Core._User.Contracts.AppServices;

public interface ICustomerAppServices
{
    Task<List<CustomerOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<CustomerOutputDto> GetDetail(int customerId, CancellationToken cancellationToken);
    Task Create(CustomerCreateDto customerCreate, CancellationToken cancellationToken);
    Task Update(CustomerAppServiceUpdateDto customerUpdate, CancellationToken cancellationToken);
    Task SoftDelete(int customerId, CancellationToken cancellationToken);

}
