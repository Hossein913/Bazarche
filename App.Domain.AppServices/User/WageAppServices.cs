using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Contracts.Services;
using App.Domain.Core._User.Dtos.WageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.User
{
    public class WageAppServices : IWageAppServices
    {
        protected readonly IWageServices _wageServices;

        public WageAppServices(IWageServices wageServices)
        {
            _wageServices = wageServices;
        }

        public async Task<List<WageOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _wageServices.GetAll(cancellationToken);
            return result;
        }
    }
}
