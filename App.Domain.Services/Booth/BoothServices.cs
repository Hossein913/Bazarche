using App.Domain.Core._Booth.Contracts.Repositories;
using App.Domain.Core._Booth.Contracts.Services;
using App.Domain.Core._Booth.Dtos.BoothDtos;
using App.Infra.Data.Repos.Ef.Booths;
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
        protected readonly IMedalRepository _medalRepository;

        public BoothServices(IBoothRepository boothRepository, IMedalRepository medalRepository)
        {
            _boothRepository = boothRepository;
            _medalRepository = medalRepository;
        }

        public async Task<int> Create(BoothCreateDto boothCreate, CancellationToken cancellationToken, bool saveChanges = true)
        {
           var result = await _boothRepository.Create(boothCreate, cancellationToken, saveChanges);
            return result;
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

        public async Task ChangeMedal(List<int> boothsId, CancellationToken cancellationToken)
        {

            var medals = await _medalRepository.GetAll(cancellationToken);

            if (medals.Count > 1)
            {
                var booths = await _boothRepository.GetAllWithListId(boothsId, cancellationToken);

                List<BoothUpdateDto> BoothWithMedalId= new List<BoothUpdateDto>();
                booths.ForEach(b => {
                    int indexMedalId = 1;

                    medals.ForEach(m => {
                        if (m.MinSalesRequired <= b.TotalSell){
                            indexMedalId = m.Id;
                        }
                        else
                        {  
                            BoothWithMedalId.Add(new BoothUpdateDto
                            {
                                Id = b.Id,
                                MedalId = indexMedalId
                            });
                        }
                    });
                });

                await _boothRepository.GroupUpdate(BoothWithMedalId, cancellationToken);


            }


        }

        public async Task SetActivity(int BoothId, bool status, CancellationToken cancellationToken)
        {
            await _boothRepository.SetActivity(BoothId, status, cancellationToken);
        }
    }
}
