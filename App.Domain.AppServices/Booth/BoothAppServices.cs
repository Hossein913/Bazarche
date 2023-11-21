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

        public async Task Create(BoothCreateDto boothCreate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async  Task<List<BoothOutputDto>> GetAllHome(CancellationToken cancellationToken)
        {
            return await _boothServices.GetAllHome(cancellationToken);
        }

        public async Task<BoothOutputDto> GetDetail(int BoothId, CancellationToken cancellationToken)
        {
            var result =  await _boothServices.GetDetail(BoothId, cancellationToken);
            return result;
        }



        public async Task SoftDelete(int BoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task Update(BoothUpdateDto boothUpdate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
