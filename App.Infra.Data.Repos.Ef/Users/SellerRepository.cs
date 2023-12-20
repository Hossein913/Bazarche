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

    public async Task<SellerOutputDto> Create(SellerCreateDto sellerCreate, CancellationToken cancellationToken, bool saveChanges = true)
    {
        Address address = new Address {
            ProvinceId = sellerCreate.Address.ProvinceId,
            City = sellerCreate.Address.City,
            PostalCode = sellerCreate.Address.PostalCode,
            FullAddress = sellerCreate.Address.FullAddress,
        };
        var newrecord = new Seller
        {
            FirstName = sellerCreate.Firstname,
            LastName = sellerCreate.Lastname,
            AddressId = address.Id,
            ProfilePicId = sellerCreate.ProfilePicId,
            Birthdate = sellerCreate.Birthdate,
            ShabaNumber = sellerCreate.ShabaNumber,
            BoothId = sellerCreate.BoothId,
            AppUserId = sellerCreate.AppUserId,
            Address = address
        };

        await _context.Sellers.AddAsync(newrecord, cancellationToken);
        if (saveChanges)
        {
            var result = await _context.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                return new SellerOutputDto { Id = newrecord.Id };
            }
            return new SellerOutputDto { Id = 0 };

        }
        return new SellerOutputDto { Id = newrecord.Id };
    }

    public async Task<List<SellerOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        var result =  await _context.Sellers
            .AsNoTracking()
            .Where(p => p.AppUser.IsDeleted == false)
            .Include(s =>s.Booth).ThenInclude(b => b.AvatarPicture)
            .Include(s =>s.Booth).ThenInclude(b => b.Medal)
            .Select<Seller, SellerOutputDto>(c => new SellerOutputDto
                    {
                    Id = c.Id,
                    Firstname = c.FirstName,
                    Lastname = c.LastName,
                    //AddressId = c.AddressId,
                    // ProfilePicFile = c.ProfilePic.ImageUrl ?? null,
                    //Birthdate = c.Birthdate,
                    //ShabaNumber = c.ShabaNumber,
                    Booth = c.Booth,
                    AppUser = c.AppUser

                    }).ToListAsync(cancellationToken);

        return result;
    }

    public async Task<SellerOutputDto> GetDetailWithRilations(int sellerAppUserId, CancellationToken cancellationToken)
    {
        //----Attention ---> when we show the user profile it's possible to decide to
        //                   Update Address and Avatar therefor force to Include object's
        //                   to use the id of entities
        
        var sellerUser = await _context.Sellers
            .Include(a => a.ProfilePic)
            .Include(a => a.AppUser)
            .Include(a => a.Booth)
            .ThenInclude(b => b.BoothProducts)
            .Include(a => a.Booth)
            .ThenInclude(b => b.Auctions)
            .Include(a => a.Booth)
            .ThenInclude(b => b.Medal)
            .Include(a => a.Booth)
            .ThenInclude(b => b.AvatarPicture)
            .Include(a => a.Address)
            .ThenInclude(ad => ad.Province)
            .FirstOrDefaultAsync(a => a.Id == sellerAppUserId && a.AppUser.IsDeleted == false, cancellationToken);

        if (sellerUser != null)
        {
            var sellerRecord = new SellerOutputDto
            {

                Id = sellerUser.Id,
                Firstname = sellerUser.FirstName,
                Lastname = sellerUser.LastName,
                Birthdate = sellerUser.Birthdate,
                ShabaNumber = sellerUser.ShabaNumber,
                Address = sellerUser.Address,
                ProfilePic = sellerUser.ProfilePic,
                AppUser = sellerUser.AppUser,
                Booth = sellerUser.Booth

            };
            return sellerRecord;
        }
        else
        {
            return null;
        }
    }



    public async Task<SellerOutputDto> GetDetails(int sellerAppUserId, CancellationToken cancellationToken)
    {

        var sellerUser = await _context.Sellers
            .Include(a => a.ProfilePic)
            .Include(a => a.Booth)
            .Include(a => a.Address)
            .ThenInclude(ad => ad.Province)
            .FirstOrDefaultAsync(a => a.Id == sellerAppUserId && a.AppUser.IsDeleted == false, cancellationToken);

        if (sellerUser != null)
        {
            var sellerRecord = new SellerOutputDto
            {

                Id = sellerUser.Id,
                Firstname = sellerUser.FirstName,
                Lastname = sellerUser.LastName,
                Birthdate = sellerUser.Birthdate,
                ShabaNumber = sellerUser.ShabaNumber,
                Address = sellerUser.Address,
                ProfilePic = sellerUser.ProfilePic,
                Booth = sellerUser.Booth

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

    public async Task SetActivity(int sellerId,bool status, CancellationToken cancellationToken)
    {
        var sellerRecord = await _context.Sellers.Include(a => a.AppUser)
        .FirstOrDefaultAsync(x => x.Id == sellerId, cancellationToken);

        if (sellerRecord != null)
        {
            sellerRecord.AppUser.IsActive = status;

        }
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(SellerUpdateDto sellerUpdate, CancellationToken cancellationToken, bool saveChanges = true)
    {
        var sellerRecord = await _context.Sellers
    .FirstOrDefaultAsync(x => x.Id == sellerUpdate.Id, cancellationToken);
        if (sellerRecord != null)
        {
            sellerRecord.FirstName = sellerUpdate.Firstname != null ? sellerUpdate.Firstname : sellerRecord.FirstName;
            sellerRecord.LastName = sellerUpdate.Lastname != null ? sellerUpdate.Lastname : sellerRecord.LastName;
            sellerRecord.ProfilePicId = sellerUpdate.ProfilePicId != 0 ? sellerUpdate.ProfilePicId : sellerRecord.ProfilePicId;
            sellerRecord.Birthdate = sellerUpdate.Birthdate != null ? sellerUpdate.Birthdate : sellerRecord.Birthdate;
            sellerRecord.ShabaNumber = sellerUpdate.ShabaNumber != null ? sellerUpdate.ShabaNumber : sellerRecord.ShabaNumber;
            sellerRecord.BoothId = sellerUpdate.BoothId != null ? sellerUpdate.BoothId : sellerRecord.BoothId;
            sellerRecord.Address = sellerUpdate.Address != null ? sellerUpdate.Address : sellerRecord.Address;
        }
        if (saveChanges)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
