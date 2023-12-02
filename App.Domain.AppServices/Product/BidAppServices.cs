using App.Domain.Core._Products.Contracts.AppServices;
using App.Domain.Core._Products.Contracts.Services;
using App.Domain.Core._Products.Dtos.BidDtos;
using App.Domain.Core._Products.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class BidAppServices : IBidAppServices
    {
        protected readonly IBidServices _bidServices;

        public BidAppServices(IBidServices bidServices)
        {
            _bidServices = bidServices;
        }

        public async Task<AddBidResult> Create(BidCreateDto bidCreate, CancellationToken cancellationToken)
        {
            var result = await _bidServices.Create(bidCreate, cancellationToken);
            return result;
        }

        public async Task Delete(int bidId, CancellationToken cancellationToken)
        {
            await _bidServices.Delete(bidId, cancellationToken);
        }

        public Task<List<BidOutputDto>> GetAll(int producAuctiontId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<BidOutputDto>> GetUserBids(int userID, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
