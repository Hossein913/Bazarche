using App.Domain.Core._Booth.Contracts.Repositories;
using App.Domain.Core._Booth.Contracts.Services;
using App.Domain.Core._Booth.Dtos.BoothDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Booth
{
    public class BoothServices : IBoothServices
    {
        protected readonly IBoothRepository _boothRepository;

        public BoothServices(IBoothRepository boothRepository)
        {
            _boothRepository = boothRepository;
        }

        public async Task<List<BoothOutputDto>> GetAllHome(CancellationToken cancellationToken)
        {
            return await _boothRepository.GetAllHome(cancellationToken);
        }
    }
}
