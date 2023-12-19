using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Booths
{
    public class UpdateBoothViewModel
    {
        public int Id { get; set; }

        public int SellerId { get; set; }

        public string? AvatarUrl { get; set;}

        public int? AvatarId{ get; set; }


        [DisplayName("نام غرفه"), Required(ErrorMessage = "نام غرفه نمی تواند خالی باشد .")]
        public string Name { get; set; }

        [DisplayName("معرفی غرفه"), Required(ErrorMessage = "توضیحات معرفی غرفه را کامل کنید .")]
        public string? Description { get; set; }

        [DisplayName("ارسال فایل")]
        public IFormFile? AvatarFileUpload { get; set; }
    }
}

//Id { get; set; }
//BoothAvatarUrl { get; set; }
//BoothAvatarId { get; set; }
//BoothName { get; set; }
//Description { get; set; }
//BoothAvatarFile { get; set; }