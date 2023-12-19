using App.Domain.Core._User.Dtos.SellersDtos;

namespace App.Domain.Core._User.Contracts.Services;

public interface ISellerServices
{
    Task<List<SellerOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<SellerOutputDto> GetDetailWithRilations(int sellerAppUserId, CancellationToken cancellationToken);
    Task<SellerOutputDto> GetDetails(int sellerAppUserId, CancellationToken cancellationToken);
    Task<SellerOutputDto> Create(SellerCreateDto sellerCreate, CancellationToken cancellationToken, bool saveChanges = true);
    Task Update(SellerUpdateDto sellerUpdate, CancellationToken cancellationToken, bool saveChanges = true);
    Task SoftDelete(int sellerId, int boothId, CancellationToken cancellationToken);
    Task SetActivity(int appUserId, bool status, CancellationToken cancellationToken);
}
