using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.AuctionDtos;
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


        public AuctionAppServices(IAuctionServices auctionServices, IProductServices productServices)
        {
            _auctionServices = auctionServices;
            this._productServices = productServices;
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

        public Task Create(AuctionCreateDto auction, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AuctionOutputDto> GetDetail(int auctionId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SoftDelete(int ProductActionId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(AuctionUpdateDto auction, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
