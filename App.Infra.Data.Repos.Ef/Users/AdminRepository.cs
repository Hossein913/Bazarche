using App.Domain.Core.User.Contracts.IRepositories;
using App.Domain.Core.User.Dtos.Admins;

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
