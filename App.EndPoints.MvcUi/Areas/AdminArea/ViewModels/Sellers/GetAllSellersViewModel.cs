using App.Domain.Core._Booth.Dtos.MedalDtos;
using App.Domain.Core._Booth.Entities;
using App.Domain.Core._Common.Dtos.PictureDtos;
using App.Domain.Core._Common.Entities;

namespace App.EndPoints.MvcUi.Areas.AdminArea.ViewModels.Sellers
{
    public class GetAllSellersViewModel
    {
        #region Seller
        public int SellerId { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        #endregion

        #region Booth
        public int BoothId { get; set; }

        public string? BoothName { get; set; } 

        public bool? IsBoothActive { get; set; }

        public PictureOutputDto? AvatarPicture { get; set; }

        public MedalOutputDto Medal { get; set; }
        #endregion


        #region AppUser
        public string Email { get; set; } 
        public int AppUserId { get; set; } 
        public string CreatedAt { get; set; } 
        public bool IsUserActive { get; set; } 
        #endregion
    }
}


//SellerId { get; set; }
//Firstname { get; set; }
//Lastname { get; set; }
//BoothId { get; set; }
//BoothName { get; set; }
//AvatarPicture { get; set; }
//Medal { get; set; }
//Email { get; set; }