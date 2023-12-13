using App.Domain.Core._Common.Entities;
using App.Domain.Core._User.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace App.EndPoints.MvcUi.Areas.SellerArea.Models.BoothViewModels
{
    public class EditBoothProfileViewModel
    {

        [DisplayName("نام غرفه"), Required(ErrorMessage = "نام غرفه نمی تواند خالی باشد .")]
        public string BoothName { get; set; }

        [DisplayName("معرفی غرفه"), Required(ErrorMessage = "توضیحات معرفی غرفه را کامل کنید .")]
        public string? Description { get; set; }

        [DisplayName("ارسال فایل")]
        public IFormFile? BoothAvatarFile { get; set; }

    }
}

