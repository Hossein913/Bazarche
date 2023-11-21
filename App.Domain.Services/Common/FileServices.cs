using App.Domain.Core._Common.Contracts.Services;
using App.Domain.Core._Common.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core._Common.Dtos.AppSettingDtos;

namespace App.Domain.Services.Common
{
    public class FileServices : IFileServices
    {
        protected readonly FileUploadPathsDto _fileUploadPaths;

        public FileServices(FileUploadPathsDto fileUploadPaths)
        {
            _fileUploadPaths = fileUploadPaths;
        }
        public async Task FileDeleteAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> FileUpdateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> FileUploadAsync(IFormFile file, FileServicesEntityType entityType, string ProjectRouteAddress)
        {
            string uploadPath = Path.Combine(ProjectRouteAddress, _fileUploadPaths.Default);

            switch (entityType)
            {
                case FileServicesEntityType.Product:
                    uploadPath = Path.Combine(ProjectRouteAddress, _fileUploadPaths.Product);
                    break;
                case FileServicesEntityType.BoothAvatar:
                    uploadPath = Path.Combine(ProjectRouteAddress, _fileUploadPaths.BoothAvatar);
                    break;
                case FileServicesEntityType.Category:
                    uploadPath = Path.Combine(ProjectRouteAddress, _fileUploadPaths.Category);
                    break;
                case FileServicesEntityType.Profiles:
                    uploadPath = Path.Combine(ProjectRouteAddress, _fileUploadPaths.Profiles);
                    break;
            }

            var fileNewName = DateTime.Now.Ticks.ToString();

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            // Get the original file extension
            var fileExtension = Path.GetExtension(file.FileName);

            // Construct the new file name
            var fileFullName = fileNewName + fileExtension;

            var filePath = Path.Combine(uploadPath, fileFullName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return  fileFullName;

        }
    }
}
