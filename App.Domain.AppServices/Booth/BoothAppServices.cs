using App.Domain.Core._Booth.Contracts.AppServices;
using App.Domain.Core._Booth.Contracts.Services;
using App.Domain.Core._Booth.Dtos.BoothDtos;

namespace App.Domain.AppServices.Booth
{
    public class BoothAppServices : IBoothAppServices
    {
        protected readonly IBoothServices _boothServices;

        public BoothAppServices(IBoothServices boothServices)
        {
            _boothServices = boothServices;
        }

        public async Task<List<BoothOutputDto>> GetAllHome(CancellationToken cancellationToken)
        {
            return await _boothServices.GetAllHome(cancellationToken);
        }
    }
}
