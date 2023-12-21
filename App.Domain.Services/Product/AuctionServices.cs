using App.Domain.Core._Booth.Contracts.Repositories;
using App.Domain.Core._Booth.Contracts.Services;
using App.Domain.Core._Booth.Dtos.BoothDtos;
using App.Domain.Core._Common.Contracts.Repositories;
using App.Domain.Core._Products.Contracts.Repositories;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.AuctionDtos;
using App.Domain.Core._Products.Dtos.OrderDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._Products.Enums;
using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Dtos.AdminsDtos;
using App.Domain.Core._User.Dtos.CustommersDtos;
using App.Domain.Core._User.Dtos.WageDtos;
using App.Domain.Core._User.Entities;
using App.Domain.Services.Common;
using App.Infra.Data.Repos.Ef.Commons;
using App.Infra.Data.Repos.Ef.Users;
using App.Infra.Data.SqlServer.Ef.Migrations;

namespace App.Domain.Services.Product;

public class AuctionServices : IAuctionServices
{

    protected readonly IAuctionRepository _auctionRepository;
    protected readonly ICustomerRepository _customerRepository ;
    protected readonly IBoothRepository _boothRepository;
    protected readonly IWageRepository _wageRepository;
    protected readonly IAdminRepository _adminRepository;
    protected readonly ISaveChangesRepository _saveChangesRepository;
    protected readonly IBoothServices _boothServices;

    public AuctionServices(IAuctionRepository auctionRepository, ICustomerRepository customerRepository, IBoothRepository boothRepository, IWageRepository wageRepository, IAdminRepository adminRepository, ISaveChangesRepository saveChangesRepository)
    {
        _auctionRepository = auctionRepository;
        _customerRepository = customerRepository;
        _boothRepository = boothRepository;
        _wageRepository = wageRepository;
        _adminRepository = adminRepository;
        _saveChangesRepository = saveChangesRepository;
    }

    public async Task<int> Create(AuctionCreateDto auction, CancellationToken cancellationToken)
    {
       var auctionId =  await _auctionRepository.Create(auction, cancellationToken);
        return auctionId;
    }
    public async Task<List<AuctionOutputDto>> GetAllRegistered(CancellationToken cancellationToken)
    {
        var result = await _auctionRepository.GetAll(AuctionStatus.Defined, cancellationToken);
        return result;
    }
    public async Task<List<AuctionOutputDto>> GetAllRuning(CancellationToken cancellationToken)
    {
        var result = await _auctionRepository.GetAll(AuctionStatus.Runing, cancellationToken);
        return result;
    }
    public async Task<List<AuctionOutputDto>> GetAllEnded(CancellationToken cancellationToken)
    {
        List<int> WinnersId = new List<int>();
        var result = await _auctionRepository.GetAll(AuctionStatus.Ended, cancellationToken);

        result.ForEach(a => {
            if (a.WinnerId != null)
            {
                WinnersId.Add(Convert.ToInt32(a.WinnerId));

            }
        });
        var customers = await _customerRepository.GetAllByIdList(WinnersId, cancellationToken);

        result.ForEach( a =>{
            if (a.WinnerId != null )
            {
                a.WinnerCustomer = customers.SingleOrDefault(c => c.Id == a.WinnerId);
            }
        });

        return result;
    }

    public async Task<List<AuctionOutputDto>> GetAllActive(CancellationToken cancellationToken)
    {
        var result = await _auctionRepository.GetAllActive(cancellationToken);
            return result;
    }

    public  async Task<List<AuctionOutputDto>> GetAllForBooth(int BoothId, CancellationToken cancellationToken)
    {
        var result = await _auctionRepository.GetAllForBooth(BoothId, cancellationToken);
        return result;
    }

    public async Task<List<AuctionOutputDto>> GetAllForCustomer(int customerId, CancellationToken cancellationToken)
    {
       var result = await _auctionRepository.GetAllForCustomer(customerId, cancellationToken);
        return result;
    }

    public async Task<AuctionOutputDto> GetDetail(int auctionId, CancellationToken cancellationToken)
    {
        var result = await _auctionRepository.GetDetail(auctionId, cancellationToken);
            return result;
    }

    public async Task GetEndAuction(int auctionId, CancellationToken cancellationToken)
    {
        var auction = await _auctionRepository.GetDetail(auctionId, cancellationToken);

        if (auction.Bids.Count > 0 && auction.Status == AuctionStatus.Runing && auction.IsConfirmed == true)
        {

            List<Bid> auctionsBids = auction.Bids.OrderByDescending(b => b.BidPrice).ToList();
            Bid winnerBib = null;

            foreach (var b in auctionsBids)
            {
                if (b.Customer.Wallet >= b.BidPrice)
                {
                    winnerBib = b;
                    break;
                }

            }

            if (winnerBib != null)
            {
                decimal wagePercentage = ((decimal)(auction.Booth.Medal.FeePercentage)) / 100;
                    int BoothIncome = Convert.ToInt32(winnerBib.BidPrice - (winnerBib.BidPrice * wagePercentage));
                    int wageAmount = winnerBib.BidPrice - BoothIncome;

                BoothUpdateDto boothUpdateDto = new BoothUpdateDto
                {
                    Id = auction.Booth.Id,
                    TotalSell = (auction.Booth.TotalSell + BoothIncome),
                    AccountBalance = (auction.Booth.AccountBalance + BoothIncome)
                };

                List<WageCreateDto> wages = new List<WageCreateDto>();
                wages.Add( new WageCreateDto
                 {
                     AuctionId = auctionId,
                     FeePercenteage = Convert.ToInt32(wagePercentage * 100),
                     WageAmount = wageAmount
                 } );

                CustomerUpdateDto customerUpdate = new CustomerUpdateDto
                {
                    Id = winnerBib.CustomerId,
                    Wallet = winnerBib.Customer.Wallet - winnerBib.BidPrice,
                };



                await _customerRepository.Update(customerUpdate, cancellationToken, false);
                await _boothRepository.Update(boothUpdateDto, cancellationToken, false);
                await _wageRepository.Create(wages, cancellationToken, false);

                int AdminWageAmount = (int)(winnerBib.BidPrice * wagePercentage);

                var admin = await _adminRepository.GetDetail(cancellationToken);
                AdminUpdateDto adminDto = new AdminUpdateDto
                {
                    Id = admin.Id,
                    Wallet = (admin.Wallet + AdminWageAmount),
                };

                await _adminRepository.Update(adminDto, cancellationToken, false);


                AuctionUpdateDto updateAuction = new AuctionUpdateDto { Id = auctionId, WinnerId= winnerBib.CustomerId, Status = AuctionStatus.Ended };
                await _auctionRepository.Update(updateAuction, cancellationToken,false);

                await _saveChangesRepository.SaveChanges(cancellationToken);



                List<int> boothsId = new List<int> { auction.BoothId };
                await _boothServices.ChangeMedal(boothsId, cancellationToken);
            }
        }



    }

    public async Task GetStartAuction(int auctionId, CancellationToken cancellationToken)
    {
        AuctionUpdateDto updateAuction= new AuctionUpdateDto{Id = auctionId,Status = AuctionStatus.Runing };
        await _auctionRepository.Update(updateAuction, cancellationToken);
    }

    public async Task SoftDelete(int ProductActionId, CancellationToken cancellationToken)
    {
        await _auctionRepository.SoftDelete(ProductActionId, cancellationToken);
    }

    public async Task Update(AuctionUpdateDto auction, CancellationToken cancellationToken)
    {
        await _auctionRepository.Update(auction, cancellationToken);
    }

    public async Task Cancel(int auctionId, CancellationToken cancellationToken)
    {
        AuctionUpdateDto auctionUpdate = new AuctionUpdateDto { Id = auctionId, Status = AuctionStatus.Cancelled };
        await _auctionRepository.Update(auctionUpdate, cancellationToken);
    }
}
