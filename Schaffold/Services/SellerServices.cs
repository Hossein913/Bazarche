using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Dtos.CustommersDtos;
using App.Domain.Core._User.Dtos.SellersDtos;
using App.Domain.Core._User.Entities;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;

namespace Scaffold.Services;

public class SellerServices : ISellerRepository
{
    private readonly BazarcheContext _context;
    public SellerServices(BazarcheContext context)
    {
        _context = context;
    }

    public async Task Create(SellerCreateDto sellerCreate, CancellationToken cancellationToken)
    {

    }

    public async Task<List<SellerOutputDto>> GetAll(CancellationToken cancellationToken)
    {

    }

    public async Task<SellerOutputDto> GetDetail(int sellerId, CancellationToken cancellationToken)
    {
       
    }

    public async Task SoftDelete(int sellerId, CancellationToken cancellationToken)
    {

    }

    public async Task Update(SellerUpdateDto sellerUpdate, CancellationToken cancellationToken)
    {

    }
}
