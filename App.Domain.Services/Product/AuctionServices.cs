using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.AuctionDtos;

namespace App.Domain.Services.Product;

public class AuctionServices : IAuctionServices
{
    protected readonly IAuctionRepository _auctionRepository;

    public AuctionServices(IAuctionRepository auctionRepository)
    {
        _auctionRepository = auctionRepository;
    }

    public async Task Create(AuctionCreateDto auction, CancellationToken cancellationToken)
    {
        await _auctionRepository.Create(auction, cancellationToken);
    }

    public async Task<List<AuctionOutputDto>> GetAllActive(CancellationToken cancellationToken)
    {
        var result = await _auctionRepository.GetAllActive(cancellationToken);
            return result;
    }

    public async Task<AuctionOutputDto> GetDetail(int auctionId, CancellationToken cancellationToken)
    {
        var result = await _auctionRepository.GetDetail(auctionId, cancellationToken);
            return result;
    }

    public async Task SoftDelete(int ProductActionId, CancellationToken cancellationToken)
    {
        await _auctionRepository.SoftDelete(ProductActionId, cancellationToken);
    }

    public async Task Update(AuctionUpdateDto auction, CancellationToken cancellationToken)
    {
        await _auctionRepository.Update(auction, cancellationToken);
    }
}
