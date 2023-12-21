using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Contracts.Services;
using App.Domain.Core._User.Dtos.AdminsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.User
{
    public class AdminAppServices : IAdminAppServices
    {
        protected readonly IAdminServices _adminServices;
public AdminAppServices(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }

        public async Task<AdminOutputDto> GetDetail(CancellationToken cancellationToken)
        {
            var result = await _adminServices.GetDetail(cancellationToken);
            return result;
        }
    }
}
