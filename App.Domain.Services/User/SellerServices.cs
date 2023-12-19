using App.Domain.Core._Booth.Contracts.Repositories;
using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Contracts.Services;
using App.Domain.Core._User.Dtos.SellersDtos;
using App.Infra.Data.SqlServer.Ef.Migrations;

namespace App.Domain.Services.User;

public class SellerServices : ISellerServices
{
    protected readonly ISellerRepository _sellerRepository;
    protected readonly IBoothRepository _boothRepository ;

    public SellerServices(ISellerRepository sellerRepository, IBoothRepository boothRepository)
    {
        _sellerRepository = sellerRepository;
        _boothRepository = boothRepository;
    }

    public async Task<SellerOutputDto> Create(SellerCreateDto sellerCreate, CancellationToken cancellationToken, bool saveChanges = true)
    {
       var result = await _sellerRepository.Create(sellerCreate, cancellationToken, saveChanges);
        return result;

    }

    public async Task<List<SellerOutputDto>> GetAll(CancellationToken cancellationToken)
    {
        var result = await _sellerRepository.GetAll(cancellationToken);
        return result;
    }

    public async Task<SellerOutputDto> GetDetails(int sellerAppUserId, CancellationToken cancellationToken)
    {
        var result = await _sellerRepository.GetDetails(sellerAppUserId, cancellationToken);
        return result;
    }

    public async Task<SellerOutputDto> GetDetailWithRilations(int sellerAppUserId, CancellationToken cancellationToken)
    {
        var result = await _sellerRepository.GetDetailWithRilations(sellerAppUserId, cancellationToken);
        return result;
    }

    public async Task SoftDelete(int sellerId, int boothId, CancellationToken cancellationToken)
    {
        await _sellerRepository.SoftDelete(sellerId, cancellationToken);
        await _boothRepository.SoftDelete(boothId, cancellationToken);
    }

    public async Task SetActivity(int sellerId, bool status, CancellationToken cancellationToken)
    {
        await _sellerRepository.SetActivity(sellerId, status, cancellationToken);
    }

    public async Task Update(SellerUpdateDto sellerUpdate, CancellationToken cancellationToken, bool saveChanges = true)
    {
        await _sellerRepository.Update(sellerUpdate, cancellationToken, saveChanges);
            
    }
}
