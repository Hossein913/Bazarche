using App.Domain.Core._User.Dtos.SellersDtos;

namespace App.Domain.Core._User.Contracts.Services;

public interface ISellerServices
{
    Task<List<SellerOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<SellerOutputDto> GetDetail(int sellerAppUserId, CancellationToken cancellationToken);
    Task<SellerOutputDto> Create(SellerCreateDto sellerCreate, CancellationToken cancellationToken, bool saveChanges = true);
    Task Update(SellerUpdateDto sellerUpdate, CancellationToken cancellationToken, bool saveChanges = true);
    Task SoftDelete(int sellerId, CancellationToken cancellationToken);
}
