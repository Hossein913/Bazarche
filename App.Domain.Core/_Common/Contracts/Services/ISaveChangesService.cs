using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core._Common.Contracts.Services
{
    public interface ISaveChangesService
    {
        Task SaveChanges(CancellationToken cancellationToken);
    }
}
