using App.Domain.Core._Common.Contracts.Services;
using App.Domain.Core._Common.Dtos.AppSettingDtos;
using App.Domain.Core._Products.Dtos.CategorieDtos;
using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Contracts.Services;
using App.Domain.Core._User.Dtos.AddresseDtos;
using App.Domain.Core._User.Dtos.ProvinceDto;
using RedisCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.User
{
   public class AddressAppServices : IAddressAppServices
    {
        protected readonly IProvinceServices _provinceServices;
        private readonly IRedisCacheServices _redisCacheServices;
        private readonly AppSettings _appSettings;

        public AddressAppServices(
            IProvinceServices provinceServices,
            AppSettings appSettings,
            IRedisCacheServices redisCacheServices )
        {
            _provinceServices = provinceServices;
            _appSettings = appSettings;
            _redisCacheServices = redisCacheServices;
        }

        public async Task<int> CreateProvince(ProvinceCreateDto provinceCreate, CancellationToken cancellationToken)
       {
            throw new NotImplementedException();
       }

       public async Task<AddressOutputDto> GetAddressDetail(int addressId, CancellationToken cancellationToken)
       {
            throw new NotImplementedException();
       }

       public async Task<List<ProvinceOutputDto>> GetAllProvinces(CancellationToken cancellationToken)
        {
            if (_appSettings.UseRedisCache)
            {
                List<ProvinceOutputDto> provinceOutputs = _redisCacheServices.Get<List<ProvinceOutputDto>>(CacheKey.Provinces);

                if (!_redisCacheServices.HasCache(CacheKey.Provinces))
                {
                    provinceOutputs = await _provinceServices.GetAll(cancellationToken);
                    _redisCacheServices.Set(CacheKey.Provinces, provinceOutputs, 7);
                }
                return provinceOutputs;
            }
            else
            {
                var result = await _provinceServices.GetAll(cancellationToken);
                return result;
            }

       }

       public async Task HardDeleteProvinces(int provinceId, CancellationToken cancellationToken)
       {
            throw new NotImplementedException();
       }

       public async Task UpdateProvinces(ProvinceUpdateDto provinceUpdate, CancellationToken cancellationToken)
       {
            throw new NotImplementedException();
       }
    }
}
