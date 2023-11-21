using App.Domain.Core._Common.Contracts.Repositories;
using App.Infra.Data.SqlServer.Ef.DbCntx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Repos.Ef.Commons
{
    public class SaveChangesRepository : ISaveChangesRepository
    {
        protected readonly BazarcheContext _context;

        public SaveChangesRepository(BazarcheContext context)
        {
            _context = context;
        }

        public async Task SaveChanges(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);    
        }
    }
}
