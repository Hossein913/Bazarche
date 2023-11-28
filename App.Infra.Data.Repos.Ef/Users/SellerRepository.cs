using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Dtos.CustommersDtos;
using App.Domain.Core._User.Dtos.SellersDtos;
using App.Domain.Core._User.Entities;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.Data.Repos.Ef.Users;

public class SellerRepository : ISellerRepository
{
    private readonly BazarcheContext _context;
    public SellerRepository(BazarcheContext context)
    {
        _context = context;
    }

    public async Task Create(SellerCreateDto sellerCreate, CancellationToken cancellationToken)
    {
        var newrecord = new Seller
        {
            FirstName = sellerCreate.Firstname,
            LastName = sellerCreate.Lastname,
            AddressId = sellerCreate.AddressId,
            ProfilePicId = sellerCreate.ProfilePicId,
            Birthdate = sellerCreate.Birthdate,
            ShabaNumber = sellerCreate.ShabaNumber,
            BoothId = sellerCreate.BoothId,
            AppUserId = sellerCreate.AppuserId
        };

        await _context.Sellers.AddAsync(newrecord, cancellationToken);
        var result = await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<SellerOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Sellers.AsNoTracking().Where(p => p.AppUser.IsDeleted == false).Select<Seller, SellerOutputDto>(c => new SellerOutputDto
        {
            Id = c.Id,
            Firstname = c.FirstName,
            Lastname = c.LastName,
            AddressId = c.AddressId,
            ProfilePicFile = c.ProfilePic.ImageUrl ?? null,
            Birthdate = c.Birthdate,
            ShabaNumber = c.ShabaNumber,
            BoothId = c.BoothId,
            BoothName = c.Booth.Name,
            AppuserId = c.AppUserId

        }).ToListAsync(cancellationToken);
    }

    public async Task<SellerOutputDto> GetDetail(int sellerAppUserId, CancellationToken cancellationToken)
    {
        //----Attention ---> when we show the user profile it's possible to decide to
        //                   Update Address and Avatar therefor force to Include object's
        //                   to use the id of entities
        
        var sellerUser = await _context.Sellers
            .Include(a => a.ProfilePic)
            .Include(a => a.AppUser)
            .Include(a => a.Address)
            .ThenInclude(ad => ad.Province)
            .FirstOrDefaultAsync(a => a.AppUserId == sellerAppUserId && a.AppUser.IsDeleted == false, cancellationToken);

        if (sellerUser != null)
        {
            var sellerRecord = new SellerOutputDto
            {

                Id = sellerUser.Id,
                Firstname = sellerUser.FirstName,
                Lastname = sellerUser.LastName,
                Birthdate = sellerUser.Birthdate,
                Address = sellerUser.Address,
                ShabaNumber = sellerUser.ShabaNumber,
                ProfilePic = sellerUser.ProfilePic,
                AppUser = sellerUser.AppUser,
                BoothId = sellerUser.BoothId

            };
            return sellerRecord;
        }
        else
        {
            return null;
        }
    }

    public async Task SoftDelete(int sellerId, CancellationToken cancellationToken)
    {
        var sellerRecord = await _context.Sellers.Include(a => a.AppUser)
        .FirstOrDefaultAsync(x => x.Id == sellerId, cancellationToken);

        if (sellerRecord != null)
        {
            sellerRecord.AppUser.IsDeleted = true;

        }
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(SellerUpdateDto sellerUpdate, CancellationToken cancellationToken)
    {
        var sellerRecord = await _context.Sellers
    .FirstOrDefaultAsync(x => x.Id == sellerUpdate.Id, cancellationToken);
        if (sellerRecord != null)
        {
            sellerRecord.FirstName = sellerUpdate.Firstname;
            sellerRecord.LastName = sellerUpdate.Lastname;
            sellerRecord.ProfilePicId = sellerUpdate.ProfilePicId;
            sellerRecord.Birthdate = sellerUpdate.Birthdate;
            sellerRecord.ShabaNumber = sellerUpdate.ShabaNumber;
        }
        await _context.SaveChangesAsync(cancellationToken);
    }
}
