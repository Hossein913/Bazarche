namespace App.EndPoints.MvcUi.Areas.SellerArea.Models.BoothViewModels
{
    public class BoothSidebarViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string AvatarPictureFile { get; set; }

        public string MedalType { get; set; }

        public int AccountBalance { get; set; }

        public int TotalSell { get; set; }

        public string? Description { get; set; }

    }
}

//Id { get; set; }
//Name { get; set; } 
//AvatarPictureFile { get; set; }
//MedalType { get; set; }
//AccountBalance { get; set; }
//TotalSell { get; set; }
//Description { get; set; }