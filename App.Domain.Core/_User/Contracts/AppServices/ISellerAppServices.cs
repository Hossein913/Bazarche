using App.Domain.Core._User.Dtos.SellersDtos;

namespace App.Domain.Core._User.Contracts.AppServices;

public interface ISellerAppServices
{
    Task<List<SellerOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<SellerOutputDto> GetDetail(int sellerAppUserId, CancellationToken cancellationToken);
    Task Create(SellerCreateDto sellerCreate, CancellationToken cancellationToken);
    Task Update(SellerUpdateDto sellerUpdate, CancellationToken cancellationToken);
    Task SoftDelete(int sellerId, CancellationToken cancellationToken);
}
