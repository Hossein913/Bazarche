
using App.Domain.Core._User.Contracts.Repositories;
using App.Domain.Core._User.Dtos.ProvinceDto;
using App.Domain.Core._User.Entities;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Products
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly BazarcheContext _context;

        public ProvinceRepository(BazarcheContext context)
        {
            _context = context;
        }

        public async Task<List<ProvinceOutputDto>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _context.Provinces
            .AsNoTracking()
            .Select<Province, ProvinceOutputDto>(o => new ProvinceOutputDto
            {
                Id = o.Id,
                Name = o.Name,
            
            }).ToListAsync(cancellationToken);
            return result;
        }

        public async Task<int> Create(ProvinceCreateDto provinceCreate, CancellationToken cancellationToken)
        {
            var newProvince = new Province
            {
                Name = provinceCreate.Name,
            };

            await _context.Provinces.AddAsync(newProvince, cancellationToken);
            var result = await _context.SaveChangesAsync(cancellationToken);
            if (result != 0)
                return newProvince.Id;

            return 0;
        }

        public async Task HardDelete(int provinceId, CancellationToken cancellationToken)
        {
            var provinceRecord = await _context.Provinces
            .FirstOrDefaultAsync(x => x.Id == provinceId, cancellationToken);

            if (provinceRecord != null)
            {
                _context.Provinces.Remove(provinceRecord);
            }
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(ProvinceUpdateDto provinceUpdate, CancellationToken cancellationToken)
        {
            var provinceRecord = await _context.Provinces
            .FirstOrDefaultAsync(x => x.Id == provinceUpdate.Id, cancellationToken);

            if (provinceRecord != null)
            {
                provinceRecord.Name = provinceUpdate.Name;

            }
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
