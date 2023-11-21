using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Contracts.Services;
using App.Domain.Core._User.Dtos.SellersDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.User
{
    public class SellerAppServices : ISellerAppServices
    {
        protected readonly ISellerServices _sellerServices;

        public SellerAppServices(ISellerServices sellerRepository)
        {
            _sellerServices = sellerRepository;
        }

        public Task Create(SellerCreateDto sellerCreate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<SellerOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<SellerOutputDto> GetDetail(int sellerAppUserId, CancellationToken cancellationToken)
        {
            var result = await _sellerServices.GetDetail(sellerAppUserId, cancellationToken);
            return result;

        }

        public Task SoftDelete(int sellerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(SellerUpdateDto sellerUpdate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
