using App.Domain.Core._Booth.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core._User.Dtos.BoothDtos.BoothAppServiceDto
{
    public class BoothAppServiceUpdateDto
    {

        public int BoothId { get; set; }

        public string BoothName { get; set; } = null!;

        public string? Description { get; set; }

        public IFormFile? BoothAvatarFile { get; set; }

    }
}
