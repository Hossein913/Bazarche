using App.Domain.Core._User.Dtos.ProvinceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core._User.Contracts.Services
{
    public interface IProvinceServices
    {
        Task<List<ProvinceOutputDto>> GetAll(CancellationToken cancellationToken);
        Task<int> Create(ProvinceCreateDto provinceCreate, CancellationToken cancellationToken);
        Task HardDelete(int provinceId, CancellationToken cancellationToken);
        Task Update(ProvinceUpdateDto provinceUpdate, CancellationToken cancellationToken);
    }
}
