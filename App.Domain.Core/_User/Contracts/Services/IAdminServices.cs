using App.Domain.Core._User.Dtos.AdminsDtos;

namespace App.Domain.Core._User.Contracts.Services;

public interface IAdminServices
{
    Task<AdminOutputDto> GetDetail(CancellationToken cancellationToken);
    Task Update(AdminUpdateDto adminUpdate, CancellationToken cancellationToken, bool saveChange = true);
}
