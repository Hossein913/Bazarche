using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Dtos.AdminsDtos;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;

namespace Scaffold.IServices;

public class IAdminServices : IAdminServices
{
    private readonly BazarcheContext _context;

    public IAdminServices(BazarcheContext context)
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

        var adminUser = await _context.Admins
            .Include(a => a.ProfilePic)
            .Include(a => a.AppUser)
            .FirstOrDefaultAsync(a => a.Id == adminId && a.AppUser.IsDeleted == false, cancellationToken);

        if (adminUser != null)
        {
            var adminrecord = new AdminOutputDto
            {
                Firstname = adminUser.FirstName,
                Lastname = adminUser.LastName,
                Birthdate = adminUser.Birthdate,
                Wallet = adminUser.Wallet,
                ShabaNumber = adminUser.ShabaNumber,
                ProfilePic = adminUser.ProfilePic,
                AppUser = adminUser.AppUser
            };
            return adminrecord;
        }
        else
        {
            return null;
        }
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
        var AdminRecord = await _context.Admins
            .FirstOrDefaultAsync(x => x.Id == adminUpdate.Id, cancellationToken);
        if (AdminRecord != null)
        {
            AdminRecord.FirstName = adminUpdate.Firstname;
            AdminRecord.LastName = adminUpdate.Lastname;
            AdminRecord.ProfilePicId = adminUpdate.ProfilePicId;
            AdminRecord.Birthdate = adminUpdate.Birthdate;
            AdminRecord.Wallet = adminUpdate.Wallet;
            AdminRecord.ShabaNumber = adminUpdate.ShabaNumber;
        }
        await _context.SaveChangesAsync(cancellationToken);
    }
}


