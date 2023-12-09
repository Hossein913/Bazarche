using App.Domain.Core._User.Dtos.AddresseDtos;
using App.Domain.Core._User.Dtos.ProvinceDto;
using System;
using System.Collections.Generic;

namespace App.Domain.Core._User.Contracts.AppServices;

public interface IAddressAppServices
{
    Task<AddressOutputDto> GetAddressDetail(int addressId, CancellationToken cancellationToken);
    Task<List<ProvinceOutputDto>> GetAllProvinces(CancellationToken cancellationToken);
    Task<int> CreateProvince(ProvinceCreateDto provinceCreate, CancellationToken cancellationToken);
    Task HardDeleteProvinces(int provinceId, CancellationToken cancellationToken);
    Task UpdateProvinces(ProvinceUpdateDto provinceUpdate, CancellationToken cancellationToken);
}
