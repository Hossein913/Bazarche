using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Contracts.Services;
using App.Domain.Core._User.Dtos.CustommersDtos;

namespace App.Domain.Services.User;

public class CustomerServices : ICustomerServices
{
    protected readonly ICustomerRepository _customerRepository;

    public CustomerServices(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task Create(CustomerCreateDto customerCreate, CancellationToken cancellationToken)
    {
        await _customerRepository.Create(customerCreate, cancellationToken);
    }

    public async Task<List<CustomerOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _customerRepository.GetAll(cancellationToken);
        return result;
    }

    public async Task<CustomerOutputDto> GetDetail(int customerId, CancellationToken cancellationToken)
    {
        var result = await _customerRepository.GetDetail(customerId, cancellationToken);
        return result;
    }

    public async Task SoftDelete(int customerId, CancellationToken cancellationToken)
    {
        await _customerRepository.SoftDelete(customerId, cancellationToken);
    }

    public async Task Update(CustomerUpdateDto customerUpdate, CancellationToken cancellationToken)
    {
        await _customerRepository.Update(customerUpdate, cancellationToken);
    }
}
