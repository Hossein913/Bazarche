using App.Domain.Core._Common.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core._Common.Contracts.Services
{
    public interface IFileServices
    {
        Task<string> FileUploadAsync(IFormFile file, FileServicesEntityType entityType, string ProjectRouteAddress);
        Task FileDeleteAsync();
        Task<bool> FileUpdateAsync();
    }
}
