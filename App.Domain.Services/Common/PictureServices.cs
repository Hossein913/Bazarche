using App.Domain.Core._Common.Contracts.Repositories;
using App.Domain.Core._Common.Contracts.Services;
using App.Domain.Core._Common.Dtos.PictureDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Common
{
    public class PictureServices : IPictureServices
    {
        protected readonly IPictureRepository _pictureRepository;

        public PictureServices(IPictureRepository pictureRepository)
        {
            _pictureRepository = pictureRepository;
        }

        public async Task<int> Create(PictureCreateDto picturedto, CancellationToken cancellationToken)
        {
            var result = await _pictureRepository.Create(picturedto, cancellationToken);
                return result;
        }

        public async Task<PictureOutputDto> GetDetails(int pictureId, CancellationToken cancellationToken)
        {
            var result = await _pictureRepository.GetDetails(pictureId, cancellationToken);
            return result;
        }

        public async Task HardDeleted(int picturedto, CancellationToken cancellationToken)
        {
            await _pictureRepository.HardDeleted(picturedto, cancellationToken);
        }

        public async Task SoftDeleted(int pictureId, CancellationToken cancellationToken)
        {
            await _pictureRepository.SoftDeleted(pictureId, cancellationToken);
        }

        public async Task Update(PictureUpdateDto picturedto, CancellationToken cancellationToken)
        {
            await _pictureRepository.Update(picturedto, cancellationToken);
        }
    }
}
