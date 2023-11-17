using App.Domain.Core._User.Dtos.AdminsDtos;

namespace App.Domain.Core._User.Contracts.Services;

public interface IAdminServices
{
    Task<AdminOutputDto> GetDetail(int adminId, CancellationToken cancellationToken);
    Task Update(AdminUpdateDto adminUpdate, CancellationToken cancellationToken);
}
