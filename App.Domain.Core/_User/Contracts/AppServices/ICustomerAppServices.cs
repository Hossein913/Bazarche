using App.Domain.Core._User.Dtos.CustomersDtos.CustomerAppServiceDto;
using App.Domain.Core._User.Dtos.CustommersDtos;

namespace App.Domain.Core._User.Contracts.AppServices;

public interface ICustomerAppServices
{
    Task<List<CustomerOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<CustomerOutputDto> GetDetailsWithRelation(int customerId, CancellationToken cancellationToken);
    Task<CustomerOutputDto> GetDetails(int customerId, CancellationToken cancellationToken);
    Task<int> Create(CustomerCreateDto customerCreate, CancellationToken cancellationToken);
    Task<string> Update(CustomerAppServiceUpdateDto customerUpdate, int CurrentUserId, string ProjectRouteAddress, CancellationToken cancellationToken);
    Task SoftDelete(int customerId, CancellationToken cancellationToken);
    Task SetActivity(int appUserId, bool status, CancellationToken cancellationToken);

}
