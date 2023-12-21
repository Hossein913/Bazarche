using App.Domain.Core._Common.Contracts.Services;
using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.AuctionDtos;
using App.Domain.Core._Products.Entities;
using App.Domain.Core._Products.Enums;
using App.Domain.Core._User.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class AuctionAppServices : IAuctionAppServices
    {
        protected readonly IAuctionServices _auctionServices;
        protected readonly IProductServices _productServices;
        protected readonly IJobServices jobServices;


        public AuctionAppServices(IAuctionServices auctionServices, IProductServices productServices, IJobServices jobServices)
        {
            _auctionServices = auctionServices;
            _productServices = productServices;
            this.jobServices = jobServices;
        }

        public async Task<List<AuctionOutputDto>> GetAllRegistered(CancellationToken cancellationToken)
        {
            var result = await _auctionServices.GetAllRegistered(cancellationToken);
            return result;
        }
        public async Task<List<AuctionOutputDto>> GetAllRuning(CancellationToken cancellationToken)
        {
            var result = await _auctionServices.GetAllRuning(cancellationToken);
            return result;
        }
        public async Task<List<AuctionOutputDto>> GetAllEnded(CancellationToken cancellationToken)
        {
            var result = await _auctionServices.GetAllEnded(cancellationToken);
            return result;
        }
        public async Task<List<AuctionOutputDto>> GetAllAuctions(CancellationToken cancellationToken)
        {
            var auctions =await _auctionServices.GetAllActive(cancellationToken);

            List<int> ids = new List<int>();
            auctions.ForEach(auction =>
            {
                ids.Add(auction.ProductId);
            });

            var Products = await _productServices.GetAllWithIdList(ids, cancellationToken);

            auctions.ForEach(auction =>
            {
                auction.ProductDto = Products.FirstOrDefault(p => p.Id == auction.ProductId);
            });

            return auctions;
        }

        public async Task<string> Create(AuctionCreateDto createAuction, CancellationToken cancellationToken)
        {
            if(
                DateTime.Compare(DateTime.Now, createAuction.StartTime) <=0 &&
                DateTime.Compare(DateTime.Now, createAuction.EndTime) < 0 &&
                DateTime.Compare(createAuction.EndTime, createAuction.StartTime) > 0 
            )
            {
                var auctionId = await _auctionServices.Create(createAuction, cancellationToken);
                jobServices.AddNewJub<IAuctionServices>(a => a.GetStartAuction(auctionId, cancellationToken), createAuction.StartTime);
                jobServices.AddNewJub<IAuctionServices>(a => a.GetEndAuction(auctionId, cancellationToken), createAuction.EndTime);
                return "success";
            }
            else
            {
                return "تاریخ های وارد شده نامعتر است.";
            }
        }

        public async Task<AuctionOutputDto> GetDetail(int auctionId, CancellationToken cancellationToken)
        {
            var auctions = await _auctionServices.GetDetail(auctionId,cancellationToken);
            return auctions;
        }

        public async Task SoftDelete(int ProductActionId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task Update(AuctionUpdateDto auction, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AuctionOutputDto>> GetAllForCustomer(int customerId, CancellationToken cancellationToken)
        {
            var result = await _auctionServices.GetAllForCustomer(customerId, cancellationToken);
            return result;
        }

        public async Task<List<AuctionOutputDto>> GetAllForBooth(int BoothId, CancellationToken cancellationToken)
        {
            var result = await _auctionServices.GetAllForBooth(BoothId, cancellationToken);
            return result;
        }

        public async Task Cancel(int auctionId, CancellationToken cancellationToken)
        {
            await _auctionServices.Cancel(auctionId, cancellationToken);
        }
        public async Task GetEndAuction(int auctionId, CancellationToken cancellationToken)
        {
            await _auctionServices.GetEndAuction(auctionId, cancellationToken);
        }
    }
}
