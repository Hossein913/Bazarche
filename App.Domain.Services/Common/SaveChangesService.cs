using App.Domain.Core._Common.Contracts.Repositories;
using App.Domain.Core._Common.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Common
{
    public class SaveChangesService : ISaveChangesService
    {
        protected readonly ISaveChangesRepository _saveChangesRepository;

        public SaveChangesService(ISaveChangesRepository saveChangesRepository)
        {
            _saveChangesRepository = saveChangesRepository;
        }

        public async Task SaveChanges(CancellationToken cancellationToken)
        {
            await _saveChangesRepository.SaveChanges(cancellationToken);
        }
    }
}
