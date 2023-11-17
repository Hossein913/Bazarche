using App.Domain.Core._User.Dtos.SellersDtos;

namespace App.Domain.Core._User.Contracts.Services;

public interface ISellerServices
{
    Task<List<SellerOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<SellerOutputDto> GetDetail(int sellerId, CancellationToken cancellationToken);
    Task Create(SellerCreateDto sellerCreate, CancellationToken cancellationToken);
    Task Update(SellerUpdateDto sellerUpdate, CancellationToken cancellationToken);
    Task SoftDelete(int sellerId, CancellationToken cancellationToken);
}
