using App.Domain.Core._User.Contracts.AppServices;
using App.Domain.Core._User.Contracts.Services;
using App.Domain.Core._User.Dtos.AddresseDtos;
using App.Domain.Core._User.Dtos.ProvinceDto;
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

       public AddressAppServices(IProvinceServices provinceServices)
       {
            _provinceServices = provinceServices;
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
            var result = await _provinceServices.GetAll(cancellationToken);
            return result;
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
