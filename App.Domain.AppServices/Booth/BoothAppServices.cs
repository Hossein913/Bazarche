using App.Domain.Core._Booth.Contracts.AppServices;
using App.Domain.Core._Booth.Contracts.Services;
using App.Domain.Core._Booth.Dtos.BoothDtos;
using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Common.Contracts.Services;
using App.Domain.Core._Common.Entities;
using App.Domain.Core._Common.Enums;
using App.Domain.Core._User.Dtos.BoothDtos.BoothAppServiceDto;

namespace App.Domain.AppServices.Booth
{
    public class BoothAppServices : IBoothAppServices
    {
        protected readonly IBoothServices _boothServices;
        protected readonly IFileServices _fileServices;

        public BoothAppServices(IBoothServices boothServices, IFileServices fileServices)
        {
            _boothServices = boothServices;
            _fileServices = fileServices;
        }

        public async Task Create(BoothCreateDto boothCreate, CancellationToken cancellationToken)
        {
            await _boothServices.Create(boothCreate, cancellationToken);
        }

        public async  Task<List<BoothOutputDto>> GetAllHome(CancellationToken cancellationToken)
        {
            return await _boothServices.GetAllHome(cancellationToken);
        }

        public async Task<BoothOutputDto> GetDetails(int BoothId, CancellationToken cancellationToken)
        {
            var result =  await _boothServices.GetDetail(BoothId, cancellationToken);
            return result;
        }

        public async Task<BoothOutputDto> GetDetailsWithRelations(int BoothId, CancellationToken cancellationToken)
        {
            var result = await _boothServices.GetDetailsWithRelations(BoothId, cancellationToken);
            return result;
        }

        public async Task SetActivity(int BoothId, bool status, CancellationToken cancellationToken)
        {
            await _boothServices.SetActivity(BoothId, status,cancellationToken);
        }

        public Task SoftDelete(int BoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task Update(BoothAppServiceUpdateDto boothUpdate, int CurrentUserId, string ProjectRouteAddress, CancellationToken cancellationToken)
        {
            Picture createPicture = null;
            if (boothUpdate.BoothAvatarFile != null)
            {
                BoothUpdateDto boothAvatarUpdateDto = new BoothUpdateDto
                {
                    AvatarPicture = new Picture { IsDeleted = true }
                };
                await _boothServices.Update(boothAvatarUpdateDto, CancellationToken.None);
                var photoName = await _fileServices.FileUploadAsync(boothUpdate.BoothAvatarFile, FileServicesEntityType.BoothAvatar, ProjectRouteAddress);
                createPicture = new Picture
                {
                    ImageUrl = photoName,
                    CreatedAt = DateTime.Now,
                    CreatedBy = CurrentUserId,
                    IsDeleted = false

                };
            }

            BoothUpdateDto boothUpdateDto = new BoothUpdateDto
            {
                Id = boothUpdate.BoothId,
                Name = boothUpdate.BoothName,
                Description = boothUpdate.Description,
                AvatarPicture = createPicture
            };
            await _boothServices.Update(boothUpdateDto, CancellationToken.None);
        }
    }
}
