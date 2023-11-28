using App.Domain.Core._Products.Dtos.ProductDtos;
using App.Domain.Core._User.Dtos.WageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core._User.Contracts.Services
{
    public interface IWageServices
    {
        Task Create(List<WageCreateDto> WageCreate, CancellationToken cancellationToken, bool saveChange = true);

        Task<List<WageOutputDto>> GetAll(CancellationToken cancellationToken);

    }
}
