using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Dtos.AdminsDtos;

namespace App.Infra.Data.Repos.Ef.Users;

public class AdminRepository : IAdminRepository
{
    public Task Create(AdminCreateDto adminCreate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<AdminOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<AdminOutputDto> GetDatail(int adminId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SoftDelete(int adminId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(AdminUpdateDto adminUpdate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
