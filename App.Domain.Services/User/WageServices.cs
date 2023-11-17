using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Contracts.Services;
using App.Domain.Core._User.Dtos.WageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.User
{
    public class WageServices : IWageServices
    {
        protected readonly IWageRepository _wageRepository;
        public WageServices(IWageRepository wageRepository)
        {
            _wageRepository = wageRepository;
        }

        public async Task Create(WageCreateDto WageCreate, CancellationToken cancellationToken)
        {
            await _wageRepository.Create(WageCreate, cancellationToken);
        }

        public async Task<List<WageOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _wageRepository.GetAll(cancellationToken);
            return result;
        }
    }
}
