using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Dtos.AdminsDtos;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Users;

public class AdminRepository : IAdminRepository
{
    private readonly BazarcheContext _context;

    public AdminRepository(BazarcheContext context)
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

    public async Task<AdminOutputDto> GetDetail(CancellationToken cancellationToken)
    {

        var adminUser = await _context.Admins
            .Include(a => a.ProfilePic)
            .Include(a => a.AppUser)
            .FirstOrDefaultAsync(cancellationToken);

        if (adminUser != null)
        {
            var adminrecord = new AdminOutputDto
            {
                Id = adminUser.Id,
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

    public async Task Update(AdminUpdateDto adminUpdate, CancellationToken cancellationToken,bool saveChange = true)
    {
        var AdminRecord = await _context.Admins
            .FirstOrDefaultAsync(x => x.Id == adminUpdate.Id,cancellationToken);
        if (AdminRecord != null)
        {
            AdminRecord.FirstName = adminUpdate.Firstname != null ? adminUpdate.Firstname : AdminRecord.FirstName;
            AdminRecord.LastName = adminUpdate.Lastname  != null ? adminUpdate.Lastname : AdminRecord.LastName;
            AdminRecord.ProfilePicId = adminUpdate.ProfilePicId  != null ? adminUpdate.ProfilePicId : AdminRecord.ProfilePicId;
            AdminRecord.Birthdate = adminUpdate.Birthdate  != null ? adminUpdate.Birthdate : AdminRecord.Birthdate;
            AdminRecord.Wallet = adminUpdate.Wallet  != null ? adminUpdate.Wallet : AdminRecord.Wallet;
            AdminRecord.ShabaNumber = adminUpdate.ShabaNumber  != null ? adminUpdate.ShabaNumber : AdminRecord.ShabaNumber;
        }
        
        if (saveChange)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}


