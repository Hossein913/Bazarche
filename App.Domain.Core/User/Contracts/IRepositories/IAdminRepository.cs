using App.Domain.Core.User.Dtos.Admins;

namespace App.Domain.Core.User.Contracts.IRepositories;

public interface IAdminRepository
{
    Task<List<AdminOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<AdminOutputDto> GetDatail(int adminId, CancellationToken cancellationToken);
    Task Create(AdminCreateDto adminCreate, CancellationToken cancellationToken);
    Task Update(AdminUpdateDto adminUpdate, CancellationToken cancellationToken);
    Task SoftDelete(int adminId, CancellationToken cancellationToken);

}
