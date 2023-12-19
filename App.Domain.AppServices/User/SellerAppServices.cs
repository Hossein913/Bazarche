using App.Domain.Core._Booth.Dtos.BoothDtos;
using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Common.Contracts.Services;
using App.Domain.Core._Common.Dtos.AppSettingDtos;
using App.Domain.Core._Common.Entities;
using App.Domain.Core._Common.Enums;
using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Contracts.Services;
using App.Domain.Core._User.Dtos.SellersDtos;
using App.Domain.Core._User.Dtos.SellersDtos.SellerAppServiceDto;
using App.Domain.Core._User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.User
{
    public class SellerAppServices : ISellerAppServices
    {
        protected readonly ISellerServices _sellerServices;
        protected readonly IFileServices _fileServices ;
        protected readonly IPictureServices _pictureServices ;


        public SellerAppServices(
            ISellerServices sellerRepository,
            IFileServices fileServices,
            IPictureServices pictureServices)
        {
            _sellerServices = sellerRepository;
            _fileServices = fileServices;
            _pictureServices = pictureServices;
        }

        public Task Create(SellerRegisterDto sellerCreate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SellerOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _sellerServices.GetAll(cancellationToken);
            return result;
        }

        public async Task<SellerOutputDto> GetDetail(int sellerAppUserId, CancellationToken cancellationToken)
        {
            var result = await _sellerServices.GetDetail(sellerAppUserId, cancellationToken);
            return result;
        }

        public async Task<SellerOutputDto> GetDetailWithRilations(int sellerAppUserId, CancellationToken cancellationToken)
        {
            var result = await _sellerServices.GetDetailWithRilations(sellerAppUserId, cancellationToken);
            return result;

        }

        public async Task SoftDelete(int sellerId,int boothId, CancellationToken cancellationToken)
        {
            await _sellerServices.SoftDelete(sellerId, boothId, cancellationToken);
        }

        public async Task SetActivity(int sellerId, bool status, CancellationToken cancellationToken)
        {
            await _sellerServices.SetActivity(sellerId, status, cancellationToken);

        }

        public async Task Update(SellerAppServiceUpdateDto sellerUpdate,string projectRouteAddress, CancellationToken cancellationToken)
        {
            Address address = new Address
            {
                ProvinceId = sellerUpdate.ProvinceId,
                City = sellerUpdate.City,
                FullAddress = sellerUpdate.FullAddress,
                PostalCode = sellerUpdate.PostalCode,
            };


            if (sellerUpdate.SellerProfilePicFile != null)
            {
                //var PicDetail = await _pictureServices.GetDetails(sellerUpdate.ProfilePicId, cancellationToken);
                //await _fileServices.FileUpdateAsync(sellerUpdate.SellerProfilePicFile, PicDetail.ImageUrl, FileServicesEntityType.Profiles, projectRouteAddress);

            }

            SellerUpdateDto sellerUpdateDto = new SellerUpdateDto
            {
                Id = sellerUpdate.Id,
                Firstname = sellerUpdate.FirstName,
                Lastname = sellerUpdate.LastName,
                Birthdate = sellerUpdate.Birthdate,
                ShabaNumber = sellerUpdate.ShabaNumber,
                Address = address,
            };

            await _sellerServices.Update(sellerUpdateDto, cancellationToken);

        }
    }
}