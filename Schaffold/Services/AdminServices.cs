using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Dtos.AdminsDtos;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;

namespace Scaffold.Services;

public class AdminServices : IAdminRepository
{
    private readonly BazarcheContext _context;

    public AdminServices(BazarcheContext context)
    {
        _context = context;
    }
    //public Task Create(AdminCreateDto adminCreate, CancellationToken cancellationToken)
    //{
    //    throw new NotImplementedException();
    //}

    //public Task<List<AdminOutputDto>> GetAll(CancellationToken cancellationToken)
    //{
    //    throw new NotImplementedException();
    //}

    public async Task<AdminOutputDto> GetDetail(int adminId, CancellationToken cancellationToken)
    {

    }

    //public async Task SoftDelete(int adminId, CancellationToken cancellationToken)
    //{
    //    var adminRecord = await _context.Admins.Include(a => a.AppUser)
    //    .FirstOrDefaultAsync(x => x.Id == adminId, cancellationToken);

    //    if (adminRecord != null)
    //    {
    //        adminRecord.AppUser.IsDeleted = true;

    //    }
    //    await _context.SaveChangesAsync(cancellationToken);
    //}

    public async Task Update(AdminUpdateDto adminUpdate, CancellationToken cancellationToken)
    {

    }
}


