using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Contracts.Services;
using App.Domain.Core._User.Dtos.ProvinceDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.User
{
    public class ProvinceServices : IProvinceServices
    {
        protected readonly IProvinceRepository _provinceRepository;

        public ProvinceServices(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public async Task<int> Create(ProvinceCreateDto provinceCreate, CancellationToken cancellationToken)
        {
            var result = await _provinceRepository.Create(provinceCreate, cancellationToken);
            return result;
        }

        public async Task<List<ProvinceOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _provinceRepository.GetAll(cancellationToken);
            return result;
        }

        public async Task HardDelete(int provinceId, CancellationToken cancellationToken)
        {
            await _provinceRepository.HardDelete(provinceId, cancellationToken);
        }

        public async Task Update(ProvinceUpdateDto provinceUpdate, CancellationToken cancellationToken)
        {
            await _provinceRepository.Update(provinceUpdate, cancellationToken);
        }
    }
}
