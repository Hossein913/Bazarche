using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Contracts.Services;
using App.Domain.Core._User.Dtos.SellersDtos;

namespace App.Domain.Services.User;

public class SellerServices : ISellerServices
{
    protected readonly ISellerRepository _sellerRepository;

    public SellerServices(ISellerRepository sellerRepository)
    {
        _sellerRepository = sellerRepository;
    }

    public async Task Create(SellerCreateDto sellerCreate, CancellationToken cancellationToken)
    {
        await _sellerRepository.Create(sellerCreate, cancellationToken);

    }

    public async Task<List<SellerOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _sellerRepository.GetAll(cancellationToken);
        return result;
    }

    public async Task<SellerOutputDto> GetDetail(int sellerAppUserId, CancellationToken cancellationToken)
    {
        var result = await _sellerRepository.GetDetail(sellerAppUserId, cancellationToken);
        return result;
    }

    public async Task SoftDelete(int sellerId, CancellationToken cancellationToken)
    {
        await _sellerRepository.SoftDelete(sellerId, cancellationToken);

    }

    public async Task Update(SellerUpdateDto sellerUpdate, CancellationToken cancellationToken)
    {
        await _sellerRepository.Update(sellerUpdate, cancellationToken);
            
    }
}
