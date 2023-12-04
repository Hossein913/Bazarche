using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core._Common.Contracts.Services
{
    public interface IJobServices
    {
        string AddNewJub<T>(Expression<Action<T>> expression, DateTimeOffset enqueueAt);
    }
}
