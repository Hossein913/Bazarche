﻿using App.Domain.Core._Booth.Dtos.MedalDtos;

namespace App.Domain.Core._Booth.Contracts.Repositories;

public interface IMedalRepository
{
    Task<List<MedalOutputDto>> GetAll(CancellationToken cancellationToken);
    //Task<MedalOutputDto> GetDetail(int medalId, CancellationToken cancellationToken);
    Task Create(MedalCreateDto medalCreate, CancellationToken cancellationToken);
    Task Update(MedalUpdateDto medalUpdate, CancellationToken cancellationToken);
    Task HardDelete(int medalId, CancellationToken cancellationToken);

}
