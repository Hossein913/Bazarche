using App.Domain.Core._Common.Contracts.Services;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Hangfire
{
    public class HangfireServices : IJobServices
    {
        public string AddNewJub<T>(Expression<Action<T>> expression, DateTimeOffset enqueueAt) {

           return BackgroundJob.Schedule<T>(expression, enqueueAt);

        }
    }
}
