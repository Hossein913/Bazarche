using App.Domain.Core._User.Dtos.SellersDtos;
using App.Domain.Core._User.Dtos.SellersDtos.SellerAppServiceDto;

namespace App.Domain.Core._User.Contracts.AppServices;

public interface ISellerAppServices
{
    Task<List<SellerOutputDto>> GetAll(CancellationToken cancellationToken);
    Task<SellerOutputDto> GetDetails(int sellerAppUserId, CancellationToken cancellationToken);
    Task Create(SellerAppServiceCreateDto sellerCreate, CancellationToken cancellationToken);
    Task Update(SellerAppServiceUpdateDto sellerUpdate, string projectRouteAddress, CancellationToken cancellationToken);
    Task SoftDelete(int sellerId, CancellationToken cancellationToken);
}
