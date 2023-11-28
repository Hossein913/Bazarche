using App.Domain.Core._User.Dtos.AdminsDtos;

namespace App.Domain.Core._User.Contracts.Repositories;

public interface IAdminRepository
{
    //Task<List<AdminOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<AdminOutputDto> GetDetail(CancellationToken cancellationToken);
    Task Update(AdminUpdateDto adminUpdate, CancellationToken cancellationToken, bool saveChange = true);

    //Task Create(AdminCreateDto adminCreate, CancellationToken cancellationToken);

    //Task SoftDelete(int adminId, CancellationToken cancellationToken);
}
