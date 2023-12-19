using App.Domain.Core._User.Dtos.SellersDtos;

namespace App.Domain.Core._User.Contracts.Repositories;

public interface ISellerRepository
{
    Task<List<SellerOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<SellerOutputDto> GetDetailWithRilations(int sellerId, CancellationToken cancellationToken);
    Task<SellerOutputDto> GetDetail(int sellerAppUserId, CancellationToken cancellationToken);
    Task<SellerOutputDto> Create(SellerCreateDto sellerCreate, CancellationToken cancellationToken,bool saveChanges = true);
    Task Update(SellerUpdateDto sellerUpdate, CancellationToken cancellationToken, bool saveChanges = true);
    Task SoftDelete(int sellerId, CancellationToken cancellationToken);
    Task SetActivity(int sellerId, bool status, CancellationToken cancellationToken);

}
