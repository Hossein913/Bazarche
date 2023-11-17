using App.Domain.Core._Booth.Contracts.Repositories;
using App.Domain.Core._Booth.Contracts.Services;
using App.Domain.Core._Booth.Dtos.MedalDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Booth
{
    public class MedalServices : IMedalServices
    {
        protected readonly IMedalRepository _medalRepository;

        public MedalServices(IMedalRepository medalRepository)
        {
            _medalRepository = medalRepository;
        }

        public async Task Create(MedalCreateDto medalCreate, CancellationToken cancellationToken)
        {
            await _medalRepository.Create(medalCreate, cancellationToken);
        }

        public async Task<List<MedalOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _medalRepository.GetAll(cancellationToken);
            return result;
        }

        public async Task HardDelete(int medalId, CancellationToken cancellationToken)
        {
            await _medalRepository.HardDelete(medalId, cancellationToken);
        }

        public async Task Update(MedalUpdateDto medalUpdate, CancellationToken cancellationToken)
        {
            await _medalRepository.Update(medalUpdate, cancellationToken);
        }
    }
}
