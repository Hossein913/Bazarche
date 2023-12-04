using App.Domain.Core._User.Dtos.WageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core._User.Contracts.AppServices
{
    public interface IWageAppServices
    {
        Task<List<WageOutputDto>> GetAll(CancellationToken cancellationToken);
    }
}
