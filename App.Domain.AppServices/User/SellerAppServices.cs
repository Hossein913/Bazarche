using App.Domain.Core._Booth.Dtos.BoothDtos;
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

        public Task Create(SellerAppServiceCreateDto sellerCreate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<SellerOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<SellerOutputDto> GetDetails(int sellerAppUserId, CancellationToken cancellationToken)
        {
            var result = await _sellerServices.GetDetail(sellerAppUserId, cancellationToken);
            return result;

        }

        public Task SoftDelete(int sellerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
                var PicDetail = await _pictureServices.GetDetails(sellerUpdate.ProfilePicId, cancellationToken);
                await _fileServices.FileUpdateAsync(sellerUpdate.SellerProfilePicFile, PicDetail.ImageUrl, FileServicesEntityType.Profiles, projectRouteAddress);

            }

            SellerUpdateDto sellerUpdateDto = new SellerUpdateDto
            {
                Id = sellerUpdate.SellerId,
                Firstname = sellerUpdate.SellerFirstName,
                Lastname = sellerUpdate.SellerLastName,
                Birthdate = sellerUpdate.SellerBirthdate,
                ShabaNumber = sellerUpdate.SellerShabaNumber,
                Address = address,
            };

        }
    }
}