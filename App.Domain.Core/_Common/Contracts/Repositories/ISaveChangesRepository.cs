using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core._Common.Contracts.Repositories
{
    public  interface ISaveChangesRepository
    {
        Task SaveChanges(CancellationToken cancellationToken);
    }
}
