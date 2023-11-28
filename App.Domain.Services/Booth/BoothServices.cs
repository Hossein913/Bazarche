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

        public async Task Create(BoothCreateDto boothCreate, CancellationToken cancellationToken)
        {
            await _boothRepository.Create(boothCreate, cancellationToken);
        }

        public async Task<List<BoothOutputDto>> GetAllHome(CancellationToken cancellationToken)
        {
            var result = await _boothRepository.GetAllHome(cancellationToken);
            return result;
        }

        public async Task<List<BoothOutputDto>> GetAllWithListId(List<int> boothId,CancellationToken cancellationToken)
        {
            var result = await _boothRepository.GetAllWithListId(boothId, cancellationToken);
            return result;
        }

        public async Task<BoothOutputDto> GetDetail(int BoothId, CancellationToken cancellationToken)
        {
            var result = await _boothRepository.GetDetails(BoothId, cancellationToken);
            return result;
        }

        public async Task<BoothOutputDto> GetDetailsWithRelations(int BoothId, CancellationToken cancellationToken)
        {
            var result = await _boothRepository.GetDetailsWithRelations(BoothId, cancellationToken);
            return result;
        }

        public async Task SoftDelete(int BoothId, CancellationToken cancellationToken)
        {
            await _boothRepository.SoftDelete(BoothId, cancellationToken);
        }

        public async Task Update(BoothUpdateDto boothUpdate, CancellationToken cancellationToken)
        {
            await _boothRepository.Update(boothUpdate, cancellationToken);
        }

        public async Task GroupUpdate(List<BoothUpdateDto> boothsUpdate, CancellationToken cancellationToken, bool saveChanges = true)
        {
            await _boothRepository.GroupUpdate(boothsUpdate, cancellationToken, saveChanges );
        }

    }
}
