using App.Domain.Core._User.Dtos.AdminsDtos;

namespace App.Domain.Core._User.Contracts.AppServices;

public interface IAdminAppServices
{
    Task<AdminOutputDto> GetDetail(CancellationToken cancellationToken);
}
