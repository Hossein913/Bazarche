using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Contracts.Services;
using App.Domain.Core._User.Dtos.AdminsDtos;

namespace App.Domain.Services.User;

public class AdminServices : IAdminServices
{
    protected readonly IAdminRepository _adminRepository;

    public AdminServices(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<AdminOutputDto> GetDetail(CancellationToken cancellationToken)
    {
        var result = await _adminRepository.GetDetail(cancellationToken);
        return result;
    }

    public async Task Update(AdminUpdateDto adminUpdate, CancellationToken cancellationToken, bool saveChange = true)
    {
        await _adminRepository.Update(adminUpdate, cancellationToken,saveChange);

    }
}
