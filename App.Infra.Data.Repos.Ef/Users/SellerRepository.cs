using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Dtos.SellersDtos;

namespace App.Infra.Data.Repos.Ef.Users;

public class SellerRepository : ISellerRepository
{
    public Task Create(SellerCreateDto sellerCreate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<SellerOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<SellerOutputDto> GetDatail(int sellerId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SoftDelete(int sellerId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Update(SellerUpdateDto sellerUpdate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
